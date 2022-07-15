using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project_Management.Services
{
    public class DataValidationService
    {

        public static bool CheckEmptyString(string s)
        {
            // Returns true if the string is not null. Returns false if it is.
            return !string.IsNullOrWhiteSpace(s);
        }

        public static bool CheckDateOrder(DateTime a, DateTime b)
        {
            // Returns true if the earlier date (a) is before the later date (b)
            return a < b;
        }

        public static bool CheckEmail(string e)
        {
            return !string.IsNullOrWhiteSpace(e);

            //var trimmedEmail = e.Trim();                        // Trim whitespace 
            //if (trimmedEmail.EndsWith(".")) { return false; }   // If the email ends in "." it fails the test

            //try
            //{
            //    // Shortcutting by using the MailAddress class to verify the email address format.
            //    // We then return bool whether the trimmed email equals the verified email.
            //    // If it does, then the address is valid. If not, then it's invalid.
            //    var addr = new System.Net.Mail.MailAddress(e);
            //    Console.WriteLine(trimmedEmail);
            //    Console.WriteLine(addr.Address);
            //    return addr.Address == trimmedEmail;
            //}
            //catch
            //{
            //    // If the above check fails (i.e. the email is unvalidated by the MailAddress class),
            //    // then it's invalid and we return false.
            //    return false;
            //}
        }

        public static bool CheckPasswordComplexity(string p)
        {
            // The password score must be above the threshold in order to be valid.
            // The total possible password score is 6
            int passwordScore = 0;
            int requiredScore = 4;

            if (string.IsNullOrWhiteSpace(p) || p.Length < 8) { return false; } // If the password is blank or too short, then auto fail
            if (p.Length >= 10) { passwordScore++; }                            // If the password is 10 chars or longer, give a point
            if (p.Length >= 16) { passwordScore += 2; }                        // If the password is 16 chars or longer, give two points

            if (Regex.Match(p, @"/\d+/", RegexOptions.ECMAScript).Success)      // If it contains a number, give a point
                passwordScore++;

            if (Regex.Match(p, @"/[a-z]/", RegexOptions.ECMAScript).Success &&  // If it contains an upper AND lowercase letter, give a point
                Regex.Match(p, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                passwordScore++;

            if (Regex.Match(p, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/",           // If it contains a special character, give a point
                RegexOptions.ECMAScript).Success)
                passwordScore++;

            return passwordScore >= requiredScore;                              // Return whether the password score meets requirements
        }
    }
}
