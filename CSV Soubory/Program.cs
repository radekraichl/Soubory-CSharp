using System;
using System.IO;

namespace CSV_Soubory
{
	class Program
	{
		static void Main()
		{
			string cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ITnetwork");
			string soubor = Path.Combine(cesta, "databaze.csv");

			try
			{
				if (!File.Exists(soubor))
				{
					using StreamWriter sw = new StreamWriter(soubor);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return;
			}

			Databaze databaze = new Databaze(Path.Combine(soubor));

			databaze.PridejUzivatele("Bender Rodriguez", 45, DateTime.Now);
			databaze.PridejUzivatele("John Zoidberg", 38, DateTime.Now);
			databaze.PridejUzivatele("Hubert Farnsworth", 150, DateTime.Now);

			try
			{
				databaze.Uloz();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return;
			}

			try
			{
				databaze.Nacti();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return;
			}

			databaze.Tisk();
		}
	}
}
