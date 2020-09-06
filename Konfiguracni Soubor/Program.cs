using System;
using System.Xml;

namespace Konfiguracni_Soubor
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            using XmlWriter xw = XmlWriter.Create(@"..\..\..\config.xml", settings);

            xw.WriteStartElement("nastaveni");
            xw.WriteElementString("datumSpusteni", DateTime.Now.ToString());
            xw.WriteElementString("spusteniPoStartu", true.ToString());

            xw.WriteStartElement("cesty");
            xw.WriteElementString("cestaAplikace", @"C:\Program Files(x86)\ITnetwork");
            xw.WriteElementString("cestaDokumenty", @"C:\Users\Karel\Documents");
            xw.WriteEndElement(); // uzavření elementu "cesty"

            xw.WriteElementString("zprava", "Vítej zpět Radku!");

            xw.Flush();
        }
    }
}
