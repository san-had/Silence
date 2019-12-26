using Mp3CutterExtensibility;
using Mp3CutterExtensibility.Dto;

namespace Mp3CutterService
{
    public class Mp3InputSetter : IMp3InputSetter
    {
        public Mp3InputDto SetMp3InputDto(CuttingTimeDto cuttingTimeDto, string mp3FileName, int index)
        {
            var mp3Input = new Mp3InputDto();

            mp3Input.BeginCut = cuttingTimeDto.BeginHour * 3600 +
                cuttingTimeDto.BeginMinute * 60 + cuttingTimeDto.BeginSecond;
            mp3Input.EndCut = cuttingTimeDto.EndHour * 3600 +
                cuttingTimeDto.EndMinute * 60 + cuttingTimeDto.EndSecond;

            mp3Input.Mp3Path = mp3FileName;
            mp3Input.Index = index;

            return mp3Input;
        }
    }
}