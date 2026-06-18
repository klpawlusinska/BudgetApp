using System;
using System.Collections.Generic;

namespace BudgetApp
{
    public class BudgetManager
    {
        private List<Expense> _expenses;
        private readonly FileManager _fileManager;
        private int _nextId;

        public BudgetManager(string filePath)
        {
            _fileManager = new FileManager(filePath);
            _expenses = _fileManager.LoadExpenses();

            // Ustalamy od jakiego ID zaczaæ
            if (_expenses.Count == 0)
            {
                // Lista jest pusta, zaczynamy od 1
                _nextId = 1;
            }
            else
            {
                // Lista ma juz jakieœ wydatki, bierzemy ID ostatniego i dodajemy 1
                int lastId = _expenses[_expenses.Count - 1].Id;
                _nextId = lastId + 1;
            }
        }

        // Dodaj nowy wydatek
        public void AddExpense(string description, decimal amount, Category category, DateTime date)
        {
            Expense expense = new Expense(_nextId, description, amount, category, date);
            _expenses.Add(expense);
            _nextId++;
            _fileManager.SaveExpenses(_expenses);
        }

        // Usuñ wydatek po ID
        public bool RemoveExpense(int id)
        {
            Expense found = FindById(id);
            if (found == null)
                return false;

            _expenses.Remove(found);
            _fileManager.SaveExpenses(_expenses);
            return true; ;
        }

        // Pobierz wszystkie wydatki
        public List<Expense> GetAll()
        {
            return _expenses;
        }

        // Filtruj po kategorii
        public List<Expense> GetByCategory(Category category)
        {
            List<Expense> result = new List<Expense>();
            foreach (Expense e in _expenses)
            {
                if (e.Category == category)
                    result.Add(e);
            }
            return result;
        }

        // Filtruj po miesiacu i roku
        public List<Expense> GetByMonth(int month, int year)
        {
            List<Expense> result = new List<Expense>();
            foreach (Expense e in _expenses)
            {
                if (e.Date.Month == month && e.Date.Year == year)
                    result.Add(e);
            }
            return result;
        }

        // Suma wszystkich wydatków
        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (Expense e in _expenses)
                total += e.Amount;
            return total;
        }

        // Suma wydatków wed³ug kategorii
        public Dictionary<Category, decimal> GetSummaryByCategory()
        {
            Dictionary<Category, decimal> summary = new Dictionary<Category, decimal>();

            foreach (Expense e in _expenses)
            {
                if (!summary.ContainsKey(e.Category))
                    summary[e.Category] = 0;

                summary[e.Category] += e.Amount;
            }

            return summary;
        }

        // Suma wydatków w danym miesi¹cu
        public decimal GetMonthlyTotal(int month, int year)
        {
            decimal total = 0;
            foreach (Expense e in GetByMonth(month, year))
                total += e.Amount;
            return total;
        }

        // Szukaj wydatku po ID
        private Expense FindById(int id)
        {
            foreach (Expense e in _expenses)
            {
                if (e.Id == id)
                    return e;
            }
            return null;
        }
    }
}
