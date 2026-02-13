using System;

namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt baseklasse for alle medier
/// </summary>
public abstract class Media
{
    private static int mediaTeller = 0;
    private readonly string mediaID;
    
    //Unik og autogenerert ID for all media
    public string MediaID { get => mediaID; }

    private string tittel;
    private int publiseringsÅr;
    private bool erUtlånt;
    private int lånePeriodeDager;
    
    /// <summary>
    /// Tittel på mediet.
    /// </summary>
    public string Tittel
    {
        get => tittel;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tittel kan ikke stå tomt.");
            tittel = value;
        }
    }

    /// <summary>
    /// Publiseringsår for alle medier
    /// </summary>
    public int PubliseringsÅr
    {
        get => publiseringsÅr;
        protected set
        {
            
            if (value < 1700 || value > 2026)
                throw new ArgumentException("Årstallet er ugyldig.");

            
            publiseringsÅr = value;
        }
    }

    /// <summary>
    /// Bool som setter om mediet er utlånt eller ikke
    /// </summary>
    public bool ErUtlånt
    {
        get => erUtlånt;
        set => erUtlånt = value;
    }

    /// <summary>
    /// Låneperiode for alle medier, settes senere i hvert medie
    /// </summary>
    public int LånePeriodeDager
    {
        get => lånePeriodeDager;
        protected set => lånePeriodeDager = value;

    }
    
    /// <summary>
    /// Oppretter nytt Media med MediaID, Tittel, Publiseringsår og Låneperiodedager
    /// </summary>
        protected Media(string Tittel, int PubliseringsÅr, int LånePeriodeDager){
            
        mediaTeller++;
        mediaID = "M" + mediaTeller.ToString("D3");
        this.Tittel = Tittel;
        this.PubliseringsÅr = PubliseringsÅr;
        this.LånePeriodeDager = LånePeriodeDager;
        ErUtlånt = false;
    }
    /// <summary>
    /// Abstrakt metode for å vise info for hvert medie etterhvert som de blir laget
    /// </summary>
    public abstract void VisInfo();
}


