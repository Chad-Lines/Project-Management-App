using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Management.Views
{
    public partial class UserAdd : Form
    {
        public UserAdd()
        {
            InitializeComponent();

            // Hiding the test button by default
            btnTest.Enabled = false;
            btnTest.Visible = false;

            // Hiding the password characters
            tbPassword.PasswordChar = '*';
            tbPasswordConfirm.PasswordChar = '*';
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // We're checking for successes (i.e. true returns)
            if (Services.DataValidationService.CheckEmptyString(tbUsername.Text) &&     // If the username is not empty,
                Services.DataValidationService.CheckEmptyString(tbFirstName.Text) &&    // and the first name is not empty,
                Services.DataValidationService.CheckEmptyString(tbLastName.Text))       // and the last name is not empty...
            {
                if (Services.DataValidationService.CheckEmail(tbEmail.Text))            // And the email is formated correctly...
                {
                    if (tbPassword.Text == tbPasswordConfirm.Text)                      // And if the passwords match
                    {
                        // Generate the salt and password hashes
                        string salt = Services.PasswordSecurityService.GenerateSalt();
                        string saltedPassword = tbPassword.Text + salt;
                        string passwordHash = Services.PasswordSecurityService.HashPassword(saltedPassword);

                        // Create the new user object based on user-provided info
                        Models.User newUser = new Models.User();
                        newUser.UserName = tbUsername.Text;
                        newUser.FirstName = tbFirstName.Text;
                        newUser.LastName = tbLastName.Text;
                        newUser.Email = tbEmail.Text;
                        newUser.PasswordSalt = salt;
                        newUser.PasswordHash = passwordHash;

                        // Automatically generated data
                        newUser.CreatedDate = DateTime.Now;
                        newUser.CreatedByUserId = 1;            // UPDATE!!!
                        newUser.ModifiedDate = DateTime.Now;
                        newUser.ModifiedByUserId = 1;           // UPDATE!!!                      

                        // Save the user to the database and close the window
                        // Services.DatabaseOperations.AddUser(newUser);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The passwords don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Email entry is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("All fields must be completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void btnTest_Click(object sender, EventArgs e)
        {
            // Generate the salt and password hashes
            string salt = Services.PasswordSecurityService.GenerateSalt();
            string saltedPassword = "test" + salt;
            string passwordHash = Services.PasswordSecurityService.HashPassword(saltedPassword);

            // Create the new user object based on user-provided info
            Models.User newUser = new Models.User();
            newUser.UserName = "test";
            newUser.FirstName = "John";
            newUser.LastName = "Doe";
            newUser.Email = "johndoe@test.com";
            newUser.PasswordSalt = salt;
            newUser.PasswordHash = passwordHash;

            // Automatically generated data
            newUser.CreatedDate = DateTime.Now;
            newUser.CreatedByUserId = 1;
            newUser.ModifiedDate = DateTime.Now;
            newUser.ModifiedByUserId = 1;

            // Add the test user to the database
            Services.DatabaseService.AddUser(newUser);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
