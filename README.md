# Dagboksappen

## Kort beskrivning
Det här är en enkel konsolapplikation i C# där användaren kan skriva dagboksanteckningar, spara dem till fil och läsa tillbaka dem. Anteckningarna lagras i en lista och sparas i JSON-format.

## Hur man kör appen
1. Öppna projektet i Visual Studio 2022.
2. Kör programmet (F5).
3. Följ menyn i konsolen för att skriva, lista, söka, spara och läsa anteckningar.







Exempel
- Datum: 2025-10-02
- Text: Idag lärde jag mig om JSON och Listor i C#.

## Kort reflektion
Jag valde att använda `List<DiaryEntry>` för att lagra anteckningar eftersom det är enkelt att hantera och passar bra för sekventiell data. Jag använder `System.Text.Json` för att spara och läsa data från filen, eftersom JSON är ett lättläst och vanligt format. Fel hanteras med `try/catch` för att undvika krascher om filen saknas eller innehåller felaktig data. Jag validerar datum med `DateTime.TryParse()` och kontrollerar att texten inte är tom. Programmet är uppbyggt med en meny i konsolen och använder kontrollstrukturer som `while` och `switch` för navigation.
