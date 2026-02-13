using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Arbeidskrav1_TirilTorseth.Domene;

namespace Arbeidskrav1_TirilTorseth.Services;

/// <summary>
/// Klasse for et felles biblotek
/// Bibloteket inneholder funksjonen av de andre klassene sammen
/// </summary>
public class Bibliotek
{
    /// <summary>
    /// Oppretter nytt objekt Mediaregister i en liste, basert på Media objekt
    /// Inneholder alle medier
    /// </summary>
    public List<Media> MediaRegister = new List<Media>(); 
    
    /// <summary>
    /// Oppretter nytt objekt Brukerregister i en liste, basert på Bruker objekt
    /// Inneholder alle brukere
    /// </summary>
    public List<Bruker> BrukerRegister = new List<Bruker>(); 
    
    /// <summary>
    /// Oppretter nytt objekt Utlånshistorikk i en liste, basert på Utlån objekt
    /// Inneholder alle utlån
    /// </summary>
    public List<Utlån> UtlånsHistorikk = new List<Utlån>();

    /// <summary>
    /// Boolsk metode for å legge til media
    /// Tar inn Media objektet, Bruker objektet og meida og bruker variabler
    /// Sjekker om bruker er ansatt før media blir lagt til
    /// </summary>
    public bool LeggTilMedia(Media media, Bruker bruker)
    {   
        if (bruker is not Ansatt)
        {
            return false;
        }
        
        MediaRegister.Add(media);
        return true;
    }

    /// <summary>
    /// Metode som registrerer nye brukere og tar inn Bruker objekt og variabel bruker
    /// Sjekker om brukeren finnes, basert på epost og reurnerer null
    /// Legger til bruker og returnerer brukeren
    /// </summary>
    public Bruker RegistrerBruker(Bruker bruker)
    {
        if (BrukerRegister.Any(b => b.Epost == bruker.Epost))
        {
            return null;
        }

        BrukerRegister.Add(bruker);
        return bruker;

    }

    /// <summary>
    /// Metode som registrerer lån til bruker og returnerer lånet til utlån for lagring
    /// Tar inn mediaID og brukerID
    /// Dersom lånet ikke eksisterer registreres utlån til Utlånshistorikk og returnerer null hvis det gjør
    /// Returerer utlån til slutt
    /// </summary>
    public Utlån? LånMedia(string mediaID, string brukerID)
    {
        var bruker = BrukerRegister
            .FirstOrDefault(b => b.BrukerID == brukerID);

        if (bruker == null)
        {
            Console.WriteLine("Bruker eksisterer ikke.");
            return null;
        }

        if (!bruker.KanLåne())
        {
            Console.WriteLine("Bruker kan ikke låne flere medier.");
            return null;
        }

        var media = MediaRegister
            .FirstOrDefault(m => m.MediaID == mediaID);

        if (media == null)
        {
            Console.WriteLine("Mediet eksisterer ikke.");
            return null;
        }

        if (media.ErUtlånt)
        {
            Console.WriteLine("Mediet er allerede utlånt.");
            return null;
        }

        media.ErUtlånt = true;
        bruker.UtlånteMedier.Add(media);
        
        var utlån = new Utlån(media,bruker,DateTime.Now);
        UtlånsHistorikk.Add(utlån);
        
        return utlån;
    }
    
    /// <summary>
    /// Metode som registrerer innlevering av lån og returnerer leveringen til utlån for lagring
    /// Tar inn mediaID og brukerID
    /// Dersom lånet ikke eksisterer returneres null
    /// Dersom lånet eksisteres, registreres innlevering til utlånshistorikk og utlån returneres
    /// </summary>
    public Utlån? LeverInnMedia(string MediaID, string BrukerID)
    {
        var bruker = BrukerRegister
            .FirstOrDefault(b => b.BrukerID == BrukerID);

        if (bruker == null)
        {
            Console.WriteLine("Bruker eksisterer ikke.");
            return null;
        }

        var media = MediaRegister
            .FirstOrDefault(m => m.MediaID == MediaID);

        if (media == null)
        {
            Console.WriteLine("Mediet eksisterer ikke.");
            return null;
        }

        if (!media.ErUtlånt)
        {
            Console.WriteLine("Mediet er ikke utlånt.");
            return null;
        }

        var utlån = UtlånsHistorikk
            .FirstOrDefault(u =>
                u.media.MediaID == MediaID &&
                u.bruker.BrukerID == BrukerID &&
                u.InnlevertDato == null);

        if (utlån == null)
        {
            Console.WriteLine("Fant ikke aktivt lån.");
            return null;
        }

        media.ErUtlånt = false;
        bruker.UtlånteMedier.Remove(media);
        utlån.InnlevertDato = DateTime.Now;

        Console.WriteLine("Innlevering registrert.");
        Console.WriteLine($"{media.MediaID} - {media.Tittel}");

        return utlån;

    }

    /// <summary>
    /// Metode som viser alle medier som ikke er utlånt, ingen parametere
    /// Sjekker om media har status false eller ikke, før metoden VisInfo() kalles
    /// Returnerer ingenting
    /// </summary>
    public void VisTilgjengeligeMedier()
    {
        
        foreach (var media in MediaRegister)
        {
            if (media.ErUtlånt)
            {
                continue;
            }
            else
            { 
                media.VisInfo();
            }
        }
    }
    
    /// <summary>
    /// Metode som viser alle utlån, tar inn brukerID som parameter
    /// Sjekker om bruker eksisterer og skriver deretter ut om brukeren har registrerte lån eller ikke
    /// Returerer ingenting
    /// </summary>
    public void VisMineUtlån(string brukerID)
    {
        var bruker = BrukerRegister
            .FirstOrDefault(b => b.BrukerID == brukerID);

        if (bruker == null)
        {
            Console.WriteLine("Bruker eksisterer ikke.");
            return;
        }

        if (!bruker.UtlånteMedier.Any())
        {
            Console.WriteLine("Du har ingen aktive lån.");
            return;
        }
        

        foreach (var media in bruker.UtlånteMedier)
        {
            Console.WriteLine($"{media.MediaID} - {media.Tittel}");
        }
    }

}