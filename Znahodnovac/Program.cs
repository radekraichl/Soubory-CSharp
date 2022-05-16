using System;
using System.IO;
using System.Linq;

namespace Znahodnovac;

class Program
{
    static readonly Random random = new();
    static void Main()
    {
        string[] vstup;
        string vstupniSouborCesta = @"..\..\..\vstup.txt";

        if (File.Exists(vstupniSouborCesta))
        {
            vstup = File.ReadAllLines(vstupniSouborCesta);

            try
            {
                File.WriteAllLines(@"..\..\..\vystup.txt", vstup.OrderBy(x => random.Next()).ToArray());
                Console.WriteLine("OK");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba zápisu do souboru");
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Vstupní soubor neexistuje");
        }
    }
}
