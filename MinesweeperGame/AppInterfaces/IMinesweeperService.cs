using MinesweeperGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.AppInterfaces
{
    public interface IMinesweeperService
    {
        void StartGame();
        bool NextTurn();
    }
}
