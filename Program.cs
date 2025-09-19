namespace bankaccount
{
    internal class Program
    {
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

            class Person //Person: inkapslar namn och personnummer
            {
                public string Name { get; }
                public string PersonalNumber { get; }
                public Person(string name, string personalNumber)
                {
                    Name = name;
                    PersonalNumber = personalNumber;
                }
            }

        }
    }
}
