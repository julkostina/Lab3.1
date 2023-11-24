using Data_layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace Data_layer.Entities
{
    public class Librarian : Human
    {
        string firstName { get; set; }
         string lastName { get; set; }
         string passport { get; set; }
        public override string Activity()
        {
            return "I like reading";
        }
        public override string Cycling()
        {
            return "I like cycling";
        }
        public override string ToString()
        {
            return ($" Librarian {firstName} {lastName}\r\n{{\r\n    \"entity\": \"librarian\",\r\n    \"firstName\": \"{firstName}\",\r\n    \"lastName\": \"{lastName}\",\r\n     \"passport\": \"{passport}\"\r\n}}");
        }
        public Librarian(string firstName, string lastName, string passport):base(firstName, lastName,passport)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passport = passport;
        }

    }
}
