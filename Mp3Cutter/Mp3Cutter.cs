namespace Mp3Cutter
{
    using System;
    using System.IO;
    using NAudio.Wave;

    public class Mp3Cutter
    {
        private const string Postfix = "cut.mp3";

        public Mp3Cutter()
            : this(3, 4, "huhu")
        {
        }

        public Mp3Cutter(int beginCut, int endCut, string mp3Path)
        {
            var mp3InputDto = new Mp3InputDto
            {
                BeginCut = beginCut,
                EndCut = endCut,
                Mp3Path = mp3Path
            };

            this.Mp3InputData = mp3InputDto;
        }

        public Mp3InputDto Mp3InputData { get; set; }

        public void ExecuteCut()
        {
            int totalFrameCount = GetTotalFrameCount(this.Mp3InputData.Mp3Path);

            int totalTimeLength = GetTotalTimeLength(this.Mp3InputData.Mp3Path);

            this.Mp3InputData.FrameProSec = GetFrameProSec(totalFrameCount, totalTimeLength);

            var mp3OutputDto = this.SetMp3OutputDto(this.Mp3InputData.Mp3Path);

            Directory.CreateDirectory(mp3OutputDto.OutputDir);

            CuttingMp3(this.Mp3InputData, mp3OutputDto);
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
            mp3OutputDto.Mp3OutputFileName = Path.Combine(mp3OutputDto.OutputDir, Path.ChangeExtension(mp3OutputFile, Postfix));

            return mp3OutputDto;
        }

        public void CuttingMp3(Mp3InputDto mp3InputDto, Mp3OutputDto mp3OutputDto)
        {
            int beginCount = (int)Math.Round(mp3InputDto.BeginCut * mp3InputDto.FrameProSec);
            int endCount = (int)Math.Round(mp3InputDto.EndCut * mp3InputDto.FrameProSec);

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

        public class Mp3InputDto
        {
            public int BeginCut { get; set; }

            public int EndCut { get; set; }

            public string Mp3Path { get; set; }

            public double FrameProSec { get; set; }
        }

        public class Mp3OutputDto
        {
            public string OutputDir { get; set; }

            public string Mp3OutputFileName { get; set; }
        }
    }
}