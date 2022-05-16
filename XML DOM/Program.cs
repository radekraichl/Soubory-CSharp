using System;
using System.Collections.Generic;
using System.Xml;
using XML_SAX;

namespace XML_DOM;

class Program
{
    static void Main()
    {
        List<Uzivatel> uzivatele = new()
        {
            new Uzivatel("Jan Novák", 22, new DateTime(1980, 1, 1)),
            new Uzivatel("Tomáš Marný", 26, new DateTime(1984, 2, 5)),
            new Uzivatel("Jan Nový", 52, new DateTime(1988, 3, 8))
        };

        string filePath = @"..\..\..\soubor.xml";
        XmlDocument xmlDoc = new();

        // Vytvoření a zápis dokumentu
        // ***************************
        XmlDeclaration deklarace = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);   // Vytvoření XML hlavičky
        xmlDoc.AppendChild(deklarace);                                                  // Zapsání hlavičky do dokumentu
        XmlElement koren = xmlDoc.CreateElement("uzivatele");                           // Vytvoření root elementu
        xmlDoc.AppendChild(koren);                                                      // Zapsání root elementu do dokumentu

        foreach (Uzivatel u in uzivatele)
        {
            XmlElement uzivatel = xmlDoc.CreateElement("uzivatel");
            // Atribut
            uzivatel.SetAttribute("vek", u.Vek.ToString());
            // Jméno
            XmlElement jmeno = xmlDoc.CreateElement("jmeno");
            jmeno.InnerText = u.Jmeno;
            uzivatel.AppendChild(jmeno);
            // Registrován
            XmlElement registrovan = xmlDoc.CreateElement("registrovan");
            registrovan.InnerText = u.Registrovan.ToString();
            uzivatel.AppendChild(registrovan);
            koren.AppendChild(uzivatel);
        }

        // Uložení
        xmlDoc.Save(filePath);

        // Načtení a výpis dokumentu
        // *************************
        xmlDoc.Load(filePath);

        XmlNode root = xmlDoc.DocumentElement;      // Načtení kořenového elementu

        foreach (XmlNode node in root.ChildNodes)
        {
            if (node.Name == "uzivatel")
            {
                XmlElement uzivatel = (XmlElement)node;
                int vek = int.Parse(uzivatel.GetAttribute("vek"));
                string jmeno = uzivatel.GetElementsByTagName("jmeno")[0].InnerText;              
                DateTime registrovan = DateTime.Parse(uzivatel.GetElementsByTagName("registrovan")[0].InnerText);
                Uzivatel u = new(jmeno, vek, registrovan);
                Console.WriteLine(u);
            }
        }
    }
}
