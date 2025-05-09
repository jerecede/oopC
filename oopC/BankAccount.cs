using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class BankAccount
    {
        public Customer Owner { get; set; }
        public Employee Creator { get; set; }
        public DateTime CreationDate { get; set; }
        protected List<Transaction> Transactions { get; set; } = new List<Transaction>();
        protected decimal Balance { get; set; } = 0;

        public BankAccount(Customer owner, Employee creator)
        {
            Owner = owner;
            Creator = creator;
            CreationDate = DateTime.Now;
        }

        public BankAccount(Customer owner, Employee creator, DateTime creationDate)
        {
            Owner = owner;
            Creator = creator;
            CreationDate = creationDate;
        }

        public virtual void Operate(decimal amount)
        {
            decimal negativeThreshold = 0;
            if (Owner is VipCustomer)
            {
                negativeThreshold = ((VipCustomer)Owner).NegativeThresHold;
            }

            if (Balance + amount >= -negativeThreshold)
            {
                Transactions.Add(new Transaction(amount, DateTime.Now));
                Balance += amount;
            }
        }

        public override string ToString()
        {
            string vipOwnerStr = Owner is VipCustomer ? "VIP " : "";
            string thresholdStr = Owner is VipCustomer ? $"Threshold: {((VipCustomer)Owner).NegativeThresHold}\n" : "";
            string transactionsStr = "";
            if(Transactions.Count > 0)
            {
                transactionsStr = "-----------\n";
            }
            for (int i = 0; i < Transactions.Count; i++)
            {
                transactionsStr += $"Money Moved: {Transactions[i].Amount}\nDate: {Transactions[i].Date}\n-----------\n";
            }
            transactionsStr = transactionsStr.TrimEnd('\n');

            return $"BANK ACCOUNT\n{vipOwnerStr}Owner: {Owner.Name}\nCreator: {Creator.Name}\nCreation Date: {CreationDate}\nBalance: {Balance}\n{thresholdStr}TRANSACTIONS\n{transactionsStr}";
        }
    }
}
