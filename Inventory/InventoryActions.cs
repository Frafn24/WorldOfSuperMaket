using WorldOfSuperMaket.data;

namespace WorldOfSuperMaket.Inventory;

public class InventoryActions
{
    public List<Inv> Add(List<Inv> inv, Items itm)
    {
        if(inv.Count != 0)
        {
            if (inv.Count(x => x.item == itm) == 0)
            {
                var newitem = new Inv{ Number=1, item=itm};
                inv.Add(newitem);
            }
            else
            {
                int index = inv.FindIndex(x=>x.item==itm);
                var inve = inv.FirstOrDefault(x => x.item == itm);
                inve.Number++;
                inv[index] = inve;
                
            }
            return inv;
        }
        return inv;
        //int count = inv.Count;
        //var newarray = new Items[count + 1];
        //newarray[inv.Count + 1] = item;
        //return newarray;
    }
    public List<Inv> Remove(List<Inv> inv, Items item)
    {
        if (inv.Count == 0) 
        {
            Console.WriteLine("Der er ikke noget i dit inventory :(");
            return inv;
        }
        var newarray =  inv.Where(x=>x.item != item).ToList();
        return inv;
    }
    public void Show(List<Inv> inv)
    {
        Console.WriteLine("Vare i din kurv:");
        foreach (var itm in inv)
        {
            Console.WriteLine($"Vare: {itm.item.Name}, Mængde: ");

        }
    }
}