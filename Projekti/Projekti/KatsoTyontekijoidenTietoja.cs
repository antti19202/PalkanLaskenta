using System;
using System.Collections.Generic;
using ConsoleTables;

namespace Projekti
{
    class KatsoTyontekijoidenTietoja
    {
        public void KatsoTietoja()
        {

            try
            {
                // Tyhjennetään konsoli
                Console.Clear();

                // Kirjoitetaan konsoliin
                Console.WriteLine("Kenen tietoja haluat katsoa... \n");

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
                    tyontekijoiden_Tiedot.Osoite = pilkottuTyontekija[2];
                    tyontekijoiden_Tiedot.Postinumero = pilkottuTyontekija[3];
                    tyontekijoiden_Tiedot.Postitoimipaikka = pilkottuTyontekija[4];
                    tyontekijoiden_Tiedot.Henkilotunnus = pilkottuTyontekija[5];
                    tyontekijoiden_Tiedot.Tilinumero = pilkottuTyontekija[6];
                    tyontekijoiden_Tiedot.Puhelinnumero = pilkottuTyontekija[7];
                    tyontekijoiden_Tiedot.Sahkoposti = pilkottuTyontekija[8];
                    tyontekijoiden_Tiedot.TyosuhteenAlkupaiva = pilkottuTyontekija[9];
                    tyontekijoiden_Tiedot.Tuntipalkka = Double.Parse(pilkottuTyontekija[10]);
                    tyontekijoiden_Tiedot.Veroprosentti = Double.Parse(pilkottuTyontekija[11]);
                    tyontekijoiden_Tiedot.Tuloraja = Int32.Parse(pilkottuTyontekija[12]);
                    tyontekijoiden_Tiedot.Lisaverorosentti = Double.Parse(pilkottuTyontekija[13]);

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
                // Luodaan ConsoleTable olio, ja tulostetaan työntekijän tiedot hyödyntäen ConsoleTable taulukkoa
                var taulukko = new ConsoleTable("Pekka-Kenkä Kuljetus Oy","Työntekijän tiedot");
                taulukko.AddRow("Sukunimi:", valittuTyontekija.Sukunimi);
                taulukko.AddRow("Etunimet:", valittuTyontekija.Etunimet);
                taulukko.AddRow("Osoite:", valittuTyontekija.Osoite);
                taulukko.AddRow("Postinumero:", valittuTyontekija.Postinumero);
                taulukko.AddRow("Postitoimipaikka:", valittuTyontekija.Postitoimipaikka);
                taulukko.AddRow("Henkilötunnus:", valittuTyontekija.Henkilotunnus);
                taulukko.AddRow("Tilinumero:", valittuTyontekija.Tilinumero);
                taulukko.AddRow("Puhelinnumero:", valittuTyontekija.Puhelinnumero);
                taulukko.AddRow("Sähköposti:", valittuTyontekija.Sahkoposti);
                taulukko.AddRow("Työsuhteen alkupäivä:", valittuTyontekija.TyosuhteenAlkupaiva);
                taulukko.AddRow("Tuntipalkka:", valittuTyontekija.Tuntipalkka);
                taulukko.AddRow("Veroprosentti:", valittuTyontekija.Veroprosentti);
                taulukko.AddRow("Tuloraja:", valittuTyontekija.Tuloraja);
                taulukko.AddRow("Lisäveroprosentti:", valittuTyontekija.Lisaverorosentti);
                taulukko.Write(Format.Alternative);
                
                // Ohjelma ilmoittaa ohjelman jatkammisesta
                Console.WriteLine("\nPaina ENTER jatkaaksesi...");
                Console.ReadLine();
                
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
