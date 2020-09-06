using System;
using System.Xml;
using System.Collections.Generic;

namespace XML_SAX
{
    class Program
    {
        static void Main()
        {
            List<Uzivatel> uzivatele = new List<Uzivatel>
            {
                new Uzivatel("Pavel Slavík", 22, new DateTime(2000, 3, 21)),
                new Uzivatel("Jan Novák", 31, new DateTime(2012, 10, 30)),
                new Uzivatel("Tomáš Marný", 16, new DateTime(2011, 1, 12))
            };

            // Zapisování do souboru
            // ---------------------
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            using (XmlWriter xw = XmlWriter.Create(@"..\..\..\soubor.xml", settings))
            {
                //xw.WriteStartDocument();
                xw.WriteStartElement("uzivatele");

                foreach (Uzivatel u in uzivatele)
                {
                    xw.WriteStartElement("uzivatel");
                    xw.WriteAttributeString("vek", u.Vek.ToString());

                    xw.WriteElementString("jmeno", u.Jmeno);
                    xw.WriteElementString("registrovan", u.Registrovan.ToShortDateString());

                    xw.WriteEndElement();
                }

                //xw.WriteEndElement(); // uzavření kořenového elementu
                //xw.WriteEndDocument(); // konec dokumentu
                xw.Flush();
            }

            uzivatele.Clear();

            // Čtení ze souboru
            // ----------------
            using XmlReader xr = XmlReader.Create(@"..\..\..\soubor.xml");

            string element = string.Empty;
            string jmeno = string.Empty;
            int vek = default;
            DateTime registrovan = DateTime.Now;

            while (xr.Read())
            {
                // načítáme element
                if (xr.NodeType == XmlNodeType.Element)
                {
                    element = xr.Name; // název aktuálního elementu
                    if (element == "uzivatel")
                    {
                        vek = int.Parse(xr.GetAttribute("vek"));
                    }
                }
                // načítáme hodnotu elementu
                else if (xr.NodeType == XmlNodeType.Text)
                {
                    switch (element)
                    {
                        case "jmeno":
                            jmeno = xr.Value;
                            break;
                        case "registrovan":
                            registrovan = DateTime.Parse(xr.Value);
                            break;
                    }
                }
                // načítáme ukončující element
                else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "uzivatel"))
                    uzivatele.Add(new Uzivatel(jmeno, vek, registrovan));
            }

            // výpis načtených objektů
            foreach (Uzivatel u in uzivatele)
            {
                Console.WriteLine(u);
            }
        }
    }
}
