namespace WorldOfSuperMaket;

public class CheckOut
{
    public void DoCheckOut(Items[] inv, UserInfo userInfo)
    {
        foreach (var item in inv)
        {
            Console.WriteLine($"Vare: {item.GetName()}");
            var info = item.GetMacros();
            Console.WriteLine($"Kalorier: {info[0]}");
            Console.WriteLine($"Kulhydrater: {info[1]}");
            Console.WriteLine($"Protein: {info[2]}");
            Console.WriteLine($"Fedt: {info[3]}");
            Console.WriteLine($"CO2: {info[4]}");
            Console.WriteLine();
        }

        double totalCalories = inv.Sum(i => i.Calorie);
        double totalPrice = inv.Sum(i => i.Price);
        double totalCO2 = inv.Sum(i => i.C02);
        double totalFat = inv.Sum(i => i.Fat);
        double totalCarbs = inv.Sum(i => i.Carbo);
        double totalProteins = inv.Sum(i => i.Protien);

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
        Console.Clear();
        Console.WriteLine("**********************************************");
        Console.WriteLine("                 RECEIPT");
        Console.WriteLine("**********************************************");
        Console.WriteLine();
        Console.WriteLine("Varer".PadRight(30) + "Pris".PadLeft(10) + "Kalorier".PadLeft(10) + "fedt".PadLeft(10)+ "Protein".PadLeft(10)+ "Kulhydrater".PadLeft(10));
        Console.WriteLine(new string('-', 50));

        foreach (var item in inv)
        {
            var info = item.GetMacros();
            Console.WriteLine($"{item.GetName()}".PadRight(30) + $"{info[4]}".PadLeft(10) + $"{info[0]}".PadLeft(10)+ $"{info[3]}".PadLeft(10)+ $"{info[2]}".PadLeft(10) + $"{info[1]}".PadLeft(10) + $"{info[5]}".PadLeft(10));
        }

        Console.WriteLine("");
        Console.WriteLine($"Varene i din kurv dækker over {foodScore} % af de påkrævet macros.");
        Console.WriteLine($"Hvis alle handlede som dig, skulle vi bruge {EnviromentScore} jordkloder, kun til at handle madvarer.");
        Console.WriteLine("");
        
        Console.WriteLine(new string('-', 50));
    }
}


