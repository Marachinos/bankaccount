namespace bankaccount
{
    using System;

    internal class Program
    {
        class BankAccount //class representing a bank account,
                          //with methods to deposit and withdraw money
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
        class Person //class representing a customer,
                     //with a name and security number (personal number)

        {
            public string Name { get; }
            public string PersonalNumber { get; }

            public Person(string name, string personalNumber)
            {
                Name = name;
                PersonalNumber = personalNumber;
            }
        }
        class Customer //Links a person to a bank account
        {
            private const string HardcodedPin = "1234";
            public Person Person { get; }
            public BankAccount Account { get; }

            public Customer(Person person, BankAccount account)
            {
                Person = person;
                Account = account;
            }

            //Returns true/false depending on whether the pin matches or not
            public bool Authenticate(string pin)
            {
                if (pin == null) return false;
                return pin.Trim() == HardcodedPin;
            }
        }
        class ProgramMain //
        {
            static void Main(string[] args)
            {
                //Account and person created
                var person = new Person("Ziwa", "20001018-1234");
                var account = new BankAccount();
                var customer = new Customer(person, account);
                //The customer is prompted to enter their pin code
                Console.WriteLine($"Välkommen till bankkonto.se!\n Fyll i din 4-siffriga kod: ");
            }
        }
    }
