using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace WorldOfSuperMaket.Sounds
{
    public  class Lyd
    {
        //public static string gameOver = $"GOM.mp3"; // Replace with your audio file path
        public  void GameOver()
        {

            try
            {
                var path= getPlaceMent("GOM.mp3");
                if (OperatingSystem.IsWindows())
                {
                    using (var audioFile = new AudioFileReader(path))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100); // Keeps the app alive while playing
                        }
                    }
                    //using (SoundPlayer player = new SoundPlayer(filePath))
                    //{
                    //    player.Load();
                    //    player.PlaySync();
                    //}
                }
                else if (OperatingSystem.IsMacOS())
                {
                    Process.Start("afplay", path);
                }
                else if (OperatingSystem.IsLinux())
                {
                    Process.Start("aplay", path);
                }
                else
                {
                    throw new NotSupportedException("This operating system is not supported.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
        public void LOL()
        {
            try
            {
                
                string path = getPlaceMent("LOL.mp3");
                if (OperatingSystem.IsWindows())
                {
                    using (var audioFile = new AudioFileReader(path))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100); // Keeps the app alive while playing
                        }
                    }
                    //using (SoundPlayer player = new SoundPlayer(filePath))
                    //{
                    //    player.Load();
                    //    player.PlaySync();
                    //}
                }
                else if (OperatingSystem.IsMacOS())
                {
                    Process.Start("afplay", path);
                }
                else if (OperatingSystem.IsLinux())
                {
                    Process.Start("aplay", path);
                }
                else
                {
                    throw new NotSupportedException("This operating system is not supported.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }

        }
        public string getPlaceMent(string filename)
        {
            //string update = "";
            //string placement = Path.GetFullPath(filename);
            ////string xmlFile = HostingEnvironment.MapPath("filename");
            //if (placement.Contains(@"bin\\Debug\\net8.0\"))
            //{
            //    update = placement.Replace(@"bin\\Debug\\net8.0\", "Sounds");
            //}
            //update = placement.Replace(@"bin\\Debug\\net8.0", "Sounds");
            //return update;

            string placement = Path.GetFullPath(filename);
            string basePath = @"bin\Debug\net8.0";
            string replacementPath = "Sounds";

            if (placement.Contains(basePath))
            {
                string update = placement.Replace(basePath, replacementPath);
                return update;
            }
            return placement; // Returnerer uændret, hvis stien ikke matcher

        }
    }
}
