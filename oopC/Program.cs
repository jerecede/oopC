namespace oopC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dob1 = new DateTime(2000, 12, 3);
            var c1 = new Customer("pippo", "de pippis", dob1, "via vannucci 3, 16123 Genova, Italy", "pippoo@gmail.com");
            c1.PayMethod = PaymentMethod.Iban;
            c1.PayMethod = 0;
            //c1.PayMethod = 5; //da errore

            var c2 = new Customer("clarabella", "de pippis", 2001, 3, 23, "via vannucci 3, 16123 Genova, Italy", "clarabll@gmail.com");

            var c3 = new Customer("orazio", "de pippis", new DateTime(1999, 1, 1), "via vannucci 3, 16123 Genova, Italy", "orazi00@gmail.com");

            var v1 = new VipCustomer("topolino", "mouse", 1990, 1, 30, "via gramsci 3, 16123 Genova, Italy", "topolino.disney@gmail.com", 1500);

            var e1 = new Employee("paperino", "de paperis", 1980, 3, 23, "genova 1");
            e1.Level = ExperienceLevels.Senior;

            //var p1 = new Person("jeremias", "cedeno", 2003, 7, 5); //errore, non puoi creare istanza di una classe astratta

            List<VipCustomer> vipCustomers = [];
            vipCustomers.Add(v1);
            //vipCustomers.Add(c1); //da errore

            List<Customer> customers = []; //puo contenere anche figli, come VipCustomer, POLIMORFISMO
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(v1);

            //foreach (var customer in customers)
            //{
            //    //Console.WriteLine(customer.ToString());
            //    Console.WriteLine(customer.PrintAddress());
            //}

            List<Person> people = new List<Person>();
            people.Add(c1);
            people.Add(c3);
            people.Add(v1);
            people.Add(e1);

            //foreach (var person in people)
            //{
            //    Console.WriteLine(person.Welcome());
            //}

            var bankAcc1 = new BankAccount(c1, e1);
            bankAcc1.Operate(1000);
            bankAcc1.Operate(-500);
            bankAcc1.Operate(-1500);
            Console.WriteLine(bankAcc1.ToString());

            var bankAcc2 = new BankAccount(v1, e1);
            bankAcc2.Operate(1000);
            bankAcc2.Operate(-1500);
            Console.WriteLine("\n\n" + bankAcc2.ToString());

            var saveAcc1 = new SavingsAccount(v1, e1);
            saveAcc1.Operate(1000);
            saveAcc1.Operate(-1500);
            Console.WriteLine("\n\n" + saveAcc1.ToString());

            var cbAcc1 = new CashBackAccount(v1, e1);
            cbAcc1.Operate(1000);
            cbAcc1.Operate(-1500);
            Console.WriteLine("\n\n" + cbAcc1.ToString());
        }
    }
}
