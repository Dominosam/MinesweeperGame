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
    public class MinesweeperService : IMinesweeperService
    {
        private readonly Mineboard _mineboard;
        private readonly IGameService _gameService;
        private readonly IOutputService _outputService;
        private readonly IInputService _inputService;


        public MinesweeperService(IGameService gameService, IOutputService outputService, IInputService inputService)
        {
            _gameService = gameService;
            _outputService = outputService;
            _inputService = inputService;

            _mineboard = _gameService.InitializeMineboard();
        }

        public bool NextTurn()
        {
            _outputService.Print(_mineboard.Minefields);

            bool hasOperation = false;
            bool hasCoordinate = false;

            Operation operation = Operation.None;
            Coordinates coordinates = null;

            int possibleOperationsCount = Enum.GetNames(typeof(Operation)).Length - 1;
            while (!hasOperation)
            {
                Console.WriteLine("Which operation do you choose?");
                Console.WriteLine("");
                Console.WriteLine("1. Discover minefield");
                Console.WriteLine("2. Flag minefield");
                Console.WriteLine("");

                operation = _inputService.ReadOperation(possibleOperationsCount: Enum.GetNames(typeof(Operation)).Length, _inputService.GetInput());

                if (operation != Operation.None)
                {
                    hasOperation = true;
                }
                else
                {
                    Console.WriteLine($"You must enter an integer between {1} and {possibleOperationsCount}.");
                }

            }

            int minCoordinate = 0;
            int maxCoordinate = _mineboard.Size - 1;
            while (!hasCoordinate)
            {
                Console.WriteLine("What's your move?");
                Console.WriteLine("Please put coordinates separating it by a space e.g.: '0 0' ");
                Console.WriteLine($"Remember that values should be between <{minCoordinate},{maxCoordinate}>");
                Console.WriteLine("");
                
                coordinates = _inputService.ReadCoordinates(minCoordinate, maxCoordinate, _inputService.GetInput());

                if (coordinates != null)
                {
                    hasCoordinate = true;
                }
                else
                {
                    Console.WriteLine($"You must enter an integer between {minCoordinate} and {maxCoordinate}.");
                }

            }

            if (operation == Operation.Flag)    
            {
                _mineboard.ToggleFlag(coordinates);
                return false;
            }
            Console.WriteLine("");
            return _mineboard.DiscoverMinefield(coordinates);
        }

        public void StartGame()
        {
            while (!NextTurn())
            {
                if (_mineboard.Minefields.Cast<Minefield>()
                    .All(field => field.HasMine || field.State == MinefieldState.Discovered))
                {
                    _outputService.Print(_mineboard.Minefields);
                    Console.WriteLine("YOU WON, CONGRATULATIONS");
                    return;
                }
            }
            _outputService.Print(_mineboard.Minefields, true);
            Console.WriteLine("GAMEOVER");
        }
    }
}
 