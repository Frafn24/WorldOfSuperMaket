using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Readers;
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
           // Console.WriteLine($"Vare: {item.item.GetName()}");
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Item"),item.item.GetName());
            var info = item.item.GetMacros();
           // Console.WriteLine($"Kalorier: {info[0]}");
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Calories"),info[0]);
            //Console.WriteLine($"Kulhydrater: {info[1]}");
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Carbs"),info[1]);
            Console.WriteLine($"Protein: {info[2]}");
           // Console.WriteLine($"Fedt: {info[3]}");
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Fat"),info[3]);
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

        Console.WriteLine(
            $"{Translate.Instance.GetTranslation("Varer").PadRight(25)}" +
            $"{Translate.Instance.GetTranslation("Pris").PadLeft(15)}" +
            $"{Translate.Instance.GetTranslation("Kalorier").PadLeft(14)}" +
            $"{Translate.Instance.GetTranslation("Fedt").PadLeft(8)}" +
            $"{Translate.Instance.GetTranslation("Protein").PadLeft(10)}" +
            $"{Translate.Instance.GetTranslation("Kulhydrater").PadLeft(14)}" +
            $"{Translate.Instance.GetTranslation("CO2").PadLeft(7)})");

        Console.WriteLine(new string('-', 100));

        foreach (var item in inv)
        {
            var info = item.item.GetMacros();
            Console.WriteLine($"{item.item.GetName()}".PadRight(30) + $"{info[4]}".PadLeft(10) +
                              $"{info[0]}".PadLeft(10) + $"{info[3]}".PadLeft(10) + $"{info[2]}".PadLeft(10) +
                              $"{info[1]}".PadLeft(10) + $"{info[5]}".PadLeft(10));
        }

        Console.WriteLine("");
        Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Items_In_Cart"),Math.Round(foodScore,2));
        Console.WriteLine(Translate.Instance.GetTranslation("Earths"),Math.Round(EnviromentScore,2));
        Console.WriteLine("");

        Console.WriteLine(new string('-', 100));
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Tryk 'Enter' for at komme videre til spørgeskema.");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Har du lært noget om at reducere dit CO2-aftryk, når du handler ind? (ja/nej)");

        string? svar = string.Empty;
        while (true)
        {
            Console.Write("> ");
            svar = Console.ReadLine()?.ToLower(); 
            if (svar == "ja")
            {
                Console.WriteLine("Det er fantastisk at høre! Tak for din feedback.");
                break; 
            }
            else if (svar == "nej")
            {
                Console.WriteLine("Det er ærgerligt at høre. Vi håber, du vil lære mere næste gang!");
                break; 
            }
            else
            {
                Console.WriteLine("Ugyldigt svar. Prøv venligst igen og skriv 'ja' eller 'nej'.");
            }
        }

        Console.WriteLine("Tak fordi du spillede spillet!");
        sounds.GameOver();
        Console.WriteLine("Game Over 😥");
        //Console.WriteLine("Håber du eller de, somm spiller vores spil");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
}