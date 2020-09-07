using System.Linq;
using System.Xml.Linq;
using System.Globalization;
using System;

namespace Pocitace_LINQ
{
    class Program
    {
        static void Main()
        {
            XDocument document = XDocument.Load(@"..\..\..\pocitace.xml");

            var pocitaceKolekce =
                document.Element("pocitace").Elements("pocitac").Select(p => p);

            int celkovaRamSystemu = default;
            double celkovaFrekvenceSystemu = default;
            string nejvykonejsiPocitac = default;

            double nejvyssiFrekvencePocitace = default;     // pomocná proměnná

            foreach (var pocitac in pocitaceKolekce)
            {
                // frekvence procesoru
                var dotazFrekvence = pocitac.Element("procesor").Element("frekvence").Value;
                double frekvenceProcesoru = double.Parse(dotazFrekvence.Split(' ')[0], CultureInfo.InvariantCulture);

                // počet jader procesoru
                int pocetJader = int.Parse(pocitac.Element("procesor").Element("jader").Value);

                // frekvence grafiky
                var dotazFrekvenceGrafiky = pocitac.Element("grafika").Element("frekvence").Value;
                double frekvenceGrafiky = int.Parse(dotazFrekvenceGrafiky.Split(' ')[0]);

                // získání a přičteni ram počítače k celkové ram celého systému
                celkovaRamSystemu += int.Parse(pocitac.Element("ram").Value.Split(' ')[0]);

                // přičtení celkové frekvence procesoru k celkové frekvenci systému
                double celkovaFrekvenceProcesoru = frekvenceProcesoru * pocetJader;
                celkovaFrekvenceSystemu += celkovaFrekvenceProcesoru;

                // zjištění nejvýkonějšího počítače
                double celkovaFrekvencePocitace =
                    celkovaFrekvenceProcesoru + frekvenceGrafiky / 1000;    // frekvence grafiky převedena na GHz

                if (celkovaFrekvencePocitace > nejvyssiFrekvencePocitace)
                {
                    nejvyssiFrekvencePocitace = celkovaFrekvencePocitace;
                    nejvykonejsiPocitac = pocitac.Attribute("nazev").Value;
                }
            }

            Console.WriteLine("Celokvý součet výkonů všech jader všech počítačů je {0} GHz", celkovaFrekvenceSystemu);
            Console.WriteLine("Průměrná velikost operační paměti je {0} GB", (double)celkovaRamSystemu / pocitaceKolekce.Count());
            Console.WriteLine("Nejvýkonější počítač je " + nejvykonejsiPocitac);
        }
    }
}