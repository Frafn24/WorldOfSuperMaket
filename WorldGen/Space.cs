/* Space class for modeling spaces (rooms, caves, ...)
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Commands;
using WorldOfSuperMaket.Inventory;
using WorldOfSuperMaket.Models;

class Space : Node
{
    TextCommand TextC = new TextCommand();
    private CheckOut checkOut = new CheckOut();
    public Space(String name) : base(name)
    {
    }
    
    public string Name { get; set; }
    private List<Items> items; 
    
    public void AddItem(Items item)
    {
        items.Add(item); // Add item to a space (eg. Meats)
    }
    
    public List<Items> GetItems()
    {
        return items; // get the items from a space (eg. Meats)
    }

    public void Welcome()
    {
        //Items[] inv = // her skal der være en metode som får fat i spillerens inventory
        //UserInfo userInfo = //her skal der være den metode som får fat i spillerinfo

        //if (name == "checkout")
        //{
        //    Checkout(inv, userInfo);
        //}
        //else
        //{
        TextC.InfoText();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Du er nu ved: " + name);
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Det er nu ved: ");
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
        
        //}

    }
    public string GetName()
    {
        return name;
    }
    public void Goodbye()
    {
    }
    public void Checkout(List<Inv> inv,UserInfo userInfo)
    {
        var info = userInfo;
        double CaloriesInCart = inv.Sum(i => i.item.Calorie);

        bool EnoughCalories = CaloriesInCart >= userInfo.DailyCalo;
        
        double Calodif = CaloriesInCart - userInfo.DailyCalo;

        if (name.Equals("Checkout") && EnoughCalories)
        {
            CheckOut checkOut = new CheckOut(); 
            checkOut.DoCheckOut(inv,userInfo);
        }
        else
        {
            Console.WriteLine($"Du mangler at tilføje flere kalorier til din kurv, før du kan gå til Kurv du mangler {Calodif} Kalorier");
        }
    }

    public Space FollowEdge(string direction)
    {
        return (Space)(base.FollowEdge(direction));
    }
}
