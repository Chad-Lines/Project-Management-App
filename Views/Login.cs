﻿using System;
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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

            lblError.Hide();                // Hide the error label
            tbPassword.PasswordChar = '*';  // Hide the password characters
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string un = tbUsername.Text;    // Capturing the username
            string pw = tbPassword.Text;    // Capturing the password
            
            // If the username or password are empty, then show the error
            if (string.IsNullOrEmpty(un) || string.IsNullOrEmpty(pw)) { lblError.Show(); }

            // If the username and password are not empty, then try to authenticate
            else { AuthenticateUser(un, pw); }
        }

        private void AuthenticateUser(string un, string pw)
        {
            string logMsg;                                                                          // The log message
            string logType;                                                                         // The log type
            Models.User user = new Models.User();                                                   // Object to hold the user

            int uid = Services.DatabaseService.GetUserId(un);                                       // Check the username and get the user id
            
            if (uid <= 0) 
            { 
                lblError.Show();                                                                    // If the uid is not legitimate, show the error'

                logMsg = $"Unsuccessful login with username {un}";                                  // The log message
                logType = "Warning";                                                                // The log type
                Services.LogService.Add(logMsg, logType);                                           // Logging the event
            }                                                      
            else
            {
                user = Services.DatabaseService.GetUserById(uid);                                   // Getting the user from the database

                string salt = user.PasswordSalt;                                                    // Getting the salt from the database
                string dbHash = user.PasswordHash;                                                  // Getting database hash
                string saltedPassword = pw + salt;                                                  // Add salt to password
                string inputHash = Services.PasswordSecurityService.HashPassword(saltedPassword);   // Hash salted password

                if (inputHash == dbHash) 
                { 
                    LaunchDashboard();                                                              // Check hash against database hash

                    logMsg = $"Successful login by user {un} (id: {uid})";                          // The message to log
                    logType = "Information";                                                        // The log type
                }                                     
                else 
                { 
                    lblError.Show();                                                                // Show the error label
                    logMsg = $"{un} (id: {uid}) failed login attempt: incorrect password";          // The message to log
                    logType = "Warning";                                                            // The log type
                }
            }
            Services.LogService.Add(logMsg, logType, user);                                         // Log the message
        }

        private void LaunchDashboard()
        {
            Dashboard dashboard = new Dashboard();              // Launch dashboard
            dashboard.FormClosed += (s, args) => this.Close();  // This will close the login form when the dashboard is closed
            dashboard.Show();                                   // Show the dashboard
            this.Hide();                                        // Hide the login page
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
