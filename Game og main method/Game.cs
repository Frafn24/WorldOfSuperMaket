/* Main class for launching the game
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Commands;
using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Sounds;



class Game {
  Items[] items = new Items[1];
    Items[] inv = new Items[0];
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  TextCommand TextC = new TextCommand();
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  UserInfo user;
  bool whil = false;
  TextAnime text = new TextAnime();
  Sounds sounds = new Sounds();
  //SoundsClass sound = new SoundsClass();
  
  private void InitRegistry () 
  {

        ICommand commandAction = new CommandActios(user);
        //items = CommandItem.AddItems();
        ICommand cmdExit = new CommandExit();
        registry.Register("exit", cmdExit);
        registry.Register("quit", cmdExit);
        registry.Register("bye", cmdExit);
        registry.Register("go", new CommandGo());
        registry.Register("help", new CommandHelp(registry));
        registry.Register("Actions", commandAction);
        registry.Register("Checkout", commandAction);
        //registry.Register("Items", new CommandItem(items));
        

  }
  
    public void run()
    {
        Console.Clear();
        Console.WriteLine("Velkommen til supermarkedet.");
        TextC.InfoText();
        InitRegistry();
        context.GetCurrent().Welcome();
        while (context.IsDone() == false)
        {
            //context.
            Console.Write("> ");
            var line = Console.ReadLine();
            if (line != null)
            {
                if (line =="lol")
                {
                    sounds.LOL();
                }
                if (line=="Actions")
                {
                    TextC.ActionsText();
                    Console.Write(">");
                    var line2 = Console.ReadLine();
                    line = line +" "+ line2;
                }
                if (line == "Checkout")
                {
                    line = line + " Checkout";
                }
                registry.Dispatch(line);
                //Console.WriteLine(context.GetCurrent().GetName());
                
            }
            /*if (string.IsNullOrEmpty(line))
            {
                context.MakeDone();
            }*/
        }
        //sound.Play();
        sounds.GameOver();
        Console.WriteLine("Game Over 😥");


    }
}
