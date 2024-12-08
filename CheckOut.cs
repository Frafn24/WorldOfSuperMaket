﻿using WorldOfSuperMaket.Models;
namespace WorldOfSuperMaket;

public class CheckOut
{
    double carbsPercentage = 1.0;
    double proteinsPercentage = 1.0;
    double fatPercentage = 1.0;
    private string linkDanish = "https://da.surveymonkey.com/r/KKH5KRY";
   // string linkEnglish = "";
    
    public void DoCheckOut(List<Inv> inv, UserInfo userInfo)
    {
        foreach (var item in inv)
        {
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Vare"), item.item.GetName());
            var info = item.item.GetMacros();
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Kalorier"), info[0]);
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Kulhydrater"), info[1]);
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Protein"), info[2]);
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Fedt"), info[3]);
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_CO2"), info[4]);
            Console.WriteLine();
           
        }

        double totalCalories = inv.Sum(i => i.item.Calorie);
        double totalPrice = inv.Sum(i => i.item.Price);
        double totalCO2 = inv.Sum(i => i.item.C02);
        double totalFat = inv.Sum(i => i.item.Fat);
        double totalCarbs = inv.Sum(i => i.item.Carbo);
        double totalProteins = inv.Sum(i => i.item.Protien);

       // double carbsPercentage = (totalCarbs / userInfo.DailyKulhydrat) * 100;
      //  double proteinsPercentage = (totalProteins / userInfo.DailyProtien) * 100;
        //double fatPercentage = (totalFat / userInfo.DailyFat) * 100;

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
            var info = item.item.GetMacros();
            Console.WriteLine($"{item.item.GetName()}".PadRight(30) + $"{info[4]}".PadLeft(10) + $"{info[0]}".PadLeft(10)+ $"{info[3]}".PadLeft(10)+ $"{info[2]}".PadLeft(10) + $"{info[1]}".PadLeft(10) + $"{info[5]}".PadLeft(10));
        }

        Console.WriteLine("");
        Console.WriteLine($"Varene i din kurv dækker over {foodScore} % af de påkrævet macros.");
        Console.WriteLine($"Hvis alle handlede som dig, skulle vi bruge {EnviromentScore} jordkloder, kun til at handle madvarer.");
        Console.WriteLine("");
        
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"Thank you for playing. If you wouldn't mind, we would love for you to answer a survey");
        Console.WriteLine("to tell us what you've learned so far!");
        Console.WriteLine($"link to danish survey --> " +linkDanish);
        //Console.WriteLine($"Link to english survey --> " +linkEnglish);
    }
}


