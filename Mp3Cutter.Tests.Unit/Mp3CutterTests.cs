namespace Mp3Cutter.Tests.Unit
{
    using Xunit;

    public class Mp3CutterTests
    {
        [Fact]
        public void GetFrameProSec_WithGeneralInput_ReturnGeneralOutput()
        {
            // Arrange
            var mp3Cutter = new Mp3Cutter();

            int totalFrameCount = 24;
            int totalTimeLength = 12;

            double expectedResult = 2.0;

            // Act
            double actualResult = mp3Cutter.GetFrameProSec(totalFrameCount, totalTimeLength);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}