using System;

namespace Projekti
{
    class TietojenKysyminenJaTallentaminen
    {
        public string TietojenKysyminen()
        {
            // Käyttää "Tyontekijoiden_Tiedot" classia
            Tyontekijoiden_tiedot tyontekijoiden_Tiedot = new Tyontekijoiden_tiedot();

            // Tyhjennetään konsolin
            Console.Clear();

            // Konsolissa otsikko
            Console.WriteLine("Uuden työntekijän lisääminen \n");

            // Pyydetään sukunimeä ja tallennetaan se muuttujaan
            try
            {
               while (!tyontekijoiden_Tiedot.OnkoSukunimiValidi())
                {
                    Console.Write("Sukunimi: ");
                    tyontekijoiden_Tiedot.Sukunimi = Console.ReadLine();
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

            // Pyydetään etunimeä ja tallennetaan se muuttujaan
            try
            {
                while (!tyontekijoiden_Tiedot.OnkoEtunimiValidi())
                {
                    Console.Write("Etunimet: ");
                    tyontekijoiden_Tiedot.Etunimet = Console.ReadLine();
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


            // Pyydetään osoitetta ja tallennetaan se muuttujaan
            Console.Write("Osoite: ");
            tyontekijoiden_Tiedot.Osoite = Console.ReadLine();

            // Pyydetään postinumeroa ja tallennetaan se muuttujaan
            Console.Write("Postinumero: "); 
            while (tyontekijoiden_Tiedot.Postinumero == null)
            {
                try
                {
                    tyontekijoiden_Tiedot.Postinumero = Console.ReadLine();
                }
                catch(Exception e)
                {
                    // Konsoliin tulee virheilmoitus
                    Console.WriteLine($"Syötä postinumero oikeassa muodossa.", e);
                    // Enteriä painamalla pääsee takaisin päävalikkoon
                    Console.Write("Postinumero: ");
                }
            }

            // Pyydetään postitoimipaikkaa ja tallennetaan se muuttujaan
            Console.Write("Postitoimipaikka: ");
            tyontekijoiden_Tiedot.Postitoimipaikka = Console.ReadLine();

            // Pyydetään henkilötunnusta ja tallennetaan se muuttujaan
            Console.Write("Henkilötunnus: ");
            tyontekijoiden_Tiedot.Henkilotunnus = Console.ReadLine();
            Console.Write("Tilinumero: ");
            tyontekijoiden_Tiedot.Tilinumero = Console.ReadLine();

            // Pyytää työntekijän puhelinnumeroa ja tallentaa sen muuttujaan
            Console.Write("Puhelinnumero: ");
            tyontekijoiden_Tiedot.Puhelinnumero = Console.ReadLine();

            // Pyytää työntekijän sähköpostia ja tallentaa sen muuttujaan
            Console.Write("Sähköposti: ");
            tyontekijoiden_Tiedot.Sahkoposti = Console.ReadLine();

            // Pyytää työsuhteen alkamispäivää ja tallentaa sen muuttujaan
            Console.Write("Työsuhteen alkamispäivä: ");
            tyontekijoiden_Tiedot.TyosuhteenAlkupaiva = Console.ReadLine();

            // Pyydetään tuntipallkkaa ja tallennetaan se muuttujaan
            Console.Write("Tuntipalkka: ");
            while (tyontekijoiden_Tiedot.Tuntipalkka == 0)
            {
            try
            {
                tyontekijoiden_Tiedot.Tuntipalkka = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                // Konsoliin tulee virheilmoitus
                Console.WriteLine($"\nError: {ex.Message}");
                // Enteriä painamalla pääsee takaisin päävalikkoon
                Console.Write("\nTuntipalkka:");
            }
            }

            // Pyydetään veroprosenttia ja tallennetaan se muuttujaan
            Console.Write("Veroprosentti: ");
            tyontekijoiden_Tiedot.Veroprosentti = Convert.ToDouble(Console.ReadLine());

            // Pyydetään tuloorajaa ja tallennetaan se muuttujaan
            Console.Write("Tuloraja: ");
            tyontekijoiden_Tiedot.Tuloraja = Convert.ToInt32(Console.ReadLine());

            // Pyydetään lisäveroprosenttia ja tallennetaan se muuttujaan
            Console.Write("Lisäveroprosentti: ");
            tyontekijoiden_Tiedot.Lisaverorosentti = Convert.ToDouble(Console.ReadLine());

            // Työntekijöiden tiedot muutetaan tallennettavaan muotoon
            string csvRivi = $"{tyontekijoiden_Tiedot.Sukunimi};{tyontekijoiden_Tiedot.Etunimet};{tyontekijoiden_Tiedot.Osoite};{tyontekijoiden_Tiedot.Postinumero};{tyontekijoiden_Tiedot.Postitoimipaikka};{tyontekijoiden_Tiedot.Henkilotunnus};{tyontekijoiden_Tiedot.Tilinumero};{tyontekijoiden_Tiedot.Puhelinnumero};{tyontekijoiden_Tiedot.Sahkoposti};{tyontekijoiden_Tiedot.TyosuhteenAlkupaiva};{tyontekijoiden_Tiedot.Tuntipalkka};{tyontekijoiden_Tiedot.Veroprosentti};{tyontekijoiden_Tiedot.Tuloraja};{tyontekijoiden_Tiedot.Lisaverorosentti}";
            // Palautetaan tiedot tallennus muodossa
            return csvRivi;
        }

        public void TietojenTallentaminen(string csvRivi)
        {
            // Tietojen tallennuspaikka muuttujassa
            string filename = "c:\\temp\\palkanlaskenta\\työntekijät.csv";

            // Tiedot tallennetaan valittuun tiedostoon edellisen henkilön alapuolelle
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true))
            {
                file.WriteLine(csvRivi);
            }
        }
    }
}
