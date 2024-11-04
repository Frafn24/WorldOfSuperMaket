namespace WorldOfSuperMaket.Inventory;

public class Inventory
{
    Items[]res= new Items[1];
    void inte()
    {
        res[1] = new Items("test", 100);
    }

    public void add()
    {
        int count = res.Length;
        var newarray = new Items[count+1];
        newarray[res.Length+1]= new Items("test2", 100);
        res=newarray;
    }
    public void remove()
    {
        
    
    
}
    }
    
    public void RemoveItem(string name)
    {
        if (items.ContainsKey(name) && items[name].Count > 0)
        {
            items[name].RemoveAt(items[name].Count - 1);
            Console.WriteLine($"You have dropped {name} on the floor.");
            if (items[name].Count == 0)
            {
                items.Remove(name);
            }
        }
        else
        {
            Console.WriteLine($"You do not have {name} in your cart.");
        }
    }
    
    public void ListItems()
    {
        Console.WriteLine("Items in your cart:");
        foreach (var itm in items)
        {
            Console.WriteLine($"Item: {itm.Key}, Quantity: ");
            
        }
    }
    //det her er for at pushe
    
}