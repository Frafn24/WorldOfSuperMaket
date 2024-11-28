using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Inventory;

namespace WorldOfSuperMaket.Commands
{
    public class CommandActions : BaseCommand,ICommand
    {
        CheckOut check = new CheckOut();
        List<Items> Stock = new List<Items>();
        InventoryActions InvActions = new InventoryActions();
        //List<Items> StockInRoom = new List<Items>();
        List<Inv> inv = new List<Inv>();
        CsvReader reader = new CsvReader();
        UserInfo User { get; set; }
        string description;
        Items Test;
        TextCommand TextC = new TextCommand();

        // Bruger bare en TestItem


        public CommandActions()
        {
            Test = new Items("HakkeKød", "Hakkekød 7-12%", "Meats", 198, 28, 16, 8, 100,10);
            description = "Her kan du lave alle dine actions i rummet";
            //User = userInfo;
        }

        void ICommand.Execute(Context context, string command, string[] parameters)
        {
  
            context.GetCurrent().GetName();
            var room = context.GetCurrent().GetName();
            //if (GuardEq(parameters, 1))
            //{
            //    Console.WriteLine("Jeg kan ikke finde ud af hvor det er henne? 🤔");
            //    return;
            //}
            TextC.ActionsText();
            Console.Write(">");
            var line2 = Console.ReadLine();
            //parameters= line2;
            if (Stock.Count == 0)
            {
                addStock();
            }
            switch (line2)
            {
                case "Tilføj":
                    inv = InvActions.Add(inv, Stock);
                    break;
                case "Fjern":
                    inv = InvActions.Remove(inv,Stock[0]);
                    break;
                case "Kurv":
                    InvActions.Show(inv);
                    break;
                case "Checkout":
                    //checkout(context);
                    break;
            }
        }
        
        public void addStock()
        {
                Stock.AddRange(reader.csvTest());
/*            if (Stock.Count == 0)
            {
                LoadCsv();
            }
            List<Items> LoadCsv(string filePath)
            {
                var items = new List<Items>();
            
                var csvPath = @"data\items.csv";

                if (!File.Exists(csvPath))
                {
                    Stock=LoadCsv(filePath);
                }
                else
                {
                    Console.WriteLine("CSV File Not Found, HerbDeDerp");
                }
            
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
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
                            csv.GetField<double>("C02"),
                            csv.GetField<double>("Price")
                        );

                        items.Add(item);
                        
                        
                    
                    }
            
                    return items;
                }
            }
            
            //var TestItem = new Items("HakkeKød", "Hakkekød 7-12%", "Meats", 198, 28, 16, 8, 100);
            
*/            description = "alle de ting, som du kan gøre i dette rum ";
            
            
            
        }
        public void AddItems(string room)
        {
            if (Stock.Count == 0)
            {
                addStock();
            }
             List<Items> roomsItem = new List<Items>();
            Console.WriteLine($"ønsker du at tilføje denne varer til din kurv?");
            string anwser = ">";
            bool right = false;
            while (right==false) 
            {
                Console.WriteLine("Du skal vælge mellem Ja eller Nej");
                Console.Write(">");
                var line = Console.ReadLine();
                if (line == "Yes")
                {
                    //Inv(Stock.First());
                    Console.WriteLine("der er nu tilføjet en vare til din kurv");
                    right = true;
                }
                else if (line =="No")
                {
                    Console.WriteLine("der er ikke tilføjet en vare til din kurv");
                    right= true;
                }
                else
                {
                    Console.WriteLine("Du skal vælge mellem Ja eller Nej");
                }
            }
            Items[] items = new Items[1];
            //return items;
        }
        
        
        
        // New Command 
       /* public void ShowInv()
        {
            if (inv != null)
            {
                Console.WriteLine("Vis vare i din kurv.");
                Console.WriteLine("Vare i din kurv: ");
                for (int i = 0; i < inv.Count(); i++)
                {
                    Console.WriteLine($"antal:{inv[i].Number} stk. " + inv[i].item.Name);
                }
            }
            else
            {
                Console.WriteLine("Der er ingen items i dit inventory");
            }
        }
        public void AddItem(Items item)
        {

            if (item !=null)
            {
                if (inv.Count(x=>x.item ==item) == 0) 
                {
                    Inv inve = new Inv();
                    inve.Number = 1;
                    inve.item = item;
                    inv.Add(inve);
                    //inv = new Items[1];
                    
                }
                else
                {
                    var index = inv.FindIndex(x=>x.item == item);
                    var number = inv[index].Number + 1;
                    inv[index].Number = number;
                    //for (int i = 0; i < inv.Count(); i++)
                    //{
                    //    newArray[i] = inv[i];
                    //}

                    //newArray[newLenght - 1] = item;
                    //inv = newArray;
                }

                //return inv;
                
            }
            else
            {
                Console.WriteLine("Der er ingen items i dit inventory");
                //eturn inv;
            }
        }
        public void Remove(Items item)
        {
            if (inv.Count(x=> x.item == item) > 1)
            {
                var index = inv.FindIndex(x => x.item == item);
                var number = inv[index].Number - 1;
                inv[index].Number = number;
            }
            else
            {

                var index = inv.FindIndex(x => x.item == item);
                inv.RemoveAt(index);
            }

            /*if (inv.Length==0)
            {
                Console.WriteLine("Der er ingen ting du kan fjerne i din kurv");
                return inv;
            }
            var NewArray = inv.Where(x => x.Name != item.Name).ToArray();
            inv = NewArray;
            Console.WriteLine("Den ønskede vare er nu fjernet fra din kurv");
            return inv;*/
        }
        //public void checkout(Context context)
        //{
        //    context.GetCurrent().Checkout(inv,User);
        //    check.DoCheckOut(inv,User);
        //}
        //public static void Checkout(Items[] inv, Context context)
        //{

        //}


    //}
}
