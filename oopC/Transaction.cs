﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}
