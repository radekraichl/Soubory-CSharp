using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace BinarniSoubory;

class Program
{
    static void Main()
    {
        // zapsání jednoho čísla
        string filePath = @"..\..\..\cislo.dat";

        using (BinaryWriter bw = new(new FileStream(filePath, FileMode.Create)))
        {
            int cislo = 12345;
            bw.Write(cislo);
        }

        // přečtení čísla
        using (BinaryReader br = new(new FileStream(filePath, FileMode.Open)))
        {
            int cislo = br.ReadInt32();
            WriteLine(cislo);
        }

        // zapsání listu uživatelů
        filePath = @"..\..\..\uzivatele.dat";

        List<Uzivatel> uzivatele = new()
        {
            new Uzivatel("Jan Novák", 28, new DateTime(1980, 1, 1)),
            new Uzivatel("Tomáš Marný", 46, new DateTime(1984, 2, 5)),
            new Uzivatel("Jan Nový", 84, new DateTime(1988, 3, 8))
        };

        using (BinaryWriter bw = new(new FileStream(filePath, FileMode.Create)))
        {
            foreach (Uzivatel u in uzivatele)
            {
                bw.Write(u.Jmeno);
                bw.Write(u.Vek);
                bw.Write(u.Registrovan.Ticks);
            }
        }

        using (BinaryReader br = new(new FileStream(filePath, FileMode.Open)))
        {
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                string jmeno = br.ReadString();
                int vek = br.ReadInt32();
                DateTime registrovan = new(br.ReadInt64());
                Uzivatel uzivatel = new(jmeno, vek, registrovan);
                WriteLine(uzivatel);
            }
        }
    }
}
