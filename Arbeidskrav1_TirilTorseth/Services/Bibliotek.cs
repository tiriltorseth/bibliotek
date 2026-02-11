using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Arbeidskrav1_TirilTorseth.Domene;

namespace Arbeidskrav1_TirilTorseth.Services;

public class Bibliotek
{
    public List<Media> MediaRegister = new List<Media>(); 
    public List<Bruker> BrukerRegister = new List<Bruker>(); 
    public List<Utlån> UtlånsHistorikk = new List<Utlån>();

    public void LeggTilMedia(Media media, Bruker bruker)
    {   
        if (bruker is Ansatt)
        {
            MediaRegister.Add(media);
        }
    }

    public void RegistrerBruker(Bruker bruker)
    {
        BrukerRegister.Add(bruker); // hva skjer hvis den allerede eksisterer???
    }

    public void LånMedia(string mediaID, string brukerID)
    {
        var bruker = BrukerRegister
            .FirstOrDefault(b => b.BrukerID == brukerID);

        if (bruker == null)
        {
            Console.WriteLine("Bruker eksisterer ikke.");
            return;
        }

        if (!bruker.KanLåne())
        {
            Console.WriteLine("Bruker kan ikke låne flere medier.");
            return;
        }

        var media = MediaRegister
            .FirstOrDefault(m => m.MediaID == mediaID);

        if (media == null)
        {
            Console.WriteLine("Mediet eksisterer ikke.");
            return;
        }

        if (media.ErUtlånt)
        {
            Console.WriteLine("Mediet er allerede utlånt.");
            return;
        }

        media.ErUtlånt = true;
        bruker.UtlånteMedier.Add(media);
        
        var utlån = new Utlån(media,bruker,DateTime.Now);
        UtlånsHistorikk.Add(utlån);

        Console.WriteLine("Lånet er registrert!.");
    }
    
    

    public void LeverInnMedia(string MediaID, string BrukerID)
    {
        var bruker = BrukerRegister
            .FirstOrDefault(b => b.BrukerID == BrukerID);

        if (bruker == null)
        {
            Console.WriteLine("Bruker eksisterer ikke.");
            return;
        }

        var media = MediaRegister
            .FirstOrDefault(m => m.MediaID == MediaID);

        if (media == null)
        {
            Console.WriteLine("Mediet eksisterer ikke.");
            return;
        }

        if (!media.ErUtlånt)
        {
            Console.WriteLine("Mediet er ikke utlånt.");
            return;
        }

        var utlån = UtlånsHistorikk
            .FirstOrDefault(u =>
                u.media.MediaID == MediaID &&
                u.bruker.BrukerID == BrukerID &&
                u.InnlevertDato == null);

        if (utlån == null)
        {
            Console.WriteLine("Fant ikke aktivt lån.");
            return;
        }

        media.ErUtlånt = false;
        bruker.UtlånteMedier.Remove(media);
        utlån.InnlevertDato = DateTime.Now;

        Console.WriteLine("Innlevering registrert.");
        Console.WriteLine($"{media.MediaID} - {media.Tittel}");

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