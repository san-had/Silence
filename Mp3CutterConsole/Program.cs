using System;
using Mp3Cutter;
using Mp3CutterExtensibility.Dto;
using Mp3CutterService;

namespace Mp3CutterConsole
{
    internal class Program
    {
        private static void Main()
        {
            //CutMp3();

            MergeMp3();
        }

        private static void CutMp3()
        {
            var cuttingTimeDto = new CuttingTimeDto
            {
                BeginHour = 0,
                BeginMinute = 0,
                BeginSecond = 0,
                EndHour = 0,
                EndMinute = 0,
                EndSecond = 1
            };

            var mp3InputSetter = new Mp3InputSetter();

            var mp3InputDto = mp3InputSetter.SetMp3InputDto(cuttingTimeDto, null, 1);

            mp3InputDto.Mp3Path = @"D:\mp3\20191215_ori.mp3";

            var mp3Cutter = new Mp3CutterService.Mp3Cutter();

            var mp3OutputDto = mp3Cutter.ExecuteCut(mp3InputDto);

            Console.WriteLine(mp3OutputDto.Mp3OutputFileName);
        }

        private static void MergeMp3()
        {
            string mp3Path = @"D:\mp3\20191201.mp3";
            string mp3Path2 = @"D:\mp3\20191208.mp3";

            var mp3Merger = new Mp3Merger();

            mp3Merger.MergingMp3(mp3Path, mp3Path2);
        }
    }
}