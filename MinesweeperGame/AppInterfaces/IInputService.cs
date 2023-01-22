using MinesweeperGame.Models;
using MinesweeperGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.AppInterfaces
{
    public interface IInputService
    {
        string GetInput();
        Coordinates ReadCoordinates(int min, int max, string input);
        Operation ReadOperation(int possibleOperationsCount, string input);
    }
}
