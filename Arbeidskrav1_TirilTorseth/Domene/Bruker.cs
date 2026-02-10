namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt baseklasse for alle brukere
/// </summary>

public abstract class Bruker
{
    // Statisk id generator
    private static int brukerTeller = 0;

    // BrukerID, public
    public string BrukerID { get; }
    
    //Private felter
    private string navn;
    private string epost;

    public string Navn
    {
        get => navn;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Navnet kan ikke stå tomt.");
            navn = value;
        }
    }

    public string Epost
    {
        get => epost;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Epost kan ikke stå tomt.");
            epost = value;
        }
    }

    public List<Media> UtlånteMedier { get; }
    
    //KONSTRUKTØR
    protected Bruker(string navn, string epost)
    {
        brukerTeller++;
        BrukerID = "B" + brukerTeller.ToString("D3");
        Navn = navn;
        Epost = epost;
        UtlånteMedier = new List<Media>();
    }
    
    // Abstrakt metode
    public abstract bool KanLåne();
}
