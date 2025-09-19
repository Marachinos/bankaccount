namespace bankaccount
{
    using System;
   internal class Program
    {
        class Person //Person: inkapslar namn och personnummer/encapsulates name and social security number
        {
            public string Name { get; }
            public string PersonalNumber { get; }
            public Person(string name, string personalNumber)
            {
                Name = name;
                PersonalNumber = personalNumber;
            }
        }

        class BankAccount //BankAccount: inkapslar saldot/encapsulates the balance
        {
            private decimal balance;
            public decimal Balance => balance;

            public void Deposit(decimal amount)
                {
                    if (amount > 0) balance += amount;
                }

            public void Withdraw(decimal amount)
                {
                    if (amount > 0 && amount <= balance)
                        balance -= amount;
                }
        }
        class Customer //Customer: kopplar en person till ett bankkonto/links a person to a bank account
        {
            private const string HardcodedPin = "1234";
            public Person Person { get; }
            public BankAccount Account { get; }
            public Customer(Person person, BankAccount account)
            {
                Person = person;
                Account = account;
            }
            // Returnerar true/false beroende på om pin matchar eller inte/Returns true/false depending on whether the pin matches or not
            public bool Authenticate(string pin)
            {
                if (pin == null) return false;
                return pin.Trim() == HardcodedPin;
            }
        }

        class ProgramMain
        {
            static void Main(string[] args)
            {
                //skapar en kund med ett namn och personnummer/creates a customer with a name and social security number
                var person = new Person("Ziwa", "20031018-1357");
                var account = new BankAccount();
                var customer = new Customer(person, account);

            Console.WriteLine("Välkommen!\n Fyll i din 4-siffriga kod: ");
            }



        }


    }
}
