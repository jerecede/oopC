using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class CashBackAccount: BankAccount
    {
        private decimal CashBack { get; set; } = 0;
        private decimal CashBackPercentage { get; set; } = 0.05m;

        public CashBackAccount(Customer owner, Employee creator) : base(owner, creator)
        {
        }

        public CashBackAccount(Customer owner, Employee creator, DateTime creationDate) : base(owner, creator, creationDate)
        {
        }

        public override void Operate(decimal amount)
        {
            //guaradare soluzione andrea, perche lui tiene traccia anche del cashback
            base.Operate(amount);
            if (amount < 0)
            {
                CashBack += Math.Abs(amount) * CashBackPercentage;
                Balance += Math.Abs(amount) * CashBackPercentage;
            }
        }

        public override string ToString()
        {
            return $"CASHBACK {base.ToString()}\nCASHBACK\nCashBack Accumulated: {CashBack}€\nCashBack Percentage: {CashBackPercentage * 100}%";
        }
    }
}
