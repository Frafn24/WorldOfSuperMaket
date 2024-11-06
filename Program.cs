using System.Globalization;
using CsvHelper;

namespace WorldOfSuperMaket;

public class Program
{
    static void Main(string[] args)
    {
        RunGame();
        Console.ReadLine();

    }
    static void RunGame()
    {
        Game game = new Game();
        game.run();
    }
}

