using MinesweeperGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.Models
{
    public class Mineboard
    {
        public Minefield[,] Minefields { get; set; }
        public int Size { get; set; }
        public int Bombs { get; set; }


        public Mineboard(Minefield[,] Minefields, int size, int bombs)
        {
            this.Minefields = Minefields;
            Size = size;
            Bombs = bombs;
        }

        public bool DiscoverMinefield(Coordinates coordinates)
        {
            var undiscoveredMinefield = Minefields[coordinates.X, coordinates.Y];
            if (undiscoveredMinefield.HasMine)
                return true;

            DiscoverSurrondingMinfields(coordinates);

            return false;

        }
        public void DiscoverSurrondingMinfields(Coordinates coordinates)
        {
            var maxX = Minefields.GetUpperBound(0);
            var maxY = Minefields.GetUpperBound(1);

            var minefieldsToDiscover = new Queue<Minefield>();
            minefieldsToDiscover.Enqueue(Minefields[coordinates.X, coordinates.Y]);

            while (minefieldsToDiscover.Count > 0)
            {
                var minefield = minefieldsToDiscover.Dequeue();
                if (minefield.State == MinefieldState.Discovered || minefield.State == MinefieldState.Flagged)
                    continue;

                minefield.State = MinefieldState.Discovered;

                if (minefield.SurroundingMinesCounter > 0)
                    continue; // only check neighbors if zero adjacent bombs

                // add adjacent to check
                if (minefield.Coordinates.X > 0)
                    minefieldsToDiscover.Enqueue(Minefields[minefield.Coordinates.X - 1, minefield.Coordinates.Y]);
                if (minefield.Coordinates.Y > 0)
                    minefieldsToDiscover.Enqueue(Minefields[minefield.Coordinates.X, minefield.Coordinates.Y - 1]);
                if (minefield.Coordinates.X < maxX)
                    minefieldsToDiscover.Enqueue(Minefields[minefield.Coordinates.X + 1, minefield.Coordinates.Y]);
                if (minefield.Coordinates.Y < maxY)
                    minefieldsToDiscover.Enqueue(Minefields[minefield.Coordinates.X, minefield.Coordinates.Y + 1]);

            }

        }


        public void ToggleFlag(Coordinates coordinates)
        {
            var minefield = Minefields[coordinates.X, coordinates.Y];
            if (minefield.State == MinefieldState.Discovered)
                return;

            minefield.State = minefield.State == MinefieldState.Flagged
                ? MinefieldState.Undiscovered
                : MinefieldState.Flagged;
        }
    } 
}
