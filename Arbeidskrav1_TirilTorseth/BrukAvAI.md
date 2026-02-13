## Bruk av AI i Arbeidskrav 1

**Omtrent all kode har blitt feilsøkt med AI for å unngå unødvendige feil.** 

*Etter en klasse har blitt kodet ferdig, 
har den blitt limt inn i ChatGPT for å sjekke for eventuelle slurvefeil i Console.WriteLine, 
mellomrom feil, "utseende" feil og lignende. Dette er gjort for å unngå risiko for at slurvefeil har blitt
igjen i arbeidskravet.*

**Svar med kodesnutter som er brukt i oppgaven er dokumentert, sparring og logisk nedbrytning 
av oppgaver er ikke inkludert.**

Jeg har satt AI  til å svare med så lite kodeeksempler som mulig og heller koble det sammen med
Python slik at jeg forstår mens jeg koder og oversetter konseptene på egenhånd.

***!!!Viktig!!!***

Mot slutten av dokumentasjonen vil det vises at jeg hadde et uhell lukking av en fane, noe som førte til at deler av 
lagringen ikke lenger var tilgjengelig. Dette var spørsmål knyttet til koblingen mellom Bibliotek og Program og er derfor helt i slutten av gjennomførelsen.
I den forbindelse har jeg bedt AI om å rekonstruere de spørsmålene jeg tidligere 
stilte, samt kodesnutter som jeg har inkludert i oppgaven, basert på det jeg ikke lenger har tilgang til.

Jeg har også ført korte notater underveis om hvilke konkrete ting jeg fikk hjelp til, og minnet AI på disse i etterkant 
for å sikre at alt vesentlig ble med.

Dersom dette ikke anses som gyldig dokumentasjon av AI, eller sensor har spørsmål, tar jeg gjerne en prat for å vise at 
jeg har forstått løsningene jeg har implementert, og at AI kun har vært brukt som støtte for læring og forståelse.

Til neste arbeidskrav vil ikke den samme feilen bli gjentatt.

### Spørringer og svar:

**Prompt:**
Etter flere logiske nedbrytninger av oppgaven spurte jeg om et annet eksempel slik at jeg kunne se det i praksis og 
da ble det laget en treningsapp med lignende flyt i interaksjonen. Her har jeg hentet ut et eksempel på hvordan propertien
navn ble skrevet og basert alle kommende properties på dette.

**Svar:**

        public string Navn
        {
            get => navn;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Navn kan ikke være tomt.");

                navn = value;
            }
        }


**Prompt:**
Hvordan får jeg dette formatet på idene mine? B001, for nå får jeg bare til å sette vanlig tall som øker automatisk?
**Svar:**

        øktId = $"ØKT{idTeller++:D3}";


**Prompt:**
I en "Hvorfor er dette feil-spørring": Første utkast av media klassen:

    using System;
    
    namespace Arbeidskrav1_TirilTorseth.Domene;
    
    /// <summary>
    /// Abstrakt baseklasse for all media
    /// </summary>
    public abstract class Media
    {
    // STATIC ID-GENERATOR
    private static int mediaTeller = 0;

    // PRIVATE FELTER
    public string MediaID { get; }

    protected Media()
    {
        mediaTeller++;
        MediaID = "M" + mediaTeller.ToString("D3");
    }

    private string tittel;
    private int publiseringsÅr;
    private bool erUtlånt;
    private int lånePeriodeDager;
    
    // public MediaID => mediaID;

    public string Tittel
    {
        get => tittel;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Navn kan ikke stå tomt.");
        }
    }

    public int PubliseringsÅr
    {
        get => publiseringsÅr;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Publiseringsår kan ikke stå tomt.");
            
            if (value >= 1400 || value < 2026)
                throw new ArgumentException("Årstallet er ugyldug.");
            
            publiseringsÅr = value;
        }
    }

    public bool ErUtlånt
    {
        get => erUtlånt;
        protected set => erUtlånt = value;
    }

    public int LånePeriodeDager
    {
        get => lånePeriodeDager;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Låneperioden kan ikke stå tom.");

            if (value > 30 || value < 1)
                throw new ArgumentException("Låneperioden kan ikke være lenger enn 30 dager eller mindre enn én dag");
            
            lånePeriodeDager = value;
            
        }
        
        //KONSTRUKTØR
        
        protected Media(string MediaID, string Tittel, int PubliseringsÅr, int LånePeriodeDager){

        MediaID = $"M{mediaTeller++:D3}";
        Tittel = tittel;
        PubliseringsÅr = publiseringsÅr;
        LånePeriodeDager = lånePeriodeDager;
        ErUtlånt = false;
    }
    // ABSTRAKT METODE
    public abstract void VisInfo();
}




