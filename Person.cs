using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankaccount
{
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
}
