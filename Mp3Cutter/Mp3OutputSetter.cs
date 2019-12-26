using System.IO;
using Mp3CutterExtensibility;
using Mp3CutterExtensibility.Dto;

namespace Mp3CutterService
{
    public class Mp3OutputSetter : IMp3OutputSetter
    {
        private const string Postfix = "cut{0}.mp3";

        public Mp3OutputDto SetMp3OutputDto(int index, string mp3Path)
        {
            string postFix = string.Format(Postfix, index);
            var mp3OutputDto = new Mp3OutputDto();
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            string previouspostfix = $".cut{index - 1}";
            var mp3OutputFile = Path.GetFileName(mp3Path).Replace(previouspostfix, string.Empty);
            mp3OutputDto.OutputDir = mp3Dir;
            mp3OutputDto.Mp3OutputFileName = Path.Combine(mp3OutputDto.OutputDir, Path.ChangeExtension(mp3OutputFile, postFix));

            return mp3OutputDto;
        }
    }
}