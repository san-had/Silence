using Mp3CutterExtensibility.Dto;

namespace Mp3CutterExtensibility
{
    public interface IMp3OutputSetter
    {
        Mp3OutputDto SetMp3OutputDto(int index, string mp3Path);
    }
}