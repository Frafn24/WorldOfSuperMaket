using System.Security.Cryptography;
using WorldOfSuperMaket;
using WorldOfSuperMaket.Models;

/*class InventoryCommand : BaseCommand, ICommand {
    Items[] Items;
    public InventoryCommand()
    {
        description = "Vis items i din kurv.";
       // Items = items;
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (parameters.Length>0 && parameters[0].ToLower()=="show")
        {
            Show();
        }
        else
        {
            //Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕");
        }
        switch (parameters[0].ToLower())
        {
            case "show":
                Show();
                break;
        }
    }
    public void Show()
    {
        if (Items.Count()>0)
        {
            Console.WriteLine(Translate.Instance.GetTranslation("Inventory"));
            for (int i = 0; i < Items.Length; i++)
            {
                //Console.WriteLine(Translate.Instance.GetTranslation("Inventory_Print"));
               Console.WriteLine($"Antal: {inv[i].Number} stk. {inv[i].Item.Name}");
            }
        }
        else
        {
            Console.WriteLine("Der er ingen items i dit inventory");
        }
    }
    public void DoCheckOut(List<Inv> inv, UserInfo userInfo)
    {
        //foreach (var item in inv)
        {
            //Console.WriteLine($"Vare: {item.item.GetName()}");
            //var info = item.item.GetMacros();
            //Console.WriteLine($"Kalorier: {info[0]}");
            //Console.WriteLine($"Kulhydrater: {info[1]}");
            //Console.WriteLine($"Protein: {info[2]}");
            //Console.WriteLine($"Fedt: {info[3]}");
            //Console.WriteLine($"CO2: {info[4]}");
            //Console.WriteLine();
        }
        
        double totalCalories = inv.Sum(i => i.item.Calorie);
        double totalPrice = inv.Sum(i => i.item.Price);
        double totalCO2 = inv.Sum(i => i.item.C02);
        double totalFat = inv.Sum(i => i.item.Fat);
        double totalCarbs = inv.Sum(i => i.item.Carbo);
        double totalProteins = inv.Sum(i => i.item.Protien);
        int totalItems = inv.Sum(i => i.Number);
        

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

        double foodScorep = (fatPercentage + carbsPercentage + proteinsPercentage) / 3;
        double EnviromentScorep = totalCO2 / (0.55 / 52);
        double foodScore = Math.Round(foodScorep, 2);
        double EnviromentScore = Math.Round(EnviromentScorep, 2);
        
        Console.Clear();
        Console.WriteLine(new string('*', 110));
        Console.WriteLine("                                          KVITTERING");
        Console.WriteLine(new string('*', 110));
        Console.WriteLine();
        Console.WriteLine("Varer".PadRight(30) + "Antal".PadLeft(10) + "Pris".PadLeft(10) + "Kalorier".PadLeft(10) + "fedt".PadLeft(10) +
                          "Protein".PadLeft(10) + "Kulhydrater".PadLeft(15)+ "CO2".PadLeft(10));
        Console.WriteLine(new string('-', 110));

        foreach (var item in inv)
        {
            var info = item.item.GetMacros();
            Console.WriteLine($"{item.item.GetName()}".PadRight(30) + $"{item.Number}".PadLeft(10) + $"{item.item.GetPrice()}".PadLeft(10) +
                              $"{info[0]}".PadLeft(10) + $"{info[3]}".PadLeft(10) + $"{info[2]}".PadLeft(10) +
                              $"{info[1]}".PadLeft(10) + $"{item.item.GetCO2()}".PadLeft(15));
            
            
        }
        Console.WriteLine(new string('-', 110));
            
        Console.WriteLine("samlet".PadRight(30) + $"{totalItems}".PadLeft(10) + $"{totalPrice}".PadLeft(10) +
                          $"{totalCalories}".PadLeft(10) + $"{totalFat}".PadLeft(10) + $"{totalProteins}".PadLeft(10) +
                          $"{totalCarbs}".PadLeft(10) + $"{totalCO2}".PadLeft(15));
        Thread.Sleep(1000);
        Console.WriteLine(new string('-', 110));
        Thread.Sleep(1000);
        Console.WriteLine("");
        Console.WriteLine($"Varene i din kurv dækker over {foodScore} % af de påkrævet macros.");
        Console.WriteLine(
            $"Hvis alle handlede som dig, skulle vi bruge {EnviromentScore} jordkloder, kun til at handle madvarer.");
        Console.WriteLine("");

        Console.WriteLine(new string('-', 100));
        
        Console.Write(">");

        //context.MakeDone();
    }
}
/*public void Add()
{

}


public void Remove()
{

}*/

