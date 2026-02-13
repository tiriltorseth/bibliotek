using Arbeidskrav1_TirilTorseth.Domene;

namespace Arbeidskrav1_TirilTorseth.Services;

/// <summary>
///  Klasse for utlån
/// </summary>
public class Utlån
{
    private static int utlånTeller = 0;
    
    private readonly string utlånsID; 
    
    /// <summary>
    ///  String som oppretter UtlånsID og henter utlåndsID fra privat property
    /// </summary>
    public string UtlånsID { get=> utlånsID; }
    
    /// <summary>
    ///  Media objekt som tar inn media
    /// </summary>
    public Media media { get; }
    /// <summary>
    ///  Bruker objekt som tar inn bruker
    /// </summary>
    public Bruker bruker { get; }
    
    private DateTime utlånsDato;
    private DateTime forventetInnleveringsDato;
    private DateTime? innlevertDato;
        

    /// <summary>
    ///  Utlånsdate som en DateTime for å lagre datoen mediet ble utlånt
    /// </summary>
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
    
    /// <summary>
    ///  Forventet innlevering som en DateTime for å lagre når mediet skal leveres inn
    /// </summary>
    public DateTime ForventetInnleveringsDato
    {
        get => forventetInnleveringsDato;
        protected set
        {
            forventetInnleveringsDato = value;
        }
    }

    /// <summary>
    /// Nullable Innlevert dato for å registrere når mediet faktisk ble levert
    /// 
    /// </summary>
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

    /// <summary>
    /// Oppretter utlån og tar inn Media objekt med variabel, Bruker objekt med variabel og utlånsdato
    /// Setter UtlånsID per utlån
    /// </summary>
    public Utlån(Media media, Bruker bruker, DateTime utlånsDato)
    {
        utlånTeller++;
        utlånsID = "U" + utlånTeller.ToString("D3");
        forventetInnleveringsDato = DateTime.Now.AddDays(media.LånePeriodeDager);

        this.media = media;
        this.bruker = bruker;
        UtlånsDato = utlånsDato;
        
    }

    /// <summary>
    ///  Boolsk metode som returnerer true dersom mediet ikke er levert til forventet dato
    /// </summary>
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