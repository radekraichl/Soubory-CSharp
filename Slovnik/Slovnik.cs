using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Slovnik
{
    class Slovnik
    {
        private readonly Dictionary<string, string[]> slovaDb;
        private readonly Random ranadom = new Random();

        public KeyValuePair<string, string[]> NahodneSlovo
        {
            get => slovaDb.ElementAt(ranadom.Next(slovaDb.Count));
        }

        public Slovnik()
        {
            string[] slova = File.ReadAllLines(@"../../../slova.txt");

            slovaDb =
                slova.Select(i => i.Split('\t')).ToDictionary(s => s[0], s => s[1].Split(','));
        }

        public override string ToString()
        {
            var slova = slovaDb.Select(s => s.Key.PadRight(30) + string.Join(',', s.Value) + "\n");
            return string.Concat(slova);
        }
    }
}
