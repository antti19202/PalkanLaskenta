using System;

namespace Projekti
{
    class Program
    {
        static void Main(string[] args)
        {
            // Käyttää "Päävalikko" classia
            Tunnistautuminen tunnistautuminen = new Tunnistautuminen();

            // Käytetään "TiedostonLuominen" classia
            TiedostonLuominen tiedostonLuominen = new TiedostonLuominen();

            // Tarkastaa onko kansiota ja csv tiedostoa olemassa. Jos ei niin sellainen luodaan
            tiedostonLuominen.LuoUusiTiedosto();

            tunnistautuminen.Kirjautuminen();
        }
    }
}
