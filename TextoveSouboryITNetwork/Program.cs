using System;
using System.IO;

namespace TextoveSouboryITNetwork
{
    class Program
    {
        static void Main()
        {
            string cesta = string.Empty;

            // vytvoreni slozky
            try
            {
                cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ITnetwork");

                Console.WriteLine(cesta);

                if (!Directory.Exists(cesta))
                {
                    Directory.CreateDirectory(cesta);
                }
            }
            catch
            {
                Console.WriteLine("Nepodařilo se vytvořit složku {0}, zkontrolujte prosím svá oprávnění.", cesta);
            }

            // zapis do souboru
            if (File.Exists(Path.Combine(cesta, "soubor.txt")))
            {
                try
                {
                    ZapisDoSouboru(cesta);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Při zápisu do souboru došlo k následující chybě: {0}", e.Message);
                }
            }
            else
            {
                try
                {
                    VytvorSoubor(cesta);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Při vytvoření souboru došlo k následující chybě: {0}", e.Message);
                }
            }

            // vypis obsahu souboru
            Console.WriteLine("Vypisuji soubor:");

            using StreamReader sr = new StreamReader(Path.Combine(cesta, "soubor.txt"));
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }

            // vypis obsahu souboru pomoci tridy File
            Console.WriteLine("\nVypisuji soubor pomocí statické třídy File:");

            string[] radky = File.ReadAllLines(Path.Combine(cesta, "soubor.txt"));
            foreach (string radka in radky)
            {
                Console.WriteLine(radka);
            }
        }

        private static void VytvorSoubor(string cesta)
        {
            using StreamWriter sw = new StreamWriter(Path.Combine(cesta, "soubor.txt"));
            sw.WriteLine("soubor.txt");
            sw.Flush();
        }

        private static void ZapisDoSouboru(string cesta)
        {
            // druhy parametr true - provede se append (pripsani)
            using StreamWriter sw = new StreamWriter(Path.Combine(cesta, "soubor.txt"), true);
            sw.WriteLine("Zápis do souboru " + DateTime.Now);
            sw.Flush();
        }
    }
}