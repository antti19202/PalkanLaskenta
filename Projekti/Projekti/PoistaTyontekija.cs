using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projekti
{
    class PoistaTyontekija
    {
        public void PoistaTietoja()
        {
            try
            {
                // Tyhjennetään konsoli
                Console.Clear();

                // Kirjoitetaan konsoliin
                Console.WriteLine("Kenen tiedot haluat poistaa... \n");

                // Tallennetaan tekstitiedosto muuttujaan
                string filename = "c:\\temp\\palkanlaskenta\\työntekijät.csv";

                // Kirjoitetaan tekstitiedosto taulukkoon (array)
                string[] tyontekijat = System.IO.File.ReadAllLines(filename);

                // Luodaan uusi lista joka avulla katsotaan työntekijöiden tietoja
                List<Tyontekijoiden_tiedot> lista = new List<Tyontekijoiden_tiedot>();

                // Muuttuja joka näkyy työntekijän nimen edessä kun ne on listattu konsolissa
                int valinta = 0;

                // Haetaan työntekijöiden tiedot
                foreach (string tyontekija in tyontekijat)
                {
                    // Tekstitiedostoon tallennetut tuedot on eroteltu ";" merkillä. Splitillä erottaan ne toisistaan
                    string[] pilkottuTyontekija = tyontekija.Split(';');

                    // Käytetään "Tyontekijoiden_tiedot" classia
                    Tyontekijoiden_tiedot tyontekijoiden_Tiedot = new Tyontekijoiden_tiedot();

                    // Haetaan työntekijöiden tiedot
                    tyontekijoiden_Tiedot.Sukunimi = pilkottuTyontekija[0];
                    tyontekijoiden_Tiedot.Etunimet = pilkottuTyontekija[1];
                    

                    // Kasvattaa valikossa työntekijöiden edessä olevaa valintanumeroa yhdellä joka kierros
                    valinta++;

                    // Konsoli kirjoittaa numeron, henkilön sukunimen ja henkilön etunimen
                    Console.WriteLine($"{valinta}. {pilkottuTyontekija[0]}, {pilkottuTyontekija[1]}");

                    // Työntekijän teidot tallennetaa joka kierros listaan tulevia toimintoja varten
                    lista.Add(tyontekijoiden_Tiedot);
                }

                // Kirjoitetaa että nollalla pääsee takaisin päävalikkoon
                Console.WriteLine("0. Poistu...");

                // Ohjemlan käyttäjän valinta tallennetaan muuttujaan
                int valittuHenkilo = Int32.Parse(Console.ReadLine());

                // Tarkastetaan onko vailittu "Poistu" vaihtoehto
                if (valittuHenkilo == 0)
                {
                    return;
                }

                // Tyhjennetään konsoli
                Console.Clear();

                // Käyttäjän valinnasta vähennetään yksi ohjelman oikein toimimisen takia ja haetaan listasta valittu henkilö
                Tyontekijoiden_tiedot valittuTyontekija = lista[valittuHenkilo - 1];
                // Kysytään mitä tietoa halutaan muuttaa
                Console.WriteLine($"Haluatko  varmasti poistaa {valittuTyontekija.Sukunimi}, {valittuTyontekija.Etunimet}n tiedot... \n");
                //Vahvistetaan poisto tai perutaan se
                Console.WriteLine("1. Kyllä \n2. Ei");
                //Tallennetaan valinta muuttujaan
                string poisto = Console.ReadLine();
                //Jos valittiin kaksi hyppää takaisin päävalikkoon
                if (poisto == "2")
                {
                    return;
                }
                //Jos valittiin yksi poistaa tiedot
                if (poisto == "1")
                {
                    //Lukee tekstitiedoston tiedot
                    string[] arrLine = File.ReadAllLines(filename);
                    //Muuttaa valitun kohdan tyhjäksi tekstitiedostossa
                    arrLine[valittuHenkilo - 1] = "";
                    // Tallentaa tiedot tekstitiedostoon
                    File.WriteAllLines(filename, arrLine);
                    //Tarkastaa tekstitiedoston tyhjän kohdan ja poistaa sen
                    File.WriteAllLines(filename, File.ReadAllLines(filename).Where(l => !string.IsNullOrWhiteSpace(l)));
                }


            }

            // Jos tietojen syötössä tapahtuu virhe, ohjelma hyppää tähän
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


