using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Arbeidskrav1_TirilTorseth.Domene;
using Arbeidskrav1_TirilTorseth.Services;


namespace Arbeidskrav1_TirilTorseth;

/// <summary>
/// Klasse for progammet som skal kjøres
/// </summary>
class Program
{
    /// <summary>
    /// Main metode: Her foregår kjøringen av alle bibloteksfilene
    /// Oppretter først objekter og legger inn data i systemet
    /// Inneholder meny og brukerinteraksjon
    /// Bruker switch for å kjøre de ulike valgene
    /// </summary>
    static void Main(string[] args)
    {
        //Lager bibliotek og legger inn data og objekter 
        var bibliotek = new Bibliotek();

        //Medlemmer
        bibliotek.BrukerRegister.Add(new Medlem("Anna Berg", "anna@gmail.com"));
        bibliotek.BrukerRegister.Add(new Medlem("Jonas Lie", "jonas@gmail.com"));
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

        
        //KJØRING
        while (true)
        {
            //Meny oppsett                                                           
            Console.WriteLine("\nTilgjengelige operasjoner:");                         
            Console.WriteLine(" 1. Vis medier");                                     
            Console.WriteLine(" 2. Lån medie");                                      
            Console.WriteLine(" 3. Lever inn medie");                                
            Console.WriteLine(" 4. Vis mine utlån");                                 
            Console.WriteLine(" 5. Legg til nytt medie (kun ansatte)");              
            Console.WriteLine(" 6. Registrer ny bruker");                            
            Console.WriteLine(" 0. Avslutt\n");                                        
                                                                         
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
            
            //Velg meny
            switch (velgMeny)
            {
                    //VALG 1 - VIS ALLE MEDIER
                    case 1:
                        
                    Console.WriteLine("\n=== Tilgjengelige medier ===\n");
                    
                    bibliotek.VisTilgjengeligeMedier();    
                    

                    break;

                    // VALG 2 - LÅN MEDIE
                    case 2:
                    Console.Write("\nSkriv inn BrukerID (B###): ");
                    string brukerID = Console.ReadLine();

                    Console.Write("Skriv inn MediaID (M###): ");
                    string mediaID = Console.ReadLine();

                    var registert = bibliotek.LånMedia(mediaID, brukerID);

                    if (registert == null)
                    {
                        Console.WriteLine("\nKunne ikke registrere lånet");
                    }
                    else
                    {
                        Console.WriteLine($"\n{registert.bruker.Navn} har lånt '{registert.media.Tittel}'\nForventet innlevering er: {registert.ForventetInnleveringsDato}");

                    }


                    break;
                    
                    //VALG 3 - LEVER INN MEDIE
                    case 3:
                        Console.Write("\nSkriv inn BrukerID (B###): ");  
                        string LeverMedieBruker = Console.ReadLine();          
                                               
                        Console.Write("Skriv inn MediaID (M###): ");   
                        string LeverMedieMedia = Console.ReadLine();           
                                               
                        var registrerLeverInn = bibliotek.LeverInnMedia(LeverMedieMedia, LeverMedieBruker);  
                        
                        if (registrerLeverInn == null)
                        {
                            Console.WriteLine("\nLånet er ikke registrert");
                        }
                        else
                        {
                            Console.WriteLine($"\n{registrerLeverInn.bruker.Navn} har levert inn '{registrerLeverInn.media.Tittel}'\n");

                        }
                        
                        break;
                    
                    // VALG 4 - VIS MINE LÅN
                    case 4:
                        Console.Write("\nSkriv inn BrukerID (B###): ");
                        string VisMineLån = Console.ReadLine();
                        
                        Console.WriteLine("\n=== Dine lån ===\n"); 
                        
                        bibliotek.VisMineUtlån(VisMineLån);
                        
                        break;
                    
                    
                    //Legg til nytt medie
                    case 5:
                        Console.Write("Skriv inn din BrukerID (B###):");
                        string sjekkAnsatt = Console.ReadLine();
                        
                        var bruker = bibliotek.BrukerRegister
                            .FirstOrDefault(b => b.BrukerID == sjekkAnsatt);

                        if (bruker == null)
                        {
                            Console.WriteLine("Bruker finnes ikke.");
                            break;
                        }

                        if (!(bruker is Ansatt))
                        {
                            Console.WriteLine("Kun ansatte kan registrere nye medier");
                            break;

                        }

                        Console.Write("\n1. Bok" +
                                      "\n2. Lydbok" +
                                      "\n3. Ebok" +
                                      "\n4. Tidskrift" +
                                      "\nVelg medietype du skal registrere:");
                            string TypeMedie = Console.ReadLine();

                            switch (TypeMedie)
                            {
                                case "1":
                                    Console.Write("Tittel: ");
                                    string Tittel = Console.ReadLine();

                                    Console.Write("Forfatter: ");
                                    string Forfatter = Console.ReadLine();

                                    Console.Write("Publiseringsår: ");
                                    string Publiseringsår = Console.ReadLine();
                                    int PubliseringsÅr = int.Parse(Publiseringsår);

                                    Console.Write("Antall sider: ");
                                    string AntallSid = Console.ReadLine();
                                    int AntallSider = int.Parse(AntallSid);

                                    var NyBok = new Bok(Tittel, Forfatter, PubliseringsÅr, AntallSider);

                                    bool RegBok = bibliotek.LeggTilMedia(NyBok, bruker);

                                    if (RegBok)
                                    {
                                        Console.WriteLine($"[{bruker.BrukerID}] har lagt til en ny bok: '{NyBok.Tittel}' ");
                                    }

                                    break;

                                case "2":
                                    Console.Write("Tittel: ");
                                    string Tittel2 = Console.ReadLine();

                                    Console.Write("Forfatter: ");
                                    string Forfatter2 = Console.ReadLine();

                                    Console.Write("Publiseringsår: ");
                                    string Publiseringsår2 = Console.ReadLine();
                                    int PubliseringsÅr2 = int.Parse(Publiseringsår2);

                                    Console.Write("Varighet (: ");
                                    int Varighe = int.Parse(Console.ReadLine());
                                    TimeSpan Varighet = new TimeSpan(Varighe, 0, 0);

                                    var NyLydbok = new Lydbok(Tittel2, Forfatter2, PubliseringsÅr2, Varighet);

                                    bool RegLydbok = bibliotek.LeggTilMedia(NyLydbok, bruker);

                                    if (RegLydbok)
                                    {
                                        Console.WriteLine($"[{bruker.BrukerID}] har lagt til en ny ebok: '{NyLydbok.Tittel}' ");
                                    }

                                    break;

                                case "3":
                                    Console.Write("Tittel: ");
                                    string Tittel3 = Console.ReadLine();

                                    Console.Write("Forfatter: ");
                                    string Forfatter3 = Console.ReadLine();

                                    Console.Write("Publiseringsår: ");
                                    string Publiseringsår3 = Console.ReadLine();
                                    int PubliseringsÅr3 = int.Parse(Publiseringsår3);

                                    Console.Write("Varighet (: ");
                                    string MegaBite = Console.ReadLine();
                                    int MB = int.Parse(MegaBite);

                                    var NyEbok = new Ebok(Tittel3, Forfatter3, PubliseringsÅr3, MB);

                                    bool RegEbok = bibliotek.LeggTilMedia(NyEbok, bruker);

                                    if (RegEbok)
                                    {
                                        Console.WriteLine($"[{bruker.BrukerID}] har lagt til en ny ebok: '{NyEbok.Tittel}' ");
                                    }

                                    break;

                                case "4":
                                    Console.Write("Tittel: ");
                                    string Tittel4 = Console.ReadLine();

                                    Console.Write("Utgavenummer: ");
                                    string UtgaveNummer = Console.ReadLine();
                                    int UtgaveNmr = int.Parse(UtgaveNummer);

                                    Console.Write("Måned: ");
                                    string Måned = Console.ReadLine();

                                    Console.Write("Publiseringsår: ");
                                    string Publiseringsår4 = Console.ReadLine();
                                    int PubliseringsÅr4 = int.Parse(Publiseringsår4);

                                    var NyTidsskrift = new Tidsskrift(Tittel4, UtgaveNmr, Måned, PubliseringsÅr4);

                                    bool RegTidsskrift = bibliotek.LeggTilMedia(NyTidsskrift, bruker);

                                    if (RegTidsskrift)
                                    {
                                        Console.WriteLine(
                                            $"[{bruker.BrukerID}] har lagt til en ny bok: '{NyTidsskrift.Tittel}' ");
                                    }

                                    break;
                        }
                        break;
                    
                    
                    
                    // Registrer ny bruker
                    case 6:
                        Console.Write("\nRegistrer medlem (1) eller ansatt (2): ");
                        string VelgType = Console.ReadLine();

                        if (VelgType == "1")
                        {
                            Console.Write("\nSkriv inn Navn: ");
                            string RegistrerNavnMedlem = Console.ReadLine();
                            
                            Console.Write("Skriv inn Epost: ");
                            string RegistrerEpostMedlem = Console.ReadLine();
                            
                            var NyttMedlem = new Medlem(RegistrerNavnMedlem, RegistrerEpostMedlem);
                            
                            var registrert = bibliotek.RegistrerBruker(NyttMedlem);

                            Console.WriteLine($"\nNytt medlem lagt til: [{registrert.BrukerID}] [{registrert.Navn}] [{registrert.Epost}]");
                        }
                            
                        if (VelgType == "2") 
                        {
                            Console.Write("\nSkriv inn Navn: ");
                            string RegistrerNavnAnsatt = Console.ReadLine();
                        
                            Console.Write("Skriv inn Epost: ");
                            string RegistrerEpostAnsatt = Console.ReadLine();
                        
                            var NyAnsatt = new Ansatt(RegistrerNavnAnsatt, RegistrerEpostAnsatt);
                        
                           var registrert = bibliotek.RegistrerBruker(NyAnsatt);
                            
                            Console.WriteLine($"\nNy ansatt lagt til: [{registrert.BrukerID}] [{registrert.Navn}] [{registrert.Epost}]");
                        }
                        
                        break;
                    
                    
                    // VALG 0 - AVSLUTT PROGRAM
                    case 0:
                        Console.WriteLine("\nProgram avsluttet. Hadet!");  
                        return;
                    
            }
        }
    }
}