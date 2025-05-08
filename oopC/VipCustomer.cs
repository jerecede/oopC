using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class VipCustomer: Customer
    {
        private string? NamePrefix { get; set; }
        private decimal NegativeThresHold { get; set; }

        public VipCustomer(string name, string surname, DateTime dob, string address, string mailAddress, decimal treshold) : base(name, surname, dob, address, mailAddress) //richiamo costruttore papa, non come js che dentro le graffe scrivo super()
        {
            NamePrefix = "Sua Eccellenza";
            NegativeThresHold = treshold;
        }

        public VipCustomer(string name, string surname, int year, int month, int day, string address, string mailAddress, decimal treshold) : base(name, surname, year, month, day, address, mailAddress)
        {
            NamePrefix = "Sua Eccellenza";
            NegativeThresHold = treshold;
        }

        public override string ToString()
        {
            return NamePrefix + " " + base.ToString();
        }

        public override string Welcome() //non obbligatorio perche nipote
        {
            return base.Welcome() + " " + NamePrefix;
        }

        public override string PrintAddress() //ha il permesso di padre
        {
            return NamePrefix + base.PrintAddress();
        }
    }
}
