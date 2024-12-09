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
using WorldOfSuperMaket.Readers;

namespace WorldOfSuperMaket.Commands
{
    public class CommandActions : BaseCommand, ICommand
    {
        CommandInv check = new CommandInv();
        List<Items> Stock = new List<Items>();

        InventoryActions InvActions = new InventoryActions();
        
        List<Inv> inv = new List<Inv>();
        CsvItems reader = new CsvItems();
        UserInfo User { get; set; }
        string description;
        Items Test;
        TextCommand TextC = new TextCommand();

        // Bruger bare en TestItem


        public CommandActions(UserInfo userInfo)
        {
            description = "Her kan du lave alle dine actions i rummet";
            User = userInfo;
        }

        void ICommand.Execute(Context context, string command, string[] parameters)
        {

            context.GetCurrent().GetName();
            var room = context.GetCurrent().GetName();
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
                    inv = InvActions.Add(inv, Stock, room);
                    break;
                case "tilføj":
                    inv = InvActions.Add(inv, Stock, room);
                    break;
                case "Fjern":
                    inv = InvActions.Remove(inv, Stock[0]);
                    break;
                case "fjern":
                    inv = InvActions.Remove(inv, Stock[0]);
                    break;
                case "Kurv":
                    InvActions.Show(inv, User);
                    break;
                case "kurv":
                    InvActions.Show(inv, User);
                    break;
                
                case "Kassen":
                    InvActions.CheckOut(inv, User);
                    break;
                case "kassen":
                    InvActions.CheckOut(inv, User);
                    break;

                //Engelske oversættelser
                case "Add":
                    inv = InvActions.Add(inv, Stock, room);
                    break;

                case "add":
                    inv = InvActions.Add(inv, Stock, room);
                    break;

                case "Remove":
                    inv = InvActions.Remove(inv, Stock[0]);
                    break;
                    
                case "remove":
                    inv = InvActions.Remove(inv, Stock[0]);
                    break;
                    
                case "Inventory":
                    InvActions.Show(inv, User);
                    break;
                
                case "Checkout":
                    InvActions.CheckOut(inv, User);
                    break;
                case "checkout":
                    InvActions.CheckOut(inv, User);
                    break;

            }
        }

        public void addStock()
        {
            Stock.AddRange(reader.csvTest());
            
            description = "alle de ting, som du kan gøre i dette rum ";



        }

        public void AddItems(string room)
        {
            if (Stock.Count == 0)
            {
                addStock();
            }

            List<Items> roomsItem = new List<Items>();
            Console.WriteLine(Translate.Instance.GetTranslation("Add_item"));
            string anwser = ">";
            bool right = false;
            while (right == false)
            {
                Console.WriteLine(Translate.Instance.GetTranslation("If_Add_WrongInput"));
                Console.Write(">");
                var line = Console.ReadLine();
                if (line == "Yes")
                {
                    //Inv(Stock.First());
                    Console.WriteLine(Translate.Instance.GetTranslation("If_Add_Yes"));
                    right = true;
                }
                else if (line == "No")
                {
                    Console.WriteLine(Translate.Instance.GetTranslation("If_Add_No"));
                    right = true;
                }
                else
                {
                    Console.WriteLine(Translate.Instance.GetTranslation("If_Add_WrongInput"));
                }
            }

            Items[] items = new Items[1];
           
        }
    }

    
}

        
        



