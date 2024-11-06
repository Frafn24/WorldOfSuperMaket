/* Main class for launching the game
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Commands;

class Game {
  Items[] items = new Items[1];
    Items[] inv = new Items[0];
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  UserInfo user;
  bool whil = false;
  TextAnime text = new TextAnime();
  //SoundsClass sound = new SoundsClass();
  
  private void InitRegistry () 
  {

        //items = CommandItem.AddItems();
        ICommand cmdExit = new CommandExit();
        registry.Register("exit", cmdExit);
        registry.Register("quit", cmdExit);
        registry.Register("bye", cmdExit);
        registry.Register("go", new CommandGo());
        registry.Register("help", new CommandHelp(registry));
        registry.Register("Actions", new CommandActions(user));
        //registry.Register("Items", new CommandItem(items));
        

  }
  
    public void run()
    {
        //int Age=0;
        //int height = 0;
        //int Weaght = 0;
        //string Gender = "";
        
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

            Console.Clear();
            Console.WriteLine("Velkommen til supermarkedet.");
            Console.WriteLine("Du kan skrive 'go' + 'lokation' for at bevæge dig igennem supermarkedet");
            Console.WriteLine("Skriv 'Actions' for at tilføje eller fjerne en vare");
            Console.WriteLine("Skriv 'help' for at se alle kommandoer");
        InitRegistry();
            context.GetCurrent().Welcome();
        while (context.IsDone() == false)
        {
            //context.
            //Console.Write("> ");
            var line = Console.ReadLine();
            if (line != null)
            {
                if (line=="Actions")
                {
                    Console.WriteLine("Disse Action du kan vælge imellem her er");
                    Console.WriteLine(" Tilføj vare - Tilføj");
                    Console.WriteLine(" Fjern vare - Fjern");
                    Console.WriteLine(" Se kurv - Kurv");
                    Console.Write(">");
                    var line2 = Console.ReadLine();
                    line = line +" "+ line2;
                }
                registry.Dispatch(line);
                //Console.WriteLine(context.GetCurrent().GetName());
                
            }
            if (string.IsNullOrEmpty(line))
            {
                context.MakeDone();
            }
        }
        //sound.Play();
        Console.WriteLine("Game Over 😥");


    }
}
