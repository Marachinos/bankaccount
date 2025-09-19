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
            public Person Person { get; }
            public BankAccount Account { get; }
            public Customer(Person person, BankAccount account)
            {
                Person = person;
                Account = account;
            }
        }

    }
}
