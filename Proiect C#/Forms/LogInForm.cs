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

namespace Proiect_C_.Forms
{
    public partial class LogInForm : Form
    {
        public Client Client { get; set; }
        public LogInForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
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
            // if error provider is not empty, then there are errors
            if(this.errorProvider.GetError(emailTxtBox)=="")
                if (this.pwdTxtBox.Text == "")
                    { MessageBox.Show("Enter a password first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if(this.errorProvider.GetError(emailTxtBox)=="")
            {
                string connectionString = Properties.Settings.Default.DbConnection;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", emailTxtBox.Text);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] hashBytes = Convert.FromBase64String(reader["Password"].ToString());
                                byte[] salt = new byte[16];
                                Array.Copy(hashBytes, 0, salt, 0, 16);
                                var pbkdf2 = new Rfc2898DeriveBytes(pwdTxtBox.Text, salt, 10000);
                                byte[] hash = pbkdf2.GetBytes(20);
                                for (int i = 0; i < 20; i++)
                                {
                                    if (hashBytes[i + 16] != hash[i])
                                    {
                                        MessageBox.Show("The password is not matching the Email you have typed!","Wrong password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                //MessageBox.Show("Welcome!"); // TODO: open the next form
                                this.DialogResult = DialogResult.OK;
                                this.Client = new Client(reader["FirstName"].ToString(), reader["LastName"].ToString(), (byte[])reader["Photo"], reader["Email"].ToString(), reader["Phone"].ToString(), reader["Password"].ToString());
                            }
                            else
                            {
                                MessageBox.Show("The Email has not been found in the database!","Wrong user!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
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
            this.welcomeLabel.BackColor = Color.Transparent;
            this.emailLabel.BackColor = Color.Transparent;
            this.passwordLabel.BackColor = Color.Transparent;
        }
    }
}
