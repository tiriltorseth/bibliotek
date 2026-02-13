namespace Arbeidskrav1_TirilTorseth.Domene;

/// <summary>
/// Klasse for alle medlemmer, arver fra Bruker
/// </summary>
public class Medlem : Bruker
{
    private const int MaksLån = 5;

    /// <summary>
    /// Oppretter medlem med navn og epost, som er arvet fra Bruker-klassen
    /// Tom konstruktør da medlem har samme variabler som bruker
    /// </summary>
    public Medlem(string navn, string epost) :
        base(navn, epost)
    {
        
    }

    /// <summary>
    /// Boolsk metode som overrider lik metode i foreldreklassen
    /// Returnerer false eller true basert på hvor mange lån et medlem kan låne 
    /// </summary>
    public override bool KanLåne()
    {
        return UtlånteMedier.Count < MaksLån;
    }
}