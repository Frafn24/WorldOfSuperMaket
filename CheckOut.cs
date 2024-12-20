﻿using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Readers;
using WorldOfSuperMaket.Sounds;

namespace WorldOfSuperMaket;

public class CheckOut
{
    public void DoCheckOut(List<Inv> inv, UserInfo userInfo)
    {
        decimal totalPrice = 0;
        decimal totalFat = 0;
        decimal totalCO2 = 0;
        decimal totalCarbs = 0;
        decimal totalProteins=0;
        decimal totalCal =0;
        var sounds = new Lyd();
        Console.Clear();
        foreach (var item in inv)
        {
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Item"),item.item.GetName());
            var info = item.item.GetMacros();
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Calories"),info[0]);
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Carbs"),info[1]);
            Console.WriteLine($"Protein: {info[2]}");
            Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Fat"),info[3]);
            Console.WriteLine($"CO2: {info[4]}");
            Console.WriteLine();
        }
        foreach (var item in inv)
        {
            totalPrice = totalPrice+item.Number * item.item.Price;
            totalFat = totalFat+item.Number * item.item.Fat;
            totalCO2 = totalCO2+item.Number * item.item.C02;
            totalCarbs = totalCarbs+item.Number * item.item.Carbo;
            totalProteins= totalProteins+item.Number * item.item.Protien;
            totalCal = totalCal+item.Number * item.item.Calorie;
        }


        decimal carbsPercentage = Convert.ToDecimal((totalCarbs / userInfo.DaliyKullhydrat) * 100);
        decimal proteinsPercentage = (totalProteins / userInfo.DaliyProtien) * 100;
        decimal fatPercentage = (totalFat / userInfo.DaliyFat) * 100;

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

        decimal foodScore = (fatPercentage + carbsPercentage + proteinsPercentage) / 3;
        
        decimal EnviromentScore = (totalCO2 / 100) / (decimal)(0.55 / 52.0);
        Console.Clear();
        Console.WriteLine("****************************************************************************************************");
        Console.WriteLine("                                         KVITTERING");
        Console.WriteLine("****************************************************************************************************");
        Console.WriteLine();

        Console.WriteLine(
            $"{Translate.Instance.GetTranslation("Varer").PadRight(25)}" +
            $"{Translate.Instance.GetTranslation("Pris").PadLeft(15)}" +
            $"{Translate.Instance.GetTranslation("Kalorier").PadLeft(14)}" +
            $"{Translate.Instance.GetTranslation("Fedt").PadLeft(8)}" +
            $"{Translate.Instance.GetTranslation("Protein").PadLeft(10)}" +
            $"{Translate.Instance.GetTranslation("Kulhydrater").PadLeft(14)}" +
            $"{Translate.Instance.GetTranslation("CO2").PadLeft(7)}");

        Console.WriteLine(new string('-', 100));

        foreach (var item in inv)
        {
            var info = item.item.GetMacros();
            Console.WriteLine($"{item.item.GetName()}".PadRight(30) + $"{info[1]/100} Kr.".PadLeft(10) +
                              $"{info[0]} g".PadLeft(10) + $"{info[4]} g".PadLeft(10) + $"{info[3]} g".PadLeft(10) +
                              $"{info[2]} g".PadLeft(10) + $"{info[5]/100} kg".PadLeft(20));
        }
        Console.WriteLine(new string('-', 100));

        Console.Write(
            $"{Translate.Instance.GetTranslation("KviteringSamlet").PadRight(30)}");
        
        Console.WriteLine($"{totalPrice / 100} Kr.".PadLeft(10) +$"{totalCal} g".PadLeft(10) + $"{totalFat} g".PadLeft(10) + $"{totalProteins} g".PadLeft(10) +
                           $"{totalCarbs} g".PadLeft(10) + $"{totalCO2 / 100} kg".PadLeft(20));                
        
        Console.WriteLine("");
        Console.WriteLine(Translate.Instance.GetTranslation("Checkout_Items_In_Cart"),Math.Round(foodScore,2));
        Console.WriteLine(Translate.Instance.GetTranslation("Earths"),Math.Round(EnviromentScore,2)/1000);
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
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
}