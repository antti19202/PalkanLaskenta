using System;
using System.ComponentModel.Design;

namespace Projekti
{
    class Paavalikko
    {
        // Käyttää "PalkanLaskeminen" classia
        PalkanLaskeminen palkanLaskeminen = new PalkanLaskeminen();
        // Käyttää "LisääUusiTyöntekijä" classia
        LisaaUusiTyontekija lisaaUusiTyontekija = new LisaaUusiTyontekija();
        // Käytetään "KatsoTyontekijoidenTietoja" classia
        KatsoTyontekijoidenTietoja KatsoTyontekijoidenTietoja = new KatsoTyontekijoidenTietoja();
        // Käytetään "MuutaTyontekijanTietoja" classia
        MuutaTyontekijanTietoja muutaTyontekijanTietoja = new MuutaTyontekijanTietoja();
        //Käytetään "PoistaTyontekija" classia
        PoistaTyontekija poistaTyontekija = new PoistaTyontekija();

        public void Aloitusvalikko()
        {

        // Päävalikon käynnistyksen ehto
        bool start = true;

            // Loputon luuppi päävalikosta
            while (start)
            {
                // Tyhjentää konsolin
                Console.Clear();

                // Konsolissa näkyvä valikko

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("***************************************************");
                Console.WriteLine("*            Pekka Kenkä Kuljetus Oy              *");
                Console.WriteLine("***************************************************");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Valitse toiminto \n\n1. Laske uusi palkka \n2. Muuta työntekijöiden tietoja \n3. Katso työntekijöiden tietoja \n4. Lisää uusi työntekijä \n5. Työntekijöiden aiemmat palkat \n6. Työntekijän poistaminen \n0. Lopeta ohjelma");
  
                // Annetaan muuttujaan valittu vaihtoehto
                string valinta = Console.ReadLine();

                // ´Tarkastetaan minkä vaihtoehdon käyttäjä syötti
                switch (valinta)
                {
                    // Käynnistää vaihtoehdon 1.
                    case "1":
                        palkanLaskeminen.LaskeUusiPalkka();
                        break;

                    // Käynnistää vaihtoehdon "MuutaTyontekijanTietoja"
                    case "2":
                        muutaTyontekijanTietoja.MuutaTyontekijoidenTietoja();
                        break;

                    // Käynnistää vaihtoehdon "Katso työntekijöiden tietoja"
                    case "3":
                        KatsoTyontekijoidenTietoja.KatsoTietoja();
                        break;

                    // Käynnistää vaihtoehdon "Lisää uusi työntekijä"
                    case "4":
                        lisaaUusiTyontekija.UusiTyontekija();
                        break;

                    // Käynnistää vaihtoehdon 5.
                    case "5":
                        break;

                    // Käynnistää vaihtoehdon 6.
                    case "6":
                        poistaTyontekija.PoistaTietoja();
                        break;

                    // Sammuttaa ohjelman
                    case "0":
                        start = false;
                        break;

                    // Ilmoittaa käyttäjälle ettei kyseistä toimintaa ole ja alottaa while luupin alusta... eli päävalikon
                    default:
                        Console.WriteLine("\nTällaista vaihtoehtoa ei ole! \n\nPaina ENTER jatkaaksesi...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
