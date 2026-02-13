using System.Runtime.CompilerServices;

namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt klasse for mediet lydbok, arver fra Media
/// </summary>
public class Lydbok : Media
{
    private string forfatter;
    private TimeSpan varighet;

    /// <summary>
    /// Forfatter på lydbok i en string
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
    /// Varighet på lydbok i en Timespan
    /// </summary>
    public TimeSpan Varighet
    {
        get => varighet;
        protected set
        {
            if (value.TotalMinutes <= 0 || value.TotalHours > 100)
                throw new ArgumentException("Varighet må være større enn 0 minutter og mindre enn 100 timer");
            varighet = value;
        }
        
    }
    
    /// <summary>
    /// Oppretter ny lydbok med Tittel, Forfatter, Publiseringsår, varighet og Låneperiode
    /// Tittel Publiseringsår og Låneperiodedager arves fra Media klassen
    /// Låneperioden er satt til 7 dager for bok 
    /// </summary>
    public Lydbok(string Tittel,string Forfatter, int PubliseringsÅr, TimeSpan Varighet)
        : base(Tittel, PubliseringsÅr, 7)
    {
        this.Forfatter = Forfatter;
        this.Varighet = Varighet;
    }

    /// <summary>
    /// Metode som ikke returnerer noe og overrider VisInfo() fra Media
    /// Skriver ut informasjon om lydboken som blir opprettet
    /// </summary>
    public override void VisInfo()
    {
        Console.WriteLine(
            $"[{MediaID}] - '{Tittel}' av {Forfatter} ({PubliseringsÅr}) - {Varighet}");
    }
    
}




    
    