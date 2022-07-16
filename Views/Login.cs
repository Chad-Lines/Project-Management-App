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
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
