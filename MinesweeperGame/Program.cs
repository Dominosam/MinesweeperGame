using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MinesweeperGame.AppInterfaces;
using MinesweeperGame.AppServices;




using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IMinesweeperService, MinesweeperService > ();
        services.AddScoped<IInputService, InputService>();
        services.AddScoped<IOutputService, OutputService>();
        services.AddSingleton<IGameService>(gameService =>
      ActivatorUtilities.CreateInstance<GameService>(gameService, 9, 10));
    })
    .Build();


IMinesweeperService _minesweeperService = host.Services.GetRequiredService<IMinesweeperService>();

Console.WriteLine("Welcome to Minesweeper Console App!");
Console.WriteLine("");
Console.WriteLine("Minesweeper is a classic puzzle game where the objective is to locate all the hidden mines in a grid.");
Console.WriteLine("The grid is filled with squares that can either contain a mine or be safe. ");
Console.WriteLine("To locate the mines, you click on the squares and mark them as either a mine, or safe.");
Console.WriteLine("If you mark a square as a mine and it is correct, then it will be revealed.");
Console.WriteLine("If it is wrong, then you will lose the game.");
Console.WriteLine("If you click on a square that is safe, then it will reveal the number of mines in the adjacent squares.");
Console.WriteLine("You can use this information to deduce which squares contain mines and which don't.");

_minesweeperService.StartGame();
