using System.Security.Cryptography.X509Certificates;

namespace WorldOfSuperMaket.Inventory;

public class Inventory
{
    Items[]inventory= new Items[0];
    //void inte()
    //{
    //    inventory[1] = new Items("test", 100);
    //}

    public void add()
    {
            int count = inventory.Length;
            var newarray = new Items[count + 1];
            //newarray[inventory.Length + 1] = new Items("test2", 100);
            inventory = newarray;
    }
    public void remove(Items items)
    {
        if (inventory.Length > 0)
        {
            var index = Array.FindIndex(inventory, x => x.Name == items.Name);

            var newinventory = inventory.Where(x => x.Name != items.Name).ToArray();
            inventory = newinventory;
        }
    

    }
    
    public void ListItems(List<Items> inventory)
    {
        Console.WriteLine("Items in your cart:");
        foreach (var itm in inventory)
        {
            Console.WriteLine($"Item: {itm.Name}, Quantity: ");
            
        }
    }
    //det her er for at pushe
    
}