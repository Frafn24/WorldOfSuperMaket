using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfSuperMaket.Commands
{
    public class TextCommand
    {
        public void InfoText()
        {

            Console.WriteLine(Translate.Instance.GetTranslation("Welcome6"));
            Console.WriteLine(Translate.Instance.GetTranslation("Welcome7"));
            Console.WriteLine(Translate.Instance.GetTranslation("Welcome8"));

        }
        public void ActionsText()
        {
            Console.WriteLine(Translate.Instance.GetTranslation("Actions1"));
            Console.WriteLine(Translate.Instance.GetTranslation("Actions2"));
            Console.WriteLine(Translate.Instance.GetTranslation("Actions3"));
            Console.WriteLine(Translate.Instance.GetTranslation("Actions4"));
            Console.WriteLine(Translate.Instance.GetTranslation("Actions5"));
        }

    }
}
