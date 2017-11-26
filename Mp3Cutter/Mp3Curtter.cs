namespace Mp3Cutter
{
    using System;
    using System.IO;
    using NAudio.Wave;

    public class Mp3Curtter
    {
        public Mp3Curtter(int beginCut, int endCut, string mp3Path)
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

            var mp3Dto = this.CreateOutputDir(this.Mp3Path);

            CuttingMp3(this.BeginCut, this.EndCut, this.Mp3Path, calculatedFrameProSec);
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

        public void PreprocessCutting(int begin, int end, string mp3Path, double frameProSec)
        {
            FileStream writer;
            Action createWriter;
            CreateMp3Writer(mp3File, splitDir, out writer, out createWriter);

            CuttingMp32(begin, end, mp3Path, frameProSec, writer, createWriter);
        }

        public void CreateMp3Writer(Mp3Dto mp3Dto, out FileStream writer, out Action createWriter)
        {
            var mp3NewFilePath = Path.Combine(mp3Dto.SplitDir, Path.ChangeExtension(mp3Dto.Mp3FileName, (++splitI).ToString("D4") + ".mp3")
            int splitI = 0;
            writer = null;
            createWriter = new Action(() =>
            {
                writer = File.Create());
            });
        }

        public Mp3Dto CreateOutputDir(string mp3Path)
        {
            var mp3Dto = new Mp3Dto();
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            mp3Dto.Mp3FileName = Path.GetFileName(mp3Path);
            mp3Dto.SplitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(mp3Dto.SplitDir);

            return mp3Dto;
        }

        public void CuttingMp32(int begin, int end, string mp3Path, double frameProSec, FileStream writer, Action createWriter)
        {
            int beginCount = (int)Math.Round(begin * frameProSec);
            int endCount = (int)Math.Round(end * frameProSec);

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
    }

    public class Mp3Dto
    {
        public string SplitDir { get; set; }

        public string Mp3FileName { get; set; }
    }
}
