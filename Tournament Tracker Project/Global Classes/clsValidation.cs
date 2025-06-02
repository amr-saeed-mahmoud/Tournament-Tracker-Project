using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Tournament_Tracker_Project
{
    public static class clsValidation
    {
        public static bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"\b[A-Za-z]+-?[A-Za-z]\b");
        }
        public static bool IsValidNumber(string Number)
        {
            return decimal.TryParse(Number, out _);
        }
        public static bool IsValidEmail(string Email)
        {
            return Regex.IsMatch(Email, @"\b[A-Za-z-\.]+[0-9]*[A-Za-z-\.]*@gmail\.com");
        }
    }
}
