using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Slovnik
{
    class Hra
    {
        private readonly string rekordCesta = @"../../../rekord.txt";
        public (string jmeno, string skore)? Rekord { get; set; }
        public int Body { get; set; }

        public Hra()
        {
            if (File.Exists(rekordCesta))
            {
                string[] rekord = File.ReadAllText(rekordCesta)
                                      .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(i => i.Trim())
                                      .Where(i => !string.IsNullOrEmpty(i))
                                      .ToArray();

                if (rekord.Length == 2)
                {
                    Rekord = (rekord[0], rekord[1]);
                }
            }
        }
    }
}
