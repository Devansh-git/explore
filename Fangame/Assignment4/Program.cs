using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    //Devansh Shah
    //Ruchit Patel
    //Maheshwari Rana
    //Mitul 

    enum ExceptionEnum { ACCOUNT_DOES_NOT_EXIST, CREDIT_LIMIT_HAS_BEEN_EXCEEDED, NAME_NOT_ASSCOCIATED_WITH_THE_ACCOUNT, NO_OVERDRAFT, PASSWORD_INCORRECT, USER_DOES_NOT_EXIST, USER_NOT_LOGGED_IN }

    class Program
    {
        class Person
        {
            private string password;
            public bool IsAuthenticated { get; private set; }

            public string SIN { get; }
            public string Name { get; }

            public Person(string name, string sin)
            {
                Name = name;
                SIN = sin;
                password = SIN.Substring(0, 3);
            }

            public void Login(string password)
            {
                if (this.password != password)
                {
                    IsAuthenticated = false;
                    AccountException e = new AccountException(ExceptionEnum.PASSWORD_INCORRECT);

                    throw e;

                }

                if (this.password == password)
                {
                    IsAuthenticated = true;

                }

            }
            public void Logout()
            {
                IsAuthenticated = false;
            }
            public override string ToString()
            {
                return $"Name - {Name}";

            }

        }

        interface ITransaction
        {
            void Withdraw(double amount, Person person);
            void Deposit(double amount, Person person);
        }

        class Transaction
        {
            public string AccountNumber { get; }
            public double Amount { get; }
            public Person Originator { get; }
            public DateTime Time { get; }

            public Transaction(string accountNumber, double amount, Person person, DateTime time)
            {
                AccountNumber = accountNumber;
                Amount = amount;
                Originator = person;
                Time = time;

            }

            public override string ToString()
            {
                return $"Account Number - {AccountNumber} , Name - {Originator.Name} , Deposit/Withdraw Amount - {Amount} , Time {Time.ToShortTimeString()} ";
            }
        }

        class AccountException:Exception
        {
          
            public AccountException(ExceptionEnum reason):base(reason.ToString())
            {
               
            }
        
        }

        abstract class Account
        {
            public readonly List<Person> users = new List<Person>();
            public readonly List<Transaction> transactions = new List<Transaction>();
            static private int LAST_NUMBER = 100000;

            public string Number { get; }
            public double Balance { get; protected set; }
            public double LowestBalance { get; protected set; }


            public Account(string type, double balance)
            {
                
                Number = string.Join("", type, LAST_NUMBER.ToString());
                ++LAST_NUMBER;
               
                Console.WriteLine(LAST_NUMBER);
                Balance = balance;
                LowestBalance = balance;

            }
            public void Deposit(double amount, Person person)
            {
                Balance += amount;
                if (LowestBalance > Balance)
                {
                    LowestBalance = Balance;
                }
                Transaction trans = new Transaction(Number, amount, person, DateTime.Now);
                transactions.Add(trans);

            }

            public void AddUser(Person person)
            {
                users.Add(person);

            }

            public bool IsUser(string name)
            {
                foreach (Person p in users)
                {
                    if (p.Name == name)
                    { return true; }
                    else
                        return false;

                }
                return false;

            }

            public abstract void PrepareMonthlyReport();
            public override string ToString()
            {
                return $"Account Number - {Number} , Users - {string.Join(", ", users)},Balance - {Balance}, Transactions - {string.Join(",",transactions)}";

            }
        }

        class CheckingAccount : Account, ITransaction
        {
            static private double COST_PER_TRANSACTION = 0.05;
            static private double INTREST_RATE = 0.005;
            private bool hasOverdraft;
            public CheckingAccount(double balance = 0, bool hasoverdraft = false) : base("CK-", balance)
            {
                hasOverdraft = hasoverdraft;
            }
            public void Deposite(double amount, Person person)
            {
                Deposit(amount, person);
            }

            public void Withdraw(double amount, Person person)
            {
                if (person.IsAuthenticated == false)
                {
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }

                else if (users.Contains(person) == false)
                {
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSCOCIATED_WITH_THE_ACCOUNT);
                }
                else if (amount > Balance && hasOverdraft==false)
                {
                    throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
                }
                else
                {
                    Deposit(-amount, person);

                }



                Deposit(-amount, person);


            }

            public override void PrepareMonthlyReport()
            {
                double serviceCharge = transactions.Count() * COST_PER_TRANSACTION;
                double intrestRate = (LowestBalance * INTREST_RATE) / 12;
                Balance = Balance + intrestRate - serviceCharge;
                transactions.Clear();

            }
        }

        class SavingAccount : Account, ITransaction
        {
            static private double COST_PER_TRANSACTION = 0.05;
            static private double INTREST_RATE = 0.015;

            public SavingAccount(double balance = 0) : base("SV-", balance)
            {

            }
            public void  Deposite(double amount, Person person)
            {
                Deposit(amount, person);
            }
            public void Withdraw(double amount, Person person)
            {
                if (person.IsAuthenticated == false)
                {
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }

                else if (users.Contains(person) == false)
                {
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSCOCIATED_WITH_THE_ACCOUNT);
                }
                else if (amount > Balance )
                {
                    throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
                }
                else
                {
                    Deposit(-amount, person);

                }


                Deposit(-amount, person);

            }
            public override void PrepareMonthlyReport()
            {
                double serviceCharge = transactions.Count() * COST_PER_TRANSACTION;
                double intrestRate = (LowestBalance * INTREST_RATE) / 12;
                Balance = Balance + intrestRate - serviceCharge;
                transactions.Clear();

            }


        }

        class VisaAccount : Account
        {
            private double creditLimit;
            static private double INTREST_RATE = 0.1995;

            public VisaAccount(double balance, double CreditLimit = 1200) : base("VS-", balance)
            {
                
                creditLimit = CreditLimit;
            }
            public void DoPayment(double amount, Person person)
            {
                Deposit(amount, person);
            }
            public void DoPurchase(double amount, Person person)
            {
               
                if(person.IsAuthenticated==false)
                {
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }

                else if(users.Contains(person)==false)
                {
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSCOCIATED_WITH_THE_ACCOUNT);
                }
                else if(amount>creditLimit)
                {
                    throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
                else
                {
                    Deposit(-amount, person);
                   
                }
                
           
            }

            public override void PrepareMonthlyReport()
            {
                double intrest = (LowestBalance * INTREST_RATE) / 12;
                Balance -= intrest;
                transactions.Clear();

            }
        }

        static class Bank
        {
            static public readonly List<Account> ACCOUNTS;
            static public readonly List<Person> USERS;

            static Bank()
            {
                //initialize the USERS collection
                USERS = new List<Person>()
                {
                    new Person("Narendra", "1234-5678"), //0
                    new Person("Ilia", "2345-6789"), //1
                    new Person("Tom", "3456-7890"), //2
                    new Person("Syed", "4567-8901"), //3
                    new Person("Arben", "5678-9012"), //4
                    new Person("Patrick", "6789-0123"), //5
                    new Person("Yin", "7890-1234"), //6
                    new Person("Hao", "8901-2345"), //7
                    new Person("Jake", "9012-3456"), //8
                    new Person("Joanne", "1224-5678"), //9
                    new Person("Nicoletta", "2344-6789"), //10
                };

                ACCOUNTS = new List<Account>{
                    new VisaAccount(150), //VS-100000

                    new VisaAccount(150), //VS-100001
                    
                    new SavingAccount(5000), //SV-100002
                    new SavingAccount(5000), //SV-100003
                    new CheckingAccount(2000), //CK-100004
                    new CheckingAccount(1500, true),//CK-100005
                    new VisaAccount(50,550), //VS-100006
                    new SavingAccount(1000), //SV-100007
                };
                
                
               
                
                
                
                //associate users with accounts
                ACCOUNTS[0].AddUser(USERS[0]);
                ACCOUNTS[0].AddUser(USERS[1]);
                ACCOUNTS[0].AddUser(USERS[2]);
               
                ACCOUNTS[1].AddUser(USERS[3]);
                ACCOUNTS[1].AddUser(USERS[4]);
                ACCOUNTS[1].AddUser(USERS[5]);
               
                ACCOUNTS[2].AddUser(USERS[6]);
                ACCOUNTS[2].AddUser(USERS[7]);
                ACCOUNTS[2].AddUser(USERS[8]);
                
                ACCOUNTS[3].AddUser(USERS[9]);
                ACCOUNTS[3].AddUser(USERS[10]);
               
                ACCOUNTS[4].AddUser(USERS[2]);
                ACCOUNTS[4].AddUser(USERS[4]);
                ACCOUNTS[4].AddUser(USERS[6]);
               
                ACCOUNTS[5].AddUser(USERS[8]);
                ACCOUNTS[5].AddUser(USERS[10]);
               
                ACCOUNTS[6].AddUser(USERS[1]);
                ACCOUNTS[6].AddUser(USERS[3]);
                
                ACCOUNTS[7].AddUser(USERS[5]);
                ACCOUNTS[7].AddUser(USERS[7]);



            }
        
        
            public static void PrintAccounts()
            {
                foreach(Account a in ACCOUNTS)
                {
                    Console.WriteLine(a);
                }
            }
            public static void PrintPersons()
            {
                foreach(Person p in USERS)
                {
                    Console.WriteLine(p);
                }
            }
            public static Person GetPerson(string name)
            {
                foreach(Person p in USERS)
                {
                    if (p.Name==name)
                    {
                        return p;
                    }
                }

                AccountException e = new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST);

                throw new Exception(e.ToString());

            }

            public static Account GetAccount(string number)
            {
                foreach (Account a in ACCOUNTS)
                {
                    if (a.Number == number)
                    {
                        return a;
                    }

                }

                           
               throw new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST);

            }



        }
            static void Main(string[] args)
            {

            //testing the visa account
            Console.WriteLine("\nAll acounts:");
            Bank.PrintAccounts();
            Console.WriteLine("\nAll Users:");
            Bank.PrintPersons();
            Person p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;
            p0 = Bank.GetPerson("Narendra");
            p1 = Bank.GetPerson("Ilia");
            p2 = Bank.GetPerson("Tom");
            p3 = Bank.GetPerson("Syed");
            p4 = Bank.GetPerson("Arben");
            p5 = Bank.GetPerson("Patrick");
            p6 = Bank.GetPerson("Yin");
            p7 = Bank.GetPerson("Hao");
            p8 = Bank.GetPerson("Jake");
            p9 = Bank.GetPerson("Joanne");
            p10 = Bank.GetPerson("Nicoletta");
            p0.Login("123"); p1.Login("234");
            p2.Login("345"); p3.Login("456");
            p4.Login("567"); p5.Login("678");
            p6.Login("789"); p7.Login("890");
            p10.Login("234"); p8.Login("901");



            //a visa account
            VisaAccount a = Bank.GetAccount("VS-100000") as VisaAccount;
            a.DoPayment(1500, p0);
            a.DoPurchase(200, p1);
            a.DoPurchase(25, p2);
            a.DoPurchase(15, p0);
            a.DoPurchase(39, p1);
            a.DoPayment(400, p0);
            Console.WriteLine(a);

            Console.WriteLine("----------------------------------------------------------------------");
            a = Bank.GetAccount("VS-100001") as VisaAccount;
            a.DoPayment(500, p0);
            a.DoPurchase(25, p3);
            a.DoPurchase(20, p4);
            a.DoPurchase(15, p5);
            Console.WriteLine(a);
            Console.WriteLine("----------------------------------------------------------------------");

           // a saving account
            ITransaction b = Bank.GetAccount("SV-100002") as SavingAccount;
            b.Deposit(300, p6);
            b.Withdraw(32, p6);
            b.Withdraw(50, p7);
            b.Withdraw(111.11, p8);
            Console.WriteLine(b);
            Console.WriteLine("----------------------------------------------------------------------");
            b = (SavingAccount)Bank.GetAccount("SV-100003");
            b.Deposit(300, p3); //ok even though p3 is not a holder
            b.Deposit(32.90, p2);
            b.Deposit(50, p5);
            b.Withdraw(111.11, p10);
            Console.WriteLine(b);

            Console.WriteLine("----------------------------------------------------------------------");
            //a checking account
            ITransaction c = Bank.GetAccount("CK-100004") as CheckingAccount;
            c.Deposit(33.33, p7);
            c.Deposit(40.44, p7);
            c.Withdraw(150, p2);
            c.Withdraw(200, p4);
            c.Withdraw(645, p6);
            c.Withdraw(35, p6);
            Console.WriteLine(c);

            Console.WriteLine("----------------------------------------------------------------------");
            c = Bank.GetAccount("CK-100005") as CheckingAccount;
            c.Deposit(33.33, p8);
            c.Deposit(40.44, p7);
            c.Withdraw(450, p10);
            c.Withdraw(500, p8);
            c.Withdraw(645, p10);
            c.Withdraw(850, p10);
            Console.WriteLine(c);
            Console.WriteLine("----------------------------------------------------------------------");
            a = Bank.GetAccount("VS-100006") as VisaAccount;
            a.DoPayment(700, p0);
            a.DoPurchase(20, p3);
            a.DoPurchase(10, p1);
            a.DoPurchase(15, p1);
            Console.WriteLine(a);
            Console.WriteLine("----------------------------------------------------------------------");
            b = Bank.GetAccount("SV-100007") as SavingAccount;
            b.Deposit(300, p3); //ok even though p3 is not a holder
            b.Deposit(32.90, p2);
            b.Deposit(50, p5);
            b.Withdraw(111.11, p7);
            Console.WriteLine(b);

            Console.WriteLine("----------------------------------------------------------------------");

            Console.WriteLine("\n\nExceptions:");
            //The following will cause exception
            try
            {
                p8.Login("911");//incorrect password
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                p3.Logout();
                a.DoPurchase(12.5, p3); //exception user is not logged in
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                a.DoPurchase(12.5, p0); //user is not associated with this account
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }

            try
            {
                a.DoPurchase(5825, p4); //credit limit exceeded
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                c.Withdraw(1500, p6); //no overdraft
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                Bank.GetAccount("CK-100018"); //account does not exist
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            //try
            //{
            //    Bank.GetPerson("Trudeau"); //user does not exist
            //}
            //catch (AccountException e) { Console.WriteLine(e.Message); }


            foreach (Account account in Bank.ACCOUNTS)
            {
                Console.WriteLine("\nBefore PrepareMonthlyReport()");
                Console.WriteLine(account);
                Console.WriteLine("\nAfter PrepareMonthlyReport()");
                account.PrepareMonthlyReport(); //all transactions are cleared, balance  changes
                Console.WriteLine(account);
            }



        }




    }
}