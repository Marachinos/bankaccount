namespace bankaccount
{
    using System;

    internal class Program
    {
        class ProgramMain //Added class-files: Customer.cs, Person.cs and Bankaacount.cs
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
                void PrintMenu() //The menu shows 1 time and can be shown again by pressing M
                {
                    Console.WriteLine("\nVälj ett av följande alternativ:");
                    Console.WriteLine("1. Sätt in pengar");
                    Console.WriteLine("2. Ta ut pengar");
                    Console.WriteLine("3. Visa saldo");
                    Console.WriteLine("4. Avsluta");
                    Console.WriteLine("M. Visa menyn igen");
                }

                PrintMenu();

                while (true)
                {
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
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Ditt saldo är: {customer.Account.Balance:C} SEK");
                            Console.ResetColor();
                            break;  
                         case "4":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Tack för att du använde bankkonto.se! Välkommen tillbaka!");
                            Console.ResetColor();
                            return;
                        case "M":
                            PrintMenu(); //Show the meny again
                            break;
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
                Console.WriteLine();
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out var amount) && amount > 0)
                {
                    account.Deposit(amount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Insättning lyckades! Nytt saldo: {account.Balance} SEK");
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
                Console.WriteLine();
                if 
                    (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    if 
                        (amount <= account.Balance)
                    {
                        account.Withdraw(amount);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Uttaget lyckades. Nytt saldo: {account.Balance} SEK");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du kan inte ta ut mer än vad som finns på kontot!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt belopp! Försök igen!");
                    Console.ResetColor();
                }
            }

        }
    }
}
