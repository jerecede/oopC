using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class Transaction: IComparable<Transaction>
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        public int CompareTo(Transaction? other)
        {
            if (other == null) return 1; //return -1; per invertire
            return Amount.CompareTo(other.Amount); //return -Amount.CompareTo(other.Amount); per invertire
        }

    }
}
