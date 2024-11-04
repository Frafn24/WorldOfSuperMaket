/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("Inventory",new CommandUnkneown());
  }

    public void run()
    {
        Console.WriteLine("Welcome to the supermarked");


        InitRegistry();
        context.GetCurrent().Welcome();

        while (context.IsDone() == false)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (line != null)
            {
                registry.Dispatch(line);
            }
            if (string.IsNullOrEmpty(line))
            {
                context.MakeDone();
            }
        }
        Console.WriteLine("Game Over 😥");


    }
}
