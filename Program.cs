using System.Globalization;
using CsvHelper;

namespace WorldOfSuperMaket;

internal class Program
{
    static void Main(string[] args)
    {
        var itemList = LoadCsv("Data/items.csv"); //Finds the CSV file at a path, we should make it generic
        RunGame(itemList);
        Console.ReadLine();

    }
    static void RunGame(List<Items> items)
    {
        World world = new World();
        
        foreach (var item in items)
        {
            Space targetSpace = world.GetSpaceType(item.Type); // Get the space based on item type
            if (targetSpace != null)
            {
                targetSpace.AddItem(item); // Add item to the corresponding space (eg. Type Meats to Meats node)
            }
        }
        
        Game game = new Game();
        game.run();
    }
    static List<Items> LoadCsv(string filePath)
    {
        var items = new List<Items>();
            
        using (var reader = new StreamReader(filePath)) //opens the file ate the earlier specified filepath
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) //Makes sure the reader reads the file and removes stuff like dates
        {
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var item = new Items(
                    csv.GetField("Name"),
                    csv.GetField("Description"),
                    csv.GetField("Type"),
                    csv.GetField<double>("Calorie"),
                    csv.GetField<double>("Carbo"),
                    csv.GetField<double>("Protien"),
                    csv.GetField<double>("Fat"),
                    csv.GetField<double>("C02")
                );

                items.Add(item);
            }
        }
        
        return items;
    }
}