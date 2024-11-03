namespace WorldOfSuperMaket.Inventory;

public class Inventory
{
    private Dictionary<string, Item> items;

    public Inventory()
    {
        items = new Dictionary<string, Item>();
    }
    public void AddItem(string name, Item item)
    {
        if (!items.ContainsKey(name))
        {
            items[name] = new List<Item>();
        }
        items[name].Add(item);
        Console.WriteLine($"{item.Name} added to your cart.");
    }
    public void RemoveItem(string name)
    {
        if (items.ContainsKey(name) && items[name].Count > 0)
        {
            items[name].RemoveAt(items[name].Count - 1);
            Console.WriteLine($"You removed {name} removed from cart.");
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
    
}