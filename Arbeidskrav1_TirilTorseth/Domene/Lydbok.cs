using System.Runtime.CompilerServices;

namespace Arbeidskrav1_TirilTorseth.Domene;

public class Lydbok : Media
{
    private string forfatter;
    private TimeSpan varighet;

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
    
    //KONSTRUKTØR
    public Lydbok(string Tittel,string Forfatter, int PubliseringsÅr, TimeSpan Varighet)
        : base(Tittel, PubliseringsÅr, 7)
    {
        this.Forfatter = Forfatter;
        this.Varighet = Varighet;
    }

    public override void VisInfo()
    {
        Console.WriteLine($"Lydbok: {Tittel} av {Forfatter}");
    }
}




    
    