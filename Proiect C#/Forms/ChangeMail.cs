using MailKit.Net.Smtp;
using MimeKit;
using Oracle.ManagedDataAccess.Client;
using Proiect_C_.Entities;
using Proiect_C_.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Proiect_C_.Forms
{
    public partial class ChangeMail : Form
    {
        public Client Client;
        string pwd;

        public ChangeMail()
        {
            InitializeComponent();
        }

        public ChangeMail(Client client, string pwd): this()
        {
            Client = client;
            this.pwd = pwd;
        }

        private void ChangeMail_Load(object sender, EventArgs e)
        {
            emailLbl.BackColor = Color.Transparent;
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

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(errorProvider.GetError(emailTxtBox) != "")
            {
                MessageBox.Show("Please enter a valid email address!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (emailTxtBox.Text == "")
            {
                MessageBox.Show("Please enter an email address!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (emailTxtBox.Text == Client.Email)
            {
                MessageBox.Show("Please enter a different email address!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string connectionString = Settings.Default.DbConnection;
                using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(connectionString, pwd)))
                {
                    connection.Open();
                    // check if the email already exists
                    string query = "SELECT * FROM Users WHERE Email = :Email";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":Email", emailTxtBox.Text);
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("This email already exists in the database!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        query = "select * from users where email = :email";
                        using (var cmd = new OracleCommand(query, connection))
                        {
                            cmd.Parameters.Add(":email", Client.Email);
                            using (var reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                if (reader["twofactor"].ToString() == "Y")
                                {
                                    MessageBox.Show("Verify your 2FA code in order to change your mail!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var verify2FA = new Verify2FA(Encryption.EncryptionUtils.DecryptString(reader["private_key"].ToString(), pwd));
                                    if (verify2FA.ShowDialog() != DialogResult.OK)
                                    {
                                        MessageBox.Show("You have to verify your 2FA code in order to change your mail! Try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    string code = new Random().Next(0, 1000000).ToString("D6");
                                    string email = emailTxtBox.Text;
                                    string subject = "Verify your new email @ Bookify™ 📓";
                                    string body = $"Hello, {Client.FirstName}! 😉\n\nYour verification code is: " + code.ToString();
                                    var msg = new MimeMessage();
                                    msg.From.Add(new MailboxAddress("Bookify Verification Service", Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd)));
                                    msg.To.Add(new MailboxAddress(Client.FirstName + " " + Client.LastName, email));
                                    msg.Subject = subject;
                                    msg.Body = new TextPart("plain")
                                    {
                                        Text = body
                                    };
                                    using (var client = new SmtpClient())
                                    {
                                        var mail = Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd);
                                        var password = Encryption.EncryptionUtils.DecryptString(Settings.Default.Password, pwd);
                                        var smtpaddr = Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpAddress, pwd);
                                        var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpPort, pwd));
                                        client.Connect(smtpaddr, smtpport, true);
                                        client.Authenticate(mail, password);
                                        client.Send(msg);
                                        client.Disconnect(true);
                                    }
                                    if (new VerificationForm(code, email).ShowDialog() == DialogResult.OK)
                                    {
                                            // update the email
                                            query = "update users set email = :newmail where email = :oldmail";
                                            using (OracleCommand command2 = new OracleCommand(query, connection))
                                            {
                                                command2.Parameters.Add(":newmail", email);
                                                command2.Parameters.Add(":oldmail", Client.Email);
                                                command2.ExecuteNonQuery();
                                            }
                                            // update the bookings 
                                            query = "update bookings set clientemail = :newmail where clientemail = :oldmail";
                                            using (OracleCommand command3 = new OracleCommand(query, connection))
                                            {
                                                command3.Parameters.Add(":newmail", email);
                                                command3.Parameters.Add(":oldmail", Client.Email);
                                                command3.ExecuteNonQuery();
                                            }
                                            // update the temp_bookings
                                            query = "update temp_bookings set clientemail = :newmail where clientemail = :oldmail";
                                            using (OracleCommand command4 = new OracleCommand(query, connection))
                                            {
                                                command4.Parameters.Add(":newmail", email);
                                                command4.Parameters.Add(":oldmail", Client.Email);
                                                command4.ExecuteNonQuery();
                                            }
                                        
                                        Client.Email = email;
                                        MessageBox.Show("Email changed successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email change cancelled!", "Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Verify the code sent to your phone in order to change your mail!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var accountSid = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioSID, pwd);
                                    var authToken = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioAuthToken, pwd);
                                    var phoneNumber = Encryption.EncryptionUtils.DecryptString(Settings.Default.PhoneNumber, pwd);
                                    TwilioClient.Init(accountSid, authToken);
                                    var verificationCode = new Random().Next(0, 1000000).ToString("D6");
                                    var message = MessageResource.Create(
                                        body: $"Enter this code to bypass login by password: {verificationCode}",
                                        from: new Twilio.Types.PhoneNumber(phoneNumber),
                                        to: new Twilio.Types.PhoneNumber("+4" + reader["phone"].ToString())
                                    );
                                    var verifySMS = new VerifySMS(verificationCode);
                                    if (verifySMS.ShowDialog() != DialogResult.OK)
                                    {
                                        MessageBox.Show("SMS not verified! Try again!", "Wrong SMS code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    string code = new Random().Next(0, 1000000).ToString("D6");
                                    string email = emailTxtBox.Text;
                                    string subject = "Verify your new email @ Bookify™ 📓";
                                    string body = $"Hello, {Client.FirstName}! 😉\n\nYour verification code is: " + code.ToString();
                                    var msg = new MimeMessage();
                                    msg.From.Add(new MailboxAddress("Bookify Verification Service", Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd)));
                                    msg.To.Add(new MailboxAddress(Client.FirstName + " " + Client.LastName, email));
                                    msg.Subject = subject;
                                    msg.Body = new TextPart("plain")
                                    {
                                        Text = body
                                    };
                                    using (var client = new SmtpClient())
                                    {
                                        var mail = Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd);
                                        var password = Encryption.EncryptionUtils.DecryptString(Settings.Default.Password, pwd);
                                        var smtpaddr = Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpAddress, pwd);
                                        var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpPort, pwd));
                                        client.Connect(smtpaddr, smtpport, true);
                                        client.Authenticate(mail, password);
                                        client.Send(msg);
                                        client.Disconnect(true);
                                    }
                                    if (new VerificationForm(code, email).ShowDialog() == DialogResult.OK)
                                    {
                                        // update the email
                                        query = "update users set email = :newmail where email = :oldmail";
                                        using (OracleCommand command2 = new OracleCommand(query, connection))
                                        {
                                            command2.Parameters.Add(":newmail", email);
                                            command2.Parameters.Add(":oldmail", Client.Email);
                                            command2.ExecuteNonQuery();
                                        }
                                        // update the bookings 
                                        query = "update bookings set clientemail = :newmail where clientemail = :oldmail";
                                        using (OracleCommand command3 = new OracleCommand(query, connection))
                                        {
                                            command3.Parameters.Add(":newmail", email);
                                            command3.Parameters.Add(":oldmail", Client.Email);
                                            command3.ExecuteNonQuery();
                                        }
                                        // update the temp_bookings
                                        query = "update temp_bookings set clientemail = :newmail where clientemail = :oldmail";
                                        using (OracleCommand command4 = new OracleCommand(query, connection))
                                        {
                                            command4.Parameters.Add(":newmail", email);
                                            command4.Parameters.Add(":oldmail", Client.Email);
                                            command4.ExecuteNonQuery();
                                        }

                                        Client.Email = email;
                                        MessageBox.Show("Email changed successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email change cancelled!", "Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void emailTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailTxtBox_Validating(sender, new CancelEventArgs());
                submitBtn_Click(sender, e);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
