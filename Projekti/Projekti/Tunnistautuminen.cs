using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Projekti
{
    class Tunnistautuminen
    {
        Paavalikko paavalikko = new Paavalikko();
        string username;
        string password;
        int ctr = 0;
        private readonly string Kayttajatunnus = "admin";
        private readonly string Salasana = "password";
        public void Kirjautuminen()
        {
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("***************************************************");
                Console.WriteLine("*            Pekka Kenkä Kuljetus Oy              *");
                Console.WriteLine("***************************************************");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");
                Console.Write("Syötä käyttäjätunnus: ");
                username = Console.ReadLine();

                Console.Write("Syötä salasana: ");
                var pwd = new SecureString();
                while (true)
                {
                    ConsoleKeyInfo i = Console.ReadKey(true);
                    if (i.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (i.Key == ConsoleKey.Backspace)
                    {
                        if (pwd.Length > 0)
                        {
                            pwd.RemoveAt(pwd.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                    {
                        pwd.AppendChar(i.KeyChar);
                        Console.Write("*");
                    }
                }
                password = new System.Net.NetworkCredential(string.Empty, pwd).Password;

                if (username != Kayttajatunnus || password != Salasana)
                    ctr++;
                else
                    ctr = 1;

            }
            while ((username != Kayttajatunnus || password != Salasana) && (ctr != 3));

            if (ctr == 3)
            { 
            Console.Write("\nKirjautuminen epäonnistui kolmesti. Yritä myöhemmin uudelleen!\n\n");
            Console.WriteLine("Voit sulkea ohjelman painamalla 'Enter'");
            Console.ReadLine();
            }

            else
            {
                Console.Write("\nKirjautuminen onnistui! Jatka painamalla 'Enter'\n\n");
                Console.ReadLine();
                paavalikko.Aloitusvalikko();
            }
        }

    }
}
