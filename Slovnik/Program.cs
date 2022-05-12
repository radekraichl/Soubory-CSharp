using System;
using System.Linq;

namespace Slovnik;

internal class Program
{
    private static readonly int pocetOtazek = 5;

    public static void Main()
    {
        Hra hra = new();
        Slovnik slovnik = new();

        Console.WriteLine("Vítej v testu anglických slovíček");
        Console.WriteLine("=================================");

        if (hra.Rekord != null)
        {
            Console.WriteLine("Nejvyšší rekord drží {0}: {1} bodů", hra.Rekord.Value.jmeno, hra.Rekord.Value.score);
        }

        Console.Write("Nový test spustíš libovolnou klávesou...");
        Console.ReadKey(true);
        Console.WriteLine('\n');

        for (int i = 0; i < pocetOtazek; i++)
        {
            (string enSlovo, string[] czSlova) = slovnik.NahodneSlovo;
            Console.WriteLine("Co znamená {0}?", enSlovo);

            string odpoved = Console.ReadLine().Trim();

            if (czSlova.Contains(odpoved.ToLower()))
            {
                Console.WriteLine("Výborně! Pojďme dál.");
                hra.Score++;
            }
            else
            {
                Console.WriteLine($"Správný překlad je {string.Join(',', czSlova)}. ");

                if (i < pocetOtazek - 1)
                {
                    Console.WriteLine("Nevadí, zkusme to ještě jednou.");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("KONEC HRY");
        Console.WriteLine($"Počet bodů: {hra.Score}");

        int rekordScore = hra.Rekord == null ? 0 : int.Parse(hra.Rekord.Value.score);

        if (hra.Score > rekordScore)
        {
            Console.Write("Nový rekord! Napiš své jméno: ");

            string jmeno = Console.ReadLine().Trim();

            hra.UlozRekord(jmeno, hra.Score);
        }
    }
}
