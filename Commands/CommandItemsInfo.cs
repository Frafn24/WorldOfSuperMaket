using System.Data;
using System.Threading.Channels;
using WorldOfSuperMaket.Models;

namespace WorldOfSuperMaket;

class CommandItemsInfo : BaseCommand, ICommand
{
    private Items[] Itm;
    public CommandItemsInfo(Items[] items)
    {
        description = "Information omkring varer.";
        Itm = items;
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        
    }
}