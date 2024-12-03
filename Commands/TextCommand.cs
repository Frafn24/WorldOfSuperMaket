using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfSuperMaket.Commands
{
    public class TextCommand
    {
        Translate translate = new Translate();
        public void InfoText()
        {
            //Console.WriteLine(translate.GetTranslation("Welcome6"));
            //Console.WriteLine(translate.GetTranslation("Welcome7"));
            //Console.WriteLine(translate.GetTranslation("Welcome8"));
            Console.WriteLine("Du kan skrive 'go' + 'lokation' for at bevæge dig igennem supermarkedet");
            Console.WriteLine("Skriv 'Actions' for at tilføje eller fjerne en vare samt også for at se din kurv");
            Console.WriteLine("Skriv 'help' for at se alle kommandoer");

        }
        public void ActionsText()
        {
            //Console.WriteLine(translate.GetTranslation("Actions1"));
            //Console.WriteLine(translate.GetTranslation("Actions2"));
            //Console.WriteLine(translate.GetTranslation("Actions3"));
            //Console.WriteLine(translate.GetTranslation("Actions4"));
            Console.WriteLine("Disse Action du kan vælge imellem her er");
            Console.WriteLine(" Tilføj vare - Tilføj");
            Console.WriteLine(" Fjern vare - Fjern");
            Console.WriteLine(" Se kurv - Kurv");
        }

    }
}
