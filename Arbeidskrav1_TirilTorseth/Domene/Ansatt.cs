namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Klasse for alle ansatte, arver fra Bruker
/// </summary>
public class Ansatt : Bruker
{
    private const int MaksLån = 10;

    /// <summary>
    /// Oppretter ansatt med navn og epost, arvet fra Bruker
    /// Tom konstruktør da en ansatt har samme variabler som en Bruker
    /// </summary>
    public Ansatt(string navn, string epost) :
        base(navn, epost)
    {
        
    }

    /// <summary>
    /// Boolsk metode som overrider lik metode i foreldreklassen
    /// Returnerer false eller true basert på hvor mange lån en ansatt kan låne 
    /// </summary>
    public override bool KanLåne()
    {
        return UtlånteMedier.Count < MaksLån;
    }
}