namespace Arbeidskrav1_TirilTorseth.Domene;

public class Medlem : Bruker
{
    private const int MaksLån = 5;

    public Medlem(string navn, string epost) :
        base(navn, epost)
    {
        
    }

    public override bool KanLåne()
    {
        return UtlånteMedier.Count < MaksLån;
    }
}