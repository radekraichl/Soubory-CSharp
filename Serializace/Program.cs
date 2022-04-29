using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Serializace;

class Program
{
    static void Main()
    {
        string path = @"..\..\..\uzivatele.xml";

        List<Uzivatel> uzivatele = new()
        {
            new Uzivatel() { Jmeno = "Franta", Prijmeni = "Klika", DatumNarozeni = new DateTime(1994, 5, 12) },
            new Uzivatel() { Jmeno = "Jan", Prijmeni = "Tleskač", DatumNarozeni = new DateTime(1943, 3, 3) },
        };

        var xmlWriterSettings = new XmlWriterSettings()
        {
            Indent = true   // EOL
        };

        XmlSerializer serializer = new(uzivatele.GetType());

        using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
        {
            serializer.Serialize(xmlWriter, uzivatele);
        }

        uzivatele.Add(new Uzivatel() { Jmeno = "Kamil", Prijmeni = "Vidlička", DatumNarozeni = new DateTime(2005, 6, 18) });

        using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
        {
            serializer.Serialize(xmlWriter, uzivatele);
        }

        using StreamReader streamReader = new(path);
        List<Uzivatel> deserUzivatele = (List<Uzivatel>)serializer.Deserialize(streamReader);

        deserUzivatele.ForEach(u => Console.WriteLine(u));
    }
}
