using MinesweeperGame.AppInterfaces;
using MinesweeperGame.AppServices;
using MinesweeperGame.Models;
using MinesweeperGame.Models.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MinesweeperGame.Tests.UnitTests.AppServices
{
    public class InputServiceUnitTests
    {
        private readonly Mock<InputService> _inputServiceMock = new Mock<InputService>();
        [Fact]
        public void ReadCoordinates_WithEmptyString_ReturnsNull()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 1;
            var emptyString = "";

            //Act
            var result = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, emptyString);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadCoordinates_WithOutOfRangeInput_ReturnsNull()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 3;
            var outOfRangeInput = "0 4";

            //Act
            var result = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, outOfRangeInput);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadCoordinates_WithOneCoordinate_ReturnsNull()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 3;
            var outOfRangeInput = "0";

            //Act
            var result = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, outOfRangeInput);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadCoordinates_WithMoreThanOneSpace_ReturnsNull()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 3;
            var moreThanOneSpaceInput = "0  1";

            //Act
            var result = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, moreThanOneSpaceInput);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadCoordinates_WithMoreThanTwoCoordinates_ReturnsNull()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 3;
            var moreThanTwoCoordinatesInput = "0 1 1";

            //Act
            var result = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, moreThanTwoCoordinatesInput);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadCoordinates_WithTwoCoordinates_ReturnsCoordinatesObject()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 3;
            var outOfRangeInput = "0 1";

            var expectedCoordinatesObject = new Coordinates(0, 1);

            //Act
            var result = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, outOfRangeInput);

            //Assert
            Assert.Equal(expectedCoordinatesObject.X, result.X);
            Assert.Equal(expectedCoordinatesObject.Y, result.Y);
        }

        [Fact]
        public void ReadOperation_WithEmptyString_ReturnsOperationNone()
        {
            //Arrange
            var possibleOperationsCount = 2;
            var emptyInput = "";

            var expectedOperation = Operation.None;

            //Act
            var result = _inputServiceMock.Object.ReadOperation(possibleOperationsCount, emptyInput);

            //Assert
            Assert.Equal(expectedOperation, result);
        }

        [Fact]
        public void ReadOperation_WithOutOfRangeInput_ReturnsOperationNone()
        {
            //Arrange
            var possibleOperationsCount = 2;
            var emptyInput = "3";

            var expectedOperation = Operation.None;

            //Act
            var result = _inputServiceMock.Object.ReadOperation(possibleOperationsCount, emptyInput);

            //Assert
            Assert.Equal(expectedOperation, result);
        }

        [Fact]
        public void ReadOperation_WithTopBoundRangeInput_ReturnsOperationFlag()
        {
            //Arrange
            var possibleOperationsCount = 2;
            var emptyInput = "2";

            var expectedOperation = Operation.Flag;

            //Act
            var result = _inputServiceMock.Object.ReadOperation(possibleOperationsCount, emptyInput);

            //Assert
            Assert.Equal(expectedOperation, result);
        }

        [Fact]
        public void ReadOperation_WithBottomBoundRangeInput_ReturnsOperationDiscover()
        {
            //Arrange
            var possibleOperationsCount = 2;
            var emptyInput = "1";

            var expectedOperation = Operation.Discover;

            //Act
            var result = _inputServiceMock.Object.ReadOperation(possibleOperationsCount, emptyInput);

            //Assert
            Assert.Equal(expectedOperation, result);
        }

        [Fact]
        public void ReadOperation_WithZeroAsInput_ReturnsOperationNone()
        {
            //Arrange
            var possibleOperationsCount = 2;
            var emptyInput = "0";

            var expectedOperation = Operation.None;

            //Act
            var result = _inputServiceMock.Object.ReadOperation(possibleOperationsCount, emptyInput);

            //Assert
            Assert.Equal(expectedOperation, result);
        }

        [Fact]
        public void GetInput_WithChar_ReturnsNull()
        {
            //Arrange
            var minValue = 0;
            var maxValue = 3;

            var possibleOperationsCount = 2;
            var charInput = "r";

            var expectedOperation = Operation.None;

            //Act
            var operationsResult = _inputServiceMock.Object.ReadOperation(possibleOperationsCount, charInput);
            var coordinateResult = _inputServiceMock.Object.ReadCoordinates(minValue, maxValue, charInput);

            //Assert
            Assert.Equal(expectedOperation, operationsResult);
            Assert.Null(coordinateResult);
        }
    }
}
