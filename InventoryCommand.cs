using System.Security.Cryptography;
using WorldOfSuperMaket;

class InventoryCommand : BaseCommand, ICommand {
    Items[] Items;
    public InventoryCommand()
    {
        description = "Show items in your inventory";
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
        if (Items!=null)
        {
            Console.WriteLine("Show items in your inventory");
            for (int i = 0; i < Items.Length; i++)
            {
                Console.WriteLine("Items in inventory: " + Items[i].Name);
            }
        }
        else
        {
            Console.WriteLine("Der er ingen item i din inventory");
        }
    }
}
/*public void Add()
{

}


public void Remove()
{

}*/

