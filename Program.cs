// See https://aka.ms/new-console-template for more information
internal class Program
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