using System;
using System.Collections.Generic;
using System.Linq;

namespace Slovnik
{
    class Program
    {
        static void Main()
        {
            Slovnik slovnik = new Slovnik();
            Hra hra = new Hra();

            Console.WriteLine("Vítej v testu anglických slovíček");
            Console.WriteLine("=================================");

            if (hra.Rekord != null)
            {
                Console.WriteLine("Nejvyšší rekord drží {0}: {1} bodů", hra.Rekord.Value.jmeno, hra.Rekord.Value.skore);
            }

            Console.Write("Nový test spustíš libovolnou klávesou...");
            Console.ReadKey();
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                (string enSlovo, string[] czSlova) = slovnik.NahodneSlovo;
                Console.WriteLine("Co znamená {0}?", enSlovo);

                string odpoved = Console.ReadLine().Trim();

                if (czSlova.Contains(odpoved.ToLower()))
                {
                    Console.WriteLine("Výborně! Pojďme dál.");
                    hra.Body++;
                }
                else
                {
                    Console.Write($"Správný překlad je {string.Join(',', czSlova)}. ");
                    Console.WriteLine("Nevadí, zkusme to ještě jednou.");
                }
            }
        }
    }
}
