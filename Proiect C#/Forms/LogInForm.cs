using Proiect_C_.Entities;
using Proiect_C_.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Proiect_C_.Forms
{
    public partial class LogInForm : Form
    {
        public Client Client { get; set; }
        public string pwd;
        public LogInForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
        }
        public LogInForm(string pwd):this()
        {
            this.pwd = pwd;
        }
        private void emailTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!isValidMail(emailTxtBox.Text, out errorMsg))
            {
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

        private void logInBtn_Click(object sender, EventArgs e)
        {
            if(this.errorProvider.GetError(emailTxtBox)=="")
                if (this.pwdTxtBox.Text == "")
                    { MessageBox.Show("Enter a password first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if(this.errorProvider.GetError(emailTxtBox)=="")
            {
                DBUtils.DBUtils.UnzipArchive(pwd);
                string connectionString = Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd);
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Email = :Email";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":Email", emailTxtBox.Text);
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] hashBytes = Convert.FromBase64String(reader["Password"].ToString());
                                byte[] salt = new byte[16];
                                Array.Copy(hashBytes, 0, salt, 0, 16);
                                var pbkdf2 = new Rfc2898DeriveBytes(pwdTxtBox.Text, salt, 10000, HashAlgorithmName.MD5);
                                byte[] hash = pbkdf2.GetBytes(20);
                                for (int i = 0; i < 20; i++)
                                {
                                    if (hashBytes[i + 16] != hash[i])
                                    {
                                        MessageBox.Show("The password is not matching the one saved in the database!","Wrong password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                if (reader["TwoFactor"].ToString() == "Y")
                                {
                                    var verifyTFA = new Verify2FA(Encryption.EncryptionUtils.DecryptString(reader["private_key"].ToString(), pwd));
                                    if (verifyTFA.ShowDialog() != DialogResult.OK)
                                    {
                                        MessageBox.Show("2FA not verified! Try again!", "Wrong 2FA code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                this.DialogResult = DialogResult.OK;
                                this.emailTxtBox.Text = "";
                                this.pwdTxtBox.Text = "";
                                this.Client = new Client(reader["FirstName"].ToString(), reader["LastName"].ToString(), (byte[])reader["Photo"], reader["Email"].ToString(), reader["Phone"].ToString());
                            }
                            else
                            {
                                MessageBox.Show("The Email has not been found in the database!","Wrong user!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    DBUtils.DBUtils.DeleteFiles();
                }
            }
            else
            {
                MessageBox.Show("Enter a valid mail first!", "Type a valid mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.Close();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            this.welcomeLabel.Parent = this.bgBox;
            this.emailLabel.Parent = this.bgBox;
            this.passwordLabel.Parent = this.bgBox;
            this.forgotPwdLbl.Parent = this.bgBox;
            this.welcomeLabel.BackColor = Color.Transparent;
            this.emailLabel.BackColor = Color.Transparent;
            this.passwordLabel.BackColor = Color.Transparent;
            this.forgotPwdLbl.BackColor = Color.Black;
        }

        private void forgotPwdLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (emailTxtBox.Text == "")
            {
                MessageBox.Show("Enter an email first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(errorProvider.GetError(emailTxtBox)!="")
            {
                MessageBox.Show("Enter a valid email first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DBUtils.DBUtils.UnzipArchive(pwd);
                using (var conexiune = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd)))
                {
                    var query = "select * from users where email = :email";
                    using (var comanda = new OracleCommand(query, conexiune))
                    {
                        conexiune.Open();
                        comanda.Parameters.Add(":email", emailTxtBox.Text);
                        var reader = comanda.ExecuteReader();
                        reader.Read();
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Email not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (reader["twofactor"].ToString()=="Y")
                        {
                            var verifyTFA = new Verify2FA(Encryption.EncryptionUtils.DecryptString(reader["private_key"].ToString(), pwd));
                            if (verifyTFA.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("2FA not verified! Try again!", "Wrong 2FA code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var resetPwd = new ResetPassword();
                            if (resetPwd.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("Password not reset!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            query = "update users set password = :password where email = :email";
                            using (var comanda2 = new OracleCommand(query, conexiune))
                            {
                                byte[] salt;
                                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                                var pbkdf2 = new Rfc2898DeriveBytes(resetPwd.GetNewPassword(), salt, 10000, HashAlgorithmName.MD5);
                                byte[] hash = pbkdf2.GetBytes(20);
                                byte[] hashBytes = new byte[36];
                                Array.Copy(salt, 0, hashBytes, 0, 16);
                                Array.Copy(hash, 0, hashBytes, 16, 20);
                                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                                comanda2.Parameters.Add(":password", savedPasswordHash);
                                comanda2.Parameters.Add(":email", emailTxtBox.Text);
                                comanda2.ExecuteNonQuery();
                            }
                            MessageBox.Show("Password reset!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var accountSid = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioSID, pwd);
                            var authToken = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioAuthToken, pwd);
                            var phoneNumber = Encryption.EncryptionUtils.DecryptString(Settings.Default.PhoneNumber, pwd);
                            TwilioClient.Init(accountSid, authToken);
                            var code = new Random().Next(0, 1000000).ToString("D6");
                            var message = MessageResource.Create(
                                body: $"Enter this code to bypass login by password: {code}",
                                from: new Twilio.Types.PhoneNumber(phoneNumber),
                                to: new Twilio.Types.PhoneNumber("+4"+reader["phone"].ToString())
                            );
                            var verifySMS = new VerifySMS(code);
                            if (verifySMS.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("SMS not verified! Try again!", "Wrong SMS code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var resetPwd = new ResetPassword();
                            if (resetPwd.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("Password not reset!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            query = "update users set password = :password where email = :email";
                            using (var comanda2 = new OracleCommand(query, conexiune))
                            {
                                byte[] salt;
                                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                                var pbkdf2 = new Rfc2898DeriveBytes(resetPwd.GetNewPassword(), salt, 10000, HashAlgorithmName.MD5);
                                byte[] hash = pbkdf2.GetBytes(20);
                                byte[] hashBytes = new byte[36];
                                Array.Copy(salt, 0, hashBytes, 0, 16);
                                Array.Copy(hash, 0, hashBytes, 16, 20);
                                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                                comanda2.Parameters.Add(":password", savedPasswordHash);
                                comanda2.Parameters.Add(":email", emailTxtBox.Text);
                                comanda2.ExecuteNonQuery();
                            }
                            MessageBox.Show("Password reset!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    DBUtils.DBUtils.DeleteFiles();
                }

            }
        }

        private void hideFirstPwdBtn_Click(object sender, EventArgs e)
        {
            pwdTxtBox.UseSystemPasswordChar = !pwdTxtBox.UseSystemPasswordChar;
            hideFirstPwdBtn.Visible = !hideFirstPwdBtn.Visible;
            showSecondPwdBtn.Visible = !showSecondPwdBtn.Visible;
        }

        private void showSecondPwdBtn_Click(object sender, EventArgs e)
        {
            pwdTxtBox.UseSystemPasswordChar = !pwdTxtBox.UseSystemPasswordChar;
            showSecondPwdBtn.Visible = !showSecondPwdBtn.Visible;
            hideFirstPwdBtn.Visible = !hideFirstPwdBtn.Visible;
        }

        private void pwdTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                logInBtn_Click(sender, e);
            }
        }
    }
}
