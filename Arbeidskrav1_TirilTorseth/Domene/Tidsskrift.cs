namespace Arbeidskrav1_TirilTorseth.Domene;

public class Tidsskrift : Media
{
    private int utgaveNummer;
    private string måned;

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

    public Tidsskrift(string Tittel, int UtgaveNummer, string Måned, int PubliseringsÅr)
        : base(Tittel, PubliseringsÅr, 3)
    {
        this.UtgaveNummer = UtgaveNummer;
        this.Måned = Måned;
    }
    
    public override void VisInfo()
    {
        Console.WriteLine($"Tidsskrift: {Tittel} med utgavenummer {UtgaveNummer}");
    }
}