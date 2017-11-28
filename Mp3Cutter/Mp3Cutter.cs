namespace Mp3Cutter
{
    using System;
    using System.IO;
    using NAudio.Wave;

    public class Mp3Cutter
    {
        public Mp3Cutter(int beginCut, int endCut, string mp3Path)
        {
            this.BeginCut = beginCut;
            this.EndCut = endCut;
            this.Mp3Path = mp3Path;
        }

        public int BeginCut { get; set; }

        public int EndCut { get; set; }

        public string Mp3Path { get; set; }

        public void ExecuteCut()
        {
            int totalFrameCount = GetTotalFrameCount(this.Mp3Path);

            int totalTimeLength = GetTotalTimeLength(this.Mp3Path);

            double calculatedFrameProSec = GetFrameProSec(totalFrameCount, totalTimeLength);

            var mp3OutputDto = this.SetMp3OutputDto(this.Mp3Path);

            CuttingMp3(this.BeginCut, this.EndCut, this.Mp3Path, calculatedFrameProSec, mp3OutputDto);
        }

        public int GetTotalFrameCount(string mp3Path)
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

        public int GetTotalTimeLength(string mp3Path)
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

        public Mp3OutputDto SetMp3OutputDto(string mp3Path)
        {
            var mp3OutputDto = new Mp3OutputDto();
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3OutputFile = Path.GetFileName(mp3Path);
            mp3OutputDto.OutputDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            mp3OutputDto.Mp3OutputFileName = Path.Combine(mp3OutputDto.OutputDir, Path.ChangeExtension(mp3OutputFile, "cut.mp3"));

            return mp3OutputDto;
        }

        public void CuttingMp3(int begin, int end, string mp3Path, double frameProSec, Mp3OutputDto mp3OutputDto)
        {
            int beginCount = (int)Math.Round(begin * frameProSec);
            int endCount = (int)Math.Round(end * frameProSec);

            Directory.CreateDirectory(mp3OutputDto.OutputDir);

            FileStream writer = null;
            Action createWriter = new Action(() =>
            {
                writer = File.Create(mp3OutputDto.Mp3OutputFileName);
            });
            int totalFrameCount = 0;

            using (var reader = new Mp3FileReader(mp3Path))
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

        public class Mp3OutputDto
        {
            public string OutputDir { get; set; }

            public string Mp3OutputFileName { get; set; }
        }
    }
}