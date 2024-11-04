
class CommandUnkneown : BaseCommand, ICommand {
    public CommandUnkneown()
    {
        description = "Show items in your inventory";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕");
    }
}
/*public void Add()
{

}

public void Show(Item[] inventory)
{
    Console.WriteLine("Show items in your inventory");
    for (int i = 0; i < inventory.Length; i++)
    {
        Console.WriteLine("Items in inventory: " + inventory[i].Name);
    }
}

public void Remove()
{

}*/

