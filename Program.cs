using System.Globalization;
using CsvHelper;

namespace WorldOfSuperMaket;

public class Program
{
    static void Main(string[] args)
    {
        CsvReader csvReader = new CsvReader();
        csvReader.csvTest();
        //RunGame();
        Console.ReadLine();

    }
    static void RunGame()
    {
        Game game = new Game();
        game.run();
    }
}

