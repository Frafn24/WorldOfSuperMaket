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
        public string gameOver = $"C:\\Users\\frede\\source\\repos\\WorldOfSuperMaket\\Sounds\\GOM.mp3"; // Replace with your audio file path
        public void GameOver()
        {

            try
            {
                if (OperatingSystem.IsWindows())
                {
                    using (var audioFile = new AudioFileReader(gameOver))
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
                    Process.Start("afplay", $"\"{gameOver}\"");
                }
                else if (OperatingSystem.IsLinux())
                {
                    Process.Start("aplay", $"\"{gameOver}\"");
                }
                else
                {
                    Console.WriteLine("Unsupported operating system.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
        public void LOL()
        {
            if (OperatingSystem.IsWindows())
            {
                using (var audioFile = new AudioFileReader(@"C:\\Users\\frede\\source\\repos\\WorldOfSuperMaket\\Sounds\\LOL.mp3"))
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
        }
    }
}
