using Proiect_C_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class YourBookings : Form
    {
        public YourBookings()
        {
            InitializeComponent();
        }
        public YourBookings(List<Booking> bookings):this()
        {
            bookingsListView.Columns.Add("Location");
            bookingsListView.Columns.Add("Place");
            bookingsListView.Columns.Add("Building");
            bookingsListView.Columns.Add("RoomNumber");
            bookingsListView.Columns.Add("Floor");
            bookingsListView.Columns.Add("HasBalcony");
            bookingsListView.Columns.Add("RoomType");
            bookingsListView.Columns.Add("CheckIn");
            bookingsListView.Columns.Add("CheckOut");
            bookingsListView.Columns.Add("TotalCost");
            foreach (var booking in bookings)
            {
                bookingsListView.Items.Add(new ListViewItem(new string[] { booking.Location, booking.Place, booking.Building, booking.RoomNumber.ToString(), booking.Floor.ToString(), booking.HasBalcony ? "Yes" : "No", Enum.GetName(typeof(RoomType), booking.RoomType), booking.CheckIn.ToString("d"), booking.CheckOut.ToString("d"), booking.TotalCost.ToString("C") }));
                bookingsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}
