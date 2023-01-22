using MinesweeperGame.AppInterfaces;
using MinesweeperGame.AppServices;
using MinesweeperGame.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MinesweeperGame.Tests.IntegrationTests
{
    public class OutputServiceIntegrationTests
    {
        private readonly int minCoordinateX = 0;
        private readonly int minCoordinateY = 0;
        private readonly int maxCoordinateX = 9;
        private readonly int maxCoordinateY = 10;

        private readonly Mock<OutputService> _outputServiceMock = new Mock<OutputService>();
        private readonly Mock<GameService> _gameServiceMock = new Mock<GameService>(9, 10);

        [Fact]
        public void PrintBoard_WithInitializedBoard_ReturnsFilledBoardRepresentation()
        {
            //Arrange
            //Initialize board
            var mineboard = _gameServiceMock.Object.InitializeMineboard();
            var freeSpace = " ";
            var labelingMaxValue = "8";
            var undiscoveredField = "?";

            //Act
            var outputResult = _outputServiceMock.Object.Print(mineboard.Minefields);

            //Assert
            //Coordinates - 0 0
            Assert.Equal(outputResult[minCoordinateX, minCoordinateY], freeSpace);

            //Coordinates - 0 10
            Assert.Equal(outputResult[minCoordinateX, maxCoordinateY], labelingMaxValue);

            //Coordinates - 9 0
            Assert.Equal(outputResult[maxCoordinateX, minCoordinateY], labelingMaxValue);

            //Coordinates - 9 10
            Assert.Equal(outputResult[maxCoordinateX, maxCoordinateY], undiscoveredField);
        }


        [Fact]
        public void PrintBoard_WithShowAllBombs_ReturnsAllBombsMineboard()
        {
            //Arrange
            //Initialize board
            var mineboard = _gameServiceMock.Object.InitializeMineboard();
            var exploadedBomb = "#";
            var bombsAmount = 10;
            var showAllBombs = true;

            
            //Act
            var outputResult = _outputServiceMock.Object.Print(mineboard.Minefields, showAllBombs);


            //Assert
            var bombCounter = 0;
            foreach(var output in outputResult)
            {
                if (output == exploadedBomb)
                {
                    bombCounter++;
                }
            }
            Assert.Equal(bombCounter, bombsAmount);
        }
    }
}
