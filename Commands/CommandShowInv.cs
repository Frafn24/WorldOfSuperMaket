namespace WorldOfSuperMaket.Commands;

class CommandInv
{
    
    
    
    
    public List<Inv> Remove(Items item, List<Inv> inv)
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

        return inv;

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
    //public static void Checkout(Items[] inv, Context context)
    //{

    //}
}
  