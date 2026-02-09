namespace Arbeidskrav1_TirilTorseth.Domene;

public class Ansatt : Bruker
{
    private const int MaksLån = 10;

    public Ansatt(string navn, string epost) :
        base(navn, epost)
    {
        
    }

    public override bool KanLåne()
    {
        return UtlånteMedier.Count < MaksLån;
    }
}