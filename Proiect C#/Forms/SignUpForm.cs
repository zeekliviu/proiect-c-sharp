using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using Oracle.ManagedDataAccess.Client;

namespace Proiect_C_.Forms
{
    public partial class SignUpForm : Form
    {
        public string pwd;

        public SignUpForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
            firstPwdTxtBox.MaxLength = secondPwdTxtBox.MaxLength = 20;
        }
        public SignUpForm(string pwd):this()
        {
            this.pwd = pwd;
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.Close();
        }

        private void emailTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!isValidMail(emailTxtBox.Text, out errorMsg))
            {
                emailTxtBox.Select(0, emailTxtBox.Text.Length);
                this.errorProvider.SetError(emailTxtBox, errorMsg);
                if (this.ActiveControl != backBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
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
            if (!IsValidPassword(firstPwdTxtBox.Text, out errorMsg))
            {
                this.errorProvider.SetError(firstPwdTxtBox, errorMsg);
                if (this.ActiveControl != backBtn && this.ActiveControl != showFirstPwdBtn && this.ActiveControl != hideFirstPwdBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
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
            if (!PasswordsMatch(secondPwdTxtBox.Text, out errorMsg))
            {
                this.errorProvider.SetError(secondPwdTxtBox, errorMsg);
                if (this.ActiveControl != backBtn && this.ActiveControl != showSecondPwdBtn && this.ActiveControl != hideSecondPwdBtn)
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
            if (!isNameValid(firstNameTxtBox.Text, out errorMsg))
            {
                firstNameTxtBox.Select(0, firstNameTxtBox.Text.Length);
                this.errorProvider.SetError(firstNameTxtBox, errorMsg);
                if (this.ActiveControl != backBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
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
            if (!isNameValid(lastNameTxtBox.Text, out errorMsg))
            {
                lastNameTxtBox.Select(0, lastNameTxtBox.Text.Length);
                this.errorProvider.SetError(lastNameTxtBox, errorMsg);
                if (this.ActiveControl != backBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
            }
        }


        private void phoneTxtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!isPhoneValid(phoneTxtBox.Text, out errorMsg))
            {
                phoneTxtBox.Select(0, phoneTxtBox.Text.Length);
                this.errorProvider.SetError(phoneTxtBox, errorMsg);
                if (this.ActiveControl != backBtn)
                    e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
                e.Cancel = false;
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

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Please fill in all the fields correctly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.errorProvider.GetError(emailTxtBox)=="" && this.errorProvider.GetError(firstPwdTxtBox) == "" && this.errorProvider.GetError(secondPwdTxtBox) == "" && this.errorProvider.GetError(firstNameTxtBox) == "" && this.errorProvider.GetError(lastNameTxtBox) == "" && this.errorProvider.GetError(phoneTxtBox) == "")
            {
                try
                {
                    DBUtils.DBUtils.UnzipArchive(pwd);
                    string connectionString = Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.DbConnection, pwd);
                    using (OracleConnection connection = new OracleConnection(connectionString))
                    {
                        connection.Open();
                        // check if the email already exists
                        string query = "SELECT * FROM Users WHERE Email = :Email";
                        using (OracleCommand command = new OracleCommand(query, connection))
                        using (OracleParameter parameter = new OracleParameter(":Email", emailTxtBox.Text))
                        {
                            {
                                command.Parameters.Add(parameter);
                                using (OracleDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        MessageBox.Show("This email already exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }
                        // verification code generation + email sending
                        string code = new Random().Next(0, 1000000).ToString("D6");
                        string email = emailTxtBox.Text;
                        string subject = "Verify your email @ Bookify™ 📓";
                        string body = $"Hello, {firstNameTxtBox.Text}! 😉\n\nYour verification code is: " + code.ToString();
                        var msg = new MimeMessage();
                        msg.From.Add(new MailboxAddress("Bookify Verification Service", Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.Email, pwd)));
                        msg.To.Add(new MailboxAddress(firstNameTxtBox.Text + " " + lastNameTxtBox.Text, email));
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
                        this.Hide();
                        var result = verifyEmailForm.ShowDialog();
                        // if the email is verified, then add the user to the database
                        // if the email is not verified, then redirect to the register form and ask the user to enter the email again
                        if (result == DialogResult.OK)
                        {
                            query = "INSERT INTO Users (Email, Password, FirstName, LastName, Phone, Photo) VALUES (:Email, :Password, :FirstName, :LastName, :Phone, :Photo)"; // cand se foloseste SQL Oracle, nu se folosesc parametrii cu @, ci cu :, la SQL Server se folosesc parametrii cu @
                            using (OracleCommand command = new OracleCommand(query, connection))
                            {
                                command.Parameters.Add(":Email", emailTxtBox.Text);
                                // the password should be hashed; I chose MD5 because it's faster than SHA1 and SHA256
                                byte[] salt;
                                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                                var pbkdf2 = new Rfc2898DeriveBytes(firstPwdTxtBox.Text, salt, 10000, HashAlgorithmName.MD5);
                                byte[] hash = pbkdf2.GetBytes(20);
                                byte[] hashBytes = new byte[36];
                                Array.Copy(salt, 0, hashBytes, 0, 16);
                                Array.Copy(hash, 0, hashBytes, 16, 20);
                                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                                // end of hashing
                                command.Parameters.Add(":Password", savedPasswordHash);
                                command.Parameters.Add(":FirstName", firstNameTxtBox.Text);
                                command.Parameters.Add(":LastName", lastNameTxtBox.Text);
                                command.Parameters.Add(":Phone", phoneTxtBox.Text);
                                var photo = new OracleParameter(":Photo", OracleDbType.Blob); // OracleDbType.Blob in Oracle SQL vs SqlDbType.VarBinary in SQL Server; SqlDbType.VarBinary has a maximum capacity of 8000 bytes, while OracleDbType.Blob has a maximum capacity of 4GB
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    imageBox.Image.Save(ms, imageBox.Image.RawFormat);
                                    photo.Value = ms.ToArray();
                                }
                                command.Parameters.Add(photo);
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Your account has been registered and added to the database!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("You canceled! The account has been not added to database. You may change your mail and try again.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Show();
                        }
                        DBUtils.DBUtils.DeleteFiles();
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

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            welcomeLabel.Parent = bgBox;
            reqLabel.Parent = bgBox;
            FirstNameLabel.Parent = bgBox;
            LastNameLabel.Parent = bgBox;
            EmailLabel.Parent = bgBox;
            FirstPwdLabel.Parent = bgBox;
            RetypePwdLabel.Parent = bgBox;
            PhoneLabel.Parent = bgBox;
            photoLabel.Parent = bgBox;
            welcomeLabel.BackColor = Color.Transparent;
            reqLabel.BackColor = Color.Transparent;
            FirstNameLabel.BackColor = Color.Transparent;
            LastNameLabel.BackColor = Color.Transparent;
            EmailLabel.BackColor = Color.Transparent;
            FirstPwdLabel.BackColor = Color.Transparent;
            RetypePwdLabel.BackColor = Color.Transparent;
            PhoneLabel.BackColor = Color.Transparent;
            photoLabel.BackColor = Color.Transparent;
        }

        private void showFirstPwdBtn_Click(object sender, EventArgs e)
        {
            firstPwdTxtBox.UseSystemPasswordChar = !firstPwdTxtBox.UseSystemPasswordChar;
            showFirstPwdBtn.Visible = !showFirstPwdBtn.Visible;
            hideFirstPwdBtn.Visible = !hideFirstPwdBtn.Visible;
        }

        private void hideFirstPwdBtn_Click(object sender, EventArgs e)
        {
            firstPwdTxtBox.UseSystemPasswordChar = !firstPwdTxtBox.UseSystemPasswordChar;
            hideFirstPwdBtn.Visible = !hideFirstPwdBtn.Visible;
            showFirstPwdBtn.Visible = !showFirstPwdBtn.Visible;
        }

        private void showSecondPwdBtn_Click(object sender, EventArgs e)
        {
            secondPwdTxtBox.UseSystemPasswordChar = !secondPwdTxtBox.UseSystemPasswordChar;
            showSecondPwdBtn.Visible = !showSecondPwdBtn.Visible;
            hideSecondPwdBtn.Visible = !hideSecondPwdBtn.Visible;
        }

        private void hideSecondPwdBtn_Click(object sender, EventArgs e)
        {
            secondPwdTxtBox.UseSystemPasswordChar = !secondPwdTxtBox.UseSystemPasswordChar;
            hideSecondPwdBtn.Visible = !hideSecondPwdBtn.Visible;
            showSecondPwdBtn.Visible = !showSecondPwdBtn.Visible;
        }
    }
}
