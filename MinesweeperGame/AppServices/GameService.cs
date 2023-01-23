using MinesweeperGame.AppInterfaces;
using MinesweeperGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.AppServices
{
    public class GameService : IGameService
    {
        private readonly int _size;
        private readonly int _bombsAmount;
        
        public GameService(int size, int bombsAmount)
        {
            _size = size;
            _bombsAmount = bombsAmount;
        }

        public Mineboard InitializeMineboard()
        {
            var minefields = new Minefield[_size, _size];

            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    minefields[x, y] = new Minefield(new Coordinates(x,y));
                }
            }

            return new Mineboard(GetBombInitializedMinefields(minefields), _size, _bombsAmount);
        }

        private Minefield[,] GetBombInitializedMinefields(Minefield[,] minefields)
        {
            var tmpBombAmount = _bombsAmount;
            var rand = new Random();
            while (tmpBombAmount != 0)
            {
                var x = rand.Next(0, _size);
                var y = rand.Next(0, _size);

                if (!minefields[x, y].HasMine)
                {
                    minefields[x, y].HasMine = true;
                    minefields = GetSurroundingMinefieldsIncremented(minefields, x, y);
                    tmpBombAmount--;
                }
            }
            return minefields;
        }

        private Minefield[,] GetSurroundingMinefieldsIncremented(Minefield[,] minefields, int x, int y)
        {
            var tmpMinefields = minefields;

            //Left neighbours
            if (x > 0)
            {
                tmpMinefields[x - 1, y].SurroundingMinesCounter++;
                if (y > 0)
                    tmpMinefields[x - 1, y - 1].SurroundingMinesCounter++;
                if (y < _size - 1)
                    tmpMinefields[x - 1, y + 1].SurroundingMinesCounter++;
            }

            //Right neighbours
            if (x < _size - 1)
            {
                tmpMinefields[x + 1, y].SurroundingMinesCounter++;
                if (y > 0)
                    tmpMinefields[x + 1, y - 1].SurroundingMinesCounter++;
                if (y < _size - 1)
                    tmpMinefields[x + 1, y + 1].SurroundingMinesCounter++;
            }

            //Top neighbours
            if (y > 0)
            {
                tmpMinefields[x, y - 1].SurroundingMinesCounter++;
            }

            //Bottom neighbours
            if (y < _size - 1)
            {
                tmpMinefields[x, y + 1].SurroundingMinesCounter++;
            }

            return tmpMinefields;
        }
    }
}
