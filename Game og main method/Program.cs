using System.Globalization;
using CsvHelper;
using WorldOfSuperMaket.Sounds;

namespace WorldOfSuperMaket;

public class Program
{
    static void Main(string[] args)
    {
        //test();
        RunGame();
        Console.ReadLine();

    }
    static void RunGame()
    {
        Game game = new Game();
        game.run();
        
    }
    static void test()
    {
        Lyd lyd = new Lyd();
        lyd.GameOver();
    }
}

