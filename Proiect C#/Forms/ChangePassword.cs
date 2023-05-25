using Oracle.ManagedDataAccess.Client;
using Proiect_C_.Entities;
using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class ChangePassword : Form
    {
        readonly string pwd;
        readonly Client Client;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public ChangePassword(string pwd, Client client) : this()
        {
            this.pwd = pwd;
            Client = client;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
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

        public Client getClient()
        {
            return Client;
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


        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Please revise your new password before submitting!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(oldPwdTxtBox.Text == newPwdTxtBox.Text)
            {
                MessageBox.Show("New password must be different from the old one!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DBUtils.DBUtils.UnzipArchive(pwd);
                using (var connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.DbConnection, pwd)))
                {
                    connection.Open();
                    var query = "select password from users where email = :email";
                    var cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add("email", Client.Email);
                    var reader = cmd.ExecuteReader();
                    var hashedPwd = reader.Read() ? Convert.FromBase64String(reader.GetString(0)) : Convert.FromBase64String("");
                    reader.Close();
                    var salt = new byte[16];
                    Array.Copy(hashedPwd, 0, salt, 0, 16);
                    var pbkdf2 = new Rfc2898DeriveBytes(oldPwdTxtBox.Text, salt, 10000, HashAlgorithmName.MD5);
                    var hash = pbkdf2.GetBytes(20);
                    for(int i = 0; i < 20; i++)
                        if (hashedPwd[i + 16] != hash[i])
                        {
                            MessageBox.Show("Old password is incorrect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    query = "update users set password = :password where email = :email";
                    cmd = new OracleCommand(query, connection);
                    salt = new byte[16];
                    new RNGCryptoServiceProvider().GetBytes(salt);
                    pbkdf2 = new Rfc2898DeriveBytes(newPwdTxtBox.Text, salt, 10000, HashAlgorithmName.MD5);
                    hash = pbkdf2.GetBytes(20);
                    var hashBytes = new byte[36];
                    Array.Copy(salt, 0, hashBytes, 0, 16);
                    Array.Copy(hash, 0, hashBytes, 16, 20);
                    cmd.Parameters.Add("password", Convert.ToBase64String(hashBytes));
                    cmd.Parameters.Add("email", Client.Email);
                    cmd.ExecuteNonQuery();
                    DBUtils.DBUtils.DeleteFiles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void showOldPwdBtn_Click(object sender, EventArgs e)
        {
            oldPwdTxtBox.UseSystemPasswordChar = !oldPwdTxtBox.UseSystemPasswordChar;
            showOldPwdBtn.Visible = !showOldPwdBtn.Visible;
            hideOldPwdBtn.Visible = !hideOldPwdBtn.Visible;
        }

        private void hideOldPwdBtn_Click(object sender, EventArgs e)
        {
            oldPwdTxtBox.UseSystemPasswordChar = !oldPwdTxtBox.UseSystemPasswordChar;
            hideOldPwdBtn.Visible = !hideOldPwdBtn.Visible;
            showOldPwdBtn.Visible = !showOldPwdBtn.Visible;
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
