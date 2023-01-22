
using MinesweeperGame.AppServices;
using Moq;

using Xunit;

namespace MinesweeperGame.Tests.UnitTests.AppServices
{
    public class GameServiceUnitTests
    {

        [Fact]
        public void InitializeMineboard_WithMinefields_ReturnsFilledMineboard()
        {
            //Arrange
            var expectedBoardSize = 16;
            var expectedBombsAmount = 40;
            var serviceMock = new Mock<GameService>(expectedBoardSize, expectedBombsAmount);

            //Act
            var mineboard = serviceMock.Object.InitializeMineboard();

            //Assert
            Assert.Equal(expectedBoardSize, mineboard.Size);
            Assert.Equal(expectedBombsAmount, mineboard.Bombs);

        }
    }
}
