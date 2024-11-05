/* Main class for launching the game
 */

using WorldOfSuperMaket;

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  UserInfo user;
  bool whil = false;
  TextAnime text = new TextAnime();
  SoundsClass sound = new SoundsClass();
  Items[] items = new Items[1];
  
  private void InitRegistry () 
  {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("Inventory",new InventoryCommand());

  }

    public void run()
    {
        int Age=0;
        int height = 0;
        int Weaght = 0;
        string Gender = "";
        Console.WriteLine("Welcome to the supermarked");
        //Console.WriteLine("Skriv dit og dine infomationer nede under");
        //text.printText("Hvad er dit Navn:");
        //var name = Console.ReadLine();
        //    Console.WriteLine("Du må kun skrive dit alder ifrom af hele tal");
        //while (whil == false)
        //{
        //   text.printText("Hvad er din alder:");
        //   var inputAge = Console.ReadLine();
        //    try
        //    {
        //        Age = int.Parse(inputAge);
        //        whil = true;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Du må kun skrive tal!!!");
        //    }
        //}
        //whil = false;
        //    Console.WriteLine("Du må kun skrive dit vægt ifrom af hele tal");
        //while (whil == false)
        //{
        //    text.printText("Hvad er din din vægt:");
        //    var InputWeaght = Console.ReadLine();
        //    try
        //    {
        //        Weaght = int.Parse(InputWeaght);
        //        whil = true;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Du må kun skrive tal!!!");
        //    }
        //}
        //whil = false;
        //    Console.WriteLine("Du må kun skrive dit højde ifrom af hele tal");
        //while (whil == false)
        //{
        //    text.printText("Hvad er din din højde:");
        //    var inputHøjde = Console.ReadLine();
        //    try
        //    {
        //        height = int.Parse(inputHøjde);
        //        whil = true;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Du må kun skrive tal!!!");
        //    }
        //}
        //text.printText("Hvad er din din Køn:");
        //var gender = Console.ReadLine();
        //user = new UserInfo(name, Age,height,Weaght,gender);

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
        sound.Play();
        Console.WriteLine("Game Over 😥");


    }
}
