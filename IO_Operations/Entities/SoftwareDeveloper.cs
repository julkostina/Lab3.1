using Data_layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Entities
{
    public class SoftwareDeveloper : Human
    {
        string firstName { get; set; }
        string lastName { get; set; }
        string passport { get; set; }
        public override string Activity()
        {
            return "I can code";
        }
        public override string Cycling()
        {
            return "I don't like cycling";
        }
        public override string ToString()
        {
            return ($" Software developer {firstName} {lastName}\r\n{{\r\n    \"entity\": \"software developer\",\r\n    \"firstName\": \"{firstName}\",\r\n    \"lastName\": \"{lastName}\",\r\n     \"passport\": \"{passport}\"\r\n}}");
        }
        public SoftwareDeveloper(string firstName, string lastName,string passport) : base(firstName, lastName, passport)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passport = passport;
        }
    }
}