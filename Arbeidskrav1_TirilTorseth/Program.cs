using System.Runtime.InteropServices;
using Arbeidskrav1_TirilTorseth.Domene;
using Arbeidskrav1_TirilTorseth.Services;

namespace Arbeidskrav1_TirilTorseth;

class Program
{
    static void Main(string[] args)
    {
        //Lager bibliotek og legger inn data og objekter 
        var bibliotek = new Bibliotek();

        //Medlemmer
        bibliotek.BrukerRegister.Add(new Medlem("Anna Berg", "anna@gmail.com"));
        bibliotek.BrukerRegister.Add(new Medlem("Jonas Lie", " jonas@gmail.com"));
        bibliotek.BrukerRegister.Add(new Medlem("Sara Hansen", "saara@gmail.com"));

        //Ansatte
        bibliotek.BrukerRegister.Add(new Ansatt("Kari Nordmann", "kari@gmail.com"));
        bibliotek.BrukerRegister.Add(new Ansatt("Ola Oppegård", "ola@gmail.com"));
        bibliotek.BrukerRegister.Add(new Ansatt("Per Sanden", "per@gmail.com"));

        //Media - Bok
        bibliotek.MediaRegister.Add(new Bok("Ringenes Herre", "J.R.R Tolkien", 1954, 1178));
        bibliotek.MediaRegister.Add(new Bok("1984", "George Orwell", 1949, 328));
        bibliotek.MediaRegister.Add(new Bok("Sapiens", "Yuval Noah Harari", 2011, 498));

        //Media - Lydbok
        bibliotek.MediaRegister.Add(new Lydbok("Harry Potter", "J.K.Rowling", 1997, new TimeSpan(8, 32, 00)));
        bibliotek.MediaRegister.Add(new Lydbok("Atomvaner", "James Clear", 2018, new TimeSpan(5, 10, 00)));
        bibliotek.MediaRegister.Add(new Lydbok("Dune", "Frank Herbert", 1965, new TimeSpan(21, 02, 00)));

        //Media - Ebok
        bibliotek.MediaRegister.Add(new Ebok("Clean Code", "Robert C. Martin", 2008, 5.4));
        bibliotek.MediaRegister.Add(new Ebok("Deep work", "Cal Newport", 2016, 3.1));
        bibliotek.MediaRegister.Add(new Ebok("Python Crash Course", "Eric Matthes", 2019, 7.8));

        //Media - Tidsskrift
        bibliotek.MediaRegister.Add(new Tidsskrift("Illustrert Vitenskap", 202, "Januar", 2025));
        bibliotek.MediaRegister.Add(new Tidsskrift("National Geographic", 145, "Februar", 2025));
        bibliotek.MediaRegister.Add(new Tidsskrift("Teknisk Ukeblad", 88, "Mars", 2025));


        //Meny oppsett

        Console.WriteLine("Tilgjengelige operasjoner:");
        Console.WriteLine(" 1. Vis medier");
        Console.WriteLine(" 2. Lån medie");
        Console.WriteLine(" 3. Lever inn medie");
        Console.WriteLine(" 4. Vis mine utlån");
        Console.WriteLine(" 5. Legg til nytt medie (kun ansatte)");
        Console.WriteLine(" 6. Registrer ny bruker");
        Console.WriteLine(" 0. Avslutt");

        Console.Write("Velg alternativ (0-6): ");

        int HentGyldigValg(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valg)
                    && valg >= min && valg <= max)
                {
                    return valg;
                }

                Console.Write("Ugyldig valg. Prøv igjen: \n");
            }
        }

        int velgMeny = HentGyldigValg(0, 6);


        //KJØRING
        switch (velgMeny)
        {
            //VALG 1 - VIS ALLE MEDIER
            case 1:
                Console.WriteLine("\n=== Tilgjengelige medier ===\n");
                foreach (var bok in bibliotek.MediaRegister.OfType<Bok>())
                {
                    Console.WriteLine(
                        $"[{bok.MediaID}] - '{bok.Tittel}' av {bok.Forfatter} ({bok.PubliseringsÅr}), {bok.AntallSider} sider");
                }

                foreach (var bok in bibliotek.MediaRegister.OfType<Lydbok>())
                {
                    Console.WriteLine(
                        $"[{bok.MediaID}] - '{bok.Tittel}' av {bok.Forfatter} ({bok.PubliseringsÅr}) - {bok.Varighet}");
                }

                foreach (var bok in bibliotek.MediaRegister.OfType<Ebok>())
                {
                    Console.WriteLine(
                        $"[{bok.MediaID}] - '{bok.Tittel}' av {bok.Forfatter} ({bok.PubliseringsÅr}), {bok.FilStørrelse} MB");
                }

                foreach (var bok in bibliotek.MediaRegister.OfType<Tidsskrift>())
                {
                    Console.WriteLine(
                        $"[{bok.MediaID}] - '{bok.Tittel}' - Utgave nr. {bok.UtgaveNummer}, {bok.Måned}  {bok.PubliseringsÅr}");

                }

                break;

            // VALG 2 - LÅN MEDIE
            case 2:
                Console.Write("Skriv inn BrukerID: ");
                string brukerID = Console.ReadLine();

                Console.Write("Skriv inn MediaID: ");
                string mediaID = Console.ReadLine();

                bibliotek.LånMedia(mediaID, brukerID);

                break;



        }
    }
}