using System.Data;

namespace Arbeidskrav1_TirilTorseth.Domene;

public class Ebok : Media
{
    private string forfatter;
    private double filStørrelse;
    
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

    public double FilStørrelse
    {
        get => filStørrelse;
        protected set
        {
            if (value <= 0 || value > 50)
                throw new ArgumentException("Filstørrelsen må være større enn 0 MB og mindre enn 50 MB .");
            filStørrelse = value;
        }
    }
    
    //KONSTRUKTØR
    public Ebok(string Tittel,string Forfatter, int PubliseringsÅr,  double FilStørrelse)
        : base(Tittel, PubliseringsÅr, 21)
    {
        this.Forfatter = Forfatter;
        this.FilStørrelse = FilStørrelse;

    }
    
    public override void VisInfo()
    {
        Console.WriteLine($"Ebok: {Tittel} av {Forfatter}");
    }
    
    
}