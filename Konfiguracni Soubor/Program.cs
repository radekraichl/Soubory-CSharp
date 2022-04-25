using System;
using System.Xml;

namespace Konfiguracni_Soubor_XML;

class Program
{
    static void Main()
    {
        XmlWriterSettings settings = new()
        {
            Indent = true
        };

        using XmlWriter xmlWriter = XmlWriter.Create(@"..\..\..\config.xml", settings);

        xmlWriter.WriteStartElement("Nastaveni");
        xmlWriter.WriteElementString("DatumSpusteni", DateTime.Now.ToString());
        xmlWriter.WriteElementString("SpusteniPoStartu", true.ToString());

        xmlWriter.WriteStartElement("Cesty");
        xmlWriter.WriteElementString("CestaAplikace", @"C:\Program Files(x86)");
        xmlWriter.WriteElementString("CestaDokumenty", @"C:\Users\Radek\Documents");
        
        xmlWriter.WriteEndElement();    // uzavření elementu "Cesty"

        xmlWriter.WriteElementString("Zprava", "Vítej zpět Radku!");

        xmlWriter.Flush();
    }
}
