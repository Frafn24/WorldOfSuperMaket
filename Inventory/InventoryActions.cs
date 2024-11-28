using WorldOfSuperMaket.Models;

namespace WorldOfSuperMaket.Inventory;

public class InventoryActions
{
    public List<Inv> Add(List<Inv> inv, List<Items> itm)
    {

        if (inv.Count != 0)
        {
            //if (inv.Count(x => x.item == itm) == 0)
            //{
            //    var newitem = new Inv { Number = 1, item = itm };
            //    inv.Add(newitem);
            //}
            //else
            //{
            //    int index = inv.FindIndex(x => x.item == itm);
            //    var inve = inv.FirstOrDefault(x => x.item == itm);
            //    inve.Number++;
            //    inv[index] = inve;

            //}
            return inv;
        }
        return inv;
    }
    public List<Inv> Remove(List<Inv> inv, Items item)
    {
        try
        {
            if (inv.Count() == 0)
            {
                Console.WriteLine("Der er ikke noget i dit inventory eller du har ikke valgt noget item:(");
            }
            else
            {
                int selectedIndex = 0;
                bool back = true;
                bool exMark = false;
                while (back)
                {
                    Console.Clear();
                    Console.WriteLine("Brug piletasterne til at vælge, hvad du vil fjerne vare fra kurven, og tryk Enter:");

                    // Vis listen med vare i din kurv
                    item.Name = "afslut";
                    inv.Add(new Inv {Number=1,item=item});
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            if (inv[i].item.Name == "afslut")
                            {
                                Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                                Console.WriteLine($"> {inv[i].item}");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green; // Markér valget
                                Console.WriteLine($"> {inv[i].Number}.stk : {inv[i].item}");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            if (inv[i].item.Name== "afslut")
                            {
                                Console.WriteLine($">{inv[i].item}");
                            }
                            else
                            {
                                Console.WriteLine($"> {inv[i].Number}.stk : {inv[i].item}");
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
                                    Console.WriteLine($"Fjerner: {inv[selectedIndex].Number - 1}");
                                    inv[selectedIndex].Number--;
                                }
                                else
                                {
                                    Console.WriteLine($"Fjerner: {inv[selectedIndex]}");
                                    inv.RemoveAt(selectedIndex);
                                }
                            }
                            else
                            {
                                return inv;
                            }
                            //Console.WriteLine($"Fjerner: {inv[selectedIndex]}");

                            // Håndter tom liste
                            if (inv.Count() == 0)
                            {
                                Console.WriteLine("din kurn er nu tom.");
                                
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
    public void Show(List<Inv> inv)
    {
        Console.Clear();
        if (inv.Count() > 0)
        {
            Console.WriteLine("Varer er i din Kurv.");
            foreach (var itm in inv)
            {
                Console.WriteLine($"Mængde:{itm.Number} ,Vare: {itm.item.Name} ");

            }
        }
        else
        {
            Console.WriteLine("Der er ingen items i dit inventory");
        }
    }
}