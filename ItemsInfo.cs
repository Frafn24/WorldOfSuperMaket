using System.Data;
using System.Threading.Channels;

namespace WorldOfSuperMaket;

class ItemsInfo : BaseCommand, ICommand
{
    private Items[] Itm;
    public ItemsInfo(Items[] items)
    {
        description = "Information omkring varer.";
        Itm = items;
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        
    }

    public void Show()
    {
        //Console.WriteLine($"{Itm[0].Getname()}");
    }
}