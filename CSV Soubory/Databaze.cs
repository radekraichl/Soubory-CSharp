using System;
using System.Collections.Generic;
using System.IO;

namespace CSV_Soubory
{
	class Databaze
	{
		private readonly List<Uzivatel> uzivatele;
		private readonly string soubor;

		public Databaze(string soubor)
		{
			uzivatele = new List<Uzivatel>();
			this.soubor = soubor;
		}

		public void PridejUzivatele(string jmeno, int vek, DateTime registrovan)
		{
			Uzivatel u = new Uzivatel(jmeno, vek, registrovan);
			uzivatele.Add(u);
		}

		public Uzivatel[] VratVsechny()
		{
			return uzivatele.ToArray();
		}

		public void Uloz()
		{
			// otevření souboru pro zápis
			using StreamWriter sw = new StreamWriter(soubor);

			// projetí uživatelů
			foreach (Uzivatel u in uzivatele)
			{
				// vytvoření pole hodnot
				string[] hodnoty = { u.Jmeno, u.Vek.ToString(), u.Registrovan.ToShortDateString() };
				// vytvoření řádku
				string radek = string.Join(";", hodnoty);
				// zápis řádku
				sw.WriteLine(radek);
			}
			// vyprázdnění bufferu
			sw.Flush();
		}

		public void Nacti()
		{
			uzivatele.Clear();
			// Otevře soubor pro čtení
			using StreamReader sr = new StreamReader(soubor);

			string s;
			// čte řádek po řádku
			while ((s = sr.ReadLine()) != null)
			{
				// rozdělí string řádku podle středníků
				string[] rozdeleno = s.Split(';');
				string jmeno = rozdeleno[0];
				int vek = int.Parse(rozdeleno[1]);
				DateTime registrovan = DateTime.Parse(rozdeleno[2]);

				// přidá uživatele s danými hodnotami
				PridejUzivatele(jmeno, vek, registrovan);
			}
		}

		public void Tisk()
		{
			foreach (Uzivatel uzivatel in uzivatele)
			{
				Console.WriteLine($"Jméno: {uzivatel.Jmeno}");
				Console.WriteLine($"Věk: {uzivatel.Vek}");
				Console.WriteLine($"Datum registrace: {uzivatel.Registrovan.ToShortDateString()}\n");
			}
		}
	}
}
