using System;

namespace XML_SAX
{
    public class Uzivatel
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

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Jmeno, Vek, Registrovan.ToShortDateString());
        }
    }
}
