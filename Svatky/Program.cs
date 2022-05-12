using System;
using System.IO;
using System.Linq;

namespace Svatky;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Dnes je {DateTime.Today.ToLongDateString()}");
        Console.WriteLine($"Svátek má {VratSvatek(DateTime.Today.Day, DateTime.Today.Month)}");
        Console.WriteLine($"Zítra má svátek {VratSvatek(DateTime.Today.Day + 1, DateTime.Today.Month)}");
    }

    static string VratSvatek(int den, int mesic)
    {
        string[] jmena = File.ReadAllLines(@"..\..\..\jmena.txt");

        // odstraní ze začátku pole jmena[] nepotřebné měsíce
        for (int i = 0; i < mesic - 1; i++)
        {
            jmena = jmena.SkipWhile(j => j != string.Empty).Skip(1).ToArray();
        }

        // odstraní prázdných řádků z pole jmena[] (kvůli přetečení do dalšího měsíce)
        jmena = jmena.Where(x => x != string.Empty).ToArray();

        return jmena.ElementAt(den - 1);
    }
}
