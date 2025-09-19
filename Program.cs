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
        static void Main(string[] args)
        {
            Person person = new Person("Alice", "123456-7890");
            BankAccount account = new BankAccount();
            account.Deposit(1000);
            Console.WriteLine($"Balance after deposit: {account.Balance}");
            account.Withdraw(500);
            Console.WriteLine($"Balance after withdrawal: {account.Balance}");
            account.Withdraw(600); // This should not be allowed
            Console.WriteLine($"Balance after attempted over-withdrawal: {account.Balance}");
        }

    }
}
