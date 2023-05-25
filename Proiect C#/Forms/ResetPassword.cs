using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
            newPwdTxtBox.MaxLength = retypePwdTxtBox.MaxLength = 20;
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

        private void newPwdTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!IsValidPassword(newPwdTxtBox.Text, out errorMsg))
            {
                this.errorProvider.SetError(newPwdTxtBox, errorMsg);
                if (this.ActiveControl != cancelBtn && this.ActiveControl != showNewPwdBtn && this.ActiveControl != hideNewPwdBtn && this.ActiveControl != showNewRetypedPwdBtn && this.ActiveControl != hideNewRetypedPwdBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
            }
        }

        private bool PasswordsMatch(string password, out string errorMsg)
        {
            if (password == newPwdTxtBox.Text)
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

        private void retypePwdTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!PasswordsMatch(retypePwdTxtBox.Text, out errorMsg))
            {
                this.errorProvider.SetError(retypePwdTxtBox, errorMsg);
                if (this.ActiveControl != cancelBtn && this.ActiveControl != showNewPwdBtn && this.ActiveControl != hideNewPwdBtn && this.ActiveControl != showNewRetypedPwdBtn && this.ActiveControl != hideNewRetypedPwdBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Please revise the password you entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        public string GetNewPassword()
        {
            return newPwdTxtBox.Text;
        }

        private void showNewPwdBtn_Click(object sender, EventArgs e)
        {
            newPwdTxtBox.UseSystemPasswordChar = !newPwdTxtBox.UseSystemPasswordChar;
            showNewPwdBtn.Visible = !showNewPwdBtn.Visible;
            hideNewPwdBtn.Visible = !hideNewPwdBtn.Visible;
        }

        private void hideNewPwdBtn_Click(object sender, EventArgs e)
        {
            newPwdTxtBox.UseSystemPasswordChar = !newPwdTxtBox.UseSystemPasswordChar;
            hideNewPwdBtn.Visible = !hideNewPwdBtn.Visible;
            showNewPwdBtn.Visible = !showNewPwdBtn.Visible;
        }

        private void showNewRetypedPwdBtn_Click(object sender, EventArgs e)
        {
            retypePwdTxtBox.UseSystemPasswordChar = !retypePwdTxtBox.UseSystemPasswordChar;
            showNewRetypedPwdBtn.Visible = !showNewRetypedPwdBtn.Visible;
            hideNewRetypedPwdBtn.Visible = !hideNewRetypedPwdBtn.Visible;
        }

        private void hideNewRetypedPwdBtn_Click(object sender, EventArgs e)
        {
            retypePwdTxtBox.UseSystemPasswordChar = !retypePwdTxtBox.UseSystemPasswordChar;
            hideNewRetypedPwdBtn.Visible = !hideNewRetypedPwdBtn.Visible;
            showNewRetypedPwdBtn.Visible = !showNewRetypedPwdBtn.Visible;
        }
    }
}
