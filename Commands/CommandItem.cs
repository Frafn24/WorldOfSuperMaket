using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfSuperMaket.Commands
{
    class CommandItem: BaseCommand,ICommand
    {
        Items[] Items { get; set; }
        public CommandItem(Items[] items)
        {
            description = "Information omkring vare i dette rum";
            Items = items;
        }
        public void Execute(Context context, string command, string[] parameters)
        {
            if (GuardEq(parameters, 1))
            {
                Console.WriteLine("I don't seem to know where that is 🤔");
                return;
            }

            //Console.WriteLine(Info);
        }



    }
}
