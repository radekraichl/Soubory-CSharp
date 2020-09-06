using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serializace
{
    class Program
    {
        static void Main()
        {
            string path = @"..\..\..\uzivatele.xml";

            List<Uzivatel> uzivatele = new List<Uzivatel>
            {
                new Uzivatel() { Jmeno = "Franta", Prijmeni = "Klika", DatumNarozeni = new DateTime(1994, 5, 12) },
                new Uzivatel() { Jmeno = "Jan", Prijmeni = "Tleskač", DatumNarozeni = new DateTime(1943, 3, 3) },
            };
        
            XmlSerializer serializer = new XmlSerializer(uzivatele.GetType());

            using (StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, uzivatele);
            }

            uzivatele.Add(new Uzivatel() { Jmeno = "Kamil", Prijmeni = "Vidlička", DatumNarozeni = new DateTime(2005, 6, 18) });

            using (StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, uzivatele);
            }

            using StreamReader sr = new StreamReader(path);
            List<Uzivatel> deserUzivatele = (List<Uzivatel>)serializer.Deserialize(sr);

            deserUzivatele.ForEach(u => Console.WriteLine(u));
        }
    }
}