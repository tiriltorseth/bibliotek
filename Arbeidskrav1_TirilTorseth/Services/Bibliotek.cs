using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Arbeidskrav1_TirilTorseth.Domene;

namespace Arbeidskrav1_TirilTorseth.Services;

public class Bibliotek
{
    public List<Media> MediaRegister = new List<Media>(); 
    public List<Bruker> BrukerRegister = new List<Bruker>(); 
    public List<Utlån> UtlånsHistorikk = new List<Utlån>();

    public bool LeggTilMedia(Media media, Bruker bruker)
    {   
        if (bruker is not Ansatt)
        {
            return false;
        }
        
        MediaRegister.Add(media);
        return true;
    }

    public Bruker RegistrerBruker(Bruker bruker)
    {
        if (BrukerRegister.Any(b => b.Epost == bruker.Epost))
        {
            return null;
        }

        BrukerRegister.Add(bruker);
        return bruker;

    }

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

    public void VisTilgjengeligeMedier()
    {
        Console.WriteLine(MediaRegister);
    }

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