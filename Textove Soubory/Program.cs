using System;
using System.IO;

namespace TextoveSoubory;

class Program
{
    static readonly string nazevSouboru = "soubor.txt";
    static readonly string obsahSouboru = "Testovací zápis";
    static readonly string cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CSharpTest");

    static void Main()
    {

        // vytvoreni slozky
        try
        {
            if (!Directory.Exists(cesta))
            {
                Directory.CreateDirectory(cesta);
            }
        }
        catch
        {
            Console.WriteLine("Nepodařilo se vytvořit složku {0}, zkontrolujte prosím svá oprávnění.", cesta);
            Environment.Exit(1);
        }

        // zapis do souboru
        if (File.Exists(Path.Combine(cesta, nazevSouboru)))
        {
            try
            {
                ZaznamDoSouboru(cesta, nazevSouboru);
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
                VytvorSoubor(cesta, nazevSouboru);
            }
            catch (Exception e)
            {
                Console.WriteLine("Při vytvoření souboru došlo k následující chybě: {0}", e.Message);
            }
        }

        // vypis obsahu souboru
        Console.WriteLine("Vypisuji soubor:");

        using StreamReader sr = new(Path.Combine(cesta, nazevSouboru));
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }

        // vypis obsahu souboru pomoci tridy File
        Console.WriteLine("\nVypisuji soubor pomocí statické třídy File:");

        string[] radky = File.ReadAllLines(Path.Combine(cesta, nazevSouboru));
        foreach (string radka in radky)
        {
            Console.WriteLine(radka);
        }
    }

    private static void VytvorSoubor(string cesta, string nazevSouboru)
    {
        using StreamWriter sw = new(Path.Combine(cesta, nazevSouboru));
        sw.WriteLine(obsahSouboru);
        sw.Flush();
    }

    private static void ZaznamDoSouboru(string cesta, string nazevSouboru)
    {
        // druhy parametr true - provede se append (pripsani)
        using StreamWriter sw = new(Path.Combine(cesta, nazevSouboru), true);
        sw.WriteLine("Záznam do souboru " + DateTime.Now);
        sw.Flush();
    }
}
