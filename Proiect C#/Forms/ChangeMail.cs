﻿using MailKit.Net.Smtp;
using MimeKit;
using Oracle.ManagedDataAccess.Client;
using Proiect_C_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class ChangeMail : Form
    {
        Client Client;
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
                string connectionString = Properties.Settings.Default.DbConnection;
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string code = new Random().Next(0, 1000000).ToString("D6");
            string email = emailTxtBox.Text;
            string subject = "Verify your new email @ Bookify™ 📓";
            string body = $"Hello, {Client.FirstName}! 😉\n\nYour verification code is: " + code.ToString();
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("Bookify Verification Service", Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Email, pwd)));
            msg.To.Add(new MailboxAddress(Client.FirstName + " " + Client.LastName, email));
            msg.Subject = subject;
            msg.Body = new TextPart("plain")
            {
                Text = body
            };
            using (var client = new SmtpClient())
            {
                var mail = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Email, pwd);
                var password = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Password, pwd);
                var smtpaddr = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.SmtpAddress, pwd);
                var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.SmtpPort, pwd));
                client.Connect(smtpaddr, smtpport, true);
                client.Authenticate(mail, password);
                client.Send(msg);
                client.Disconnect(true);
            }
            var verifyEmailForm = new VerificationForm(code, email);
            var result = verifyEmailForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                try
                {
                    string connectionString = Properties.Settings.Default.DbConnection;
                    using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(connectionString, pwd))) 
                    {
                        connection.Open();
                        // update the email
                        string query = "UPDATE Users SET Email = :Email WHERE Email = :ClientEmail";
                        using (OracleCommand command = new OracleCommand(query, connection))
                        {
                            command.Parameters.Add(":Email", email);
                            command.Parameters.Add(":ClientEmail", Client.Email);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Email changed successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}