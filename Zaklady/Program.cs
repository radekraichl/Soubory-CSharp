using System;
using System.IO;

namespace Zaklady
{
    class Program
    {
        static void Main()
        {
            string cesta = "";

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

            if (File.Exists(Path.Combine(cesta, "databaze.dat")))
            {
                try
                {
                    // Zde umístěte kód pro načtení vašeho nastavení ze souboru
                }
                catch (Exception e)
                {
                    Console.WriteLine("Při načítání nastavení došlo k následující chybě: {0}", e.Message);
                }
            }
            else
            {
                try
                {
                    // Zde umístěte kód pro vytvoření vašeho nastavení
                }
                catch (Exception e)
                {
                    Console.WriteLine("Při vytvoření nastavení došlo k následující chybě: {0}", e.Message);
                }
            }
        }
    }
}
