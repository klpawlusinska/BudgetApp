# Kalkulator Wydatkow

Prosta aplikacja konsolowa w C# do sledzenia wydatkow domowych.

## Opis aplikacji

Aplikacja pozwala uzytkownikowi zapisywac swoje wydatki z opisem, kwota, kategoria i data.
Wszystkie dane sa automatycznie zapisywane do pliku CSV, dzieki czemu nie gina po zamknieciu
programu i sa dostepne po ponownym uruchomieniu.

## Funkcje

- Dodawanie wydatku (opis, kwota, kategoria, data)
- Wyswietlanie wszystkich wydatkow w formie tabeli
- Filtrowanie wydatkow wedlug wybranej kategorii
- Filtrowanie wydatkow wedlug miesiaca i roku
- Podsumowanie wydatkow pogrupowane wedlug kategorii, z suma calkowita
- Usuwanie wydatku po numerze ID
- Walidacja danych wprowadzanych przez uzytkownika (np. kwota musi byc liczba wieksza od zera)
- Automatyczny zapis i odczyt danych z pliku wydatki.csv

## Kategorie wydatkow

Jedzenie, Transport, Rozrywka, Zdrowie, Mieszkanie, Ubrania, Inne

## Instrukcja uruchomienia

### Wymagania

- .NET 8.0 SDK (do pobrania ze strony: https://dotnet.microsoft.com/download)

### Uruchomienie z linii komend

\`\`\`
git clone <adres-repozytorium>
cd BudgetApp
dotnet run --project BudgetApp/BudgetApp.csproj
\`\`\`

### Uruchomienie z Visual Studio

Otworz plik BudgetApp.sln i nacisnij F5.

### Dane

Plik wydatki.csv jest tworzony automatycznie w katalogu, z ktorego uruchamiana jest aplikacja.
Nie trzeba go tworzyc recznie.

## Struktura projektu

\`\`\`
BudgetApp/
|-- BudgetApp.sln
`-- BudgetApp/
    |-- BudgetApp.csproj
    |-- Program.cs          - menu glowne i punkt wejscia do programu
    |-- Expense.cs           - klasa pojedynczego wydatku + enum kategorii
    |-- BudgetManager.cs     - logika aplikacji (dodawanie, filtrowanie, liczenie sum)
    |-- FileManager.cs       - zapis i odczyt danych z pliku CSV
    `-- ConsoleHelper.cs     - metody pomocnicze do komunikacji z uzytkownikiem
\`\`\`

## Elementy dodatkowe

- [x] **OOP** - wlasne klasy (Expense, BudgetManager, FileManager, ConsoleHelper),
  enum, wlasciwosci, podzial odpowiedzialnosci miedzy klasami
- [x] **IO** - zapis i odczyt danych z pliku CSV (wydatki.csv)
- [ ] **WPF** - nie zaimplementowano
