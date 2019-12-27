using System;
using System.IO;
using Mp3CutterExtensibility;
using NAudio.Wave;

namespace Mp3Cutter
{
    public class Mp3Merger : IMp3Merger
    {
        public void MergingMp3(string mp3Path, string mp3Path2)
        {
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            int splitI = 0;
            FileStream writer = null;
            Action createWriter = new Action(() =>
            {
                writer = File.Create(Path.Combine(splitDir, Path.ChangeExtension(mp3File, (++splitI).ToString("D4") + ".mp3")));
            });

            int totalFrameCount = 0;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null)
                        createWriter();

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                }
            }

            using (var reader = new Mp3FileReader(mp3Path2))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null)
                        createWriter();

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                    ++totalFrameCount;
                }
            }

            if (writer != null)
                writer.Dispose();
        }
    }
}