﻿namespace Mp3Cutter
{
    using System;
    using System.IO;
    using NAudio.Wave;

    class Program
    {
        private static int beginSplit = 647;  // seconds
        private static int endSplit = 708;
        private static string mp3Path = @"D:\mp3\20171001.mp3";
        private static double frameProSec = 19.14183087027915;

        static void Main(string[] args)
        {
            int totalFrameCount = CuttingMp3(beginSplit, endSplit, mp3Path);

            Console.WriteLine($"Total frame count: {totalFrameCount}");

            Console.Read();
        }

        private static int CuttingMp3(int begin, int end, string mp3Path)
        {
            int beginCount = (int)Math.Round(begin * frameProSec);
            int endCount = (int)Math.Round(end * frameProSec);

            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            int splitI = 0;
            int totalFrameCount = 0;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                FileStream writer = null;
                Action createWriter = new Action(() => {
                    writer = File.Create(Path.Combine(splitDir, Path.ChangeExtension(mp3File, (++splitI).ToString("D4") + ".mp3")));
                });

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

            return totalFrameCount;
        }
    }
}
