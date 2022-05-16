using System;

namespace XML_SAX;

public class Uzivatel
{
    public string Jmeno { get; }
    public int Vek { get; }
    public DateTime Registrovan { get; }

    public Uzivatel(string jmeno, int vek, DateTime registrovan)
    {
        Jmeno = jmeno;
        Vek = vek;
        Registrovan = registrovan;
    }

    public override string ToString()
    {
        return String.Format("{0}, {1}, {2}", Jmeno, Vek, Registrovan.ToShortDateString());
    }
}
