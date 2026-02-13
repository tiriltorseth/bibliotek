# Biblotekssystem i C#
**Arbeidskrav 1, Objektorientert Programmering**

### Funksjonalitet
Konsollbasert biblotekssystem skrevet i C#. 
Systemet håndterer registrering av brukere, visning av medier, 
utlån og innlevering og visning av utlån via en lokal meny

Funksjonaliteter er:
- Visning av tilgjengelige medier                                   
- Låne medier                                      
- Levere inn medier                              
- Visning av utlån                                 
- Legg til nytt medie (kun ansatte)              
- Registrere nye brukere                            
- Avslutt

### Struktur
Systemet er delt inn i Domene og Services. Innrykk viser arv:

Domene:
- Media
  - Bok
  - Lydbok
  - Ebok
  - Tidsskrift
- Bruker
  - Medlem
  - Ansatt
Services:
- Bibliotek
- Utlån


- Program

### Kjøring
Programmet kjøres fra Program.cs og en meny vil dukke opp i terminalen.
Bruker velger mellom tallene 1-6. Hvert valg har ulike krav
for input, feks BrukerID eller MediaID i format B/M###. Velg 0 å lukke program

### Annet
Se fil BrukAvAI.md for dokumentasjon på AI brukt i oppgaven

### Refleksjoner
(Redigert for formulering og flyt av ChatGPT)

Jeg opplevde oppgaven som ganske krevende i begynnelsen, særlig fordi den kombinerte mange nye konsepter i C# og objektorientert design samtidig. OOP har aldri falt meg helt naturlig, og derfor var det spesielt utfordrende å forstå hvordan klassene skulle samhandle og hvorfor så mye kode var nødvendig for relativt små funksjonelle utfall. Syntaksen følte jeg meg ganske trygg på, men selve logikkaspektet var vanskelig før oppgaven, og er fortsatt det mest krevende, selv om jeg opplevde at det etter hvert ble mer naturlig å tenke i objektorienterte baner mot slutten. Underveis måtte jeg flere ganger stoppe opp og tenke gjennom logikken før jeg gikk videre.

Samtidig opplevde jeg at jeg lærte mye mer gjennom denne prosessen enn ved enklere oppgaver. Etter hvert ble jeg tryggere på hvordan jeg kunne bryte ned problemer, vurdere hvor logikk hører hjemme, og formulere egne hypoteser før jeg eventuelt spurte AI om veiledning. Jeg merket også at spørsmålene mine ble mer presise etter hvert som forståelsen økte.

Totalt sett opplevde jeg oppgaven som krevende, men svært lærerik, og jeg sitter igjen med en bedre forståelse av både C#-struktur, objektorientert modellering og egen problemløsningsprosess.

