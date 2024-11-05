using System.Security.Cryptography.X509Certificates;
using WMPLib;

namespace WorldOfSuperMaket.Inventory;

public class Inventory
{
    //void inte()
    //{
    //    inventory[1] = new Items("test", 100);
    //}

    public Items[] Add(Items[] inv, Items item)
    {
        int count = inv.Length;
        var newarray = new Items[count + 1];
        newarray[inv.Length + 1] = item;
        return newarray;
    }
    public Items[] Remove(Items[] inv, Items item)
    {
        if (inv.Length == 0) 
        {
            Console.WriteLine("Der er ikke noget i din inventory :(");
            return inv;
        }
        int count = inv.Length;
        var newarray = inv.Where(x => x != item).ToArray();
        return inv;
    }
    public void Show(Items[] inv)
    {
        Console.WriteLine("Items in your cart:");
        foreach (var itm in inv)
        {
            Console.WriteLine($"Item: {itm.Name}, Quantity: ");

        }
    }

    //public void RemoveItem(string name)
    //{
    //    //if (items.ContainsKey(name) && items[name].Count > 0)
    //    //{
    //    //    items[name].RemoveAt(items[name].Count - 1);
    //    //    Console.WriteLine($"You have dropped {name} on the floor.");
    //    //    if (items[name].Count == 0)
    //    //    {
    //    //        items.Remove(name);
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    Console.WriteLine($"You do not have {name} in your cart.");
    //    //}
    //}

}