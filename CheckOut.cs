using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Sounds;

namespace WorldOfSuperMaket;

public class CheckOut
{
    public void DoCheckOut(List<Inv> inv, UserInfo userInfo)
    {
        var sounds = new Lyd();
        Console.Clear();
        foreach (var item in inv)
        {
            Console.WriteLine($"Vare: {item.item.GetName()}");
            var info = item.item.GetMacros();
            Console.WriteLine($"Kalorier: {info[0]}");
            Console.WriteLine($"Kulhydrater: {info[1]}");
            Console.WriteLine($"Protein: {info[2]}");
            Console.WriteLine($"Fedt: {info[3]}");
            Console.WriteLine($"CO2: {info[4]}");
            Console.WriteLine();
        }

        double totalCalories = inv.Sum(x => x.item.Calorie*x.Number);
        double totalPrice = inv.Sum(x => x.item.Price*x.Number);
        double totalCO2 = inv.Sum(x => x.item.C02 * x.Number);
        double totalFat = inv.Sum(x => x.item.Fat * x.Number);
        double totalCarbs = inv.Sum(x => x.item.Carbo * x.Number);
        double totalProteins = inv.Sum(x => x.item.Protien * x.Number);

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
        Console.WriteLine("                 KVITTERING");
        Console.WriteLine("**********************************************");
        Console.WriteLine();
        Console.WriteLine("Varer".PadRight(30) + "Pris".PadLeft(10) + "Kalorier".PadLeft(10) + "fedt".PadLeft(10) +
                          "Protein".PadLeft(10) + "Kulhydrater".PadLeft(10));
        Console.WriteLine(new string('-', 50));

        foreach (var item in inv)
        {
            var info = item.item.GetMacros();
            Console.WriteLine($"{item.item.GetName()}".PadRight(30) + $"{info[4]}".PadLeft(10) +
                              $"{info[0]}".PadLeft(10) + $"{info[3]}".PadLeft(10) + $"{info[2]}".PadLeft(10) +
                              $"{info[1]}".PadLeft(10) + $"{info[5]}".PadLeft(10));
        }

        Console.WriteLine("");
        Console.WriteLine($"Varene i din kurv dækker over {Math.Round(foodScore,2)} % af de påkrævet macros.");
        Console.WriteLine(
            $"Hvis alle handlede som dig, skulle vi bruge {Math.Round(EnviromentScore,2)} jordkloder, kun til at handle madvarer.");
        Console.WriteLine("");

        Console.WriteLine(new string('-', 50));
        Console.ReadKey();
        Console.Clear();
        sounds.GameOver();
        Console.WriteLine("Game Over 😥");
        Console.WriteLine("Håber du eller de, somm spiller vores spil");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
}