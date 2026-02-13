using System.Text.RegularExpressions;
namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt baseklasse for alle brukere
/// </summary>
public abstract class Bruker
{

    private static int brukerTeller = 0;
    private readonly string brukerID;
    
    /// <summary>
    /// BrukerID i en string
    /// Genereres automatisk og er unik for hver bruker
    /// </summary>
    public string BrukerID { get => brukerID; }
    
    
    private string navn;
    private string epost;

    /// <summary>
    /// Navn på alle brukere
    /// </summary>
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

    /// <summary>
    /// Epost til alle brukere
    /// </summary>
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

    /// <summary>
    /// Oppretter liste for alle utlånte medier
    /// </summary>
    public List<Media> UtlånteMedier { get; }
    
    
    /// <summary>
    /// Oppretter bruker med navn, epost og unik ID
    /// Lager UtlånteMedier til nytt objekt
    /// </summary>
    protected Bruker(string navn, string epost)
    {
        brukerTeller++;
        brukerID = $"B{brukerTeller:D3}"; ;
        Navn = navn;
        Epost = epost;
        UtlånteMedier = new List<Media>();
    }
    
    /// <summary>
    /// Abstrakt metode som bestemmer hvem som kan låne
    /// </summary>
    public abstract bool KanLåne();
}


