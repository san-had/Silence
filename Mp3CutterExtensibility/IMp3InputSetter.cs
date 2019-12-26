using Mp3CutterExtensibility.Dto;

namespace Mp3CutterExtensibility
{
    public interface IMp3InputSetter
    {
        Mp3InputDto SetMp3InputDto(CuttingTimeDto cuttingTimeDto, string mp3FileName, int index);
    }
}