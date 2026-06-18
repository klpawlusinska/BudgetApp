# Kalkulator Wydatków

Prosta aplikacja konsolowa w C# do śledzenia codziennych wydatków.

## Opis

Aplikacja pozwala użytkownikowi zapisywać wydatki z opisem, kwotą, kategorią i datą.
Dane są przechowywane w pliku CSV, dzięki czemu są dostępne po ponownym uruchomieniu programu.

## Funkcje

- Dodawanie wydatku (opis, kwota, kategoria, data)
- Wyświetlanie wszystkich wydatków
- Filtrowanie wydatków według kategorii
- Filtrowanie wydatków według miesiąca i roku
- Podsumowanie wydatków według kategorii z sumą całkowitą
- Usuwanie wydatku po ID
- Automatyczny zapis i odczyt danych z pliku `wydatki.csv`

## Kategorie

Jedzenie, Transport, Rozrywka, Zdrowie, Mieszkanie, Ubrania, Inne

## Instrukcja uruchomienia

### Wymagania

- .NET 8.0 SDK – pobierz z https://dotnet.microsoft.com/download

### Uruchomienie

```bash
# Sklonuj repozytorium
git clone <adres-repozytorium>
cd BudgetApp

# Uruchom aplikację
dotnet run --project BudgetApp/BudgetApp.csproj
```

Lub otwórz plik `BudgetApp.sln` w Visual Studio i naciśnij F5.

### Dane

Plik `wydatki.csv` tworzony jest automatycznie w katalogu, z którego uruchamiasz aplikację.

## Struktura projektu

```
BudgetApp/
├── BudgetApp.sln
└── BudgetApp/
    ├── BudgetApp.csproj
    ├── Program.cs          # Menu i punkt wejścia
    ├── Expense.cs          # Klasa Expense + enum Category
    ├── BudgetManager.cs    # Logika aplikacji (dodawanie, filtrowanie, sumy)
    ├── FileManager.cs      # Zapis i odczyt CSV
    └── ConsoleHelper.cs    # Statyczne metody pomocnicze do UI
```

## Elementy dodatkowe

- ✅ **OOP** – własne klasy (`Expense`, `BudgetManager`, `FileManager`, `ConsoleHelper`), enum, właściwości, podział odpowiedzialności
- ✅ **IO** – zapis i odczyt danych z pliku `.csv`
- ❌ WPF – nie zaimplementowano
