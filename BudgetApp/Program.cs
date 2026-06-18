using System;
using System.Collections.Generic;

namespace BudgetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "wydatki.csv";
            BudgetManager manager = new BudgetManager(filePath);

            Console.WriteLine("--- KALKULATOR WYDATKOW ---");
            Console.WriteLine("Dane wczytane z pliku: " + filePath);

            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddExpense(manager);
                        break;
                    case "2":
                        ShowAll(manager);
                        break;
                    case "3":
                        ShowByCategory(manager);
                        break;
                    case "4":
                        ShowByMonth(manager);
                        break;
                    case "5":
                        ShowSummary(manager);
                        break;
                    case "6":
                        RemoveExpense(manager);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Nieznana opcja. Wybierz numer z menu.");
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Do widzenia! Na przysz³oœæ, pamiêtaj aby byæ oszczêdnym!");
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------------- MENU --------------");
            Console.WriteLine("  1. Dodaj wydatek");
            Console.WriteLine("  2. Wyœwietl wszystkie wydatki");
            Console.WriteLine("  3. Filtruj wedlug kategorii");
            Console.WriteLine("  4. Filtruj wedlug miesiaca");
            Console.WriteLine("  5. Podsumowanie wszystkich kategorii");
            Console.WriteLine("  6. Usuñ wydatek");
            Console.WriteLine("  0. Wyjœcie");
            Console.WriteLine("----------------------------------");
            Console.Write("  Twój wybór: ");
        }

        // Dodawanie wydatku
        static void AddExpense(BudgetManager manager)
        {
            Display.PrintHeader("Dodaj nowy wydatek");

            string description = Display.ReadNonEmpty("  Opis: ");
            decimal amount = Display.ReadDecimal("  Kwota (z³): ");
            Category category = Display.ReadCategory();

            Console.Write("  Data (dd.MM.yyyy), Enter = dzisiaj: ");
            string dateInput = Console.ReadLine() ?? "";
            DateTime date;

            if (string.IsNullOrWhiteSpace(dateInput))
            {
                date = DateTime.Today;
            }
            else if (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("  B³êdny format daty. U¿yta dzisiejsza data.");
                date = DateTime.Today;
            }


            manager.AddExpense(description, amount, category, date);
            Console.WriteLine("  Wydatek dodany i zapisany do pliku.");
            Display.WaitForEnter();
        }

        // Wyœwietl wszystkie wydatki
        static void ShowAll(BudgetManager manager)
        {
            Display.PrintHeader("Wszystkie wydatki");
            List<Expense> all = manager.GetAll();
            Display.PrintExpenses(all);

            if (all.Count > 0)
                Console.WriteLine($"  £¹cznie: {manager.GetTotal():F2} zl");

            Display.WaitForEnter();
        }

        // Filtruj wed³ug kategorii
        static void ShowByCategory(BudgetManager manager)
        {
            Display.PrintHeader("Filtruj wed³ug kategorii");
            Category category = Display.ReadCategory();
            List<Expense> filtered = manager.GetByCategory(category);

            Console.WriteLine("\n  Wydatki w kategorii: " + category);
            Display.PrintExpenses(filtered);

            if (filtered.Count > 0)
            {
                decimal sum = 0;
                foreach (Expense e in filtered)
                    sum += e.Amount;
                Console.WriteLine($"  Suma: {sum:F2} zl");
            }

            Display.WaitForEnter();
        }

        // Filtruj wg miesi¹ca

        static void ShowByMonth(BudgetManager manager)
        {
            Display.PrintHeader("Filtruj wed³ug miesi¹ca");

            int month = Display.ReadInt("  Miesiac (1-12): ");
            if (month < 1 || month > 12)
            {
                Console.WriteLine("  B³êdny numer miesi¹ca.");
                Display.WaitForEnter();
                return;
            }

            int year = Display.ReadInt("  Rok (np. 2025): ");
            List<Expense> filtered = manager.GetByMonth(month, year);

            Console.WriteLine($"\n  Wydatki za {month:D2}/{year}:");
            Display.PrintExpenses(filtered);

            if (filtered.Count > 0)
                Console.WriteLine($"  Suma za miesi¹c: {manager.GetMonthlyTotal(month, year):F2} zl");

            Display.WaitForEnter();
        }

        // Podsumowanie wszystkich kategorii
        static void ShowSummary(BudgetManager manager)
        {
            Display.PrintHeader("Podsumowanie wszystkich kategorii");
            Dictionary<Category, decimal> summary = manager.GetSummaryByCategory();

            if (summary.Count == 0)
                Console.WriteLine("  Brak wydatków do podsumowania.");
            else
                Display.PrintSummary(summary, manager.GetTotal());

            Display.WaitForEnter();
        }

        // Usuñ wydatek
        static void RemoveExpense(BudgetManager manager)
        {
            Display.PrintHeader("Usuñ wydatek");

            List<Expense> all = manager.GetAll();
            Display.PrintExpenses(all);

            if (all.Count == 0)
            {
                Display.WaitForEnter();
                return;
            }

            int id = Display.ReadInt("  Podaj ID wydatku do usuniêcia (0 = powrót do menu g³ównego): ");
            if (id == 0)
                return;

            bool removed = manager.RemoveExpense(id);

            if (removed)
                Console.WriteLine("  Wydatek o ID " + id + " zosta³ usuniêty.");
            else
                Console.WriteLine("  Nie znaleziono wydatku o ID " + id + ".");

            Display.WaitForEnter();
        }
    }
}
