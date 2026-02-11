using System;
namespace Arbeidskrav1_TirilTorseth.Domene;

public class Bok : Media
{
    private string forfatter;
    private int antallSider;


    public string Forfatter
    {
        get => forfatter;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Forfatter kan ikke stå tomt.");
            forfatter = value;
        }
    }

    public int AntallSider
    {
        get => antallSider;
        protected set
        {
            if (value < 1 || value > 5000)
                throw new ArgumentException("Korriger sidetall.");
            antallSider = value;
        }
    }
    
    // KONSTRUKTØR 
    public Bok(string Tittel, string Forfatter, int PubliseringsÅr, int AntallSider)
        : base(Tittel, PubliseringsÅr, 14)
    {
        this.Forfatter = Forfatter;
        this.AntallSider = AntallSider;
    }

    public override void VisInfo()
    {
        Console.WriteLine($"Bok: {Tittel} av {Forfatter}");
    }
}