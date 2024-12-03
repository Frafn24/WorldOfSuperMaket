/* Space class for modeling spaces (rooms, caves, ...)
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Commands;
using WorldOfSuperMaket.Inventory;
using WorldOfSuperMaket.Models;

class Space : Node
{
    private double DailyCalo = 2000;
    TextCommand TextC = new TextCommand();
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
        {
            TextC.InfoText();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Du er nu ved " + name);
            HashSet<string> exits = edges.Keys.ToHashSet();
            Console.WriteLine("Det er nu ved ");
            foreach (String exit in exits)
            {
                Console.WriteLine(" - " + exit);
            }
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

    public Space FollowEdge(string direction)
    {
        return (Space)(base.FollowEdge(direction));
    }
}
