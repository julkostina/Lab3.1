using Data_layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Entities
{
    public class Student:Human
    {
        string firstName { get; set; }
        string lastName { get; set; }
        int height { get; set; }
        int weight { get; set; }
        string passport { get; set; }
        string stCard { get; set; }
        public int Weight { get { return weight; } }
        public int Height { get { return height; } }
        public string StudentCard { get { return stCard; } }
        public override string Activity()
        {
            return "I study in university";
        }
        public override string Cycling()
        {
            return "I don't like cycling";
        }
        public override string ToString()
        {
            return ($"  Student {firstName} {lastName}\r\n{{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"{firstName}\",\r\n    \"lastName\": \"{lastName}\",\r\n    \"height\": \"{height}\",\r\n    \"weight\": \"{weight}\",\r\n    \"stCard\": \"{stCard}\",\r\n    \"passport\": \"{passport}\"\r\n}}");
        }
        public Student(string firstName, string lastName, int height, int weight, string passport, string stCard) : base(firstName, lastName,passport)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.stCard = stCard;
            this.height = height;
            this.weight = weight;
            this.passport = passport;
        }
    }
}
