using WorldOfSuperMaket.Models;

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
                Console.WriteLine("Brug piletasterne til at vælge, hvad du vil Tilføje en vare fra kurven, og tryk Enter:");

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
                        Console.WriteLine($"{stock[selectedIndex].Name} er tilføjet til din kurv");

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
                        //if (inv[selectedIndex].Number > 1)
                        //{
                        //    Console.WriteLine($"Fjerner: {inv[selectedIndex].Number - 1}");
                        //    inv[selectedIndex].Number--;
                        //}
                        //else
                        //{
                        //    Console.WriteLine($"Fjerner: {inv[selectedIndex]}");
                        //    inv.RemoveAt(selectedIndex);
                        //}
                        ////Console.WriteLine($"Fjerner: {inv[selectedIndex]}");

                        //// Håndter tom liste
                        //if (inv.Count() == 0)
                        //{
                        //    Console.WriteLine("Listen er nu tom.");
                        //    return;
                        //}

                        selectedIndex = Math.Min(selectedIndex, stock.Count() - 1); // Juster index
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Du vender nu tilbage");
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
                Console.WriteLine("Der er ikke noget i dit Kurv eller du har ikke valgt noget item:(");
                return inv;
            }
            else
            {
                int selectedIndex = 0;
                var newinv = inv;
                Items itm = new Items("Tilbage", "Tilbage", "", 0, 0, 0, 0, 0, 2);
                newinv.Add(new Inv { Number = 0, item = itm });
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Brug piletasterne til at vælge, hvad du vil fjerne vare fra kurven, og tryk Enter:");

                    if (newinv.Count() == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Der er ikke noget i dit Kurv eller du har ikke valgt noget item:(");
                        Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                        Console.WriteLine($">Tilbage");
                        Console.ResetColor();
                        Console.ReadLine();
                        return inv;
                    }
                    // Vis listen med vare i din kurv
                    for (int i = 0; i < newinv.Count; i++)
                        {
                            if (i == selectedIndex)
                            {
                                if (newinv[i].item.Name == "Tilbage")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                                    Console.WriteLine($">{newinv[i].item.Name}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                                    Console.WriteLine($"> {newinv[i].Number}.stk : {newinv[i].item.Name}");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                if (newinv[i].item.Name == "Tilbage")
                                {
                                    Console.WriteLine($">{newinv[i].item.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"> {newinv[i].Number}.stk : {newinv[i].item.Name}");
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
                                if (newinv[selectedIndex].Number > 1)
                                {
                                    Console.WriteLine($"Fjerner: {newinv[selectedIndex].Number - 1}");
                                    newinv[selectedIndex].Number--;
                                }
                                else
                                {

                                    Console.WriteLine($"Fjerner: {inv[selectedIndex]}");
                                    inv.RemoveAt(selectedIndex);
                                }
                                //Console.WriteLine($"Fjerner: {inv[selectedIndex]}");

                                // Håndter tom liste
                                if (newinv.Count() == 0)
                                {
                                    Console.WriteLine("Din Kurv er nu tom.");
                                    Console.ReadLine();
                                    var res = newinv.Where(x=>x.item.Name=="Tilbage").ToList();
                                    return res;
                                }

                                selectedIndex = Math.Min(selectedIndex, newinv.Count() - 1); // Juster index
                                break;
                            case ConsoleKey.Escape:
                                Console.WriteLine("\nAfslutter programmet...");
                                return newinv;
                        }
                    
                }
                return inv;
            }
                   
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
            int selectedIndex = 0;
            Console.WriteLine($"Daglige mål er Kalorier: {user.DaliyCalo}/{Math.Round(inv.Sum(x => x.item.Calorie), 0)}");
            Console.WriteLine($"Kullhydrat:{user.DaliyKullhydrat}/{inv.Sum(x => x.item.Carbo)}");
            Console.WriteLine($"Fedt:{user.DaliyFat}/{inv.Sum(x => x.item.Fat)}");
            Console.WriteLine($"Protien:{user.DaliyProtien}/{inv.Sum(x => x.item.Protien)}");
            Console.WriteLine($"C02:{inv.Sum(x => x.item.C02)}");
            Console.WriteLine("Varer er i din Kurv.");
            foreach (var itm in inv)
            {
                Console.WriteLine($"Mængde:{itm.Number} ,Vare: {itm.item.Name} ");

            }
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Der er ingen items i dit inventory");
        }
    }
}