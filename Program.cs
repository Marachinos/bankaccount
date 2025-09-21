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
                Console.WriteLine($"Välkommen till bankkonto.se! \nFyll i din 4-siffriga kod: ");
                while (true)
                {
                    Console.Write("PIN: ");
                    var pin = Console.ReadLine();
                    if (customer.Authenticate(pin))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Inloggning lyckades! \nVälkommen {customer.Person.Name}!");
                        Console.ResetColor();
                        DisplayMenu(customer); //Menu is displayed if pin is correct
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktig kod, försök igen: ");
                        Console.ResetColor();
                    }

                }
            }
            static void DisplayMenu (Customer customer) //Displays a menu for the user to interact with their bank account
            {
                while (true)
                { 
                Console.WriteLine("\nVälj ett av följande alternativ:");
                    Console.WriteLine("1. Sätt in pengar");
                    Console.WriteLine("2. Ta ut pengar");
                    Console.WriteLine("3. Visa saldo");
                    Console.WriteLine("4. Avsluta");
                    Console.Write("Ditt val: ");
                    var choice = Console.ReadLine();
                    switch (choice) //Diffrent options for the custumer to choose from
                    {
                        case "1":
                            Console.Write("Ange belopp att sätta in: ");
                                HandleDeposit(customer.Account);
                            break;
                         case "2":
                            Console.Write("Ange belopp att ta ut: ");
                                HandleWithDraw(customer.Account);
                            break;
                         case "3":
                            Console.WriteLine($"Ditt saldo är: {customer.Account.Balance:C}");
                            break;  
                         case "4":
                            Console.WriteLine("Tack för att du använde bankkonto.se! Välkommen tillbaka!");
                            return;
                         default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            Console.ResetColor();
                            break;
                    }
                }
            }
                static void HandleDeposit(BankAccount account) //Handles deposits to the bank account
            {
                Console.WriteLine("Ange belopp att sätta in: ");
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out var amount) && amount > 0)
                {
                    account.Deposit(amount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Insättning lyckades! Nytt saldo: {account.Balance} sek");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt belopp, försök igen.");
                    Console.ResetColor();
                }
            }
            static void HandleWithDraw(BankAccount account) //Handles withdrawals from the bank account
            {
                Console.WriteLine("Ange belopp att ta ut: ");
                if 
                    (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    if 
                        (amount <= account.Balance)
                    {
                        account.Withdraw(amount);
                        Console.WriteLine($"Uttaget lyckades. Nytt saldo: {account.Balance} SEK");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du kan inte ta ut mer än vad som finns på kontot!");
                    }
                }
                else
                {
                   Console.WriteLine("Ogiltigt belopp! Försök igen!");
                    Console.ResetColor();
                }
            }

        }
    }
}
