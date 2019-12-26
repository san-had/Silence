namespace Mp3CutterService
{
    using System;
    using System.IO;
    using global::Mp3CutterService.Dto;
    using NAudio.Wave;

    public class Mp3Cutter
    {
        private const string Postfix = "cut.mp3";

        private double frameProSec;

        public Mp3OutputDto ExecuteCut(Mp3InputDto mp3InputDto)
        {
            int totalFrameCount = GetTotalFrameCount(mp3InputDto.Mp3Path);

            int totalTimeLength = GetTotalTimeLength(mp3InputDto.Mp3Path);

            frameProSec = GetFrameProSec(totalFrameCount, totalTimeLength);

            var mp3OutputDto = this.SetMp3OutputDto(mp3InputDto.Mp3Path);

            Directory.CreateDirectory(mp3OutputDto.OutputDir);

            CuttingMp3(mp3InputDto, mp3OutputDto);

            return mp3OutputDto;
        }

        private int GetTotalFrameCount(string mp3Path)
        {
            int totalFrameCount = 0;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                Mp3Frame frame;

                while ((frame = reader.ReadNextFrame()) != null)
                {
                    totalFrameCount++;
                }
            }

            return totalFrameCount;
        }

        private int GetTotalTimeLength(string mp3Path)
        {
            TimeSpan totalTimeLength = TimeSpan.MinValue;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                totalTimeLength = reader.TotalTime;
            }

            var intTotalTimeLength = (int)Math.Round(totalTimeLength.TotalSeconds);

            return intTotalTimeLength;
        }

        public double GetFrameProSec(int totalFrameCount, int totalTimeLength)
        {
            return (double)totalFrameCount / (double)totalTimeLength;
        }

        private Mp3OutputDto SetMp3OutputDto(string mp3Path)
        {
            var mp3OutputDto = new Mp3OutputDto();
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3OutputFile = Path.GetFileName(mp3Path);
            mp3OutputDto.OutputDir = mp3Dir;
            mp3OutputDto.Mp3OutputFileName = Path.Combine(mp3OutputDto.OutputDir, Path.ChangeExtension(mp3OutputFile, Postfix));

            return mp3OutputDto;
        }

        private void CuttingMp3(Mp3InputDto mp3InputDto, Mp3OutputDto mp3OutputDto)
        {
            int beginCount = (int)Math.Round(mp3InputDto.BeginCut * frameProSec);
            int endCount = (int)Math.Round(mp3InputDto.EndCut * frameProSec);

            FileStream writer = null;
            Action createWriter = new Action(() =>
            {
                writer = File.Create(mp3OutputDto.Mp3OutputFileName);
            });

            int totalFrameCount = 0;

            using (var reader = new Mp3FileReader(mp3InputDto.Mp3Path))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) createWriter();

                    if (totalFrameCount > beginCount && totalFrameCount < endCount)
                    {
                        ++totalFrameCount;
                        continue;
                    }

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                    ++totalFrameCount;
                }

                if (writer != null) writer.Dispose();
            }
        }
    }
}