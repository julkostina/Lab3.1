using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bussiness_layer
{
    public class Checking
    {
        public Checking() { }

        public Regex validNameSurname = new (@"^[A-Z]{1}[a-z]{3,20}$");

        public Regex validPassport = new (@"^\d{9}$");

        public Regex validStCard = new (@"^KB\d{8}$");

        public Regex validWeightHeight = new(@"^\d{2,3}$");

        public Regex validInput = new(@"[1-7]\d{1}");
    }
}
