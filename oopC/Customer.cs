using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC
{
    internal class Customer: Person
    {
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public PaymentMethod? PayMethod { get; set; }

        //public Customer() //cosi posso usare anche le graffe, ma se metto required da problemi, ERR ¯\_(ツ)_/¯
        //{
        //}

        public Customer(string name, string surname, int year, int month, int day, string address, string mailAddress): base(name, surname, year, month, day)
        {
            Address = address;
            MailAddress = mailAddress;
        }

        public Customer(string name, string surname, DateTime dob, string address, string mailAddress): base(name, surname, dob.Year, dob.Month, dob.Day)
        {
            Address = address;
            MailAddress = mailAddress;
        }

        public override string ToString()
        {
            return "Cliente " + base.ToString();
        }

        public override string Welcome()
        {
            return "Benvenuto";
        }

        public virtual string PrintAddress() //con virtualdo permesso che puo essere override
        {
            return Name + " " + Surname + "\n" + Address.Replace(", ", "\n");
        }
    }

    public enum PaymentMethod //questo su js non c'è, su ts si
    {
        Iban = 0,
        Cdc = 1,
        Cash = 2,
        //string non si puo
    }
}
