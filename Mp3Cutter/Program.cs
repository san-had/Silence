namespace Mp3Cutter
{
    using System;
    using System.IO;
    using NAudio.Wave;

    class Program
    {
        private static int beginCut = 0;  // seconds
        private static int endCut = 10;
        private static string mp3Path = @"D:\mp3\20180325.mp3";
        private static string mp3Path2 = @"D:\mp3\20171225b.mp3";
        private static double frameProSec = 19.14183087027915;

        static void Main(string[] args)
        {
            //int totalFrameCount = GetTotalFrameCount(mp3Path);

            //int totalTimeLength = GetTotalTimeLength(mp3Path);

            //double calculatedFrameProSec = GetFrameProSec(totalFrameCount, totalTimeLength);

            CuttingMp3(beginCut, endCut, mp3Path, frameProSec);

            //Console.WriteLine($"Total frame count: {totalFrameCount}");

            //Console.WriteLine($"Total time length: {totalTimeLength}");

            //Console.WriteLine($"FrameProSec: {calculatedFrameProSec}");

            //MergingMp3(mp3Path, mp3Path2);

            Console.Read();
        }

        private static int GetTotalFrameCount(string mp3Path)
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

        private static int GetTotalTimeLength(string mp3Path)
        {
            TimeSpan totalTimeLength = TimeSpan.MinValue;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                totalTimeLength = reader.TotalTime;
            }

            var intTotalTimeLength = (int)Math.Round(totalTimeLength.TotalSeconds);

            return intTotalTimeLength;
        }

        private static double GetFrameProSec(int totalFrameCount, int totalTimeLength)
        {
            return (double)totalFrameCount / (double)totalTimeLength;
        }

        private static void CuttingMp3(int begin, int end, string mp3Path, double frameProSec)
        {
            int beginCount = (int)Math.Round(begin * frameProSec);
            int endCount = (int)Math.Round(end * frameProSec);

            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            int splitI = 0;
            FileStream writer = null;
            Action createWriter = new Action(() => {
                writer = File.Create(Path.Combine(splitDir, Path.ChangeExtension(mp3File, (++splitI).ToString("D4") + ".mp3")));
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

        private static void MergingMp3(string mp3Path, string mp3Path2)
        {
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            int splitI = 0;
            FileStream writer = null;
            Action createWriter = new Action(() => {
                writer = File.Create(Path.Combine(splitDir, Path.ChangeExtension(mp3File, (++splitI).ToString("D4") + ".mp3")));
            });

            int totalFrameCount = 0;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) createWriter();

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                }
            }

            using (var reader = new Mp3FileReader(mp3Path2))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) createWriter();

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                    ++totalFrameCount;
                }
            }

            if (writer != null) writer.Dispose();
        }
    }
}
