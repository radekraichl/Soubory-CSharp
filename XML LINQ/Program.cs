using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XML_SAX;

namespace XML_LINQ;

class Program
{
    static void Main()
    {
        List<Uzivatel> uzivatele = new()
        {
            new Uzivatel("Jan Novák", 29, new DateTime(1980, 1, 1)),
            new Uzivatel("Tomáš Marný", 60, new DateTime(1984, 2, 5)),
            new Uzivatel("Jan Nový", 45, new DateTime(1988, 3, 8)),
            new Uzivatel("Petr Plachý", 11, new DateTime(2018, 3, 8)),
            new Uzivatel("Josef Stalin", 17, new DateTime(2018, 3, 8))
        };

        string filePath = @"..\..\..\soubor.xml";

        // Vytvoření dokumentu
        // *******************
        XDocument xmlDocument = new(
            new XDeclaration("1.0", "UTF-8", null),
            new XElement("uzivatele", uzivatele.Select(u =>
                                        new XElement("uzivatel",
                                        new XAttribute("vek", u.Vek),
                                        new XElement("jmeno", u.Jmeno),
                                        new XElement("registrovan", u.Registrovan))
            ))
        );

        // Uložení
        xmlDocument.Save(filePath);

        // Načtení dokumentu
        xmlDocument = XDocument.Load(filePath);

        // Editace dokumentu
        // *****************
        // Najde všechny Jany a změní jim věk na 31 let
        var dotaz = from u in xmlDocument.Element("uzivatele").Elements("uzivatel")
                    where u.Element("jmeno").Value.StartsWith("Jan")
                    select u;

        foreach (XElement u in dotaz)
        {
            u.Attribute("vek").Value = "31";
        }

        // Smaže uživatele mladší 18 let
        (from u in xmlDocument.Element("uzivatele").Elements("uzivatel")
         where int.Parse(u.Attribute("vek").Value) < 18
         select u).Remove();

        // Výpis dokumentu
        // ***************
        foreach (XElement u in xmlDocument.Element("uzivatele").Elements("uzivatel"))
        {
            string jmeno = u.Element("jmeno").Value;
            string vek = u.Attribute("vek").Value;
            string registrovan = DateTime.Parse(u.Element("registrovan").Value).ToShortDateString();

            Console.WriteLine($"{jmeno}, {vek}, {registrovan}");
        }

        // Uložení
        xmlDocument.Save(filePath);
    }
}
