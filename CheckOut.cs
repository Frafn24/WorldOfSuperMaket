namespace WorldOfSuperMaket;

public class CheckOut
{
    public void DoCheckOut(List<Items> inventory, UserInfo userInfo)
    {
        foreach (var item in inventory)
        {
            Console.WriteLine($"Item: {item.GetName()}");
            var info = item.GetMacros();
            Console.WriteLine($"Calories: {info[0]}");
            Console.WriteLine($"Carbohydrates: {info[1]}");
            Console.WriteLine($"Proteins: {info[2]}");
            Console.WriteLine($"Fat: {info[3]}");
            Console.WriteLine($"CO2: {info[4]}");
            Console.WriteLine();
        }

        double totalCalories = inventory.Sum(i => i.Calorie);
        double totalCO2 = inventory.Sum(i => i.C02);
        double totalFat = inventory.Sum(i => i.Fat);
        double totalCarbs = inventory.Sum(i => i.Carbo);
        double totalProteins = inventory.Sum(i => i.Protien);

        Console.WriteLine($"Total Calories: {totalCalories}");
        Console.WriteLine($"Total CO2: {totalCO2}");
        Console.WriteLine($"Total Fat: {totalFat}");
        Console.WriteLine($"Total Carbohydrates: {totalCarbs}");
        Console.WriteLine($"Total Proteins: {totalProteins}");

        double carbsPercentage = (totalCarbs / userInfo.DaliyKullhydrat) * 100;
        double proteinsPercentage = (totalProteins / userInfo.DaliyProtien) * 100;
        double fatPercentage = (totalFat / userInfo.DaliyFat) * 100;

        if (fatPercentage > 100)
        {
            fatPercentage = 100;
        }
        if (carbsPercentage > 100)
        {
            carbsPercentage = 100;
        }
        if (proteinsPercentage > 100)
        {
            proteinsPercentage = 100;
        }

        double foodScore = (fatPercentage + carbsPercentage + proteinsPercentage) / 3;

        double EnviromentScore = totalCO2 / (0.55 / 52);

        Console.WriteLine($"The food in you cart covers {foodScore} % of your required macro");
        Console.WriteLine($"If everyone shopped like you, we would need {EnviromentScore} Earths just for grocery shopping");
    }
}


