using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorldOfSuperMaket
{
    internal class SoundsClass
    {
        public void Play()
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            string currentDirectory = Directory.GetCurrentDirectory();
            var str = currentDirectory.Replace("bin", "Sounds");
            var str2 = str.Split("Debug");
            var str3 = str2[0]+ "Aliens-Gameoverman.mp3";
            var str4 = str3.Replace(@"\\",@"\");
            Console.WriteLine(str4);
            player.URL = $@"{4}";
            player.controls.play();
        }
    }
}
