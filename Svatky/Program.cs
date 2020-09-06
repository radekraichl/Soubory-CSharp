using System;
using System.IO;
using System.Linq;

namespace Svatky
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Dnes je {DateTime.Today.ToLongDateString()}");
            Console.WriteLine($"Svátek má {VratSvatek(DateTime.Today.Day, DateTime.Today.Month)}");
            Console.ReadLine();
        }

        static string VratSvatek(int den, int mesic)
        {
            string[] jmena = File.ReadAllLines(@"..\..\..\jmena.txt");

            // odstraní ze začátku pole jmena[] nepotřebné měsíce
            for (int i = 0; i < mesic - 1; i++)
            {
                jmena = jmena.SkipWhile(j => j != string.Empty).Skip(1).ToArray();
            }

            // odstraní z pole jmena[] zbytek měsíců
            jmena = jmena.TakeWhile(x => x != string.Empty).ToArray();

            return jmena.ElementAt(den - 1);
        }
    }
}
