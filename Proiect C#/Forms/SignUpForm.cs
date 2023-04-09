using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void emailTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!isValidMail(emailTxtBox.Text, out errorMsg))
            {
                e.Cancel = true;
                emailTxtBox.Select(0, emailTxtBox.Text.Length);
                this.errorProvider.SetError(emailTxtBox, errorMsg);
            }
        }
        private bool isValidMail(string email, out string errorMsg)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Match match = Regex.Match(email, pattern);
            if (match.Success)
            {
                errorMsg = "";
                return true;
            }
            else
            {
                errorMsg = "Please enter a valid email address!";
                return false;
            }
        }

        private void firstPwdTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!IsValidPassword(firstPwdTxtBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider.SetError(firstPwdTxtBox, errorMsg);
            }
        }
        private bool IsValidPassword(string password, out string errorMsg)
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                else if (char.IsLower(c))
                    hasLower = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                    hasSpecial = true;
            }

            if (password.Length < 8)
            {
                errorMsg = "Password must be at least 8 characters long";
                return false;
            }
            else if (!hasUpper)
            {
                errorMsg = "Password must contain at least one uppercase letter";
                return false;
            }
            else if (!hasLower)
            {
                errorMsg = "Password must contain at least one lowercase letter";
                return false;
            }
            else if (!hasDigit)
            {
                errorMsg = "Password must contain at least one digit";
                return false;
            }
            else if (!hasSpecial)
            {
                errorMsg = "Password must contain at least one special character";
                return false;
            }
            else
            {
                errorMsg = "";
                return true;
            }
        }

        private void secondPwdTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!PasswordsMatch(secondPwdTxtBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider.SetError(secondPwdTxtBox, errorMsg);
            }
        }

        private bool PasswordsMatch(string password, out string errorMsg)
        {
            if (password == firstPwdTxtBox.Text)
            {
                errorMsg = "";
                return true;
            }
            else
            {
                errorMsg = "Passwords do not match!";
                return false;
            }
        }

        private void firstNameTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!isNameValid(firstNameTxtBox.Text, out errorMsg))
            {
                e.Cancel = true;
                firstNameTxtBox.Select(0, firstNameTxtBox.Text.Length);
                this.errorProvider.SetError(firstNameTxtBox, errorMsg);
            }
        }

        private bool isNameValid(string name, out string errorMsg)
        {
            string pattern = "^[A-Z][a-z]*$";
            Match match = Regex.Match(name, pattern);
            if (match.Success)
            {
                errorMsg = "";
                return true;
            }
            else
            {
                errorMsg = "Please enter a valid name!";
                return false;
            }
        }

        private void lastNameTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!isNameValid(lastNameTxtBox.Text, out errorMsg))
            {
                e.Cancel = true;
                lastNameTxtBox.Select(0, lastNameTxtBox.Text.Length);
                this.errorProvider.SetError(lastNameTxtBox, errorMsg);
            }
        }


        private void phoneTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!isPhoneValid(phoneTxtBox.Text, out errorMsg))
            {
                e.Cancel = true;
                phoneTxtBox.Select(0, phoneTxtBox.Text.Length);
                this.errorProvider.SetError(phoneTxtBox, errorMsg);
            }
        }

        private bool isPhoneValid(string phone, out string errorMsg)
        {
            string pattern = @"^07\d{8}$";
            Match match = Regex.Match(phone, pattern);
            if (match.Success)
            {
                errorMsg = "";
                return true;
            }
            else
            {
                errorMsg = "Please enter a valid phone number!";
                return false;
            }
        }



        private void showPwdChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPwdChkBox.Checked)
            {
                firstPwdTxtBox.PasswordChar = '\0';
                secondPwdTxtBox.PasswordChar =
                    '\0';
            }
            else
            {
                firstPwdTxtBox.PasswordChar = '*';
                secondPwdTxtBox.PasswordChar = '*';
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Your account has been registered!");
                // try creating a database with just a table: email and unique code to be sent to mail; if it already exists, then just add a new entry to the table and send it to mail
                try
                {
                    string connectionString = Properties.Settings.Default.DbConnection;
                    
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
