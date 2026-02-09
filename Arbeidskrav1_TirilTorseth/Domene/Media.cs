using System;

namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Abstrakt baseklasse for all media
/// </summary>
public abstract class Media
{
    // STATIC ID-GENERATOR
    private static int mediaTeller = 0;
   
    // PRIVATE FELTER
    public string MediaID { get; }

    private string tittel;
    private int publiseringsÅr;
    private bool erUtlånt;
    private int lånePeriodeDager;
    

    public string Tittel
    {
        get => tittel;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Navn kan ikke stå tomt.");
            tittel = value;
        }
    }

    public int PubliseringsÅr
    {
        get => publiseringsÅr;
        protected set
        {
            
            if (value < 1400 || value > 2026)
                throw new ArgumentException("Årstallet er ugyldig.");

            
            publiseringsÅr = value;
        }
    }

    public bool ErUtlånt
    {
        get => erUtlånt;
        protected set => erUtlånt = value;
    }

    public int LånePeriodeDager
    {
        get => lånePeriodeDager;
        protected set => lånePeriodeDager = value;

    }

    //KONSTRUKTØR
        
        protected Media(string Tittel, int PubliseringsÅr, int LånePeriodeDager){
            
        mediaTeller++;
        MediaID = "M" + mediaTeller.ToString("D3");
        this.Tittel = Tittel;
        this.PubliseringsÅr = PubliseringsÅr;
        this.LånePeriodeDager = LånePeriodeDager;
        ErUtlånt = false;
    }
    // ABSTRAKT METODE
    public abstract void VisInfo();
}


