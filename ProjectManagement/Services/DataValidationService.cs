using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class DataValidationService
    {

        private static bool CheckEmptyString(string s)
        {
            // Returns true if the string is not null. Returns false if it is.
            return !string.IsNullOrWhiteSpace(s); 
        }

        private static bool CheckDateOrder(DateTime a, DateTime b)
        {
            // Returns true if the earlier date (a) is before the later date (b)
            return a < b;
        }

        private static bool CheckEmail(string e)
        {
            if (String.IsNullOrEmpty(e)) { return false; }  // If the email is empty, the check fails

            var trimmedEmail = e.Trim();                        // Trim whitespace 
            if (trimmedEmail.EndsWith(".")) { return false; }   // If the email ends in "." it fails the test

            try
            {
                // Shortcutting by using the MailAddress class to verify the email address format.
                // We then return bool whether the trimmed email equals the verified email.
                // If it does, then the address is valid. If not, then it's invalid.
                var addr = new System.Net.Mail.MailAddress(e);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                // If the above check fails (i.e. the email is unvalidated by the MailAddress class),
                // then it's invalid and we return false.
                return false;
            }
        }
    }
}
