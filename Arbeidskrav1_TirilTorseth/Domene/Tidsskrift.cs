namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt klasse for mediet tidsskrift, arver fra Media
/// </summary>
public class Tidsskrift : Media
{
    private int utgaveNummer;
    private string måned;

    /// <summary>
    /// Utgavenummer på tidsskrift i en int
    /// </summary>
    public int UtgaveNummer
    {
        get => utgaveNummer;
        protected set
        {
            if (value <= 0)
                throw new ArgumentException("Utgavenummeret må være større enn 0.");
            utgaveNummer = value;
        }
    }

    /// <summary>
    /// Utgivelsesmåned på mediet i en string
    /// </summary>
    public string Måned
    {
        get => måned;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Måned kan ikke stå tom.");

            string[] GyldigeMåneder =
                
                { "Januar", "Februar", "Mars", "April", "Mai", "Juni", "Juli", "August", "September",
                    "Oktober","November","Desember" };

        if (!(GyldigeMåneder.Contains(value)))
        {
            Console.WriteLine("Måneden er ugyldig.");
        }
            måned = value;
        }
    }

    /// <summary>
    /// Oppretter Tidsskrift med Tittel, Utgavenummer, Måned, publiseringsår og låneperiode
    /// Tittel, Publiseringsår og Låneperiode arvet fra klassen Media
    /// Låneperiode er satt til 3 dager
    /// </summary>
    public Tidsskrift(string Tittel, int UtgaveNummer, string Måned, int PubliseringsÅr)
        : base(Tittel, PubliseringsÅr, 3)
    {
        this.UtgaveNummer = UtgaveNummer;
        this.Måned = Måned;
    }
    
    /// <summary>
    /// Metode som overrider tidligere VisInfo() fra Media
    /// Returnerer ingenting
    /// Skriver ut informasjon om mediet
    /// </summary>
    public override void VisInfo()
    {
        Console.WriteLine(
            $"[{MediaID}] - '{Tittel}' - Utgave nr. {UtgaveNummer}, {Måned}  {PubliseringsÅr}");
    }
}