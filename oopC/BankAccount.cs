using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace oopC
{
    //guardare correzione andrea

    internal class BankAccount
    {
        public Customer Owner { get; set; }
        public Employee Creator { get; set; }
        public DateTime CreationDate { get; set; }
        protected List<Transaction> Transactions { get; set; } = new List<Transaction>();
        protected decimal Balance { get; set; } = 0;

        //lo possiamo generare runtime con list transactions, ci mette più tempo ma più elegante
        //public decimal Balance
        //{
        //    get { return Transactions.Sum(t => t.Amount); }
        //}   

        public BankAccount(Customer owner, Employee creator) //potevo mettere anche transactions
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
            decimal negativeThreshold = 0; //potevo fare getTreshold()
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

        public void OrderByAmount()
        {
            Transactions = Transactions.OrderBy(t => t.Amount).ToList(); //crea una nuova lista, bisogna fare cast, non usa funzione in più
            //Transactions = Transactions.OrderByDescending(t => t.Amount).ToList(); //ordina in modo decrescente

            //Transactions.Sort((t1, t2) => t1.Amount.CompareTo(t2.Amount)); //modifica la tua lista, usa funzione in più
            //Transactions.Sort((t1, t2) => -t1.Amount.CompareTo(t2.Amount)); //con il meno (-) inverto

            //var clone = new List<Transaction>(Transactions); //cosi si crea clone di una list
            //clone.Sort(); //in js faceva sort macchinoso, qui bisogna implementare IComparable
            //dopo implementazione funziona
        }

        public override string ToString() //generateReport()
        {
            string vipOwnerStr = Owner is VipCustomer ? "VIP " : "";
            string thresholdStr = Owner is VipCustomer ? $"Threshold: {((VipCustomer)Owner).NegativeThresHold}€\n" : "";
            string transactionsStr = "";
            if(Transactions.Count > 0)
            {
                transactionsStr = "-----------\n";
            }
            for (int i = 0; i < Transactions.Count; i++)
            {
                transactionsStr += $"Money Moved: {Transactions[i].Amount}€\nDate: {Transactions[i].Date}\n-----------\n";
            }
            transactionsStr = transactionsStr.TrimEnd('\n');

            return $"BANK ACCOUNT\n{vipOwnerStr}Owner: {Owner.Name}\nCreator: {Creator.Name}\nCreation Date: {CreationDate}\nBalance: {Balance}€\n{thresholdStr}TRANSACTIONS\n{transactionsStr}";
        }
    }
}
