using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using System.Drawing;
using System.Data;
using System.IO;

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
            this.errorProvider.Clear();
            this.Close();
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

        private void firstPwdTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            this.errorProvider.Clear();
            if (!IsValidPassword(firstPwdTxtBox.Text, out errorMsg))
            {
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
            if (this.errorProvider.GetError(emailTxtBox)=="" && this.errorProvider.GetError(firstPwdTxtBox) == "" && this.errorProvider.GetError(secondPwdTxtBox) == "" && this.errorProvider.GetError(firstNameTxtBox) == "" && this.errorProvider.GetError(lastNameTxtBox) == "" && this.errorProvider.GetError(phoneTxtBox) == "")
            {
                // try creating a database with just a table: email and unique code to be sent to mail; if it already exists, then just add a new entry to the table and send it to mail
                try
                {
                    string connectionString = Properties.Settings.Default.DbConnection;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        // check if the email already exists
                        string query = "SELECT * FROM Users WHERE Email = @Email";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Email", emailTxtBox.Text);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    MessageBox.Show("This email already exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        // verify the email by sending a code to it; the code will be a GUID and it will be sent to the user's email
                        // a new form will be opened with a textbox and a button; the user will have to enter the code and click the button to verify the email
                        // if the code is correct, then the user will be redirected to the login form
                        // if the code is incorrect, then the user will be redirected to the register form and it will be asked to enter the email again

                        string code = new Random().Next(0, 1000000).ToString("D6");
                        string email = emailTxtBox.Text;
                        string subject = "Verify your email";
                        string body = "Hello! 😉\n\nYour verification code is: " + code.ToString();
                        var msg = new MimeMessage();
                        msg.From.Add(new MailboxAddress("Verification Service", Properties.Settings.Default.Email));
                        msg.To.Add(new MailboxAddress(firstNameTxtBox.Text + " " + lastNameTxtBox.Text, email));
                        msg.Subject = subject;
                        msg.Body = new TextPart("plain")
                        {
                            Text = body
                        };
                        using (var client = new SmtpClient())
                        {
                            client.Connect(Properties.Settings.Default.SmtpAddress, Properties.Settings.Default.SmtpPort, true);
                            client.Authenticate(Properties.Settings.Default.Email, Properties.Settings.Default.Password);
                            client.Send(msg);
                            client.Disconnect(true);
                        }
                        var verifyEmailForm = new VerificationForm(code, email);
                        this.Hide();
                        var result = verifyEmailForm.ShowDialog();
                        // if the email is verified, then add the user to the database
                        // if the email is not verified, then redirect to the register form and ask the user to enter the email again
                        if (result == DialogResult.OK)
                        {
                            // if the email doesn't exist, then add it to the database
                            query = "INSERT INTO Users (Email, Password, FirstName, LastName, Phone, Photo) VALUES (@Email, @Password, @FirstName, @LastName, @Phone, @Photo)";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Email", emailTxtBox.Text);
                                // the password should be hashed
                                byte[] salt;
                                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                                var pbkdf2 = new Rfc2898DeriveBytes(firstPwdTxtBox.Text, salt, 10000);
                                byte[] hash = pbkdf2.GetBytes(20);
                                byte[] hashBytes = new byte[36];
                                Array.Copy(salt, 0, hashBytes, 0, 16);
                                Array.Copy(hash, 0, hashBytes, 16, 20);
                                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                                // end of hashing
                                command.Parameters.AddWithValue("@Password", savedPasswordHash);
                                command.Parameters.AddWithValue("@FirstName", firstNameTxtBox.Text);
                                command.Parameters.AddWithValue("@LastName", lastNameTxtBox.Text);
                                command.Parameters.AddWithValue("@Phone", phoneTxtBox.Text);
                                var param = new SqlParameter("@Photo", SqlDbType.VarBinary);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    imageBox.Image.Save(ms, imageBox.Image.RawFormat);
                                    param.Value = ms.ToArray();
                                }
                                command.Parameters.Add(param);
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Your account has been registered and added to the database!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            MessageBox.Show("You canceled! The account has been not added to database. You may change your mail and try again.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void selectImageBtn_Click(object sender, EventArgs e)
        {
            this.openImage.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (this.openImage.ShowDialog() == DialogResult.OK)
            {
                var image_path = this.openImage.FileName;
                var img = Image.FromFile(image_path);
                this.imageBox.Image = img;
            }
        }
    }
}
