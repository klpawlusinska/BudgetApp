using System;
using System.Collections.Generic;

namespace BudgetApp
{
    public static class Display
    {
        // Wyswietla liste wydatkow w formie tabeli z wyrownaniem kolumn
        public static void PrintExpenses(List<Expense> expenses)
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("  Brak wydatków do wyœwietlenia.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"  {"ID",-4} {"Data",-12} {"Kategoria",-14} {"Kwota",-11}  {"Opis"}");
            Console.WriteLine(new string('-', 65));

            foreach (Expense e in expenses)
            {
                string amountCurrency = e.Amount.ToString("F2") + " z³";
                Console.WriteLine($"  {e.Id,-4} {e.Date:dd.MM.yyyy}   {e.Category,-14} {amountCurrency,-11}  {e.Description}");
            }

            Console.WriteLine(new string('-', 65));
        }
        // Wyœwietla podsumowanie wed³ug kategorii
        public static void PrintSummary(Dictionary<Category, decimal> summary, decimal total)
        {
            Console.WriteLine();
            Console.WriteLine("  Podsumowanie Twoich wydatków wed³ug kategorii:");
            Console.WriteLine(new string('-', 35));

            foreach (var entry in summary)
            {
                Console.WriteLine($"  {entry.Key,-14} {entry.Value,10:F2} zl");
            }

            Console.WriteLine(new string('-', 35));
            Console.WriteLine($"  {"RAZEM",-14} {total,10:F2} zl");
            Console.WriteLine();
        }

        // Pobiera liczbê ca³kowit¹ od u¿ytkownika z walidacj¹
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int result))
                    return result;
                Console.WriteLine("  :( Pope³ni³eœ b³¹d: podaj liczbê ca³kowit¹.");
            }
        }

        // Pobiera kwote od uzytkownika z walidacja
        public static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                input = input.Replace(',', '.');

                decimal result;
                bool ok = decimal.TryParse(input, out result);

                if (ok && result > 0)
                    return result;

                Console.WriteLine("  Pope³ni³eœ b³¹d: podaj kwotê wiêksz¹ od zera (np. 12.50) :( .");
            }
        }

        // Pobiera niepusty tekst od uzytkownika
        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                input = input.Trim();

                if (input.Length > 0)
                    return input;

                Console.WriteLine("  Pope³ni³eœ b³¹d: opis nie mo¿e byæ pusty :( .");
            }
        }

        // Pozwala uzytkownikowi wybrac kategorie z listy
        public static Category ReadCategory()
        {
            Category[] categories = (Category[])Enum.GetValues(typeof(Category));

            Console.WriteLine("  Dostepne kategorie wydatków:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine("    " + (i + 1) + ". " + categories[i]);
            }

            while (true)
            {
                int choice = ReadInt("  Wybierz kategorie ( wpisz numer): ");
                if (choice >= 1 && choice <= categories.Length)
                    return categories[choice - 1];
                Console.WriteLine(" :( Pope³ni³eœ b³¹d: wybierz numer od 1 do " + categories.Length + ".");
            }
        }

        // Wyswietla naglowek sekcji
        public static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine("--- " + title + " ---");
            Console.WriteLine();
        }

        // Czeka na Enter od uzytkownika
        public static void WaitForEnter()
        {
            Console.WriteLine();
            Console.Write("  Nacisnij Enter, aby kontynuowaæ...");
            Console.ReadLine();
        }
    }
}
