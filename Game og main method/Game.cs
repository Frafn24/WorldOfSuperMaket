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
    private string? language;
  
  //SoundsClass sound = new SoundsClass();
  
  private void InitRegistry () 
  {

        ICommand commandAction = new CommandActions(user);
        //items = CommandItem.AddItems();
        ICommand cmdExit = new CommandExit();
        registry.Register("quit", cmdExit);
        registry.Register("Afslut", cmdExit);
        
        registry.Register("go", new CommandGo());
        registry.Register("gå", new CommandGo());
        
        registry.Register("help", new CommandHelp(registry));
        registry.Register("hjælp", new CommandHelp(registry));
        
        registry.Register("Actions", new CommandActions(user));
        registry.Register("Handlinger", new CommandActions(user));
        
        registry.Register("Checkout", commandAction);
        registry.Register("Kassen", commandAction);
        
        //registry.Register("Items", new CommandItem(items));


    }
  
    public void run()
    {
        Console.Clear();
        
        Console.WriteLine("Before we start, please type what language you want to play in.");
        Console.WriteLine("You can either play in danish or english");
        Console.WriteLine("Type 'danish' or 'english'");
        language = Console.ReadLine();
        if (language == "english")
        {
            Translate.Instance.SetLanguage("english");
        }
        else
        {
            Translate.Instance.SetLanguage("danish");
        }
        Console.WriteLine(Translate.Instance.GetTranslation("Your_Name"));
        Console.Write(">");
        string playerName = Console.ReadLine();
        user = new UserInfo(playerName);
        InitRegistry();
        Console.WriteLine();
        Console.WriteLine($"Hello {UserInfo.Username}!");
        Console.WriteLine(Translate.Instance.GetTranslation("Welcome5"));
        Console.WriteLine("");
        Console.WriteLine(Translate.Instance.GetTranslation("Welcome1"));
        Console.WriteLine(Translate.Instance.GetTranslation("Welcome2"));
        Console.WriteLine(Translate.Instance.GetTranslation("Welcome3"));
        Console.WriteLine(Translate.Instance.GetTranslation("Welcome4"));
        Console.WriteLine("");
     
        
        while (context.IsDone() == false)
        {
            context.GetCurrent().Welcome();
            //context.
            Console.Write("> ");
            var line = Console.ReadLine();
            var result = Lowercap(line);
            
            String Lowercap(string? input)
            {
                string[] words = input.ToLower().Split(' ');
                if (words.Length < 2)
                {
                    words[0] = char.ToUpper(words[0][0]) + words[0].Substring(1);
                    return String.Join(" ", words);
                }

                words [1] = char.ToUpper(words[1][0]) + words[1].Substring(1);
                return String.Join(" ", words);
            }

            line = result;
            
            if (line != null)
            {
                if (line == "lol")
                {
                    sounds.LOL();
                }
                /* if (line=="Actions")
                 {
                     TextC.ActionsText();
                     Console.Write(">");
                     var line2 = Console.ReadLine();
                     line = line +" "+ line2;
                 }*/
                if (line == "Checkout")
                {
                    line = line + " Checkout";
                }
                registry.Dispatch(line);

            }
            Console.Clear();
        }
        sounds.GameOver();
        Console.WriteLine("Game Over 😥");
    }
}

