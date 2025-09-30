using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankaccount
{
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
}
