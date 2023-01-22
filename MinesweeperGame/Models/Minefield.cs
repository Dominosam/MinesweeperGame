using MinesweeperGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.Models
{
    public class Minefield
    {
        public bool HasMine { get; set; }
        public MinefieldState State { get; set; } = MinefieldState.Undiscovered;
        public Coordinates Coordinates { get; set; }
        public int SurroundingMinesCounter { get; set; }

        public Minefield(Coordinates Coordinates) 
        { 
            this.Coordinates = Coordinates;
        }
    }
}
