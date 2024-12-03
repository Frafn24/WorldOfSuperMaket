using System.Globalization;
using CsvHelper;

namespace WorldOfSuperMaket;

public class Program
{
    static void Main(string[] args)
    {
        /*CsvReader csvReader = new CsvReader();
        var s =csvReader.csvTest();
        foreach (var item in s)
        {
            Console.WriteLine(item.Name);
        }*/

        RunGame();
        Console.ReadLine();

    }
    static void RunGame()
    {
        Game game = new Game();
        game.run();
        
    }
}

