using System.Data;

namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt klasse for mediet ebok, arver fra Media
/// </summary>
public class Ebok : Media
{
    private string forfatter;
    private double filStørrelse;
    
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
    /// Filstørrelse på eboken som en double
    /// </summary>
    public double FilStørrelse
    {
        get => filStørrelse;
        protected set
        {
            if (value <= 0 || value > 50)
                throw new ArgumentException("Filstørrelsen må være større enn 0 MB og mindre enn 50 MB .");
            filStørrelse = value;
        }
    }
    
    /// <summary>
    /// Oppretter ny ebok med Tittel, Forfatter, Publiseringsår, filstørrelse og Låneperiode
    /// Tittel Publiseringsår og Låneperiodedager arves fra Media klassen
    /// Låneperioden er satt til 21 dager for ebok 
    /// </summary>
    public Ebok(string Tittel,string Forfatter, int PubliseringsÅr,  double FilStørrelse)
        : base(Tittel, PubliseringsÅr, 21)
    {
        this.Forfatter = Forfatter;
        this.FilStørrelse = FilStørrelse;

    }
    
    /// <summary>
    /// Metode som ikke returnerer noe og overrider VisInfo() fra Media
    /// Skriver ut informasjon om eboken som blir opprettet
    /// </summary>
    public override void VisInfo()
    {
        Console.WriteLine(
            $"[{MediaID}] - '{Tittel}' av {Forfatter} ({PubliseringsÅr}), {FilStørrelse} MB");
    }
    
    
}