using System;

namespace Textove_Soubory_Vobornik;

class Program
{
    static void Main()
    {
        try
        {
            //Soubor.PrectiCelySoubor(@"..\..\..\Soubor.cs");
            //Soubor.PrectiCelySouborPoRadcich2(@"..\..\..\Soubor.cs");
            //Soubor.ZapisujDoSouboru(@"..\..\..\temp\Slova.txt");
            Soubor.ZapisujCislaDoSouboru(@"..\..\..\temp\Cisla.txt");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
