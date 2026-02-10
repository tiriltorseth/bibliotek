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

    public void LånMedia(string MediaID, string BrukerID)
    {
        foreach (var bruker in BrukerRegister)
        {
            if (bruker.BrukerID == BrukerID)
            {
                if (bruker.KanLåne())
                {
                    foreach (var media in MediaRegister)
                    {
                        if (media.MediaID == MediaID)
                        {
                            if (!media.ErUtlånt)
                            {
                                media.ErUtlånt = true;
                                bruker.UtlånteMedier.Add(media);
                                UtlånsHistorikk.Add(new Utlån(media, bruker, DateTime.Now));
                            }
                            else
                            {
                                Console.WriteLine("Mediet er allerede utlånt!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mediet eksisterer ikke, få ansatt til å legge til mediet først.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bruker kan ikke låne flere medier, maks utlånte medier er nådd.");
                }
            }
            else
            {
                Console.WriteLine("Feil: Bruker eksisterer ikke, registerer bruker først.");
            }
        }
    }

    public void LeverInnMedia(string MediaID, string BrukerID)
    {
        foreach (var bruker in BrukerRegister)
        {
            if (bruker.BrukerID == BrukerID)
            {
                foreach (var media in MediaRegister)
                {
                    if (media.MediaID == MediaID)
                    {
                        if (media.ErUtlånt)
                        {
                            media.ErUtlånt = false; // leverer inn
                            bruker.UtlånteMedier.Remove(media);
                            foreach (var utlån in UtlånsHistorikk)
                            {
                                if (utlån.media.MediaID == MediaID)
                                {
                                    utlån.InnlevertDato = DateTime.Now;
                                }
                                else
                                {
                                    Console.WriteLine("Du har ikke lånt dette mediet. Kan ikke levere inn noe du ikke har lånt.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mediet er allerede utlånt!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Mediet eksisterer ikke, få ansatt til å legge til mediet først.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Feil: Bruker eksisterer ikke, registerer bruker først.");
            }
        }
        
    }

    public void VisTilgjengeligeMedier()
    {
        Console.WriteLine(MediaRegister);
    }

    public void VisMineUtlån(string BrukerID)
    {
        foreach (var bruker in BrukerRegister)
        {
            if (bruker.BrukerID == BrukerID)
            {
                Console.WriteLine("Dine utlån: " + bruker.UtlånteMedier);
            }
            else
            {
                Console.WriteLine("Feil: Bruker eksisterer ikke, registerer bruker først.");
            }
        }
    }
}