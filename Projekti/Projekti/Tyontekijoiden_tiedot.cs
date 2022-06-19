using System;
using System.Text.RegularExpressions;

namespace Projekti
{
    class Tyontekijoiden_tiedot
    {
        //Luodaan regexit syötettävän tiedon validoimiseen
        private static readonly Regex nimivalidointi = new Regex("[a-zåäö A-ZÅÄÖ-]");
        private static readonly Regex osoitevalidointi = new Regex("[a-zåäö A-ZÅÄÖ][0-9]");

        public string Sukunimi { get; set; }
        public string Etunimet { get; set; }
        public string Osoite { get; set; }
        public string Postinumero { get; set; }
        public string Postitoimipaikka { get; set; }
        public string Henkilotunnus { get; set; }
        public string Tilinumero { get; set; }
        public string Puhelinnumero { get; set; }
        public string Sahkoposti { get; set; }
        public string TyosuhteenAlkupaiva { get; set; }
        public double Tuntipalkka { get; set; }
        public double Veroprosentti { get; set; }
        public int Tuloraja { get; set; }
        public double Lisaverorosentti { get; set; }

        //tarkastetaan onko sukunimi syötetty oikein
        public bool OnkoSukunimiValidi()
        {
            if (Sukunimi == null) return false!;
            if (!nimivalidointi.IsMatch(Sukunimi))
            {
                Console.WriteLine("Syötä vain kirjaimia.");
                return false;
            }
            if (Sukunimi.Length > 20)
            {
                Console.WriteLine("Syötetty sukunimi voi olla korkeintaan 20 merkkiä pitkä");
                return false;
            }
            return true;

        }

        //Tarkastetaan onko etunimet syötetty oikein
        public bool OnkoEtunimiValidi()
        {
            if (Etunimet == null) return false!;
            if (!nimivalidointi.IsMatch(Etunimet))
            {
                Console.WriteLine("Syötä vain kirjaimia.");
                return false;
            }
            if (Etunimet.Length > 30)
            {
                Console.WriteLine("Syötetty etunimi voi olla korkeintaan 20 kirjainta.");
                return false;
            }
            if (Etunimet.Length < 2)
            {
                    Console.WriteLine("Syötetyn etunimen on oltava vähintään 2 kirjainta.");
                    return false;
            }
            return true;

        }
    }
}