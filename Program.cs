namespace bankaccount
{
    class Program
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


            static void Main(string[] args)
        {
            
        }
    }
}
