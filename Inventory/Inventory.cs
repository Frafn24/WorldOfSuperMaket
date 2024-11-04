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
    public void remove(Items item)
    {
        var index = Array.FindIndex(res, row => row.Name == item.Name);
        var newres = res.Where(x => x.Name != item.Name).ToArray();
        res = newres;

    }
    
    public void ListItems()
    {
        Console.WriteLine("Items in your cart:");
        foreach (var item in res)
        {
            if (item != null)
            {
                Console.WriteLine($"Item: {item.Name}, Calories: {item.Calories}");
            }
        }
    }

    public void Add(Items itemToPickUp)
    {
    }
}