using System;

namespace Projekti
{
    class LisaaUusiTyontekija
    {
        public void UusiTyontekija()
        {
            // Käyttää "TietojenKysyminenJaTallentaminen" calssia
            TietojenKysyminenJaTallentaminen tietojenKysyminenJaTallentaminen = new TietojenKysyminenJaTallentaminen();

            try
            {
                // Kysyy työntekijän tietoja ja palauttaa ne tallennettavassa muodossa
                string csvRivi = tietojenKysyminenJaTallentaminen.TietojenKysyminen();
                // Tallentaa tallennettavan muodon "työntekijät.csv" tiedostoon
                tietojenKysyminenJaTallentaminen.TietojenTallentaminen(csvRivi);
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