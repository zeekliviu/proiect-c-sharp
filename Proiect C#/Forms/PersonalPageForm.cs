using Proiect_C_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class PersonalPageForm : Form
    {
        public Client Client;
        public List<Booking> Bookings;
        public PersonalPageForm()
        {
            InitializeComponent();
        }
        public PersonalPageForm(LogInForm lf) : this()
        {
            welcomeLabel.Text = "Welcome, " + lf.Client.FirstName + " " + lf.Client.LastName + "!";
            if (lf.Client.ProfilePicture != null)
            {
                using (var ms = new System.IO.MemoryStream(lf.Client.ProfilePicture))
                {
                    photoBox.Image = Image.FromStream(ms);
                }
            }
            Client = lf.Client;
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm(this)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Close();
        }

        private void yourBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DbConnection))
            {
                string query = "SELECT * FROM Bookings WHERE ClientId = @ClientId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", Client.BDId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Bookings = new List<Booking>();
                            while(reader.Read())
                                Bookings.Add(new Booking(Client, DateTime.Parse(reader["CheckIn"].ToString()), DateTime.Parse(reader["CheckOut"].ToString()), new Room(int.Parse(reader["RoomNumber"].ToString()), (RoomType)Enum.Parse(typeof(RoomType), reader["RoomType"].ToString()), decimal.Parse(reader["PricePerNight"].ToString()), int.Parse(reader["Floor"].ToString()), int.Parse(reader["HasBalcony"].ToString()) == 1 ? true : false), reader["Location"].ToString(), reader["Place"].ToString(), reader["Building"].ToString()));
                            var yourBookings = new YourBookings(Bookings, Client);
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
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DbConnection))
                {
                    string query = "UPDATE Users SET Photo = @ProfilePicture WHERE ID = @BDId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProfilePicture", Client.ProfilePicture);
                        command.Parameters.AddWithValue("@BDId", Client.BDId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void removePhotosetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            photoBox.Image = Properties.Resources.default_avatar;
            using (var ms = new System.IO.MemoryStream())
            {
                photoBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Client.ProfilePicture = ms.ToArray();
            }
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DbConnection))
            {
                string query = "UPDATE Users SET Photo = @ProfilePicture WHERE ID = @BDId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProfilePicture", Client.ProfilePicture);
                    command.Parameters.AddWithValue("@BDId", Client.BDId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