**Svar:**
Det var flere feil jeg løste selv via forklaringer,da jeg har satt min AI til å kode minst mulig for meg og kun bruke eksempler der det ikke kan forklares 
lett med ord. 

Du overskriver parametere i stedet for felt

I konstruktøren:

        Tittel = tittel;
        PubliseringsÅr = publiseringsÅr;
        LånePeriodeDager = lånePeriodeDager;

Hva er feil?

Dette er baklengs.

tittel er felt

Tittel er property

Du setter property = felt (som er tomt)

Riktig rekkefølge

        this.Tittel = Tittel;
        this.PubliseringsÅr = PubliseringsÅr;
        this.LånePeriodeDager = LånePeriodeDager;

**Prompts:**
Hva tenker du om denne? ok? 
    
    using System.Data;
    namespace Arbeidskrav1_TirilTorseth.Domene;
    
    public class Ebok : Media
    {
    private string forfatter;
    private double filStørrelse;

    public string Forfatter
    {
        get => forfatter;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Forfatter kan ikke stå tomt.");
            forfatter = value;
        }
    }

    public double FilStørrelse
    {
        get => filStørrelse;
        protected set
        {
            if (value < 0)
                throw new ArgumentException("Filstørrelsen kan ikke stå tom.");
            filStørrelse = value;
        }
    }
    
    //KONSTRUKTØR
    public Ebok(string Tittel, int PubliseringsÅr, string Forfatter, double FilStørrelse)
        : base(Tittel, PubliseringsÅr, 21)
    {
        this.Forfatter = Forfatter;
        this.FilStørrelse = FilStørrelse;

    }
    
    public override void VisInfo()
    {
        Console.WriteLine($"Ebok: {Tittel} av {Forfatter}");
    }

**Svar:**
Litt bedre validering av FilStørrelse
    if (value < 0)
    throw new ArgumentException("Filstørrelsen kan ikke stå tom.");


To små ting her:

En double kan ikke være “tom”

0 MB er sannsynligvis også ugyldig

Bedre:

    if (value <= 0)
    throw new ArgumentException("Filstørrelsen må være større enn 0.");


**Prompt:**
Feilsøk brukerklassen min er du grei 
    
    namespace Arbeidskrav1_TirilTorseth.Domene;

    /// <summary>
    /// Abstrakt baseklasse for alle brukere
    /// </summary>
    
    public abstract class Bruker
    {
    // Statisk id generator
    private static int brukerTeller = 0;

    // BrukerID, public
    public string BrukerID { get; }
    
    //Private felter
    private string navn;
    private string epost;
    private List<Media> utlånteMedier;

    public string Navn
    {
        get => navn;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Navnet kan ikke stå tomt.");
            navn = value;
        }
    }

    public string Epost
    {
        get => epost;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Epost kan ikke stå tomt.");
            epost = value;
        }
    }

    public List<Media> UtlånteMedier { get; }
    
    //KONSTRUKTØR
    protected Bruker(string navn, string epost)
    {
        brukerTeller++;
        BrukerID = brukerTeller.ToString("D3");
        this.Navn = navn;
        this.Epost = epost;
        UtlånteMedier = new List<Media>();
    }
    
    // Abstrakt metode
    public abstract bool KanLåne();


