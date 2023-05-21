using Oracle.ManagedDataAccess.Client;
using Proiect_C_.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Proiect_C_.Properties;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Proiect_C_.Forms
{
    public partial class PersonalPageForm : Form
    {
        public Client Client;
        public List<Booking> Bookings;
        public Booking[] bookFormBookings;
        public string pwd;

        public PersonalPageForm()
        {
            InitializeComponent();
        }

        public PersonalPageForm(LogInForm lf) : this()
        {
            welcomeLabel.Text = "Welcome, " + lf.Client.FirstName + " " + lf.Client.LastName + "!";
            float fontSize = welcomeLabel.Font.Size;
            float newWidth = TextRenderer.MeasureText(welcomeLabel.Text, new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style)).Width;
            while (welcomeLabel.Left + newWidth > welcomeLabel.Parent.Width - 30)
            {
                fontSize -= 0.25f;
                newWidth = TextRenderer.MeasureText(welcomeLabel.Text, new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style)).Width;
            }
            while (welcomeLabel.Left + newWidth < welcomeLabel.Parent.Width - 30)
            {
                fontSize += 0.25f;
                newWidth = TextRenderer.MeasureText(welcomeLabel.Text, new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style)).Width;
            }
            welcomeLabel.Font = new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style);
            if (lf.Client.ProfilePicture != null)
            {
                using (var ms = new System.IO.MemoryStream(lf.Client.ProfilePicture))
                {
                    photoBox.Image = Image.FromStream(ms);
                }
            }
            Client = lf.Client;
            pwd = lf.pwd;
            bookFormBookings = new Booking[0];
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yourBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd)))
            {
                string query = "SELECT * FROM Bookings WHERE ClientEmail = :ClientEmail";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":ClientEmail", Client.Email);
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Bookings = new List<Booking>();
                            while (reader.Read())
                                Bookings.Add(new Booking(Client, DateTime.Parse(reader["CheckIn"].ToString()), DateTime.Parse(reader["CheckOut"].ToString()), new Room(int.Parse(reader["RoomNumber"].ToString()), (RoomType)Enum.Parse(typeof(RoomType), reader["RoomType"].ToString()), decimal.Parse(reader["PricePerNight"].ToString()), int.Parse(reader["Floor"].ToString()), int.Parse(reader["HasBalcony"].ToString()) == 1 ? true : false), reader["Location"].ToString(), reader["Place"].ToString(), reader["Building"].ToString()));
                            var yourBookings = new YourBookings(Bookings, Client, pwd);
                            while (yourBookings.ShowDialog() != DialogResult.Cancel)
                                continue;
                        }
                        else
                        {
                            MessageBox.Show("You don't have any bookings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
            }
        }

        private void changePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                photoBox.Image = new Bitmap(openFileDialog.FileName);
                using (var ms = new System.IO.MemoryStream())
                {
                    photoBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Client.ProfilePicture = ms.ToArray();
                }
                using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd)))
                {
                    string query = "UPDATE Users SET Photo = :ProfilePicture WHERE Email = :EmailClient";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":ProfilePicture", Client.ProfilePicture);
                        command.Parameters.Add(":EmailClient", Client.Email);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void removePhotosetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            photoBox.Image = Resources.default_avatar;
            using (var ms = new System.IO.MemoryStream())
            {
                photoBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Client.ProfilePicture = ms.ToArray();
            }
            using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd)))
            {
                string query = "UPDATE Users SET Photo = :ProfilePicture WHERE Email = :EmailClient";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":ProfilePicture", Client.ProfilePicture);
                    command.Parameters.Add(":EmailClient", Client.Email);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void changeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changeMail = new ChangeMail(Client, pwd);
            changeMail.ShowDialog();
            if (changeMail.DialogResult == DialogResult.OK)
                Client = changeMail.Client;
        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changeName = new ChangeName(Client, pwd);
            changeName.ShowDialog();
            if (changeName.DialogResult == DialogResult.OK)
            {
                Client = changeName.client;
                welcomeLabel.Text = "Welcome, " + Client.FirstName + " " + Client.LastName + "!";
                float fontSize = welcomeLabel.Font.Size;
                float newWidth = TextRenderer.MeasureText(welcomeLabel.Text, new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style)).Width;
                while (welcomeLabel.Left + newWidth > welcomeLabel.Parent.Width - 30)
                {
                    fontSize -= 0.25f;
                    newWidth = TextRenderer.MeasureText(welcomeLabel.Text, new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style)).Width;
                }
                while (welcomeLabel.Left + newWidth < welcomeLabel.Parent.Width - 30)
                {
                    fontSize += 0.25f;
                    newWidth = TextRenderer.MeasureText(welcomeLabel.Text, new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style)).Width;
                }
                welcomeLabel.Font = new Font(welcomeLabel.Font.FontFamily, fontSize, welcomeLabel.Font.Style);
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var conexiune = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd)))
            {
                var query = "select * from users where email = :email";
                using (var command = new OracleCommand(query, conexiune))
                {
                    command.Parameters.Add(":email", Client.Email);
                    conexiune.Open();
                    var reader = command.ExecuteReader();
                    reader.Read();
                    if (reader["twofactor"].ToString() == "Y")
                    {
                        var verifyTFA = new Verify2FA(Encryption.EncryptionUtils.DecryptString(reader["private_key"].ToString(), pwd));
                        if (verifyTFA.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show("2FA not verified! Try again!", "2FA code not verified!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        var accountSid = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioSID, pwd);
                        var authToken = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioAuthToken, pwd);
                        var phoneNumber = Encryption.EncryptionUtils.DecryptString(Settings.Default.PhoneNumber, pwd);
                        TwilioClient.Init(accountSid, authToken);
                        var code = new Random().Next(0, 1000000).ToString("D6");
                        var message = MessageResource.Create(
                            body: $"Enter this code to change your password: {code}",
                            from: new Twilio.Types.PhoneNumber(phoneNumber),
                            to: new Twilio.Types.PhoneNumber("+4" + reader["phone"].ToString())
                        );
                        var verifySMS = new VerifySMS(code);
                        if (verifySMS.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show("SMS not verified! Try again!", "Wrong SMS code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            var changePassword = new ChangePassword(pwd, Client);
            changePassword.ShowDialog();
            if (changePassword.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Password changed successfully! Please log in again with your new password!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logOutToolStripMenuItem_Click(sender, e);
            }
        }

        private void enable2FAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = "select twofactor from users where email = :email";
            var connString = Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd);
            var result = "";
            using (OracleConnection connection = new OracleConnection(connString))
            {
                connection.Open();
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":email", Client.Email);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    result = reader["twofactor"].ToString();
                }

                if (result == "Y")
                {
                    MessageBox.Show("2FA is already enabled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Guid guid = Guid.NewGuid();
                    var secret_key = guid.ToString().Replace("-", "").Substring(0, 10);
                    var enable2FA = new Enable2FA(secret_key, Client.Email, pwd, Client.Phone);
                    enable2FA.ShowDialog();
                    if (enable2FA.DialogResult == DialogResult.OK)
                    {
                        query = "update users set twofactor = 'Y' where email = :email";
                        using (OracleCommand command2 = new OracleCommand(query, connection))
                        {
                            command2.Parameters.Add(":email", Client.Email);
                            command2.ExecuteNonQuery();
                        }
                        query = "update users set private_key = :key where email = :email";
                        using (OracleCommand command2 = new OracleCommand(query, connection))
                        {
                            command2.Parameters.Add(":key", Encryption.EncryptionUtils.EncryptString(secret_key, pwd));
                            command2.Parameters.Add(":email", Client.Email);
                            command2.ExecuteNonQuery();
                        }
                        MessageBox.Show("2FA enabled successfully! Please log in again!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        logOutToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("2FA not enabled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void disable2FAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = "select * from users where email = :email";
            var connString = Encryption.EncryptionUtils.DecryptString(Settings.Default.DbConnection, pwd);
            var TwoFAstatus = "";
            string number;
            using(var conexiune = new OracleConnection(connString))
            {
                conexiune.Open();
                using (var command = new OracleCommand(query, conexiune))
                {
                    command.Parameters.Add(":email", Client.Email);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    TwoFAstatus = reader["twofactor"].ToString();
                    number = reader["phone"].ToString();
                }
                if(TwoFAstatus == "N")
                {
                    MessageBox.Show("2FA is already disabled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var accountSid = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioSID, pwd);
                var authToken = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioAuthToken, pwd);
                var phoneNumber = Encryption.EncryptionUtils.DecryptString(Settings.Default.PhoneNumber, pwd);
                TwilioClient.Init(accountSid, authToken);
                var code = new Random().Next(0, 1000000).ToString("D6");
                var message = MessageResource.Create(
                    body: $"Enter this code to disable 2FA: {code}",
                    from: new Twilio.Types.PhoneNumber(phoneNumber),
                    to: new Twilio.Types.PhoneNumber("+4" + number)
                );
                var verifySMS = new VerifySMS(code);
                if (verifySMS.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("SMS not verified! Try again!", "Wrong SMS code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                query = "update users set twofactor = 'N' where email = :email";
                using (OracleCommand command = new OracleCommand(query, conexiune))
                {
                    command.Parameters.Add(":email", Client.Email);
                    command.ExecuteNonQuery();
                }
                query = "update users set private_key = null where email = :email";
                using (OracleCommand command = new OracleCommand(query, conexiune))
                {
                    command.Parameters.Add(":email", Client.Email);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("2FA disabled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
