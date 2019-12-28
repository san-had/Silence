using Mp3CutterService;
using Xunit;

namespace Mp3Cutter.Tests.Unit
{
    public class Mp3OutputSetterTests
    {
        [Fact]
        public void OutputSettingTest()
        {
            // Arrange
            int index = 1;
            string mp3Path = @"D:\mp3\20191208.mp3";

            Mp3OutputSetter mp3OutputSetter = new Mp3OutputSetter();

            // Act
            var mp3OutputDto = mp3OutputSetter.SetMp3OutputDto(index, mp3Path);

            // Assert
            string expectedOutputDir = @"D:\mp3";
            string expectedOutputFileName = @"D:\mp3\20191208.cut1.mp3";

            Assert.Equal(expectedOutputDir, mp3OutputDto.OutputDir);
            Assert.Equal(expectedOutputFileName, mp3OutputDto.Mp3OutputFileName);
        }
    }
}