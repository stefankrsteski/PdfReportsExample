using System.Collections.Generic;

namespace IText7Example.Models
{
    class Budget
    {
        public string Title { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }

        public Budget(string title, IEnumerable<Transaction> transactions)
        {
            Title = title;
            Transactions = transactions;
        }
    }
}