**Svar:**
1. Reell feil: utlånteMedier brukes aldri

Du har både:

private List<Media> utlånteMedier;


og

public List<Media> UtlånteMedier { get; }

Problemet

Feltet utlånteMedier brukes ikke

Propertyen UtlånteMedier har ingen backing field

I konstruktøren gjør du:

    UtlånteMedier = new List<Media>();


👉 Dette funker kun fordi propertyen har get; og ingen set, som betyr:

C# lager et auto-property backing field

feltet utlånteMedier blir helt overflødig

Løsning (velg én)
✅ Alternativ A – fjern feltet (anbefalt)

Bare slett denne linjen:

    private List<Media> utlånteMedier;

Dette er helt korrekt og ryddig.

**Prompt:**
Kan du tolke dette for meg: Media (Media) -- referanse til mediet?

**Svar:**
Hvordan jeg ville modellert dette (konseptuelt)

Avhengig av hva som skal ha referansen:

Eksempel 1: Et utlån

Hvis du har et konsept som “Utlån”:

    public class Utlån
    {
    public Media Media { get; }
    public Bruker Bruker { get; }

    public Utlån(Media media, Bruker bruker)
    {
        Media = media;
        Bruker = bruker;
    }
}


👉 Her er Media (Media) helt bokstavelig oppfylt:

property heter Media

typen er Media

det er en referanse

Eksempel 2: Bruker har referanser til medier

Du har allerede dette (og det er riktig):

    public List<Media> UtlånteMedier { get; }

Dette betyr:

brukeren har referanser til flere Media-objekter

ikke kopier

samme objekt deles mellom systemet

**Prompt:**
AI har blitt brukt for å autogenerere data til Bibliotek.

Generer data for dette i et rutenett: 1. Medieklasser
Lag en abstrakt baseklasse Media med følgende fellesegenskaper:
• Tittel (string)
• MediaID (string) -- autogenerert, unik identifikator
• Publiseringsår (int)
• ErUtlånt (bool) -- status for om mediet er utlånt
• LånePeriodeDager (int) -- antall dager mediet kan lånes
Abstrakt metode: VisInfo() -- må implementeres av alle arvede klasser for å vise mediespesifikk
informasjon.
Lag følgende konkrete klasser som arver fra Media:
• Bok -- Forfatter (string), AntallSider (int), LånePeriodeDager = 14
• Lydbok -- Forfatter (string), Varighet (TimeSpan), LånePeriodeDager = 7
• EBok -- Forfatter (string), FilStørrelse (double i MB), LånePeriodeDager = 21
• Tidsskrift -- Utgavenummer (int), Måned (string), LånePeriodeDager = 3
Hver klasse må implementere VisInfo() for å vise relevant informasjon om mediet.
2. Brukerklasser
   Lag en abstrakt baseklasse Bruker med:
   • BrukerID (string) -- autogenerert, unik
   • Navn (string)
   • Epost (string)
   • UtlånteMedier (List<Media>) -- liste over medier brukeren har lånt
   Abstrakt metode: KanLåne() -- returnerer bool og bestemmer om brukeren har lov til å låne flere
   medier.
   Lag følgende konkrete brukerklasser:
   • Medlem -- Kan låne maks 5 medier samtidig
   • Ansatt -- Kan låne maks 10 medier samtidig, har tilgang til å legge til nye medier
   Implementer KanLåne() basert på brukerens utlånsgrense.. kun generer der jeg trenger data, feks 3 per medie, 3 ansatte og 3 medlemmer

**Svar:**

Der fikk jeg en wordfil med all den dataen som er lagt inn, kun rå data i rutenett, den er skrevet selv om til kode. Legger ved eksempel:

| MediaID | Tittel         | Forfatter         | Antall sider | Publiseringsår | ErUtlånt | Låneperiode (dager) |
| ------- | -------------- | ----------------- | ------------ | -------------- | -------- | ------------------- |
| M001    | Ringenes Herre | J.R.R. Tolkien    | 1178         | 1954           | false    | 14                  |
| M002    | Sapiens        | Yuval Noah Harari | 498          | 2011           | true     | 14                  |
| M003    | 1984           | George Orwell     | 328          | 1949           | false    | 14                  |


