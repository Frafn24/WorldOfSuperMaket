namespace WorldOfSuperMaket.Inventory;

public class Inventory
{
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
}