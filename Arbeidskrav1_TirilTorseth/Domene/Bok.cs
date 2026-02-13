using System;
namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt klasse for mediet bok, arver fra Media
/// </summary>
public class Bok : Media
{
    private string forfatter;
    private int antallSider;

    /// <summary>
    /// Forfatter på bok i en string
    /// </summary>
    public string Forfatter
    {
        get => forfatter;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Forfatter kan ikke stå tomt.");
            
            if (value.Length < 2)
            {
                throw new ArgumentException("Navnet må være mer enn to bokstaver");
            }
            forfatter = value;
        }
    }
    
    /// <summary>
    /// Antall sider per bok som int
    /// </summary>
    public int AntallSider
    {
        get => antallSider;
        protected set
        {
            if (value < 1 || value > 5000)
                throw new ArgumentException("Sidetall kan ikke være null eller mer enn 5000 sider.");
            antallSider = value;
        }
    }
    
    /// <summary>
    /// Oppretter ny bok med Tittel, Forfatter, Publiseringsår, antall sider og Låneperiode
    /// Tittel Publiseringsår og Låneperiodedager arves fra Media klassen
    /// Låneperioden er satt til 14 dager for bok 
    /// </summary>
    public Bok(string Tittel, string Forfatter, int PubliseringsÅr, int AntallSider)
        : base(Tittel, PubliseringsÅr, 14)
    {
        this.Forfatter = Forfatter;
        this.AntallSider = AntallSider;
    }

    /// <summary>
    /// Metode som ikke returnerer noe og overrider VisInfo() fra Media
    /// Skriver ut informasjon om boken som blir opprettet
    /// </summary>
    public override void VisInfo()
    {
        Console.WriteLine(
            $"[{MediaID}] - '{Tittel}' av {Forfatter} ({PubliseringsÅr}), {AntallSider} sider");
    }
}