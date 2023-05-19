using Proiect_C_.Entities;
using Proiect_C_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using MimeKit;

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
                    connection.Close();
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
            this.forgotPwdLbl.BackColor = Color.Transparent;
        }

        private void forgotPwdLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (emailTxtBox.Text == "")
            {
                MessageBox.Show("Enter an email first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                using (var conexiunea = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd)))
                {
                    var query = "select twofactor from users where email = :email";
                    using (var comanda = new OracleCommand(query, conexiunea))
                    {
                        comanda.Parameters.Add(":email", emailTxtBox.Text);
                        var reader = comanda.ExecuteReader();
                        reader.Read();
                        if (reader["twofactor"].ToString()=="Y")
                        {

                        }
                        else
                        {
                            //var answer = MessageBox.Show("User does not have 2FA enabled! Send verification code to mail?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            //if(answer==DialogResult.Yes)
                            //{
                            //    var code = new Random().Next(0, 1000000).ToString("D6");
                            //    string email = emailTxtBox.Text;
                            //    string subject = "Recover your mail @ Bookify™ 📓";
                            //    string body = $"Hello, a reset password request has been made from your email address! 😉\n\nIf you request it, your verification code is: " + code.ToString();
                            //    var msg = new MimeMessage();
                            //    msg.From.Add(new MailboxAddress("Bookify Verification Service", Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Email, pwd)));
                            //    msg.To.Add(new MailboxAddress(firstNameTxtBox.Text + " " + lastNameTxtBox.Text, email));
                            //    msg.Subject = subject;
                            //    msg.Body = new TextPart("plain")
                            //    {
                            //        Text = body
                            //    };
                            //    using (var client = new SmtpClient())
                            //    {
                            //        var mail = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Email, pwd);
                            //        var password = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Password, pwd);
                            //        var smtpaddr = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.SmtpAddress, pwd);
                            //        var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.SmtpPort, pwd));
                            //        client.Connect(smtpaddr, smtpport, true);
                            //        client.Authenticate(mail, password);
                            //        client.Send(msg);
                            //        client.Disconnect(true);
                            //    }
                            //    var verification = new VerificationForm();
                            //}
                        }
                    }
                }

            }
        }
    }
}
