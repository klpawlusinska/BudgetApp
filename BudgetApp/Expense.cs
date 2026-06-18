using System;

namespace BudgetApp
{
    public enum Category
    {
        Jedzenie,
        Transport,
        Rozrywka,
        Zdrowie,
        Mieszkanie,
        Ubrania,
        Inne
    }

    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }

        public Expense(int id, string description, decimal amount, Category category, DateTime date)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
        }

        // Zamiana obiektu na linie CSV
        public string ToCsv()
        {
            return Id + "," + Description + "," + Amount + "," + Category + "," + Date.ToString("yyyy-MM-dd");
        }

        // Odtworzenie obiektu z linii CSV
        public static Expense FromCsv(string line)
        {
            string[] parts = line.Split(',');
            int id = int.Parse(parts[0]);
            string description = parts[1];
            decimal amount;
            decimal.TryParse(parts[2], out amount);
            Category category = (Category)Enum.Parse(typeof(Category), parts[3]);
            DateTime date = DateTime.Parse(parts[4]);

            return new Expense(id, description, amount, category, date);
        }
    }
}
