using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProjectManagement.Services
{
    internal class PasswordSecurityService
    {
       // Function: The user-creation script should:
       // 1. Get the salt for the password (String salt = SaltPassword();)
       // 2. Save the password and the salt to the database (separately)
       // 3. Combine the password with the salt (saltedPassword = password + salt;)
       // 4. Hash the salted password (passwordHash = HashPassword(saltedPassword);) 
       // 5. Save the hash to the database

        public static string GenerateSalt()
        {            
            Random rand = new Random();                             // The object used to randomize output
            String chars = "abcdefghijklmnopqrstuvwxyz0123456789";  // The characters from which to select
            String salt = "";                                       // The string to hold the salt
            int saltSize = 10;                                      // The character length of the salt            
            
            for (int i = 0; i < saltSize; i++)                      // For each char in the size of the salt (i.e 10)...
            {
                int x = rand.Next(chars.Length);                    // Select a random index from the length of chars
                salt += chars[x];                                   // Append the character at the random index to build the salt string
            }

            return salt;                                 // Return the salted password
        }

        public static string HashPassword(string saltedPassword)
        {
            // Creating a SHA256 object that we can use to hash the salted password
            using (SHA256 sha256 = SHA256.Create())
            {
                // Generating a hash of the salted passsword (the ComputeHash returns a byte array)
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Converting the byte array to a string
                StringBuilder builder = new StringBuilder();    // Creating the StringBuilder object

                for (int i = 0; i < bytes.Length; i++)          // For each int in the bytes variable...
                {
                    /*
                     * ToString("X2") is the string format control character in C#                     *
                     * - X is hexadecimal
                     * - 2 is two digits every time
                     */
                    builder.Append(bytes[i].ToString("X2"));    // Append the byte to the string builder
                }
                // Returning the string builder as a string
                return builder.ToString();                
            }
        }        

    }
}