**Prompt:**
spørsmål. brukerid og medieid, skal være autogenerert, men burde vel fortsstt legge de til i objektet eller? bare kalle på de ? litt forvirret der siden de ikke er en del av parameterene

**Svar:**
YES. Nå er du inne på noe viktig 👌
Dette er et klassisk OOP-punkt mange blir forvirret av.

🔹 Kort svar

Ja — BrukerID og MediaID skal være en del av objektet.

Men:

De skal ikke være parametere i konstruktøren.

De skal:

genereres automatisk

settes internt

aldri kunne endres utenfra

🧠 Tenk sånn

Når du lager et objekt:

    var bok = new Bok("Harry Potter", "J.K. Rowling", 1997);


Du skal ikke skrive:

    new Bok("M001", "Harry Potter", ...)

Fordi:

ID er systemets ansvar

Ikke brukerens ansvar

Lag public property (kun get)
    
    public string MediaID => mediaId;


Nå kan du gjøre:

    Console.WriteLine(bok.MediaID);


Men du kan IKKE gjøre:

    bok.MediaID = "M999";  ❌


**Prompt**: Hva skal jeg kalle variablen makslån? den er en private hva? 

**Svar:**     

Da kan du bruke const! Makslån er en variabel som ikke skal endres og derfor kan du bruke en const = konstant.
    
    private const int MaksLån = 5;


***Videre dokumentasjon er gjengitt av AI da ChatGPT sletter deler av lange tråder og 
jeg var uheldig å lukke den ene tråden***

**Prompt:**
Jeg hadde kode i Program-fila som skulle finne en bruker i BrukerRegister basert på innlest BrukerID.
Jeg brukte en foreach-løkke, men koden ble tung og jeg fikk feil ved sjekk av null. Jeg spurte om en bedre måte å finne bruker i listen.

Dette var min kode:  

    Bruker funnet = null;

    foreach (var b in bibliotek.BrukerRegister)
    {
    if (b.BrukerID == sjekkAnsatt)
    {
    funnet = b;
    break;
    }
    }
    
    if (sjekkAnsatt == null)
    {
    Console.WriteLine("Bruker finnes ikke.");


**Svar:**

AI foreslo å bruke LINQ-metoden FirstOrDefault, som returnerer første element som matcher en betingelse, eller null hvis ingen finnes.

    var bruker = bibliotek.BrukerRegister
    .FirstOrDefault(b => b.BrukerID == sjekkAnsatt);
    
    if (bruker == null)
    {
    Console.WriteLine("Bruker finnes ikke.");
}

**Prompt:**
Jeg var usikker på om fiktive testdata (brukere og medier) skulle legges i domeneklassene eller i Program-fila, og spurte hvor det var riktig å opprette objekter.

**Svar:**

    var bibliotek = new Bibliotek();

    // Opprette medier
    var bok1 = new Bok("Sult", 1890, "Knut Hamsun", 200);

    // Legge i register
    bibliotek.MediaRegister.Add(bok1);

**Prompt:**
Feilsøk: Studenten sjekket input-variabelen i stedet for funnet objekt.
**Svar:**
Feil:

    if (sjekkAnsatt == null)


AI forklarte at man må sjekke resultatet fra søket:

Riktig:

    if (bruker == null)


**Prompt:**
Studentspørsmål

Jeg hadde en metode i bibliotekklassen (LånMedia) for å låne ut et medium til en bruker.
Koden min hadde mange nestede if-setninger for å sjekke:

om bruker finnes

om bruker kan låne

om media finnes

om media er utlånt

Jeg spurte om det fantes en bedre og mer lesbar måte å strukturere dette på. Se min kode under:
    
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

**Svar:**

AI foreslo å snu logikken og bruke tidlige returpunkter (“guard clauses”), der metoden avslutter så snart en regel brytes.

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

    var utlån = new Utlån(media, bruker, DateTime.Now);
    UtlånsHistorikk.Add(utlån);

    return utlån;
}



