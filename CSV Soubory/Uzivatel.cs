using System;

namespace CSV_Soubory;

class Uzivatel
{
    public string Jmeno { get; private set; }
    public int Vek { get; private set; }
    public DateTime Registrovan { get; private set; }

    public Uzivatel(string jmeno, int vek, DateTime registrovan)
    {
        Jmeno = jmeno;
        Vek = vek;
        Registrovan = registrovan;
    }

    public override string ToString() => Jmeno;
}
