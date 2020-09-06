using System;
using System.IO;

namespace TextoveSouboryVobornik
{
    public static class Soubor
    {
        private static readonly Random rnd = new Random();


        public static string PrectiCelySoubor(string soubor)
        {
            string obsah = string.Empty;

            using (StreamReader sr = new StreamReader(soubor))
            {
                obsah = sr.ReadToEnd();
            }

            Console.WriteLine(obsah);
            return obsah;
        }

        public static void PrectiCelySouborPoRadcich(string soubor)
        {
            using StreamReader sr = new StreamReader(soubor);
            int counter = 0;
            while (!sr.EndOfStream)
            {
                Console.WriteLine("{0, 3}: {1}", ++counter, sr.ReadLine());
            }
        }

        public static void PrectiCelySouborPoRadcich2(string soubor)
        {
            int counter = 0;
            string radekSouboru;

            using StreamReader sr = new StreamReader(soubor);
            while ((radekSouboru = sr.ReadLine()) != null)
            {
                Console.WriteLine("{0, 3}: {1}", ++counter, radekSouboru);
            }
        }

        public static void ZapisujDoSouboru(string soubor)
        {
            Console.WriteLine("Zadávej řádky, které chceš zapsat do souboru, zadávání ukonči slovem 'konec'");

            using StreamWriter sw = new StreamWriter(soubor, true);
            string s;
            while ((s = Console.ReadLine()) != "konec")
            {
                sw.WriteLine(s);
            }
        }

        public static void ZapisujCislaDoSouboru(string soubor)
        {
            using StreamWriter sw = new StreamWriter(soubor, false);
            for (int i = 0; i < 20; i++)
            {
                sw.WriteLine(rnd.Next(100));
            }
        }

        public static void VytvorTestovaciSouborCsv(string soubor)
        {
            File.WriteAllLines(soubor, new string[]
            {
                "Jan;Novák;25",
                "Karel;Vomáčka;50",
                "Alois;Levý;35",
                "Eva;Modrá;28"
            });
        }
    }
}
