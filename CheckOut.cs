namespace WorldOfSuperMaket;

public class CheckOut;

public static void DoCheckOut((List<InventoryItem> inventory, double DailyFat, double DailyCarbs, double DailyProteins, double Klimaneutral)
{
    foreach (var item in inventory)
    {
        Console.WriteLine($"Item: {item.GetName()}");
        var info = GetInfo();
        Console.WriteLine($"Calories: {info[0]}");
        Console.WriteLine($"CO2: {info[4]}");
        Console.WriteLine($"Fat: {info[3]}");
        Console.WriteLine($"Carbohydrates: {info[1]}");
        Console.WriteLine($"Proteins: {info[2]}");
        Console.WriteLine();
    }
    
    double totalCalories = inventory.Sum(i => i.Calories);
    double totalCO2 = inventory.Sum(i => i.CO2);
    double totalFat = inventory.Sum(i => i.Fat);
    double totalCarbs = inventory.Sum(i => i.Carbohydrates);
    double totalProteins = inventory.Sum(i => i.Proteins);

    Console.WriteLine($"Total Calories: {totalCalories}");
    Console.WriteLine($"Total CO2: {totalCO2}");
    Console.WriteLine($"Total Fat: {totalFat}");
    Console.WriteLine($"Total Carbohydrates: {totalCarbs}");
    Console.WriteLine($"Total Proteins: {totalProteins}");

    double fatPercentage = (totalFat / DailyFat) * 100;
    double carbsPercentage = (totalCarbs / DailyCarbs) * 100;
    double proteinsPercentage = (totalProteins / DailyProteins) * 100;

    if (fatPercentage > 100)
        fatPercentage = 100;
    if (carbsPercentage > 100)
        carbsPercentage = 100;
    if (proteinsPercentage > 100)
        proteinsPercentage = 100;

    double foodScore = (fatPercentage + carbsPercentage + proteinsPercentage) / 3;

    double EnviromentScore = totalCO2 / (0.55/52);

    Console.WriteLine($"The food in you cart covers {foodScore} % of your required macro");
    Console.WriteLine(
        $"If everyone shopped like you, we would need {EnviromentScore} Earths just for grocery shopping");
    
}

public class InventoryItem
{
    public string Name { get; set; }
    public double Calories { get; set; }
    public double CO2 { get; set; }
    public double Fat { get; set; }
    public double Carbohydrates { get; set; }
    public double Proteins { get; set; }
}
