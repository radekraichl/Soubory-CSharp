using System;
using System.IO;

namespace Zaklady;

class Program
{
    static void Main()
    {
        string cesta = string.Empty;

        try
        {
            cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Data");

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
                // Zde umístěte kód pro načtení vašeho souboru
            }
            catch (Exception e)
            {
                Console.WriteLine("Při načítání souboru došlo k následující chybě: {0}", e.Message);
            }
        }
        else
        {
            try
            {
                // Zde umístěte kód pro vytvoření vašeho souboru
            }
            catch (Exception e)
            {
                Console.WriteLine("Při vytváření souboru došlo k následující chybě: {0}", e.Message);
            }
        }
    }
}
