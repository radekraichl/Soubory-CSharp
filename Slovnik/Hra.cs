using System;
using System.IO;
using System.Linq;

namespace Slovnik;

internal class Hra
{
    private readonly string rekordCesta = @"../../../rekord.txt";
    public (string jmeno, string score)? Rekord { get; set; }
    public int Score { get; set; }

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
        else
        {
            File.Create(rekordCesta);
        }
    }

    public void UlozRekord(string jmeno, int score)
    {
        string rekord = string.Join(';', jmeno, score.ToString());

        File.WriteAllText(rekordCesta, rekord);
    }
}
