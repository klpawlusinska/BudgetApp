# Kalkulator Wydatków

Prosta aplikacja konsolowa w C# do śledzenia wydatków domowych.

## Opis aplikacji

Aplikacja pozwala użytkownikowi zapisywać swoje wydatki z opisem, kwotą, kategorią i datą.
Wszystkie dane są automatycznie zapisywane do pliku CSV, dzięki czemu nie znikają po zamknięciu
programu i są dostępne po ponownym uruchomieniu.

## Funkcje

- Dodawanie wydatku (opis, kwota, kategoria, data)
- Wyświetlanie wszystkich wydatków w formie tabeli
- Filtrowanie wydatków według wybranej kategorii
- Filtrowanie wydatków według miesiąca i roku
- Podsumowanie wydatków pogrupowane według kategorii, z sumą całkowitą
- Usuwanie wydatku po numerze ID
- Walidacja danych wprowadzanych przez użytkownika (np. kwota musi być liczbą większą od zera)
- Automatyczny zapis i odczyt danych z pliku wydatki.csv

## Kategorie wydatków

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

Otwórz plik BudgetApp.sln i naciśnij F5.

### Dane

Plik wydatki.csv jest tworzony automatycznie w katalogu, z którego uruchamiana jest aplikacja.
Nie trzeba go tworzyć ręcznie.

## Struktura projektu

BudgetApp
BudgetApp.sln
BudgetApp.csproj
Program.cs          - menu główne i punkt wejścia do programu
Expense.cs           - klasa pojedynczego wydatku + enum kategorii
BudgetManager.cs     - logika aplikacji (dodawanie, filtrowanie, liczenie sum)
FileManager.cs       - zapis i odczyt danych z pliku CSV
Display.cs     - metody pomocnicze do komunikacji z użytkownikiem

## Elementy dodatkowe

- [x] **OOP** - własne klasy (Expense, BudgetManager, FileManager, Display),
  enum, właściwości, podział odpowiedzialności między klasami
- [x] **IO** - zapis i odczyt danych z pliku CSV (wydatki.csv)
- [ ] **WPF** - nie zaimplementowano
