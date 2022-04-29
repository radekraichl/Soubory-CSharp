using System;

namespace Serializace;

public class Uzivatel
{
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public DateTime DatumNarozeni { get; set; }

    public override string ToString() => $"{Jmeno} {Prijmeni}, {DatumNarozeni.ToShortDateString()}";
}
