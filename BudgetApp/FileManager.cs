using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetApp
{
    public class FileManager
    {
        private readonly string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveExpenses(List<Expense> expenses)
        {
            List<string> lines = new List<string>();

            foreach (Expense expense in expenses)
            {
                lines.Add(expense.ToCsv());
            }

            File.WriteAllLines(_filePath, lines);
        }

        public List<Expense> LoadExpenses()
        {
            List<Expense> expenses = new List<Expense>();

            if (!File.Exists(_filePath))
                return expenses;

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    Expense expense = Expense.FromCsv(line);
                    expenses.Add(expense);
                }
                catch
                {
                    Console.WriteLine("Pominiêto b³êdn¹ liniê: " + line);
                }
            }

            return expenses;
        }
    }
}
