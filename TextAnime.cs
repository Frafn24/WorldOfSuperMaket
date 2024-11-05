using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfSuperMaket
{
    public class TextAnime
    {
        public void printAllText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
                Thread.Sleep(50);

            }
        }
        public void printText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(50);

            }
        }
    }
}