**Prompt:**
Denne vil ikke funke: 

    if ((sjekkAnsatt is not Ansatt))
    {
    Console.WriteLine("Kun ansatte kan registrere nye medier");
    break;
    }

**Svar:**

AI forklarte bruk av pattern matching:

    if (!(bruker is Ansatt))
    {
    Console.WriteLine("Kun ansatte kan registrere nye medier");
    break;
    }


Dette er korrekt runtime type-sjekk i C#.

**Prompt:**
Jeg var usikker på hvordan man filtrerer ulike medietyper fra samme liste. Hvordan henter jeg data fra flere klasser samtidig?

**Svar:**

    bibliotek.MediaRegister.OfType<Bok>()

Dette filtrerer kun objekter av typen Bok fra en List<Media>.

Dette demonstrerer polymorfi i praksis.


**Prompt:**
Jeg var usikker på hvordan et utlån skulle registreres mellom bruker og media.

**Svar:**

AI forklarte at ved utlån må tre ting skje:

Media settes som utlånt

Media legges i brukerens liste

Utlån registreres i historikk

      media.ErUtlånt = true;
      bruker.UtlånteMedier.Add(media);
   
      var utlån = new Utlån(media, bruker, DateTime.Now);
      UtlånsHistorikk.Add(utlån);


**Prompt:**
Jeg var usikker på hvordan man finner riktig aktivt utlån ved innlevering. 
Min kode ville ikke finne lånet og det viste seg at jeg manglet funkskjonaliteten i sin helhet.
**Svar:**
AI foreslo å søke i historikken etter et utlån som matcher:

samme media

samme bruker

ikke innlevert ennå

Resultat i koden

      var utlån = UtlånsHistorikk
      .FirstOrDefault(u =>
      u.media.MediaID == MediaID &&
      u.bruker.BrukerID == BrukerID &&
      u.InnlevertDato == null);


Dette sikrer at riktig lån returneres.

**Prompt:**
Hva skjer hvis den allerede eksisterer? i registrer bruker

**Svar:**

      if (BrukerRegister.Any(b => b.Epost == bruker.Epost))
      {
      return null;
      }


**Prompt:**
Husker ikke helt hvordan dette kunne løses i C#?

      if (!(Måned == "Januar", "Februar", "Mars", "April", "Mai", "Juni", "Juli", "August", "September",
      "October", "November", "December"))
      {
      Console.WriteLine("Måneden er ugyldig.");
      }

**Svar:**

roblemer:

== kan bare sammenligne med én verdi

"A", "B", "C" er ikke en gyldig uttrykksform i C#

Du trenger en måte å sjekke om verdien finnes i en samling

✅ Riktig måte: liste + Contains

Dette er standard og lesbart:

      string[] gyldigeMåneder =
      {
      "Januar", "Februar", "Mars", "April", "Mai", "Juni",
      "Juli", "August", "September", "Oktober", "November", "Desember"
      };
      
      if (!gyldigeMåneder.Contains(Måned))
      {
      Console.WriteLine("Måneden er ugyldig.");
      }

**Prompt:**
Feilsøk: feilsøk   

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
                Console.WriteLine(media.VisInfo());
            }
        }
    }

**Svar:**

🔴 Feilen

Du har:

Console.WriteLine(media.VisInfo());


Problemet er:

VisInfo() returnerer void

Det betyr: den returnerer ingenting.

Console.WriteLine(...) forventer derimot en verdi (tekst, tall osv.).

Så du prøver i praksis å skrive ut:

      Console.WriteLine(void)


→ kompileringsfeil.

bare kall metoden

Altså:

      media.VisInfo();


uten Console.WriteLine

**Prompt:**
**Svar:**

**Prompt:**
**Svar:**







