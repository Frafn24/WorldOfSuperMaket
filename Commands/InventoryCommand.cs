using System.Security.Cryptography;
using WorldOfSuperMaket.Models;

class InventoryCommand : BaseCommand, ICommand {
    Items[] Items;
    public InventoryCommand()
    {
        description = "Vis items i din kurv.";
       // Items = items;
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (parameters.Length>0 && parameters[0].ToLower()=="show")
        {
            Show();
        }
        else
        {
            //Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕");
        }
        switch (parameters[0].ToLower())
        {
            case "show":
                Show();
                break;
        }
    }
    public void Show()
    {
        if (Items.Count()>0)
        {
            Console.WriteLine("Vis varer i dit inventory.");
            for (int i = 0; i < Items.Length; i++)
            {
                Console.WriteLine("Varer i din kurv: " + Items[i].Name);
            }
        }
        else
        {
            Console.WriteLine("Der er ingen items i dit inventory");
        }
    }
}
/*public void Add()
{

}


public void Remove()
{

}*/

