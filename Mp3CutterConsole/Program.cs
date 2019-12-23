using System;
using Mp3CutterService.Dto;

namespace Mp3CutterConsole
{
    internal class Program
    {
        private static void Main()
        {
            var mp3InputDto = new Mp3InputDto
            {
                BeginCut = 0,
                EndCut = 1,
                Mp3Path = @"D:\mp3\20191215_ori.mp3"
            };

            var mp3Cutter = new Mp3CutterService.Mp3Cutter();

            var mp3OutputDto = mp3Cutter.ExecuteCut(mp3InputDto);

            Console.WriteLine(mp3OutputDto.Mp3OutputFileName);
        }
    }
}