using System;

namespace PdfSharpExample.Models
{
    class Transaction
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Coins { get; set; }
        public string Note { get; set; }

        public Transaction(DateTime date, double amount, double coins, string note = "")
        {
            Date = date;
            Amount = amount;
            Coins = coins;
            Note = note;
        }
    }

}
