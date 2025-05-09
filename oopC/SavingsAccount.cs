using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class SavingsAccount: BankAccount
    {
        private decimal InterestDeposit { get; set; } = 0.02m;
        private decimal InterestWithdraw { get; set; } = 0.03m;

        public SavingsAccount(Customer owner, Employee creator) : base(owner, creator)
        {
        }

        public SavingsAccount(Customer owner, Employee creator, DateTime creationDate) : base(owner, creator, creationDate)
        {
        }

        public override void Operate(decimal amount)
        {
            decimal negativeThreshold = 0;
            if (Owner is VipCustomer)
            {
                negativeThreshold = ((VipCustomer)Owner).NegativeThresHold;
            }

            if (amount > 0)
            {
                decimal newAmount = amount + (amount * InterestDeposit);
                Balance += newAmount;
                Transactions.Add(new Transaction(newAmount, DateTime.Now));
            }
            else if (amount < 0)
            {
                decimal newAmount = amount + (amount * InterestWithdraw);
                if (Balance + newAmount >= -negativeThreshold)
                {
                    Balance += newAmount;
                    Transactions.Add(new Transaction(newAmount, DateTime.Now));
                }
            }
            
        }

        public override string ToString()
        {
            return $"SAVINGS {base.ToString()}\nSAVINGS INTERESTS\nInterest Deposit: {InterestDeposit * 100}%\nInterest Withdraw: {InterestWithdraw * 100}%" ;
        }
    }
}
