namespace Mp3CutterService.Dto
{
    public class Mp3InputDto
    {
        public int BeginCut { get; set; }

        public int EndCut { get; set; }

        public string Mp3Path { get; set; }

        public int Index { get; set; }
    }
}