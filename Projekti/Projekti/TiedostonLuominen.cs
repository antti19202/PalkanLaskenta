using System;
using System.IO;

namespace Projekti
{
    class TiedostonLuominen
    {
        public void LuoUusiTiedosto()
        {
            // Kansion muuttuja
            string kansio = "c:\\temp\\palkanlaskenta\\";
            // Tiedoston muuttuja
            string filename = $"{kansio}työntekijät.csv";

            try
            {
                // Tarkastaa onko kansiota olemassa
                if (!Directory.Exists(kansio))
                {
                    // Luo kansion
                    Directory.CreateDirectory(kansio);
                }

                // Tarkastaa onko tekstitiedostoa olemassa
                if (!File.Exists(filename))
                {
                    // Luo tekstitiedoston
                    using (StreamWriter sw = File.CreateText(filename))
                    {

                    }
                    // Ilmoittaa luodusta tekstitiedostosta
                    Console.WriteLine($"Csv tiedosto luotu palkanlaskentaa varten paikkaan {filename}");
                    Console.WriteLine("\nPaina ENTER jatkaaksesi...");
                    Console.ReadLine();
                }
            }

            catch (Exception ex)
            {
                // Konsoliin tulee virheilmoitus
                Console.WriteLine($"\nError: {ex.Message}");
                // Enteriä painamalla pääsee takaisin päävalikkoon
                Console.WriteLine("\nPaina ENTER jatkaaksesi...");
                Console.ReadLine();
            }
        }
    }
}
