using System.Globalization;
//using CsvHelper;

namespace WorldOfSuperMaket;

internal class Program
{
    static void Main(string[] args)
    {
        RunGame();
        Console.ReadLine();

    }
    static void RunGame()
    {
        Game game = new Game();
        game.run();
        
    }
}
    /*static List<Items> LoadCsv(string filePath)
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
    }*/
