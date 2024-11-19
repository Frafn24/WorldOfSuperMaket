using WorldOfSuperMaket.data;

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
            Console.WriteLine("Der er ikke noget i dit inventory :(");
            return inv;
        }
        int count = inv.Length;
        var newarray = inv.Where(x => x != item).ToArray();
        return inv;
    }
    public void Show(Items[] inv)
    {
        Console.WriteLine("Vare i din kurv:");
        foreach (var itm in inv)
        {
            Console.WriteLine($"Vare: {itm.Name}, Mængde: ");

        }
    }
}