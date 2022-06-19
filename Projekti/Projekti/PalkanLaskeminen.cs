using System;
using System.Collections.Generic;

namespace Projekti
{
    class PalkanLaskeminen
    {
        public void LaskeUusiPalkka()
        {
            try
            {
                // Tyhjennetään konsoli
                Console.Clear();

                // Kirjoitetaan konsoliin
                Console.WriteLine("Kenen palkan haluat laskea... \n");

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
                    tyontekijoiden_Tiedot.Postinumero = (pilkottuTyontekija[3]);
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
                    // Palataan päävalikkoon
                    return;
                }

                // Käyttäjän valinnasta vähennetään yksi ohjelman oikein toimimisen takia ja haetaan listasta valittu henkilö
                Tyontekijoiden_tiedot valittuTyontekija = lista[valittuHenkilo - 1];

                Console.Clear();

                // Varmistus että valittiin oikea henkilö palkanlaskua varten
                Console.WriteLine($"Oletko varma että haluat laskea palkan henkilölle {valittuTyontekija.Sukunimi}, {valittuTyontekija.Etunimet}? \n\n0. Peruuta \nPaina ENTER jatkaaksesi palkanlaskentaan...");
                string varmenne = Console.ReadLine();

                if (varmenne == "0")
                {
                    return;
                }

                // Tyhjennetään konsoli
                Console.Clear();

                // Kirjoitetaan konsoliin tekstiä
                Console.WriteLine("Anna aikaväli jolta haluat palkkaa laskea... \n");

                // Kirjoitetaan konsoliin tekstiä
                Console.Write("Laskemisen aloituspäivä: ");
                // Tallennetaan käyttäjän syöte muuttujaan DateTime muodossa
                DateTime aloituspaiva = DateTime.Parse(Console.ReadLine());

                // Kirjoitetaan konsoliin tekstiä
                Console.Write("Laskemisen viimeinen päivä: ");
                DateTime viimeinenPaiva = DateTime.Parse(Console.ReadLine());

                // Kysytään kuinka monta työpäivää kyseisellä ajanjaksolla
                Console.WriteLine($"\nKuinka monta työpäivää ajanjaksolla {aloituspaiva:dd.MM.yyyy} - {viimeinenPaiva:dd.MM.yyyy}?");
                // Tallennetaan käyttäjän syöte muuttujaan
                int paivienMaara = int.Parse(Console.ReadLine());
                // käyttäjän syötteeseen lisätään yksi ohjelman oikein toimivuuden vuoksi
                paivienMaara++;

                // Viiva joka helpottaa koodin lukamista
                // =========================================================================================================================

                // Tyhjennetään konsoli
                Console.Clear();
                // Kirjoitetaan konsoliin tekstiä
                Console.WriteLine("Anna pyydetyt tiedot...");

                // Array johon työtunnit tallennetaan
                double kaikkiTyotunnit = 0;
                // Muuttuja johon iltalisä tallennetaan
                double kaikkiIltalisa = 0;
                // Muuttuja johon yölisä tallennetaan
                double kaikkiYolisa = 0;
                // Muuttuja johon päivärahojen määrä tallennetaan
                int puolipaivaraha = 0;

                // For luupilla kysytään työpäivän tietoja niin monta kertaa kuin työpäiviä on
                for (int i = 1; i < paivienMaara; i++)
                {
                    // Kirjoitetaan konsoliin tekstiä
                    Console.Write($"\nAnna {i}. työpäivän päivämäärä: ");
                    // Tallennetaan tieto muuttujaan
                    string tyonAloitusPaiva = Console.ReadLine();

                    // Kirjoitetaan konsoliin tekstiä
                    Console.Write($"Anna työpäivän aloitus aika: ");
                    // Tallennetaan tieto muuttujaan
                    string aloitusaika = Console.ReadLine();

                    // Kirjoitetaan konsoliin tekstiä
                    Console.Write($"Anna työpäivän lopetus aika: ");
                    // Tallennetaan tieto muuttujaan
                    string lopetusaika = Console.ReadLine();

                    // Muutetaan annetutu tiedot muotoon joilla pystytään laskemaan
                    DateTime tyonLopetusAika = DateTime.Parse($"{tyonAloitusPaiva} {lopetusaika}");
                    // Muutetaan annetutu tiedot muotoon joilla pystytään laskemaan
                    DateTime tyonAloitusAika = DateTime.Parse($"{tyonAloitusPaiva} {aloitusaika}");

                    // Iltalisän määrittely
                    // Iltalisää tulee klo 18.00 -22.00 välisenä aikana
                    DateTime iltaLisanAlku = DateTime.Parse($"{tyonAloitusPaiva} 18.00");
                    DateTime iltaLisanLoppu = DateTime.Parse($"{tyonAloitusPaiva} 22.00");

                    // Ensimmäisen yölisän määrittely
                    // Yölisää tulee klo 22.00 - 6.00 välisenä aikana
                    DateTime yoLisanAlku1 = DateTime.Parse($"{tyonAloitusPaiva} 22.00");
                    DateTime yoLisanLopetusAika = DateTime.Parse($"{tyonAloitusPaiva} 06.00");
                    DateTime yoLisanLoppu1 = yoLisanLopetusAika.AddDays(1);

                    // Toisen yölisän määrittely jos työ alkaa klo 00.00 - 6.00
                    DateTime yoLisanAlku2 = DateTime.Parse($"{tyonAloitusPaiva} 00.00");
                    DateTime yoLisanLoppu2 = DateTime.Parse($"{tyonAloitusPaiva} 06.00");

                    // Tarkastetaan loppuuko työpäivä seuraavan päivän puolella
                    if (tyonAloitusAika > tyonLopetusAika)
                    {
                        // Työn lopetusaikaan lisätään yksi päivä ohjelman oiken toimivuuden vuoksi
                        DateTime tyonLopetusPaiva = tyonLopetusAika.AddDays(1);
                        // Lasektaan annetuista työajoista tehdyt työtunnit
                        TimeSpan tyotuntienMaara = tyonLopetusPaiva.Subtract(tyonAloitusAika);
                        // Työtunnit muutetaan desimaali muotoon laskemisen helpottamiseksi
                        double tyotuntienMaaraDesimaaliski = Convert.ToDouble(tyotuntienMaara.TotalHours);

                        // Konsoliin kirjoitetaan laskettu työaika
                        Console.WriteLine($"Työaika: {tyotuntienMaaraDesimaaliski:F2}h");

                        // SUNNUNTAILISÄ JA PALKAN LISÄÄMINEN
                        // ============================================================================================

                        // Jos työpäivä alkaa sunnuntain puolella niin sunnuntain puolella tehdyt työtunnit maksetaan tuplana
                        if (tyonAloitusAika.DayOfWeek == DayOfWeek.Sunday)
                        {
                            // Määritellään sunnuntai
                            DateTime alustettuSunnuntai = DateTime.Parse($"{tyonAloitusPaiva} 00.00");
                            DateTime sunnuntai = alustettuSunnuntai.AddDays(1);
                            // Lasketaan sunnuntain puolella olevat tunnit
                            TimeSpan sunnuntainPuolella = sunnuntai.Subtract(tyonAloitusAika);
                            // Muutetaan tunnit desimaalimuotoon
                            double sunnuntainPuolellaDesimaaliksi = Convert.ToDouble(sunnuntainPuolella.TotalHours);
                            // Annetaan sunnuntain tunnit tuplana
                            double sunnuntainTunnitTuplana = sunnuntainPuolellaDesimaaliksi * 2;
                            // Lisätään työtunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += sunnuntainTunnitTuplana;
                            // Kirjoittaa konsoliin kuinka monta tuntia tehty sunnuntain puolella
                            Console.WriteLine($"Työtä tehty sunnuntain puolella {sunnuntainPuolellaDesimaaliksi:F2} tuntia");
                            // Kirjoittaa konsoliin että työpäivä oli sunnuntai ja siitä maksetaan tupla palkka
                            Console.WriteLine($"Tunnit lasketaan tuplana = {sunnuntainTunnitTuplana:F2}");
                            // Lasketaan maanantain puolelle menevät tunnit
                            double loputTunnit = tyotuntienMaaraDesimaaliski - sunnuntainPuolellaDesimaaliksi;
                            // Lisätään loput tunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += loputTunnit;
                        }

                        // Jos työpäivä alkaa lauvantain puolella ja loppuu sunnuntain puolella niin sunnuntai puolelle menneet tunnit maksetaan tuplana
                        else if (tyonLopetusPaiva.DayOfWeek == DayOfWeek.Sunday)
                        {
                            // Määritellään sunnuntai
                            DateTime AlustettuSunnuntai = DateTime.Parse($"{tyonAloitusPaiva} 00.00");
                            DateTime sunnuntai = AlustettuSunnuntai.AddDays(1);
                            // Lasketaan sunnuntain puolella tehdyt tunnit
                            TimeSpan sunnuntainPuolella = tyonLopetusPaiva.Subtract(sunnuntai);
                            // Muutetaan tunnit desimaalimuotoon
                            double sunnuntainPuolellaDesimaaliksi = Convert.ToDouble(sunnuntainPuolella.TotalHours);
                            // Annetaan sunnuntain tunnit tuplana
                            double sunnuntainTunnitTuplana = sunnuntainPuolellaDesimaaliksi * 2;
                            // Lisätään työtunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += sunnuntainTunnitTuplana;
                            // Kirjoittaa konsoliin kuinka monta tuntia tehty sunnuntain puolella
                            Console.WriteLine($"Työtä tehty sunnuntain puolella {sunnuntainPuolellaDesimaaliksi:F2} tuntia");
                            // Kirjoittaa konsoliin että työpäivä oli sunnuntai ja siitä maksetaan tupla palkka
                            Console.WriteLine($"Tunnit lasketaan tuplana = {sunnuntainTunnitTuplana:F2}");
                            // Lasketaan maanantain puolelle menevät tunnit
                            double loputTunnit = tyotuntienMaaraDesimaaliski - sunnuntainPuolellaDesimaaliksi;
                            // Lisätään loput tunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += loputTunnit;
                        }

                        // Jos työpäivä ei ole sunnuntai
                        else
                        {
                            // Lisätään työtunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += tyotuntienMaaraDesimaaliski;
                        }

                        // PÄIVÄRAHA
                        // ==============================================================================

                        // Jos työpäivä on yli 10h annetaan työntekijälle siltä päivältä päiväraha
                        if (tyotuntienMaaraDesimaaliski >= 10)
                        {
                            puolipaivaraha++;
                            // Konsoliin kirjoitetaan päivärahojen määrä
                            Console.WriteLine($"Päivältä maksetaan puolipäiväraha");
                        }
                        else
                        {
                            Console.WriteLine("Päivältä EI makseta puolipäivärahaa");
                        }

                        // ILTALISÄ
                        // =================================================================================

                        // Iltalisän laskeminen jos työ alkaa iltalisän alettua ja päättyy iltalisän loppumisen jälkeen
                        if (tyonAloitusAika < iltaLisanLoppu && tyonAloitusAika > iltaLisanAlku && tyonLopetusPaiva > iltaLisanLoppu)
                        {
                            // Lasketaan iltalisätuntien määrä
                            TimeSpan iltalisanErotus = iltaLisanLoppu.Subtract(tyonAloitusAika);
                            // Muutetaan iltalisätunnit desimaalimuotoon
                            double iltalisanMaaraDesimaaliksi = Convert.ToDouble(iltalisanErotus.TotalHours);

                            // Lisätään iltalisätunnit kaikkiin iltalisätunteihin
                            kaikkiIltalisa += iltalisanMaaraDesimaaliksi;
                            // Kirjoitetaan konsoliin tämän työpäivän iltalisätuntein määrä
                            Console.WriteLine($"Iltalisää maksetaan {iltalisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Ilstalisän laskeminen jos työ alkaa ennen iltalisän alkamista loppuu iltalisän loppumisen jälkeen
                        else if (tyonLopetusPaiva >= iltaLisanLoppu && tyonAloitusAika <= iltaLisanAlku)
                        {
                            // Iltalisätunnit ovet automaattisesti 4
                            double taysiIltalisa = 4.0;
                            // Lisää kaikkiin iltalisätunteihin 4 tuntia
                            kaikkiIltalisa += taysiIltalisa;

                            // Kirjoittaa konsoliin viestin jossa lukee kaikki iltalisätunnit yhteensä
                            Console.WriteLine($"Iltalisää maksetaan {taysiIltalisa:F2} tunnilta");
                        }

                        // Iltalisän laskeminen jos työ alkaa ennen iltalisän alkamista ja päättyy iltalisän aikana
                        else if (tyonAloitusAika < iltaLisanAlku && tyonLopetusPaiva < iltaLisanLoppu)
                        {
                            // Lasketaan iltalisätuntien määrä
                            TimeSpan iltalisanErotus = tyonLopetusPaiva.Subtract(iltaLisanAlku);
                            // Muutetaan iltalisätunnit desimaalimuotoon
                            double iltalisanMaaraDesimaaliksi = Convert.ToDouble(iltalisanErotus.TotalHours);

                            // Lisää kaikkiin iltalisätunteihin saatu määrä
                            kaikkiIltalisa += iltalisanMaaraDesimaaliksi;
                            // Kirjoittaa konsoliin viestin jossa lukee kaikki iltalisätunnit yhteensä
                            Console.WriteLine($"Iltalisää maksetaan {iltalisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Jos iltalisää ei ole
                        else
                        {
                            Console.WriteLine("Päivältä EI makseta iltalisää");
                        }

                        // YÖLISÄ
                        // ============================================================================================

                        // Yölisän laskeminen jos työ alkaa yölisän alettua ja päättyy yölisän loppumisen jälkeen
                        if (tyonAloitusAika < yoLisanLoppu1 && tyonAloitusAika > yoLisanAlku1 && tyonLopetusPaiva > yoLisanLoppu1)
                        {
                            // Lasketaan yolisätuntien määrä
                            TimeSpan yolisanErotus = yoLisanLoppu1.Subtract(tyonAloitusAika);
                            // Muutetaan yölisätunnit desimaalimuotoon
                            double yolisanMaaraDesimaaliksi = Convert.ToDouble(yolisanErotus.TotalHours);

                            // Lisätään yölisätunnit kaikkiin yölisätunteihin
                            kaikkiYolisa += yolisanMaaraDesimaaliksi;
                            // Kirjoitetaan konsoliin tämän työpäivän yölisätuntein määrä
                            Console.WriteLine($"Yölisää maksetaan {yolisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Yölisän laskeminen jos työskennellään vain yölisätuntien aikana
                        else if (tyonAloitusAika < yoLisanLoppu1 && tyonLopetusPaiva <= yoLisanLoppu1 && tyonAloitusAika >= yoLisanAlku1)
                        {
                            // Yölisätuntien määrä on sama kuin työaika
                            double yolisa = tyotuntienMaaraDesimaaliski;
                            // Lisätään Yölisätunnit kaikkiin yölisätunteihin
                            kaikkiYolisa += yolisa;
                            // Kirjoitetaan konsoliin tämän työpäivän yölisätuntein määrä
                            Console.WriteLine($"Yölisää maksetaan {yolisa:F2} tunnilta");
                        }

                        // Yölisä laskeminen jos työ alkaa ennen yölisän alkamista
                        else if (tyonLopetusPaiva >= yoLisanAlku1 && tyonAloitusAika < yoLisanAlku1)
                        {
                            // Jos työaika ylittää koko yölisän niin yölisä on automaattisesti 8 tuntia
                            if (tyonLopetusPaiva > yoLisanLoppu1)
                            {
                                // Yölisätunnit ovet automaattisesti 8
                                double taysiYolisa = 8.0;
                                // Lisää kaikkiin yölisätunteihin 8 tuntia
                                kaikkiYolisa += taysiYolisa;

                                // Kirjoittaa konsoliin viestin jossa lukee kaikki yölisätunnit
                                Console.WriteLine($"Yölisää maksetaan {taysiYolisa:F2} tunnilta");
                            }

                            // Muuten ohjelma laskee iltalisän tunneista
                            else
                            {
                                // Lasketaan yölisätuntien määrä
                                TimeSpan yolisanErotus = tyonLopetusPaiva.Subtract(yoLisanAlku1);
                                // Muutetaan yölisätunnit desimaalimuotoon
                                double yolisanMaaraDesimaaliksi = Convert.ToDouble(yolisanErotus.TotalHours);

                                // Lisää kaikkiin yölisätunteihin saatu määrä
                                kaikkiYolisa += yolisanMaaraDesimaaliksi;
                                // Kirjoittaa konsoliin viestin jossa lukee kaikki yölisätunnit yhteensä
                                Console.WriteLine($"Yölisää maksetaan {yolisanMaaraDesimaaliksi:F2} tunnilta");
                            }
                        }

                        // Jos yölisää ei ole
                        else
                        {
                            Console.WriteLine("Päivältä EI makseta yölisää");
                        }

                        // KIRJOITETAAN TIETOJA KONSOLIIN
                        // ============================================================================================

                        // Kirjoittaa moneltako päivältä maksetaan päivärahaa
                        Console.WriteLine($"\nPuolipäivärahaa maksetaan {puolipaivaraha} päivältä yhteensä");

                        // Kirjoittaa konsoliin iltalisätuntien kokonaismäärän
                        Console.WriteLine($"Iltalisää maksetaan yhteensä {kaikkiIltalisa:F2} tunnilta");

                        // Kirjoittaa konsoliin yölisätuntien kokonaismäärän
                        Console.WriteLine($"Yölisää maksetaan yhteensä {kaikkiYolisa:F2} tunnilta");

                        // Kirjoittaa kaikki työtunnit yhtennsä tähän mennessä
                        Console.WriteLine($"Työtunteja yhteensä {kaikkiTyotunnit:F2}h");
                    }

                    // JOS TYÖPÄIVÄ LOPPUU SAMANA PÄIVÄNÄ
                    // ==============================================================================================================================

                    // Jos työpäivä loppuu samana päivänä
                    else
                    {
                        // Muutetaan työaika laskettavaan muotoon ja lasketaan työaika
                        TimeSpan tyotuntienMaara = tyonLopetusAika.Subtract(tyonAloitusAika);
                        // Työtunnit muutetaan desimaali muotoon laskemisen helpottamiseksi
                        double tyotuntienMaaraDesimaaliski = Convert.ToDouble(tyotuntienMaara.TotalHours);

                        // Konsoliin kirjoitetaan laskettu työaika
                        Console.WriteLine($"Työaika: {tyotuntienMaaraDesimaaliski:F2}h");


                        // SUNNUNTAILISÄ JA PALKAN LISÄÄMINEN
                        // ============================================================================================

                        // Jos työpäivä on sunnuntei niin työtunnit ovat tuplana
                        if (tyonAloitusAika.DayOfWeek == DayOfWeek.Sunday)
                        {
                            double sunnuntaiLisa = tyotuntienMaaraDesimaaliski * 2;
                            // Lisätään työtunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += sunnuntaiLisa;
                            // Kirjoittaa konsoliin kuinka monta tuntia tehty sunnuntain puolella
                            Console.WriteLine($"Työtä tehty sunnuntain puolella {tyotuntienMaaraDesimaaliski:F2} tuntia");
                            // Kirjoittaa konsoliin että työpäivä oli sunnuntai ja siitä maksetaan tupla palkka
                            Console.WriteLine($"Tunnit lasketaan tuplana = {sunnuntaiLisa:F2}");
                        }

                        // Jos työpäivä ei ole sunnuntai
                        else
                        {
                            // Lisätään työtunnit "kaikkiTyotunnit" muuttujaan
                            kaikkiTyotunnit += tyotuntienMaaraDesimaaliski;
                        }

                        // PÄIVÄRAHA
                        // ==============================================================================

                        // Jos työpäivä on yli 10h annetaan työntekijälle siltä päivältä päiväraha
                        if (tyotuntienMaaraDesimaaliski >= 10)
                        {
                            puolipaivaraha++;
                            // Konsoliin kirjoitetaan päivärahojen määrä
                            Console.WriteLine($"Päivältä maksetaan puolipäiväraha");
                        }
                        else
                        {
                            Console.WriteLine("Päivältä EI makseta puolipäivärahaa");
                        }

                        // ILTALISÄ
                        // =================================================================================

                        // Iltalisän laskeminen jos työ alkaa iltalisän alettua ja päättyy iltalisän loppumisen jälkeen
                        if (tyonAloitusAika < iltaLisanLoppu && tyonAloitusAika > iltaLisanAlku && tyonLopetusAika > iltaLisanLoppu)
                        {
                            // Lasketaan iltalisätuntien määrä
                            TimeSpan iltalisanErotus = iltaLisanLoppu.Subtract(tyonAloitusAika);
                            // Muutetaan iltalisätunnit desimaalimuotoon
                            double iltalisanMaaraDesimaaliksi = Convert.ToDouble(iltalisanErotus.TotalHours);

                            // Lisätään iltalisätunnit kaikkiin iltalisätunteihin
                            kaikkiIltalisa += iltalisanMaaraDesimaaliksi;
                            // Kirjoitetaan konsoliin tämän työpäivän iltalisätuntein määrä
                            Console.WriteLine($"Iltalisää maksetaan {iltalisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Iltalisän laskeminen jos työskennellään vain iltalisätuntien aikana
                        else if (tyonLopetusAika < iltaLisanLoppu && tyonAloitusAika > iltaLisanAlku)
                        {
                            // Iltalisätuntien määrä on sama kuin työaika
                            double iltalisa = tyotuntienMaaraDesimaaliski;
                            // Lisätään iltalisätunnit kaikkiin iltalisätunteihin
                            kaikkiIltalisa += iltalisa;
                            // Kirjoitetaan konsoliin tämän työpäivän iltalisätuntein määrä
                            Console.WriteLine($"Iltalisää maksetaan {iltalisa:F2} tunnilta");
                        }

                        // Ilstalisän laskeminen jos työ alkaa ennen iltalisän alkamista loppuu iltalisän loppumisen jälkeen
                        else if (tyonLopetusAika >= iltaLisanLoppu && tyonAloitusAika <= iltaLisanAlku)
                        {
                            // Iltalisätunnit ovet automaattisesti 4
                            double taysiIltalisa = 4.0;
                            // Lisää kaikkiin iltalisätunteihin 4 tuntia
                            kaikkiIltalisa += taysiIltalisa;

                            // Kirjoittaa konsoliin viestin jossa lukee kaikki iltalisätunnit yhteensä
                            Console.WriteLine($"Iltalisää maksetaan {taysiIltalisa:F2} tunnilta");
                        }

                        // Iltalisän laskeminen jos työ on alkanut ennen iltalisän aikana ja päättyy sen aikana
                        else if (tyonAloitusAika < iltaLisanAlku && tyonLopetusAika < iltaLisanLoppu && tyonLopetusAika > iltaLisanAlku)
                        {
                            // Lasketaan iltalisätuntien määrä
                            TimeSpan iltalisanErotus = tyonLopetusAika.Subtract(iltaLisanAlku);
                            // Muutetaan iltalisätunnit desimaalimuotoon
                            double iltalisanMaaraDesimaaliksi = Convert.ToDouble(iltalisanErotus.TotalHours);

                            // Lisää kaikkiin iltalisätunteihin saatu määrä
                            kaikkiIltalisa += iltalisanMaaraDesimaaliksi;
                            // Kirjoittaa konsoliin viestin jossa lukee kaikki iltalisätunnit yhteensä
                            Console.WriteLine($"Iltalisää maksetaan {iltalisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Jos iltalisää ei ole
                        else
                        {
                            Console.WriteLine("Päivältä EI makseta iltalisää");
                        }


                        // YÖLISÄ
                        // ============================================================================================

                        // Yölisän laskeminen jos työ alka klo 00.00 - 06.00 välisenä aikana
                        if (tyonAloitusAika < yoLisanLoppu2 && tyonAloitusAika >= yoLisanAlku2 && tyonLopetusAika > yoLisanLoppu2)
                        {
                            // Lasketaan yolisätuntien määrä
                            TimeSpan yolisanErotus = yoLisanLoppu2.Subtract(tyonAloitusAika);
                            // Muutetaan yölisätunnit desimaalimuotoon
                            double yolisanMaaraDesimaaliksi = Convert.ToDouble(yolisanErotus.TotalHours);

                            // Lisätään yölisätunnit kaikkiin yölisätunteihin
                            kaikkiYolisa += yolisanMaaraDesimaaliksi;
                            // Kirjoitetaan konsoliin tämän työpäivän yölisätuntein määrä
                            Console.WriteLine($"Yölisää maksetaan {yolisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Jos työskennellään vain "yölisä2" välisenä aikana
                        else if (tyonAloitusAika >= yoLisanAlku2 && tyonLopetusAika <= yoLisanLoppu2)
                        {
                            // Yölisätuntien määrä on sama kuin työaika
                            double yolisa = tyotuntienMaaraDesimaaliski;
                            // Lisätään Yölisätunnit kaikkiin yölisätunteihin
                            kaikkiYolisa += yolisa;
                            // Kirjoitetaan konsoliin tämän työpäivän yölisätuntein määrä
                            Console.WriteLine($"Yölisää maksetaan {yolisa:F2} tunnilta");
                        }

                        // Yölisän laskeminen jos työ alkaa yölisän alettua ja päättyy yölisän loppumisen jälkeen
                        else if (tyonAloitusAika < yoLisanLoppu1 && tyonAloitusAika > yoLisanAlku1 && tyonLopetusAika > yoLisanLoppu1)
                        {
                            // Lasketaan yolisätuntien määrä
                            TimeSpan yolisanErotus = yoLisanLoppu1.Subtract(tyonAloitusAika);
                            // Muutetaan yölisätunnit desimaalimuotoon
                            double yolisanMaaraDesimaaliksi = Convert.ToDouble(yolisanErotus.TotalHours);

                            // Lisätään yölisätunnit kaikkiin yölisätunteihin
                            kaikkiYolisa += yolisanMaaraDesimaaliksi;
                            // Kirjoitetaan konsoliin tämän työpäivän yölisätuntein määrä
                            Console.WriteLine($"Yolisää maksetaan {yolisanMaaraDesimaaliksi:F2} tunnilta");
                        }

                        // Yölisän laskeminen jos työskennellään vain yölisätuntien aikana
                        else if (tyonAloitusAika < yoLisanLoppu1 && tyonLopetusAika <= yoLisanLoppu1 && tyonAloitusAika >= yoLisanAlku1)
                        {
                            // Yölisätuntien määrä on sama kuin työaika
                            double yolisa = tyotuntienMaaraDesimaaliski;
                            // Lisätään Yölisätunnit kaikkiin yölisätunteihin
                            kaikkiYolisa += yolisa;
                            // Kirjoitetaan konsoliin tämän työpäivän yölisätuntein määrä
                            Console.WriteLine($"Yölisää maksetaan {yolisa:F2} tunnilta");
                        }

                        // Yölisä laskeminen jos työ alkaa ennen yölisän alkamista
                        else if (tyonLopetusAika >= yoLisanAlku1 && tyonAloitusAika < yoLisanAlku1)
                        {
                            // Jos työaika ylittää koko yölisän niin yölisä on automaattisesti 8 tuntia
                            if (tyonLopetusAika > yoLisanLoppu1)
                            {
                                // Yölisätunnit ovet automaattisesti 8
                                double taysiYolisa = 8.0;
                                // Lisää kaikkiin yölisätunteihin 8 tuntia
                                kaikkiYolisa += taysiYolisa;

                                // Kirjoittaa konsoliin viestin jossa lukee kaikki yölisätunnit
                                Console.WriteLine($"Yölisää maksetaan {taysiYolisa:F2} tunnilta");
                            }

                            // Muuten ohjelma laskee iltalisän tunneista
                            else
                            {
                                // Lasketaan yölisätuntien määrä
                                TimeSpan yolisanErotus = tyonLopetusAika.Subtract(yoLisanAlku1);
                                // Muutetaan yölisätunnit desimaalimuotoon
                                double yolisanMaaraDesimaaliksi = Convert.ToDouble(yolisanErotus.TotalHours);

                                // Lisää kaikkiin yölisätunteihin saatu määrä
                                kaikkiYolisa += yolisanMaaraDesimaaliksi;
                                // Kirjoittaa konsoliin viestin jossa lukee kaikki yölisätunnit yhteensä
                                Console.WriteLine($"Yölisää maksetaan {yolisanMaaraDesimaaliksi:F2} tunnilta");
                            }
                        }

                        // Jos yölisää ei ole
                        else
                        {
                            Console.WriteLine("Päivältä EI makseta yölisää");
                        }


                        // KIRJOITETAAN TIETOJA KONSOLIIN
                        // ============================================================================================

                        // Kirjoittaa moneltako päivältä maksetaan päivärahaa
                        Console.WriteLine($"\nPuolipäivärahaa maksetaan {puolipaivaraha} päivältä yhteensä");

                        // Kirjoittaa konsoliin iltalisätuntien kokonaismäärän
                        Console.WriteLine($"Iltalisää maksetaan yhteensä {kaikkiIltalisa:F2} tunnilta");

                        // Kirjoittaa konsoliin yölisätuntien kokonaismäärän
                        Console.WriteLine($"Yölisää maksetaan yhteensä {kaikkiYolisa:F2} tunnilta");

                        // Kirjoittaa kaikki työtunnit yhtennsä tähän mennessä
                        Console.WriteLine($"Työtunteja yhteensä {kaikkiTyotunnit:F2}h");
                    }
                }

                // Viimeisen palkan annettua täytyy painaa enter jotta ohjelma laskee palkan ja näyttää palkkalaskelman
                Console.WriteLine("\nPaina ENTER jatkaaksesi...");
                Console.ReadLine();

                // KOKONAISPALKAN LASKEMINEN
                // ========================================================================================================

                // Lasketaan tuntiansio = työtunnit * tuntipalkka ja tallennetaan muuttujaan
                double tuntiansio = kaikkiTyotunnit * valittuTyontekija.Tuntipalkka;

                // Luodaan muuttujat 50% ylityökorvauksen määrästä
                // 50% YLITYÖLISÄÄ MAKSETAAN 80 - 92 TUNNIN AJALTA.
                double ylityoansio50tunnit = 0;
                double ylityoansio50palkka = 0;

                // Lasketaan 50% ylityöansion määrä jos sellaista on
                if (kaikkiTyotunnit > 80)
                {
                    // Jos työtunteja on yli 92, 50% työtunnit on 12
                    if (kaikkiTyotunnit > 92)
                    {
                        ylityoansio50tunnit = 12;
                    }
                    // Jos työtunteja on alle 92, lasketaan 50% tuntien määrä
                    else
                    {
                        ylityoansio50tunnit = kaikkiTyotunnit - 80;
                    }

                    // Lasketaan 50% ylityön hinta/palkka
                    ylityoansio50palkka = ylityoansio50tunnit * (valittuTyontekija.Tuntipalkka * 0.5);
                }

                // Luodaan muuttujat 100% ylityökorvauksen määrästä
                // 100% YLITYÖLISÄÄ MAKSETAAN JOS TYÖTUNTEJA ON YLI 92
                double ylityoansio100tunnit = 0;
                double ylityoansio100palkka = 0;

                // Lasketaan 100% ylityöansion määrä jos sellaista on
                if (kaikkiTyotunnit > 92)
                {
                    ylityoansio100tunnit = kaikkiTyotunnit - 92;


                    // Lasketaan 100% ylityön hinta/palkka
                    ylityoansio100palkka = ylityoansio100tunnit * valittuTyontekija.Tuntipalkka;
                }

                // Luodaan muuttuja iltalisäpalkalle
                // ILTALISÄ ON 15% TUNTIPALKASTA
                double iltalisanPalkka = kaikkiIltalisa * (valittuTyontekija.Tuntipalkka * 0.15);

                // Luodaan muuttuja yölisäpalkalle
                // YÖLISÄ ON 20% TUNTIPALKASTA
                double yolisanPalkka = kaikkiYolisa * (valittuTyontekija.Tuntipalkka * 0.2);

                // Luodaan bruttopalkka muuttuja johon tallennetaan palkka ja kaikki lisät yhteensä
                double bruttoPalkka = tuntiansio + ylityoansio50palkka + ylityoansio100palkka + iltalisanPalkka + yolisanPalkka;

                // Lasketaan ennnakonpidätys bruttopalkasta
                double ennakonpidätys = bruttoPalkka * (valittuTyontekija.Veroprosentti / 100);

                // Lasketaan työeläkemaksu bruttopalkasta
                // Työeläkemaksu on 7,15%
                double tyoelakemaksu = bruttoPalkka * 0.0715;

                // Työttömyysvakuusmaksun laskeminen bruttopalkasta
                // Työttömyysvakuusmaksu on 1,25%
                double tyottomuusvakuusmaksu = bruttoPalkka * 0.0125;

                // Määritellään nettopalkka muuttujaan
                double nettopalkka = bruttoPalkka - ennakonpidätys - tyoelakemaksu - tyottomuusvakuusmaksu;

                // Osapäivärahan maksaminen
                // Puolipäivärahan hinta on 15,80€... ei mene veroa
                double osapaivaraha = puolipaivaraha * 15.80;

                // MAKSETTAVA PALKKA
                double maksetaan = nettopalkka + osapaivaraha;

                // TULOSTATAAN JONKAINLAINEN PALKKALASKELMA
                // ====================================================================================================================

                // Tyhjennetään konsoli
                Console.Clear();

                // Tulostataan konsoliin alustava palkkalaskelma
                Console.WriteLine($"Tyontekijä: {valittuTyontekija.Sukunimi}, {valittuTyontekija.Etunimet}\n");
                Console.WriteLine("SELITE\t\t\t\tMÄÄRÄ\tHINTA\tSUMMA(EUR)");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Tuntiansio\t\t\t{kaikkiTyotunnit:F2}\t{valittuTyontekija.Tuntipalkka:F2}\t{tuntiansio:F2}");
                Console.WriteLine($"Ylityöansio 50% korotus\t\t{ylityoansio50tunnit:F2}\t{valittuTyontekija.Tuntipalkka * 0.5:F2}\t{ylityoansio50palkka:F2}");
                Console.WriteLine($"Ylityöansio 100% korotus\t{ylityoansio100tunnit:F2}\t{valittuTyontekija.Tuntipalkka:F2}\t{ylityoansio100palkka:F2}");
                Console.WriteLine($"Iltalisä\t\t\t{kaikkiIltalisa:F2}\t{valittuTyontekija.Tuntipalkka * 0.15:F2}\t{iltalisanPalkka:F2}");
                Console.WriteLine($"Yölisä\t\t\t\t{kaikkiYolisa:F2}\t{valittuTyontekija.Tuntipalkka * 0.2:F2}\t{yolisanPalkka:F2}");
                Console.WriteLine($"Bruttopalkka\t\t\t\t\t{bruttoPalkka:F2}");
                Console.WriteLine($"Ennakonpidätys\t\t\t{valittuTyontekija.Veroprosentti / 100:F4}\t{bruttoPalkka:F2}\t{ennakonpidätys:F2}");
                Console.WriteLine($"Työeläkemaksu\t\t\t0,0715\t{bruttoPalkka:F2}\t{tyoelakemaksu:F2}");
                Console.WriteLine($"Työttömyysvakuutusmaksu\t\t0.0125\t{bruttoPalkka:F2}\t{tyottomuusvakuusmaksu:F2}");
                Console.WriteLine($"Nettopalkka\t\t\t\t\t{nettopalkka:F2}");
                Console.WriteLine($"Osapäiväraha\t\t\t{puolipaivaraha}\t15,80\t{osapaivaraha:F2}");
                Console.WriteLine($"\nMaksetaan\t\t\t\t\t{Math.Round(maksetaan, 2)}");

                Console.WriteLine("\n\nPaina ENTER poistuaksesi...");
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
