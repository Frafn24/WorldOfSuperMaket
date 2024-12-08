using WorldOfSuperMaket.Models;
using WorldOfSuperMaket.Readers;

namespace WorldOfSuperMaket.Commands;

class CommandInv
{
    
    //Metode, der tilføjer en item til listen inv.
    public List<Inv> AddItems(Items item, List<Inv> inv)
    {
        List<Items> roomsItem = new List<Items>();
        Console.WriteLine(Translate.Instance.GetTranslation("Add_item"));
        string anwser = "";
        bool right = false;
        while (right==false) 
        {
            Console.WriteLine(Translate.Instance.GetTranslation("Add_Choose"));
            Console.Write(">");
            var line = Console.ReadLine();
            if (line == "Ja")
            {
                inv = AddItem(item,inv);
                Console.WriteLine(Translate.Instance.GetTranslation("If_Add_Yes"));
                right = true;
            }
            else if (line =="Nej")
            {
                Console.WriteLine(Translate.Instance.GetTranslation("If_Add_No"));
                right= true;
            }
            else
            {
                Console.WriteLine(Translate.Instance.GetTranslation("If_Add_WrongInput"));
            }
        }
        return inv;
    }
    
    // Metoden AddItem arbejder sammen med ovenstående metode AddItems.
    
    public List<Inv> AddItem(Items item,List<Inv> inv)
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

            return inv;
                
        }
        else
        {
            Console.WriteLine(Translate.Instance.GetTranslation("If_No_Items"));
            return inv;
        }
    }
    
    // Metode, der fjerner en item fra listen inv.
    
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
    
    //Metode, der viser alle items i listen inv.
    
    public void ShowInv(List<Inv> inv)
       {
           if (inv != null)
           {
               Console.WriteLine(Translate.Instance.GetTranslation("Inventory"));
               Console.WriteLine(Translate.Instance.GetTranslation("Show_Inventory"));
               for (int i = 0; i < inv.Count(); i++)
               {
                   Console.WriteLine(Translate.Instance.GetTranslation("Inventory_Print"));
               }
           }
           else
           {
               Console.WriteLine(Translate.Instance.GetTranslation("If_No_Items"));
           }
           
       }
}
  