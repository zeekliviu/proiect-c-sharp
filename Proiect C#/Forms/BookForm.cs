using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Proiect_C_.Entities;
using Proiect_C_.Properties;

namespace Proiect_C_.Forms
{
    public partial class BookForm : Form
    {
        public JObject json;
        public Booking[] bookings = new Booking[0];
        bool listViewHeadersSet = false;
        public PersonalPageForm personalPageForm;

        public BookForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
            startDatePicker.MinDate = DateTime.Now;
            endDatePicker.MinDate = DateTime.Now.AddDays(1);
        }
        public BookForm(PersonalPageForm ppf): this()
        {
            personalPageForm = ppf;
        }
        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgBox.Invalidate();
        }
        private void bgBox_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(global::Proiect_C_.Properties.Resources.book_room);
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            welcomeLabel.Parent = bgBox;
            welcomeLabel.BackColor = Color.Transparent;
            locationLbl.Parent = bgBox;
            locationLbl.BackColor = Color.Transparent;
            placeLbl.Parent = bgBox;
            placeLbl.BackColor = Color.Transparent;
            buildingLbl.Parent = bgBox;
            buildingLbl.BackColor = Color.Transparent;
            roomLbl.Parent = bgBox;
            roomLbl.BackColor = Color.Transparent;
            yourCartLbl.Parent = bgBox;
            yourCartLbl.BackColor = Color.Transparent;
            startDateLbl.Parent = bgBox;
            startDateLbl.BackColor = Color.Transparent;
            endDateLbl.Parent = bgBox;
            endDateLbl.BackColor = Color.Transparent;
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\final.json", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            json = JObject.Parse(File.ReadAllText(FileName));
            foreach (var item in json)
                locationComboBox.Items.Add(item.Key);
        }

        private void locationComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (!json.ContainsKey(locationComboBox.Text))
                locationComboBox.Text = string.Empty;
        }
        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            placeComboBox.Text = string.Empty;
            buildingComboBox.Text = string.Empty;
            placeComboBox.Items.Clear();
            var places = new JObject(json[locationComboBox.Text].Children());
            foreach (var item in places)
                placeComboBox.Items.Add(item.Key);
        }
        private void placeComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (!json[locationComboBox.Text].Children().Any(x => x.Path == placeComboBox.Text))
                placeComboBox.Text = string.Empty;
        }
        private void placeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildingComboBox.Text = string.Empty;
            roomComboBox.Text = string.Empty;
            buildingComboBox.Items.Clear();
            buildingComboBox.Items.AddRange(json[locationComboBox.Text][placeComboBox.Text].ToObject<string[]>());
            if (placeComboBox.Text == "Hoteluri")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.AddRange(Enum.GetNames(typeof(RoomType)));
            }
            else if (placeComboBox.Text == "Vile")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.Add("Suite");
            }
            else if(placeComboBox.Text == "Case")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.AddRange(new string[] { "Double", "Triple", "Single" });
            }
            else if(placeComboBox.Text == "Pensiuni")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.AddRange(new string[] { "Single", "Double"});
            }
            else
            { roomComboBox.Items.Clear(); }
        }

        private void buildingComboBox_TextUpdate(object sender, EventArgs e)
        {
            buildingComboBox.Text = string.Empty;
        }

        private void emptyCartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                yourCartListView.Items.Clear();
                bookings = new Booking[0];
            }
            catch { }
        }

        private void addBookingBtn_Click(object sender, EventArgs e)
        {
            if (locationComboBox.Text == string.Empty || placeComboBox.Text == string.Empty || buildingComboBox.Text == string.Empty || roomComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please select a location, place, building and room type first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (endDatePicker.Value < startDatePicker.Value)
            {
                MessageBox.Show("Please select a valid date interval!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!listViewHeadersSet)
                {
                    foreach (var prop in typeof(Room).GetProperties())
                        if (prop.Name != "Id")
                            yourCartListView.Columns.Add(prop.Name);
                    yourCartListView.Columns.Add("Days");
                    yourCartListView.Columns.Add("Price");
                    listViewHeadersSet = true;
                }
                decimal pricePerNight;
                int floor;
                bool hasBalcony;
                if (roomComboBox.Text == "Single")
                    pricePerNight = (decimal)(new Random().NextDouble() * (674.48 - 224.79) + 224.79);
                else if (roomComboBox.Text == "Double")
                    pricePerNight = (decimal)(new Random().NextDouble() * (899.60 - 359.72) + 359.72);
                else if (roomComboBox.Text == "Triple")
                    pricePerNight = (decimal)(new Random().NextDouble() * (1348.86 - 539.76) + 539.76);
                else
                    pricePerNight = (decimal)(new Random().NextDouble() * (2248.10 - 673.43) + 673.43);
                if (placeComboBox.Text == "Hoteluri")
                    floor = new Random().Next(1, 25);
                else if (placeComboBox.Text == "Vile")
                    floor = new Random().Next(1, 4);
                else if (placeComboBox.Text == "Pensiuni")
                    floor = new Random().Next(1, 3);
                else
                    floor = 1;
                if (placeComboBox.Text == "Hoteluri" || placeComboBox.Text == "Vile")
                    hasBalcony = true;
                else
                    hasBalcony = false;
                var new_room = new Room(new Random().Next(1, 1000), (RoomType)Enum.Parse(typeof(RoomType), roomComboBox.Text), pricePerNight, floor, hasBalcony);
                Array.Resize(ref bookings, bookings.Length + 1);
                bookings[bookings.Length - 1] = new Booking(personalPageForm.Client, startDatePicker.Value.Date, endDatePicker.Value.Date, new_room, locationComboBox.Text, placeComboBox.Text, buildingComboBox.Text);
                yourCartListView.Items.Add(new ListViewItem(new string[] { new_room.Number.ToString(), new_room.Type.ToString(), new_room.PricePerNight.ToString("C", new CultureInfo("ro-RO")), new_room.Floor.ToString(), new_room.HasBalcony == true ? "Yes" : "No", ((int)Math.Round((endDatePicker.Value - startDatePicker.Value).TotalDays)).ToString(), (new_room.PricePerNight * (decimal)(endDatePicker.Value - startDatePicker.Value).TotalDays).ToString("C", new CultureInfo("ro-RO")) }));
                yourCartListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            if (bookings.Length == 0)
            {
                MessageBox.Show("Please add at least one room to your cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DbConnection))
                {
                    connection.Open();
                    for (int i = 0; i < bookings.Length; i++)
                    {
                        string query = "INSERT INTO Bookings (BookingID, ClientID, CheckIn, CheckOut, RoomNumber, TotalCost, Location, Place, Building, RoomType, Floor, HasBalcony, PricePerNight) VALUES (NEXT VALUE FOR MySeq2, @ClientID, @StartDate, @EndDate, @RoomNumber, @TotalCost, @Location, @Place, @Building, @RoomType, @Floor, @HasBalcony, @PricePerNight)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ClientID", bookings[i].BDId);
                            command.Parameters.AddWithValue("@StartDate", bookings[i].CheckIn);
                            command.Parameters.AddWithValue("@EndDate", bookings[i].CheckOut);
                            command.Parameters.AddWithValue("@RoomNumber", bookings[i].RoomNumber);
                            command.Parameters.AddWithValue("@TotalCost", decimal.Round(bookings[i].TotalCost, 2));
                            command.Parameters.AddWithValue("@Location", bookings[i].Location);
                            command.Parameters.AddWithValue("@Place", bookings[i].Place);
                            command.Parameters.AddWithValue("@Building", bookings[i].Building);
                            command.Parameters.AddWithValue("@RoomType", Enum.GetName(typeof(RoomType),bookings[i].RoomType));
                            command.Parameters.AddWithValue("@Floor", bookings[i].Floor);
                            command.Parameters.AddWithValue("@HasBalcony", Convert.ToInt32(bookings[i].HasBalcony));
                            command.Parameters.AddWithValue("@PricePerNight", decimal.Round(bookings[i].PricePerNight, 2));
                            command.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Your booking was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
