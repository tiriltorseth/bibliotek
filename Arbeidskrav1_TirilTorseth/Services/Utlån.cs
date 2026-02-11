using Arbeidskrav1_TirilTorseth.Domene;

namespace Arbeidskrav1_TirilTorseth.Services;

/// <summary>
///  Klasse for utlån
/// </summary>
public class Utlån
{
    private static int utlånTeller = 0;
    
    private readonly string utlånsID; 
    public string UtlånsID { get=> utlånsID; }
    
    public Media media { get; }
    public Bruker bruker { get; }
    
    private DateTime utlånsDato;
    private DateTime forventetInnleveringsDato;
    private DateTime? innlevertDato;
        

    public DateTime UtlånsDato
    {
        get => utlånsDato;
        protected set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Utlånsdato kan ikke være i fremtiden.");
            utlånsDato = value;
        }
        
    }
    
    public DateTime ForventetInnleveringsDato
    {
        get => forventetInnleveringsDato;
        protected set
        {
            forventetInnleveringsDato = value;
        }
    }

    
    public DateTime? InnlevertDato
    {
        get => innlevertDato;
        set
        {
            if (value < UtlånsDato)
                throw new ArgumentException("Utlånsdato kan ikke være i fremtiden.");
            
            if (InnlevertDato.HasValue)
                throw new InvalidOperationException("Mediet er allerede levert inn.");
            
            innlevertDato = value;
        }
        
    }

    public Utlån(Media media, Bruker bruker, DateTime utlånsDato)
    {
        utlånTeller++;
        utlånsID = "U" + utlånTeller.ToString("D3");
        forventetInnleveringsDato = DateTime.Now.AddDays(media.LånePeriodeDager);

        this.media = media;
        this.bruker = bruker;
        UtlånsDato = utlånsDato;
        
    }

    public bool ErForsinket()
    {
        if (InnlevertDato > ForventetInnleveringsDato)
        {
            Console.WriteLine("Mediet er ikke levert innen forventet dato.");      
            return true;                                                               
        }

        return false;
        
    }
}