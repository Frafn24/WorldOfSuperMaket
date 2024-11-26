﻿using WorldOfSuperMaket.Models;

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
    }
    public List<Inv> Remove(List<Inv> inv, Items item)
    {
        try
        {
            if (inv.Count() == 0 && item is not null)
            {
                Console.WriteLine("Der er ikke noget i dit inventory eller du har ikke valgt noget item:(");
            }
            else if (inv.Count(x => x.item.Name == item.Name) > 0)
            {
                var specitem=inv.Where(x=>x.item.Name==item.Name).FirstOrDefault();
                if (specitem.Number>1)
                {
                    specitem.Number--;
                }
                else
                {
                    var itemToRemove = inv.Single(r => r.item == item);
                    inv.Remove(itemToRemove);
                }
            }
            return inv;
        }
        catch (Exception)
        {
            return inv;
            throw;
        }
        
    }
    public void Show(List<Inv> inv)
    {
        Console.Clear();
        if (inv.Count() > 0)
        {
            Console.WriteLine("Varer er i din Kurv.");
            foreach (var itm in inv)
            {
                Console.WriteLine($"Mængde:{itm.Number} ,Vare: {itm.item.Name} ");

            }
        }
        else
        {
            Console.WriteLine("Der er ingen items i dit inventory");
        }
    }
}