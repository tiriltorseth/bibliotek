##  Implementasjonsrekkefølge

For å holde prosjektet oversiktlig og redusere kompleksitet underveis, er løsningen implementert stegvis i følgende rekkefølge:

### 1. Domenegrunnmur
- **Media** (abstrakt baseklasse)
- **Bok**
- **Lydbok**
- **EBok**
- **Tidsskrift**

Disse klassene definerer hvilke typer medier som finnes i systemet og deler felles egenskaper gjennom arv. Hver medietype implementerer sin egen visningslogikk.

---

### 2. Brukerhierarki
- **Bruker** (abstrakt baseklasse)
- **Medlem**
- **Ansatt**

Brukerklassene representerer ulike roller i systemet, med forskjellig lånebegrensning og rettigheter. Reglene for utlån kapsles inn gjennom abstraksjon.

---

### 3. Utlån
- **Utlån**

Utlån fungerer som en transaksjonsklasse som knytter sammen én bruker og ett medie, og håndterer datoer, forfallsberegning og forsinkelse.

---

### 4. Systemlogikk
- **Bibliotek**

Bibliotek-klassen fungerer som systemets sentrale logikk og er ansvarlig for:
- registrering av brukere
- administrasjon av medier
- utlån og innlevering
- tilgangskontroll og validering

All forretningslogikk er samlet her.

---

### 5. Brukergrensesnitt
- **Program (konsollmeny)**

Konsollen håndterer kun brukerinteraksjon (input/output) og delegerer all logikk til `Bibliotek`-klassen.

---

## 🧠 Arkitekturprinsipp

Prosjektet følger en tydelig **"dumb UI / smart domain"**-arkitektur, hvor:
- brukergrensesnittet ikke inneholder forretningslogikk
- domeneklassene håndhever regler og tilstand
- ansvar er tydelig fordelt mellom klasser
