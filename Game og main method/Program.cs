using System.Globalization;
using CsvHelper;
using WorldOfSuperMaket.Sounds;
using WorldOfSuperMaket;

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

