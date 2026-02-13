using System.Text.RegularExpressions;
namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt baseklasse for alle brukere
/// </summary>

public abstract class Bruker
{
    // Statisk id generator
    private static int brukerTeller = 0;

    // BrukerID, public
    private readonly string brukerID;
    public string BrukerID { get => brukerID; }
    
    
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
            
            if (value.Length < 2)
            {
                throw new ArgumentException("Navnet må være mer enn to bokstaver");
            }
            
            
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
            
            string epostSjekk = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";

            if (!(Regex.IsMatch(value, epostSjekk) || value.Contains(".")))
            {
                Console.WriteLine("Ugyldig epost");
            }
                
            epost = value;
        }
    }

    public List<Media> UtlånteMedier { get; }
    
    //KONSTRUKTØR
    protected Bruker(string navn, string epost)
    {
        brukerTeller++;
        brukerID = $"B{brukerTeller:D3}"; ;
        Navn = navn;
        Epost = epost;
        UtlånteMedier = new List<Media>();
    }
    
    // Abstrakt metode
    public abstract bool KanLåne();
}


