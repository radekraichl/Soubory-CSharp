using System;
using System.Collections.Generic;
using System.IO;

namespace CSV_Soubory;

class Databaze
{
    private readonly List<Uzivatel> uzivatele;
    private readonly string soubor;

    public Databaze(string soubor)
    {
        uzivatele = new List<Uzivatel>();
        this.soubor = soubor;
    }

    public void PridejUzivatele(string jmeno, int vek, DateTime registrovan)
    {
        Uzivatel uzivatel = new(jmeno, vek, registrovan);
        uzivatele.Add(uzivatel);
    }

    public Uzivatel[] VratVsechny()
    {
        return uzivatele.ToArray();
    }

    public void Uloz()
    {
        // otevření souboru pro zápis
        using StreamWriter streamWriter = new(soubor);

        // projetí uživatelů
        foreach (Uzivatel uzivatel in uzivatele)
        {
            // vytvoření pole hodnot
            string[] hodnoty = { uzivatel.Jmeno, uzivatel.Vek.ToString(), uzivatel.Registrovan.ToShortDateString() };
            // vytvoření řádku
            string radek = string.Join(";", hodnoty);
            // zápis řádku
            streamWriter.WriteLine(radek);
        }
        // vyprázdnění bufferu
        streamWriter.Flush();
    }

    public void Nacti()
    {
        uzivatele.Clear();
        // Otevře soubor pro čtení
        using StreamReader streamReader = new(soubor);

        string radek;
        // čte řádek po řádku
        while ((radek = streamReader.ReadLine()) != null)
        {
            // rozdělí string řádku podle středníků
            string[] rozdeleno = radek.Split(';');
            string jmeno = rozdeleno[0];
            int vek = int.Parse(rozdeleno[1]);
            DateTime registrovan = DateTime.Parse(rozdeleno[2]);

            // přidá uživatele s danými hodnotami
            PridejUzivatele(jmeno, vek, registrovan);
        }
    }

    public void Tisk()
    {
        foreach (Uzivatel uzivatel in uzivatele)
        {
            Console.WriteLine($"Jméno: {uzivatel.Jmeno}");
            Console.WriteLine($"Věk: {uzivatel.Vek}");
            Console.WriteLine($"Datum registrace: {uzivatel.Registrovan.ToShortDateString()}\n");
        }
    }
}
