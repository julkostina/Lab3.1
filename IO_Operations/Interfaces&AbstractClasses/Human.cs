using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Interfaces
{
    public abstract class Human
    {
        string firstName;
        string lastName;
        string passport;
        public abstract string Activity();
        public abstract string Cycling();
        public string Name { get { return firstName; } }
        public string Surname { get { return lastName; } }
        public string Passport { get { return passport; } }
        public Human(string firstName, string lastName, string passport)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passport = passport;
        }
    }
}
