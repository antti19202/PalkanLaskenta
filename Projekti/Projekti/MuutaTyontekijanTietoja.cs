using System;
using System.Collections.Generic;
using System.IO;
using ConsoleTables;

namespace Projekti
{
    class MuutaTyontekijanTietoja
    {
        public void MuutaTyontekijoidenTietoja()
        {
            try
            {
                // Tyhjennetään konsoli
                Console.Clear();

                // Kirjoitetaan konsoliin
                Console.WriteLine("Kenen tietoja haluat muuttaa... \n");

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
                if(valittuHenkilo == 0)
                {
                    return;
                }

                // Tyhjennetään konsoli
                Console.Clear();

                // Käyttäjän valinnasta vähennetään yksi ohjelman oikein toimimisen takia ja haetaan listasta valittu henkilö
                Tyontekijoiden_tiedot valittuTyontekija = lista[valittuHenkilo - 1];
                // Kysytään mitä tietoa halutaan muuttaa
                Console.WriteLine("Mitä tietoa haluat muuttaa... \n");
                // Luodaan ConsoleTable olio, ja tulostetaan työntekijän tiedot hyödyntäen ConsoleTable taulukkoa
                var taulukko = new ConsoleTable("Nro.", "Pekka-Kenkä Kuljetus Oy", "Työntekijän tiedot");
                taulukko.AddRow("1", "Sukunimi:", valittuTyontekija.Sukunimi);
                taulukko.AddRow("2", "Etunimet:", valittuTyontekija.Etunimet);
                taulukko.AddRow("3", "Osoite:", valittuTyontekija.Osoite);
                taulukko.AddRow("4", "Postinumero:", valittuTyontekija.Postinumero);
                taulukko.AddRow("5", "Postitoimipaikka:", valittuTyontekija.Postitoimipaikka);
                taulukko.AddRow("6", "Henkilötunnus:", valittuTyontekija.Henkilotunnus);
                taulukko.AddRow("7", "Tilinumero:", valittuTyontekija.Tilinumero);
                taulukko.AddRow("8", "Puhelinnumero:", valittuTyontekija.Puhelinnumero);
                taulukko.AddRow("9", "Sähköposti:", valittuTyontekija.Sahkoposti);
                taulukko.AddRow("10", "Työsuhteen alkupäivä:", valittuTyontekija.TyosuhteenAlkupaiva);
                taulukko.AddRow("11", "Tuntipalkka:", valittuTyontekija.Tuntipalkka);
                taulukko.AddRow("12", "Veroprosentti:", valittuTyontekija.Veroprosentti);
                taulukko.AddRow("13", "Tuloraja:", valittuTyontekija.Tuloraja);
                taulukko.AddRow("14", "Lisäveroprosentti:", valittuTyontekija.Lisaverorosentti);
                taulukko.Write(Format.Alternative);
                // Tallennetaan muuttujaan valittu toiminto... mitä työntekijän tietoa muutetaan
                int valittuKohta = Int32.Parse(Console.ReadLine());

                // Tyhjennetään konsoli
                Console.Clear();

                // Käynnistää valitun toiminnan... mitä tietoa muutetaan
                switch (valittuKohta)
                {
                    case 1:
                        Console.Write("Anna uusi sukunimi: ");
                        valittuTyontekija.Sukunimi = Console.ReadLine();
                        break;

                    case 2:
                        Console.Write("Anna uusi etunimet: ");
                        valittuTyontekija.Etunimet = Console.ReadLine();
                        break;

                    case 3:
                        Console.Write("Anna uusi osoite: ");
                        valittuTyontekija.Osoite = Console.ReadLine();
                        break;

                    case 4:
                        Console.Write("Anna uusi postinumero: ");
                        valittuTyontekija.Postinumero = Console.ReadLine();
                        break;

                    case 5:
                        Console.Write("Anna uusi postitoimipaikka: ");
                        valittuTyontekija.Postitoimipaikka = Console.ReadLine();
                        break;

                    case 6:
                        Console.Write("Anna uusi henkilötunnus: ");
                        valittuTyontekija.Henkilotunnus = Console.ReadLine();
                        break;

                    case 7:
                        Console.Write("Anna uusi tilinumero: ");
                        valittuTyontekija.Tilinumero = Console.ReadLine();
                        break;

                    case 8:
                        Console.Write("Anna uusi puhelinnumero: ");
                        valittuTyontekija.Puhelinnumero = Console.ReadLine();
                        break;

                    case 9:
                        Console.Write("Anna uusi sähköposti: ");
                        valittuTyontekija.Sahkoposti = Console.ReadLine();
                        break;

                    case 10:
                        Console.Write("Anna uusi työsuhteen alkupäivä: ");
                        valittuTyontekija.TyosuhteenAlkupaiva = Console.ReadLine();
                        break;

                    case 11:
                        Console.Write("Anna uusi tuntipalkka: ");
                        valittuTyontekija.Tuntipalkka = double.Parse(Console.ReadLine());
                        break;

                    case 12:
                        Console.Write("Anna uusi veroprosentti: ");
                        valittuTyontekija.Veroprosentti = double.Parse(Console.ReadLine());
                        break;

                    case 13:
                        Console.Write("Anna uusi tuloraja: ");
                        valittuTyontekija.Tuloraja = Int32.Parse(Console.ReadLine());
                        break;

                    case 14:
                        Console.Write("Anna uusi lisäveroprosentti: ");
                        valittuTyontekija.Lisaverorosentti = double.Parse(Console.ReadLine());
                        break;

                    // Ilmoittaa käyttäjälle ettei kyseistä toimintaa ole ja alottaa while luupin alusta... eli päävalikon
                    default:
                        Console.WriteLine("\nTällaista vaihtoehtoa ei ole! \n\nPaina ENTER jatkaaksesi...");
                        Console.ReadLine();
                        break;
                }

                
                // Työntekijöiden tiedot muutetaan tallennettavaan muotoon... pötköön lisätty muutettu tieto ja säilytetään alkuperäiset muuttumattomat
                string csvRivi = $"{valittuTyontekija.Sukunimi};{valittuTyontekija.Etunimet};{valittuTyontekija.Osoite};{valittuTyontekija.Postinumero};{valittuTyontekija.Postitoimipaikka};{valittuTyontekija.Henkilotunnus};{valittuTyontekija.Tilinumero};{valittuTyontekija.Puhelinnumero};{valittuTyontekija.Sahkoposti};{valittuTyontekija.TyosuhteenAlkupaiva};{valittuTyontekija.Tuntipalkka};{valittuTyontekija.Veroprosentti};{valittuTyontekija.Tuloraja};{valittuTyontekija.Lisaverorosentti}";

                // Lukee tekstitiedoston tiedot
                string[] arrLine = File.ReadAllLines(filename);
                // Korvaa valitun työntekijän tiedot uudella tiedolla
                arrLine[valittuHenkilo - 1] = csvRivi;
                // Tallentaa tiedot tekstitiedostoon
                File.WriteAllLines(filename, arrLine);
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
