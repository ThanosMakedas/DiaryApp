using System.Text.Json;

namespace DiaryApp
{
    public class DiaryEntry
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
        private static List<DiaryEntry> entries = new List<DiaryEntry>();
        private const string FilePath = "Diary.json";

        static void Main(string[] args)
        {
            LoadFromFile();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Dagboksapp ===");
                Console.WriteLine("1) Skriv ny anteckning");
                Console.WriteLine("2) Lista alla anteckningar");
                Console.WriteLine("3) Sök anteckning på datum");
                Console.WriteLine("4) Spara till fil");
                Console.WriteLine("5) Läs från fil");
                Console.WriteLine("6) Avsluta");
                Console.Write("Välj ett alternativ (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEntry();
                        break;
                    case "2":
                        ListEntries();
                        break;
                    case "3":
                        SearchEntry();
                        break;
                    case "4":
                        SaveToFile();
                        break;
                    case "5":
                        LoadFromFile();
                        break;
                    case "6":
                        Console.WriteLine("Avslutar...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck på val mellan 1 och 6.");
                        break;
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }

        static void AddEntry()
        {
            Console.Write("Ange datum (t.ex. 2025-10-02): ");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("Felaktigt datumformat.");
                return;
            }

            Console.Write("Skriv din anteckning: ");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Anteckningen får inte vara tom.");
                return;
            }

            entries.Add(new DiaryEntry { Date = date, Text = text });
            Console.WriteLine("Anteckning tillagd.");
        }

        static void ListEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Inga anteckningar finns.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine($"\nDatum: {entry.Date.ToShortDateString()}");
                Console.WriteLine($"Text: {entry.Text}");
            }
        }

        static void SearchEntry()
        {
            Console.Write("Ange datum att söka (t.ex. 2025-10-02): ");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime searchDate))
            {
                Console.WriteLine("Felaktigt datumformat.");
                return;
            }

            var found = entries.Find(e => e.Date.Date == searchDate.Date);

            if (found != null)
            {
                Console.WriteLine($"\nDatum: {found.Date.ToShortDateString()}");
                Console.WriteLine($"Text: {found.Text}");
            }
            else
            {
                Console.WriteLine("Ingen anteckning hittades för det datumet.");
            }
        }

        static void SaveToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(entries);
                File.WriteAllText(FilePath, json);
                Console.WriteLine("Anteckningar sparade till fil.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparning: {ex.Message}");
            }
        }

        static void LoadFromFile()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Console.WriteLine("Filen finns inte.");
                    return;
                }

                string json = File.ReadAllText(FilePath);
                entries = JsonSerializer.Deserialize<List<DiaryEntry>>(json) ?? new List<DiaryEntry>();
                Console.WriteLine("Anteckningar laddade från fil.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid läsning: {ex.Message}");
            }
        }
    }
}


