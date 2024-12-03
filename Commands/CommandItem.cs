using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WorldOfSuperMaket.Models;

namespace WorldOfSuperMaket.Commands
{
    class CommandItem: BaseCommand,ICommand
    {
        Items[] Items { get; set; }
        public CommandItem(Items[] items)
        {
            description = "Information omkring varer i dette rum";
            Items = items;
        }
        public void Execute(Context context, string command, string[] parameters)
        {
            if (GuardEq(parameters, 1))
            {
                Console.WriteLine(Translate.Instance.GetTranslation("Wrong Input"));
                return;
            }

            //Console.WriteLine(Info);
        }



    }
}
