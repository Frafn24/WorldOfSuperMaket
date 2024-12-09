/* Space class for modeling spaces (rooms, caves, ...)
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Commands;
using WorldOfSuperMaket.Inventory;
using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Readers;

class Space : Node
{
    private double DailyCalo = 2000;
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

        TextC.InfoText();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(Translate.Instance.GetTranslation("Youre_At"), name);
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine(Translate.Instance.GetTranslation("Its_At"));
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
   /* public void Checkout(List<Inv> inv,UserInfo userInfo)
    {
        var info = userInfo;
        double CaloriesInCart = inv.Sum(i => i.item.Calorie);

        bool EnoughCalories = CaloriesInCart >= DailyCalo;
        
        double Calodif = CaloriesInCart - DailyCalo;

        if (name.Equals("Checkout") && EnoughCalories)
        {
            CheckOut checkOut = new CheckOut(); 
            checkOut.DoCheckOut(inv,userInfo);
        }
        else
        {
            Console.WriteLine($"Du mangler at tilføje flere kalorier til din kurv, før du kan gå til Kurv du mangler {Calodif} Kalorier");
        }
    }*/

    public Space FollowEdge(string direction)
    {
        return (Space)(base.FollowEdge(direction));
    }
}
