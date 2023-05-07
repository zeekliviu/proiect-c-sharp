using System;
using System.Collections;
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
using Oracle.ManagedDataAccess.Client;
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
            startDatePicker.MaxDate = startDatePicker.MinDate.AddMonths(18);
            endDatePicker.MinDate = DateTime.Now.AddDays(1);
            endDatePicker.MaxDate = startDatePicker.MaxDate.AddMonths(1);
        }
        public BookForm(PersonalPageForm ppf): this()
        {
            personalPageForm = ppf;
            if (ppf.bookFormBookings.Length > 0)
            {
                listViewHeadersSet = true;
                foreach (var prop in typeof(Room).GetProperties())
                    yourCartListView.Columns.Add(prop.Name);
                yourCartListView.Columns.Add("Days");
                yourCartListView.Columns.Add("Price");
                foreach (var booking in ppf.bookFormBookings)
                {
                    var room = new Room(booking.RoomNumber, booking.RoomType, booking.PricePerNight, booking.Floor, booking.HasBalcony);
                    var days = (int)Math.Round((booking.CheckOut - booking.CheckIn).TotalDays);
                    var price = days * room.PricePerNight;
                    var item = new ListViewItem(new string[] { booking.RoomNumber.ToString(), booking.RoomType.ToString(), booking.PricePerNight.ToString("C", new CultureInfo("ro-RO")), booking.Floor.ToString(), booking.HasBalcony == true ? "Yes" : "No", days.ToString(), price.ToString("C", new CultureInfo("ro-RO")) });
                    yourCartListView.Items.Add(item);
                    Array.Resize(ref bookings, bookings.Length+1);
                    bookings[bookings.Length - 1] = booking;
                }
                yourCartListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgBox.Invalidate();
        }
        private void bgBox_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(Resources.book_room);
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

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            placeComboBox.Text = string.Empty;
            buildingComboBox.Text = string.Empty;
            placeComboBox.Items.Clear();
            var places = new JObject(json[locationComboBox.Text].Children());
            foreach (var item in places)
                placeComboBox.Items.Add(item.Key);
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
        private void emptyCartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                yourCartListView.Clear();
                listViewHeadersSet = false;
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
            else if (endDatePicker.Value == startDatePicker.Value)
            {
                MessageBox.Show("Please select at least a night to spend!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (endDatePicker.Value < startDatePicker.Value)
            {
                MessageBox.Show("Please select a valid date interval!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(endDatePicker.Value - startDatePicker.Value > TimeSpan.FromDays(30))
            {
                MessageBox.Show("Please select a date interval of maximum 30 days!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!listViewHeadersSet)
                {
                    foreach (var prop in typeof(Room).GetProperties())
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
            DialogResult = DialogResult.Cancel;
            Close();
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
                using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.DbConnection, personalPageForm.pwd)))
                {
                    connection.Open();
                    for (int i = 0; i < bookings.Length; i++)
                    {
                        string query = "INSERT INTO Bookings (CheckIn, CheckOut, RoomNumber, TotalCost, ClientEmail, Location, Place, Building, RoomType, Floor, HasBalcony, PricePerNight) VALUES (:StartDate, :EndDate, :RoomNumber, :TotalCost, :ClientEmail, :Location, :Place, :Building, :RoomType, :Floor, :HasBalcony, :PricePerNight)";
                        using (OracleCommand command = new OracleCommand(query, connection))
                        {
                            command.Parameters.Add(":StartDate", bookings[i].CheckIn);
                            command.Parameters.Add(":EndDate", bookings[i].CheckOut);
                            command.Parameters.Add(":RoomNumber", bookings[i].RoomNumber);
                            command.Parameters.Add(":TotalCost", decimal.Round(bookings[i].TotalCost, 2));
                            command.Parameters.Add(":ClientEmail", bookings[i].EmailOfClient);
                            command.Parameters.Add(":Location", bookings[i].Location);
                            command.Parameters.Add(":Place", bookings[i].Place);
                            command.Parameters.Add(":Building", bookings[i].Building);
                            command.Parameters.Add(":RoomType", Enum.GetName(typeof(RoomType), bookings[i].RoomType));
                            command.Parameters.Add(":Floor", bookings[i].Floor);
                            command.Parameters.Add(":HasBalcony", Convert.ToInt32(bookings[i].HasBalcony));
                            command.Parameters.Add(":PricePerNight", decimal.Round(bookings[i].PricePerNight, 2));
                            command.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Your booking was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void yourCartListView_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var item = yourCartListView.HitTest(e.X, e.Y).Item;
                if(item != null)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Remove", new EventHandler((s, ev) =>
                    {
                        yourCartListView.Items.Remove(item);
                        // remove the bookings from the array by swapping it with the last element and then resizing the array
                        for (int i = 0; i < bookings.Length; i++)
                        {
                            if (bookings[i].RoomNumber == int.Parse(item.SubItems[0].Text))
                            {
                                bookings[i] = bookings[bookings.Length - 1];
                                Array.Resize(ref bookings, bookings.Length - 1);
                                if (bookings.Length == 0)
                                {
                                    yourCartListView.Clear();
                                    listViewHeadersSet = false;
                                }
                                break;
                            }
                        }
                    })));
                    m.MenuItems.Add(new MenuItem("Details", new EventHandler((s, ev) =>
                    {
                        for (int i = 0; i < bookings.Length; i++)
                        {
                            if (bookings[i].RoomNumber == int.Parse(item.SubItems[0].Text))
                            {
                                var result = bookings[i].HasBalcony ? "Yes" : "No";
                                MessageBox.Show($"Check-in: {bookings[i].CheckIn.ToString("dd/MM/yyyy")}\nCheck-out: {bookings[i].CheckOut.ToString("dd/MM/yyyy")}\nLocation: {bookings[i].Location}\nPlace: {bookings[i].Place}\nBuilding: {bookings[i].Building}\nRoom type: {bookings[i].RoomType}\nFloor: {bookings[i].Floor}\nHas balcony: {result}\nPrice per night: {bookings[i].PricePerNight.ToString("C", new CultureInfo("ro-RO"))}\nTotal cost: {bookings[i].TotalCost.ToString("C", new CultureInfo("ro-RO"))}", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    })));
                    m.Show(yourCartListView, new Point(e.X, e.Y));
                }
            }
        }

        private void yourCartListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView sortedListView = (ListView)sender;
            sortedListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            sortedListView.Sort();
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int column;
        public ListViewItemComparer(int column)
        {
            this.column = column; 
        }
        public int Compare(object x, object y)
        {
            if (column == 0 || column == 3 || column == 5)
            {
                return int.Parse(((ListViewItem)x).SubItems[column].Text).CompareTo(int.Parse(((ListViewItem)y).SubItems[column].Text));
            }
            else if (column == 2 || column == 6)
            {
                return float.Parse(((ListViewItem)x).SubItems[column].Text, NumberStyles.Currency, new CultureInfo("ro-RO")).CompareTo(float.Parse(((ListViewItem)y).SubItems[column].Text, NumberStyles.Currency, new CultureInfo("ro-RO")));
            }
            else
            {
                return String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
            }
        }
    }
}
