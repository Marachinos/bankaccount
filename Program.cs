namespace bankaccount
{
    using System;

    internal class Program
    {
        class Person //Inkapslar namn och personnummer/Encapsulates name and social security number

        {
            public string Name { get; }
            public string PersonalNumber { get; }

            public Person(string name, string personalNumber)
            {
                Name = name;
                PersonalNumber = personalNumber;
            }
        }

        class BankAccount //Inkapslar saldot/encapsulates the balance
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
        class Customer //Kopplar en person till ett bankkonto/Links a person to a bank account
        {
            private const string HardcodedPin = "1234";
            public Person Person { get; }
            public BankAccount Account { get; }

            public Customer(Person person, BankAccount account)
            {
                Person = person;
                Account = account;
            }

            //Returnerar true/false beroende på om pin matchar eller inte/Returns true/false depending on whether the pin matches or not
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
                //Skapar en kund med namn och personnummer
                var person = new Person("Ziwa", "20031018-1357");
                var account = new BankAccount();
                var customer = new Customer(person, account);

                //Inloggningen startar här
                Console.WriteLine("Välkommen till bankkonto.se!\nFyll i din 4-siffriga kod: ");
                while (true)
                {
                    Console.Write("PIN: ");
                    var pinInput = Console.ReadLine();
                    if (customer.Authenticate(pinInput))
                    {
                        Console.WriteLine($"Inloggning lyckades!\nVälkommen {customer.Person.Name}!");
                        DisplayMenu(customer); // <-- anropar menyn efter inlogg/calls the menu after login
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Felaktig kod, försök igen.");
                    }
                }
            }

            static void DisplayMenu(Customer customer)
            {
                while (true)
                {
                    Console.WriteLine("\nVälj ett alternativ:");
                    Console.WriteLine("1. Sätt in pengar");
                    Console.WriteLine("2. Ta ut pengar");
                    Console.WriteLine("3. Visa saldo");
                    Console.WriteLine("4. Avsluta");
                    Console.Write("Val: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            HandleDeposit(customer.Account);
                            break;
                        case "2":
                            HandleWithdraw(customer.Account);
                            break;
                        case "3":
                            Console.WriteLine($"Saldo: {customer.Account.Balance} kr");
                            break;
                        case "4":
                            Console.WriteLine("Loggas ut, Välkommen tillbaka!");
                            return;
                        default:
                            Console.WriteLine("Ogiltigt val — välj 1, 2, 3 eller 4.");
                            break;
                    }
                }
            }

            static void HandleDeposit(BankAccount account)
            {
                Console.Write("Ange belopp att sätta in: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    account.Deposit(amount);
                    Console.WriteLine($"Insättning lyckades. Nytt saldo: {account.Balance} kr");
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp, försök igen.");
                }
            }

            static void HandleWithdraw(BankAccount account)
            {
                Console.Write("Ange belopp att ta ut: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    if (amount <= account.Balance)
                    {
                        account.Withdraw(amount);
                        Console.WriteLine($"Uttag lyckades. Nytt saldo: {account.Balance} kr");
                    }
                    else
                    {
                        Console.WriteLine("Du kan inte ta ut mer än saldot.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp, försök igen.");
                }
            }
        }
    }
}
