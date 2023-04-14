using Proiect_C_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;

namespace Proiect_C_.Forms
{
    public partial class YourBookings : Form
    {
        public Client Client;
        public List<Booking> Bookings;
        public YourBookings()
        {
            InitializeComponent();
        }
        public YourBookings(List<Booking> bookings, Client client) : this()
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
                bookingsListView.Items.Add(new ListViewItem(new string[] { booking.Location, booking.Place, booking.Building, booking.RoomNumber.ToString(), booking.Floor.ToString(), booking.HasBalcony ? "Yes" : "No", Enum.GetName(typeof(RoomType), booking.RoomType), booking.CheckIn.ToString("d"), booking.CheckOut.ToString("d"), booking.TotalCost.ToString("C", new CultureInfo("ro-RO")) }));
                bookingsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            Client = client;
            Bookings = bookings;
            
        }

        private void toolStripExportToCSVBtn_Click(object sender, EventArgs e)
        {
            var output_file = "bookings_of_" + Client.FirstName + "_" + Client.LastName + ".csv";
            using (var writer = new StreamWriter(output_file))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteField("Location");
                    csv.WriteField("Place");
                    csv.WriteField("Building");
                    csv.WriteField("RoomNumber");
                    csv.WriteField("Floor");
                    csv.WriteField("HasBalcony");
                    csv.WriteField("RoomType");
                    csv.WriteField("CheckIn");
                    csv.WriteField("CheckOut");
                    csv.WriteField("TotalCost");
                    csv.NextRecord();
                    foreach(var element in Bookings)
                    {
                        csv.WriteField(element.Location);
                        csv.WriteField(element.Place);
                        csv.WriteField(element.Building);
                        csv.WriteField(element.RoomNumber);
                        csv.WriteField(element.Floor);
                        csv.WriteField(element.HasBalcony);
                        csv.WriteField(element.RoomType);
                        csv.WriteField(element.CheckIn.ToString("d"));
                        csv.WriteField(element.CheckOut.ToString("d"));
                        csv.WriteField(element.TotalCost.ToString("C", new CultureInfo("ro-RO")));
                        csv.NextRecord();
                    }
                }
            }
            statusStripExportingStatus.Text = "Exported to CSV!";
        }

        private void backToolStripBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void toolStripExportToTXTBtn_Click(object sender, EventArgs e)
        {
            var output_file = "bookings_of_" + Client.FirstName + "_" + Client.LastName + ".txt";
            using (var writer = new StreamWriter(output_file))
                foreach(var element in Bookings)
                    writer.WriteLine("Aveti o rezervare in data de "+ element.CheckIn.ToString("d")+" pana la " + element.CheckOut.ToString("d")+". Rezervarea este in localitatea "+element.Location+", la "+element.Building+". Camera este de tip "+Enum.GetName(typeof(RoomType),element.RoomType) + (element.HasBalcony ? " si are balcon." : " si n-are balcon.") + " In total, ati platit pe aceasta " + element.TotalCost.ToString("C", new CultureInfo("ro-RO")) +".");
            statusStripExportingStatus.Text = "Exported to TXT!";
        }

        private void YourBookings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.V)
                toolStripExportToCSVBtn_Click(sender, e);
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.T)
                toolStripExportToTXTBtn_Click(sender, e);
        }

        private void toolStripPageSetUpBtn_Click(object sender, EventArgs e)
        {
            pageSetupDialog.PageSettings = printDocument.DefaultPageSettings;
            if(pageSetupDialog.ShowDialog() == DialogResult.OK)
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Microsoft Sans serif", 12);
            var pageSettings = e.PageSettings;
            var printAreaHeight = e.MarginBounds.Height;
            var printAreaWidth = e.MarginBounds.Width;
            var marginLeft = pageSettings.Margins.Left;
            var marginTop = pageSettings.Margins.Top;
            if(pageSettings.Landscape)
            {
                printAreaHeight = e.MarginBounds.Width;
                printAreaWidth = e.MarginBounds.Height;
            }
            const int rowHeight = 40;
            var columnWidth = printAreaWidth / 3;
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            fmt.Trimming = StringTrimming.EllipsisCharacter;

            var currentY = marginTop;
            foreach(var element in Bookings)
            {
                var currentX = marginLeft;
                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Aveti o rezervare in data de " + element.CheckIn.ToString("d") + " pana la " + element.CheckOut.ToString("d") + ". Rezervarea este in localitatea " + element.Location + ", la " + element.Building + ". Camera este de tip " + Enum.GetName(typeof(RoomType), element.RoomType) + (element.HasBalcony ? " si are balcon." : " si n-are balcon.") + " In total, ati platit pe aceasta " + element.TotalCost.ToString("C", new CultureInfo("ro-RO")) + ".", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;
                currentY += rowHeight;
                if(currentY + rowHeight > printAreaHeight)
                {
                    e.HasMorePages = true;
                    break;
                }
            }
        }

        private void toolStripPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument_BeginPrint(sender, (System.Drawing.Printing.PrintEventArgs)e);
                printPreviewDialog.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to load the document for Print Preview. Make sure you currently have access to a printer. A printer must be connected and accessible for Print Preview to work.");
            }
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printDocument.Print();
        }
    }
}
