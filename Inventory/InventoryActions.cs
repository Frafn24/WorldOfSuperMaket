using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Readers;

namespace WorldOfSuperMaket.Inventory;

public class InventoryActions
{

    public List<Inv> Add(List<Inv> inv, List<Items> stock, string room)
    {
        try
        {

            stock = sortStock(room, stock);
            Items itm = new Items("Tilbage", "Tilbage", "", 0, 0, 0, 0, 0, 2);
            stock.Add(itm);
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(Translate.Instance.GetTranslation("Arrow_Keys_Add"));

                // Vis listen med vare i din kurv
                for (int i = 0; i < stock.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                        Console.WriteLine($">{stock[i].Name}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($">{stock[i].Name}");
                    }
                }

                // Håndter brugerinput
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? stock.Count() - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == stock.Count() - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (stock[selectedIndex].Name == "Tilbage")
                        {
                            return inv;
                        }
                       
                        Console.WriteLine(Translate.Instance.GetTranslation("Added_To_Cart"), stock[selectedIndex].Name);
                        if (inv.Count(x => x.item.Name == stock[selectedIndex].Name) > 0)
                        {
                            int index = inv.FindIndex(x => x.item == stock[selectedIndex]);
                            var inve = inv[index];
                            inve.Number++;
                            inv[index] = inve;
                        }
                        else
                        {
                            inv.Add(new Inv { Number = 1, item = stock[selectedIndex] });
                        }
                      

                        selectedIndex = Math.Min(selectedIndex, stock.Count() - 1); // Juster index
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine(Translate.Instance.GetTranslation("Returning"));
                        return inv;
                }
            }
        }
        catch (Exception)
        {
            return inv;
            throw;
        }
    }

    public List<Items> sortStock(string room, List<Items> stock)
    {
        var res = stock.Where(x => x.Type == room).ToList();
        return res;
    }

    public List<Inv> Remove(List<Inv> inv, Items item)
    {
        try
        {
            if (inv.Count() == 0)
            {
                Console.WriteLine(Translate.Instance.GetTranslation("Inv_No_Choice"));
            }
            else
            {
                var newinv = inv;
                int selectedIndex = 0;
                bool back = true;
                bool exMark = false;
                var afslut = new Items("afslut", "", "", 0, 0, 0, 0, 0, 0);
                newinv.Add(new Inv { Number = 1, item = afslut });
                while (back)
                {
                    Console.Clear();
                    Console.WriteLine(Translate.Instance.GetTranslation("Arrow_Keys_Remove"));

                    // Vis listen med vare i din kurv
                    for (int i = 0; i < inv.Count(); i++)
                    {
                        if (i == selectedIndex)
                        {
                            if (inv[i].item.Name != "afslut")
                            {
                                Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                                Console.WriteLine($"> {inv[i].Number}.stk : {inv[i].item.Name}");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                                Console.WriteLine($"> {inv[i].item.Name}");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            if (inv[i].item.Name != "afslut")
                            {
                                
                                Console.WriteLine($"> {inv[i].Number}.stk : {inv[i].item.Name}");
                               
                            }
                            else
                            {
                                 // Markér valget
                                Console.WriteLine($"> {inv[i].item.Name}");
                                
                            }
                        }

                    }


                    // Håndter brugerinput
                    var key = Console.ReadKey(intercept: true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = (selectedIndex == 0) ? inv.Count() - 1 : selectedIndex - 1;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex = (selectedIndex == inv.Count() - 1) ? 0 : selectedIndex + 1;
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            if (inv[selectedIndex].item.Name != "afslut")
                            {
                                if (inv[selectedIndex].Number > 1)
                                {
                                    Console.WriteLine(Translate.Instance.GetTranslation("Fjerner"),inv[selectedIndex].Number - 1);
                                    inv[selectedIndex].Number--;
                                }
                                else
                                {
                                    Console.WriteLine(Translate.Instance.GetTranslation("Fjerner"),inv[selectedIndex]);
                                    inv.RemoveAt(selectedIndex);
                                }
                            }
                            else
                            {
                                var res = newinv.Where(x => x.item.Name != "afslut").ToList();
                                return res;
                            }

                            // Håndter tom liste
                            if (inv.Count() == 0)
                            {
                                Console.WriteLine(Translate.Instance.GetTranslation("Cart_Empty"));

                            }

                            selectedIndex = Math.Min(selectedIndex, inv.Count() - 1); // Juster index
                            break;
                    }
                }
            }
            return inv;
        }
        catch (Exception)
        {
            return inv;
            throw;
        }

    }
    public void Show(List<Inv> inv, UserInfo user)
    {
        Console.Clear();
        if (inv.Count() > 0)
        {
            Console.WriteLine(Translate.Instance.GetTranslation("Calorie_Goal"), user.DaliyCalo, Math.Round(inv.Sum(x => x.item.Calorie ), 0));
            Console.WriteLine(Translate.Instance.GetTranslation("Carbs_Goal"),user.DaliyKullhydrat,inv.Sum(x => x.item.Carbo ));
            Console.WriteLine(Translate.Instance.GetTranslation("Fat_Goal"),user.DaliyFat,inv.Sum(x => x.item.Fat ));
            Console.WriteLine($"Protein: {inv.Sum(x => x.item.Protien / 100)} / {user.DaliyProtien} g");
            Console.WriteLine($"C02: {inv.Sum(x => x.item.C02 / 100)} Kg");
            Console.WriteLine(Translate.Instance.GetTranslation("Items_In_Cart"));
            foreach (var itm in inv)
            {
                Console.WriteLine($"Mængde:{itm.Number} ,Vare: {itm.item.Name} ");

            }
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine(Translate.Instance.GetTranslation("If_No_Items"));
        }
    }
    public void CheckOut (List<Inv> inv, UserInfo userInfo)
    {
        double CaloriesInCart = Convert.ToInt32(Math.Round(inv.Sum(x => x.item.Calorie), 0));                       
        bool EnoughCalories = CaloriesInCart >= userInfo.DaliyCalo;
        double Calodif = userInfo.DaliyCalo - CaloriesInCart;
        var checkOut = new CheckOut();
        checkOut.DoCheckOut(inv, userInfo);

       /* if (EnoughCalories)
        {

            
        }
        else
        {
            Console.WriteLine();
           // Console.WriteLine($"du mangler at tilføje flere kalorier til din kurv, før du kan gå til kurv du mangler {Math.Round(Calodif,2)} kalorier");
            Console.WriteLine(Translate.Instance.GetTranslation("Missing_Items_In_Cart"),Math.Round(Calodif,2));
            Console.ReadLine();
        }*/
    }
}