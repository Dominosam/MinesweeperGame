using MinesweeperGame.AppInterfaces;
using MinesweeperGame.Models;
using MinesweeperGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.AppServices
{
    public class OutputService : IOutputService
    {
        private readonly string _separator = "|";
        private readonly string _exploadedBomb = "#";
        private readonly string _undiscoveredField = "?";
        private readonly string _flagField = "?";
        private readonly string _freeSpace = " ";

        public string[,] Print(Minefield[,] minefields, bool showAllBombs = false)
        {
            int printerHeight = minefields.GetUpperBound(0) + 1;
            int printerWidth = minefields.GetUpperBound(1) + 2;

            int verticalLabeling;
            int horizontalLabeling;

            string[,] printedOutput = new string[printerHeight +1,printerWidth +1];

            for (int x= 0; x <= printerHeight; x++)
            {
                for (int y = 0; y <= printerWidth; y++)
                {
                    if (x == 0)
                    {
                        if (y == 0 || y == 1)
                        {
                            printedOutput[x, y] = _freeSpace;
                            Console.Write(_freeSpace);
                        }
                        else if (y <= printerWidth)
                        {
                            verticalLabeling = y - 2;
                            printedOutput[x, y] = verticalLabeling.ToString();
                            Console.Write(verticalLabeling.ToString());
                        }

                    }
                    else if (y == 0)
                    {
                        horizontalLabeling = x - 1;
                        printedOutput[x, y] = horizontalLabeling.ToString();
                        Console.Write(horizontalLabeling.ToString());
                    }
                    else if (y == 1)
                    {
                        printedOutput[x, y] = _separator;
                        Console.Write(_separator);
                    }
                    else
                    {
                        int mappedCoordinateX = x - 1;
                        int mappedCoordinateY = y - 2;
                        var currentMinefield = minefields[mappedCoordinateX, mappedCoordinateY];
                        string toPrint;

                        if (showAllBombs && currentMinefield.HasMine)
                        {
                            
                            toPrint = _exploadedBomb;
                        }
                        else if (currentMinefield.State == MinefieldState.Undiscovered)
                        {
                            toPrint = _undiscoveredField;
                        }
                        else if (currentMinefield.State == MinefieldState.Flagged)
                        {
                            toPrint = _flagField;
                        }
                        else if (currentMinefield.State == MinefieldState.Discovered && currentMinefield.SurroundingMinesCounter == 0)
                        {
                            toPrint = _freeSpace;
                        }
                        else
                        {
                            toPrint = currentMinefield.SurroundingMinesCounter.ToString();
                        }
                        printedOutput[x, y] = toPrint;
                        Console.Write(toPrint);
                    }

                }
                Console.Write('\n');
            }
            return printedOutput;
        }
    }
}
