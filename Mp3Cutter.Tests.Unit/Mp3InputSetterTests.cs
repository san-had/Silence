using Mp3CutterExtensibility.Dto;
using Mp3CutterService;
using Xunit;

namespace Mp3Cutter.Tests.Unit
{
    public class Mp3InputSetterTests
    {
        [Fact]
        public void TimeCalculationTest()
        {
            // Arrange
            CuttingTimeDto cuttingTimeDto = new CuttingTimeDto
            {
                BeginHour = 2,
                BeginMinute = 18,
                BeginSecond = 36,

                EndHour = 3,
                EndMinute = 32,
                EndSecond = 54
            };

            string mp3FileName = @"C:\Hello.mp3";
            int index = 1;

            Mp3InputSetter mp3InputSetter = new Mp3InputSetter();

            // Act
            Mp3InputDto mp3InputDto = mp3InputSetter.SetMp3InputDto(cuttingTimeDto, mp3FileName, index);

            // Assert
            int expectedBeginCut = 8316;
            int expectedEndCut = 12774;

            Assert.Equal(expectedBeginCut, mp3InputDto.BeginCut);
            Assert.Equal(expectedEndCut, mp3InputDto.EndCut);
        }
    }
}