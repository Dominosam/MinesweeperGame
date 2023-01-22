using Microsoft.Extensions.Options;
using MinesweeperGame.AppInterfaces;
using MinesweeperGame.Models;
using MinesweeperGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.AppServices
{
    public class InputService : IInputService
    {

        public string GetInput()
        {
            string? input = Console.ReadLine();
            if (input != null)
            {
                input = input.Trim();
            }
            return input ?? "";
        }

        public Coordinates ReadCoordinates(int min, int max, string input)
        {
            Coordinates? coordinates = null;
            if (input.Split(' ').Length == 2)
            {
                var inputCoordinateX = input.Split(" ")[0];
                var inputCoordinateY = input.Split(" ")[1];
                if (int.TryParse(inputCoordinateX, out int valueCoordinateX) && IsNumberInRange(valueCoordinateX, min, max)
                    && int.TryParse(inputCoordinateY, out int valueCoordinateY) && IsNumberInRange(valueCoordinateY, min, max))
                {
                    coordinates = new Coordinates(valueCoordinateX, valueCoordinateY);
                }
            }
            return coordinates;
        }

   

        public Operation ReadOperation(int possibleOperationsCount, string input)
        {
            Operation operation = Operation.None;
            if (int.TryParse(input, out int valueOperation) && valueOperation > 0 && valueOperation <= possibleOperationsCount)
            {
                operation = (Operation)valueOperation;
  
            }
            return operation;

        }

        private bool IsNumberInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

    }
}
