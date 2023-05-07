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
using Proiect_C_.Properties;
using System.Drawing.Drawing2D;
using Org.BouncyCastle.Utilities;
using MimeKit;
using MailKit.Net.Smtp;
using System.Collections.Specialized;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace Proiect_C_.Forms
{
    public partial class YourBookings : Form
    {
        public Client Client;
        public List<Booking> Bookings;
        public List<Booking> datedBookings;
        public int noOfBookings;
        string pwd;
        public YourBookings()
        {
            InitializeComponent();
        }
        public YourBookings(List<Booking> bookings, Client client, string pwd) : this()
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
            DateTime[] dates = new DateTime[bookings.Count];
            foreach (var booking in bookings)
            {
                bookingsListView.Items.Add(new ListViewItem(new string[] { booking.Location, booking.Place, booking.Building, booking.RoomNumber.ToString(), booking.Floor.ToString(), booking.HasBalcony ? "Yes" : "No", Enum.GetName(typeof(RoomType), booking.RoomType), booking.CheckIn.ToString("d"), booking.CheckOut.ToString("d"), booking.TotalCost.ToString("C", new CultureInfo("ro-RO")) }));
                bookingsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                if (!dates.Contains(booking.CheckIn.Date))
                    dates[bookings.IndexOf(booking)] = booking.CheckIn.Date;
            }
            Client = client;
            Bookings = bookings;
            noOfBookings = bookings.Count;
            this.pwd = pwd;
            Array.Sort(dates);
            foreach (var date in dates)
                if (date != DateTime.MinValue)
                { 
                    beginDateSplitBtn.DropDownItems.Add(date.ToString("d"));
                    endDateSplitBtn.DropDownItems.Add(date.ToString("d"));
                }
        }

        private void toolStripExportToCSVBtn_Click(object sender, EventArgs e)
        {
            if (beginDateSplitBtn.Text == "Begin Date" || endDateSplitBtn.Text == "End Date")
            {
                MessageBox.Show("Please select a begin date and an end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Parse(beginDateSplitBtn.Text) > DateTime.Parse(endDateSplitBtn.Text))
            {
                MessageBox.Show("The begin date cannot be greater than the end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            datedBookings = Bookings.Where(b => b.CheckIn >= DateTime.Parse(beginDateSplitBtn.Text) && b.CheckIn <= DateTime.Parse(endDateSplitBtn.Text)).ToList();
            datedBookings.Sort((b1, b2) => b1.CheckIn.CompareTo(b2.CheckIn));
            noOfBookings = datedBookings.Count;
            var output_file = $"bookings_of_{Client.FirstName}_{Client.LastName}_from_{beginDateSplitBtn.Text}_to_{endDateSplitBtn.Text}.csv";
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
                    foreach(var element in datedBookings)
                    {
                        csv.WriteField(element.Location);
                        csv.WriteField(element.Place);
                        csv.WriteField(element.Building);
                        csv.WriteField(element.RoomNumber);
                        csv.WriteField(element.Floor);
                        csv.WriteField(element.HasBalcony ? "Yes" : "No");
                        csv.WriteField(element.RoomType);
                        csv.WriteField(element.CheckIn.ToString("d"));
                        csv.WriteField(element.CheckOut.ToString("d"));
                        csv.WriteField(element.TotalCost.ToString("C", new CultureInfo("ro-RO")));
                        csv.NextRecord();
                    }
                }
            }
            // show a message box with Yes and No buttons and store the result
            DialogResult sendToMail = MessageBox.Show("Do you want to send the CSV file to your email?", "Send to email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sendToMail == DialogResult.Yes)
            {
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.Attachments.Add(output_file);
                bodyBuilder.TextBody = $"Hi, {Client.FirstName}! 👋🏻\n\nYou can find your bookings in the CSV file down below. 👇🏻";
                var msg = new MimeMessage();
                msg.Subject = "Your bookings CSV report at Bookify™ 📓";
                msg.From.Add(new MailboxAddress("CSV Reporter", Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd)));
                msg.To.Add(new MailboxAddress($"{Client.FirstName} {Client.LastName}", Client.Email));
                msg.Body = bodyBuilder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    var mail = Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd);
                    var password = Encryption.EncryptionUtils.DecryptString(Settings.Default.Password, pwd);
                    var smtpaddr = Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpAddress, pwd);
                    var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpPort, pwd));
                    client.Connect(smtpaddr, smtpport, true);
                    client.Authenticate(mail, password);
                    client.Send(msg);
                    client.Disconnect(true);
                }
                statusStripExportingStatus.Text = "Exported to CSV and sent to your email!";
                File.Delete(output_file);
            }
            else 
            {
                var filePath = new FileInfo(output_file).FullName;
                statusStripExportingStatus.Text = $"Exported to CSV and copied to Clipboard!";
                MessageBox.Show($"You may find your file at: {filePath}. It has also been copied to your Clipboard.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetFileDropList(new StringCollection() { filePath });
            }
        }

        private void backToolStripBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void toolStripExportToTXTBtn_Click(object sender, EventArgs e)
        {
            if (beginDateSplitBtn.Text == "Begin Date" || endDateSplitBtn.Text == "End Date")
            {
                MessageBox.Show("Please select a begin date and an end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Parse(beginDateSplitBtn.Text) > DateTime.Parse(endDateSplitBtn.Text))
            {
                MessageBox.Show("The begin date cannot be greater than the end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            datedBookings = Bookings.Where(b => b.CheckIn >= DateTime.Parse(beginDateSplitBtn.Text) && b.CheckIn <= DateTime.Parse(endDateSplitBtn.Text)).ToList();
            datedBookings.Sort((b1, b2) => b1.CheckIn.CompareTo(b2.CheckIn));
            noOfBookings = datedBookings.Count;
            var output_file = $"bookings_of_{Client.FirstName}_{Client.LastName}_from_{beginDateSplitBtn.Text}_and_{endDateSplitBtn.Text}.txt";
            using (var writer = new StreamWriter(output_file))
                foreach(var element in datedBookings)
                    writer.WriteLine("You got a booking from "+ element.CheckIn.ToString("d")+" to " + element.CheckOut.ToString("d")+". The booking is in "+element.Location+", at "+element.Building+". The room is of type "+Enum.GetName(typeof(RoomType),element.RoomType) + (element.HasBalcony ? " and it does have a balcony." : " and it does not have a balcony.") + " The total cost of this booking was " + element.TotalCost.ToString("C", new CultureInfo("ro-RO")) +".");
            // show a message box with Yes and No buttons and store the result
            DialogResult sendToMail = MessageBox.Show("Do you want to send the TXT file to your email?", "Send to email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sendToMail == DialogResult.Yes)
            {
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.Attachments.Add(output_file);
                bodyBuilder.TextBody = $"Hi, {Client.FirstName}! 👋🏻\n\nYou can find your bookings in the TXT file down below. 👇🏻";
                var msg = new MimeMessage();
                msg.Subject = "Your bookings TXT report at Bookify™ 📓";
                msg.From.Add(new MailboxAddress("TXT Reporter", Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd)));
                msg.To.Add(new MailboxAddress($"{Client.FirstName} {Client.LastName}", Client.Email));
                msg.Body = bodyBuilder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    var mail = Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd);
                    var password = Encryption.EncryptionUtils.DecryptString(Settings.Default.Password, pwd);
                    var smtpaddr = Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpAddress, pwd);
                    var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpPort, pwd));
                    client.Connect(smtpaddr, smtpport, true);
                    client.Authenticate(mail, password);
                    client.Send(msg);
                    client.Disconnect(true);
                }
                statusStripExportingStatus.Text = "Exported to TXT and sent to your email!";
                File.Delete(output_file);
            }
            else
            {
                var filePath = new FileInfo(output_file).FullName;
                statusStripExportingStatus.Text = $"Exported to TXT and copied to Clipboard!";
                MessageBox.Show($"You may find your file at: {filePath}. It has also been copied to your Clipboard.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetFileDropList(new StringCollection() { filePath });
            }
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
            // Set up the font and brush for the text
            Font fontPrincipal = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Black);

            // Calculate the maximum size that the logo can be while still fitting on the page
            int maxLogoWidth = e.PageBounds.Width / 4;
            int maxLogoHeight = e.PageBounds.Height / 6;

            // Load and resize the logo
            Image logo = Properties.Resources.logo1;
            float logoScale = Math.Min((float)maxLogoWidth / logo.Width, (float)maxLogoHeight / logo.Height);
            int logoWidth = (int)(logo.Width * logoScale);
            int logoHeight = (int)(logo.Height * logoScale);
            logo = new Bitmap(logo, logoWidth, logoHeight);

            // Draw the logo as a circle in the upper right corner
            int logoX = e.PageBounds.Right - logoWidth - 50;
            int logoY = e.PageBounds.Top + 50;
            GraphicsPath logoPath = new GraphicsPath();
            logoPath.AddEllipse(new Rectangle(logoX, logoY, logoWidth, logoHeight));
            e.Graphics.SetClip(logoPath);
            e.Graphics.DrawImage(logo, logoX, logoY);
            e.Graphics.ResetClip();

            // Calculate the maximum size that the profile picture can be while still fitting on the page
            int maxProfilePictureWidth = e.PageBounds.Width / 4;
            int maxProfilePictureHeight = e.PageBounds.Height / 6;

            // Load and resize the profile picture
            Image profilePicture = Image.FromStream(new MemoryStream(Client.ProfilePicture));
            float profilePictureScale = Math.Min((float)maxProfilePictureWidth / profilePicture.Width, (float)maxProfilePictureHeight / profilePicture.Height);
            int profilePictureWidth = (int)(profilePicture.Width * profilePictureScale);
            int profilePictureHeight = (int)(profilePicture.Height * profilePictureScale);
            profilePicture = new Bitmap(profilePicture, profilePictureWidth, profilePictureHeight);

            // Draw the profile picture in the center of the page
            int profilePictureX = e.PageBounds.Left + (e.PageBounds.Width - profilePictureWidth) / 2;
            int profilePictureY = logoY + logoHeight + 50;
            e.Graphics.DrawImage(profilePicture, profilePictureX, profilePictureY);

            // Draw the client's identification info
            string identificationInfo = $"Name: {Client.FirstName} {Client.LastName}\nEmail: {Client.Email}\nTelephone: {Client.Phone}";
            e.Graphics.DrawString(identificationInfo, fontPrincipal, brush, profilePictureX - 25, profilePictureY + profilePictureHeight + 20);

            Font font = new Font("Arial", 9);
            // Draw the table
            int columnWidth = e.PageBounds.Width / 10;
            int y = logo.Height + profilePictureHeight + 200;
            string[] header = { "Location", "Place", "Building", "RoomNumber", "Floor", "HasBalcony", "RoomType", "CheckIn", "CheckOut", "TotalCost" };
            int[] rectHeaderWidths = new int[10];
            int rectHeight = 60;
            var x = e.PageBounds.Left+25;
            var old_x = x;
            int i = 0;
            foreach (string s in header)
            {
                // Calculate coordinates and dimensions of rectangle
                int rectWidth;
                if(s=="Place")
                rectWidth = (int)Math.Ceiling(e.Graphics.MeasureString(s, font).Width) + s.Length*4;
                else
                rectWidth = (int)Math.Ceiling(e.Graphics.MeasureString(s, font).Width) + s.Length*3;
                rectHeaderWidths[i++] = rectWidth;
                int centerX = x + (rectWidth / 2);
                int centerY = y + (rectHeight / 2);
                Rectangle rect = new Rectangle(centerX - (rectWidth / 2), centerY - (rectHeight / 2), rectWidth, rectHeight);

                // Draw rectangle and centered text
                e.Graphics.DrawRectangle(Pens.Black, rect);
                SizeF textSize = e.Graphics.MeasureString(s, font);
                RectangleF textRect = new RectangleF(centerX - (textSize.Width / 2), centerY - (textSize.Height / 2), textSize.Width, textSize.Height);
                e.Graphics.DrawString(s, font, brush, textRect);

                // Move to next column
                x += rectWidth;
            }
            x = old_x;
            y += rectHeight; // move down a bit for the data
            while(noOfBookings>0)
            { 
                Booking booking = datedBookings[datedBookings.Count-noOfBookings];
                if(y+rectHeight>e.PageBounds.Bottom-150)
                {
                    e.HasMorePages = true;
                    return;
                }
                string[] columnContents = new string[10];
                columnContents[0] = booking.Location;
                columnContents[1] = booking.Place;
                columnContents[2] = booking.Building;
                columnContents[3] = booking.RoomNumber.ToString();
                columnContents[4] = booking.Floor.ToString();
                columnContents[5] = booking.HasBalcony ? "Yes" : "No";
                columnContents[6] = Enum.GetName(typeof(RoomType), booking.RoomType);
                columnContents[7] = booking.CheckIn.ToString("d");
                columnContents[8] = booking.CheckOut.ToString("d");
                columnContents[9] = booking.TotalCost.ToString("C", new CultureInfo("ro-RO"));
                string maxLength = columnContents.OrderByDescending(s => s.Length).First();
                // Determine the maximum height of the rectangle
                rectHeight = (int)Math.Ceiling(e.Graphics.MeasureString(maxLength, font).Width) / rectHeaderWidths[Array.IndexOf(columnContents, maxLength)] * rectHeight;
                for (int j = 0; j < 10; j++)
                {
                    StringFormat stringFormat = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    // Calculate coordinates and dimensions of rectangle
                    int rectWidth2 = rectHeaderWidths[j];
                    int centerX2 = x + (rectWidth2 / 2);
                    int centerY2 = y + (rectHeight / 2);
                    Rectangle rect2 = new Rectangle(centerX2 - (rectWidth2 / 2), centerY2 - (rectHeight / 2), rectWidth2, rectHeight);
                    // Draw rectangle and centered text
                    e.Graphics.DrawRectangle(Pens.Black, rect2);
                    RectangleF textRect2 = new RectangleF(centerX2 - (rectWidth2 / 2), centerY2 - (rectHeight / 2), rectWidth2, rectHeight);
                    e.Graphics.DrawString(columnContents[j], font, brush, textRect2, stringFormat);
                    // Move to next column
                    x += rectWidth2;
                }
                x = old_x;
                y += rectHeight;
                noOfBookings--;
            }
            if(y>e.PageBounds.Bottom-150)
            {
                e.HasMorePages = true;
                return;
            }
            // Draw the rectange for the total cost
            int totalCostRectWidth = 200;
            int totalCostRectHeight = 60;
            int totalCostRectX = e.PageBounds.Right - totalCostRectWidth - 50;
            int totalCostRectY = y + 50;
            Rectangle totalCostRect = new Rectangle(totalCostRectX, totalCostRectY, totalCostRectWidth, totalCostRectHeight);
            e.Graphics.DrawRectangle(Pens.Black, totalCostRect);
            // Draw the total cost
            int centerX3 = totalCostRectX + (totalCostRectWidth / 2);
            int centerY3 = totalCostRectY + (totalCostRectHeight / 2);
            string totalCost = $"Grand Total: {Bookings.Sum(b => b.TotalCost).ToString("C", new CultureInfo("ro-RO"))}";
            RectangleF textCostRect = new RectangleF(centerX3 - (totalCostRectWidth / 2), centerY3 - (totalCostRectHeight / 2), totalCostRectWidth, totalCostRectHeight);
            e.Graphics.DrawString(totalCost, font, brush, textCostRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
            // Draw the "Hope you had a good time!" string
            //Font largeFont = new Font("Script MT Bold", 36);
            
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(string.Format("{0}Resources\\CoffeCake.ttf", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            Font largeFont = new Font(pfc.Families[0], 36f);
            SizeF stringSize = e.Graphics.MeasureString("Hope you had a good time!", largeFont);
            e.Graphics.DrawString("Hope you had a good time!", largeFont, brush, (e.PageBounds.Width - stringSize.Width) / 2, e.PageBounds.Bottom - 100);
        }

        private void toolStripPrintPreview_Click(object sender, EventArgs e)
        {
            if (beginDateSplitBtn.Text == "Begin Date" || endDateSplitBtn.Text == "End Date")
            {
                MessageBox.Show("Please select a begin date and an end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Parse(beginDateSplitBtn.Text) > DateTime.Parse(endDateSplitBtn.Text))
            {
                MessageBox.Show("The begin date cannot be greater than the end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            datedBookings = Bookings.Where(b => b.CheckIn >= DateTime.Parse(beginDateSplitBtn.Text) && b.CheckIn <= DateTime.Parse(endDateSplitBtn.Text)).ToList();
            datedBookings.Sort((b1, b2) => b1.CheckIn.CompareTo(b2.CheckIn));
            noOfBookings = datedBookings.Count;
            printPreviewDialog.Document = printDocument;
            printDocument.DocumentName = $"Bookings_of_{Client.FirstName}_{Client.LastName}";
            if(printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
            noOfBookings = Bookings.Count;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if(beginDateSplitBtn.Text == "Begin Date" || endDateSplitBtn.Text == "End Date")
            {
                MessageBox.Show("Please select a begin date and an end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Parse(beginDateSplitBtn.Text) > DateTime.Parse(endDateSplitBtn.Text))
            {
                MessageBox.Show("The begin date cannot be greater than the end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            datedBookings = Bookings.Where(b => b.CheckIn >= DateTime.Parse(beginDateSplitBtn.Text) && b.CheckIn <= DateTime.Parse(endDateSplitBtn.Text)).ToList();
            datedBookings.Sort((b1, b2) => b1.CheckIn.CompareTo(b2.CheckIn));
            noOfBookings = datedBookings.Count;
            printDocument.DocumentName = $"bookings_of_{Client.FirstName}_{Client.LastName}_from_{beginDateSplitBtn.Text}_to_{endDateSplitBtn.Text}";
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = $"bookings_of_{Client.FirstName}_{Client.LastName}_from_{beginDateSplitBtn.Text}_to_{endDateSplitBtn.Text}.pdf";
            printDocument.Print();
            DialogResult sendToMail = MessageBox.Show("Do you want to send the booking to your email?", "Send to email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sendToMail == DialogResult.Yes)
            {
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.Attachments.Add(printDocument.PrinterSettings.PrintFileName);
                bodyBuilder.TextBody = $"Hi, {Client.FirstName}! 👋🏻\n\nYou can find your bookings in the PDF file down below. 👇🏻";
                var msg = new MimeMessage();
                msg.Subject = "Your bookings PDF report at Bookify™ 📓";
                msg.From.Add(new MailboxAddress("PDF Reporter", Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd)));
                msg.To.Add(new MailboxAddress($"{Client.FirstName} {Client.LastName}", Client.Email));
                msg.Body = bodyBuilder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    var mail = Encryption.EncryptionUtils.DecryptString(Settings.Default.Email, pwd);
                    var password = Encryption.EncryptionUtils.DecryptString(Settings.Default.Password, pwd);
                    var smtpaddr = Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpAddress, pwd);
                    var smtpport = int.Parse(Encryption.EncryptionUtils.DecryptString(Settings.Default.SmtpPort, pwd));
                    client.Connect(smtpaddr, smtpport, true);
                    client.Authenticate(mail, password);
                    client.Send(msg);
                    client.Disconnect(true);
                }
                File.Delete(printDocument.PrinterSettings.PrintFileName);
                statusStripExportingStatus.Text = "Exported to PDF and sent to email!";
            }
            else
            {
                var filePath = new FileInfo(printDocument.PrinterSettings.PrintFileName).FullName;
                statusStripExportingStatus.Text = $"Exported to PDF and copied to Clipboard!";
                MessageBox.Show($"You may find your file at: {filePath}. It has also been copied to your Clipboard.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetFileDropList(new StringCollection() { filePath });
            }
        }

        private void bookingsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView sortedListView = (ListView)sender;
            sortedListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            sortedListView.Sort();
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
                if (column == 9)
                {
                    return float.Parse(((ListViewItem)x).SubItems[column].Text, NumberStyles.Currency, new CultureInfo("ro-RO")).CompareTo(float.Parse(((ListViewItem)y).SubItems[column].Text, NumberStyles.Currency, new CultureInfo("ro-RO")));
                }
                else if (column == 3 || column == 4)
                {
                    return int.Parse(((ListViewItem)x).SubItems[column].Text).CompareTo(int.Parse(((ListViewItem)y).SubItems[column].Text));
                }
                else if (column == 7 || column == 8)
                {
                    return DateTime.Parse(((ListViewItem)x).SubItems[column].Text).CompareTo(DateTime.Parse(((ListViewItem)y).SubItems[column].Text));
                }
                else
                {
                    return String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
                }
            }
        }

        private void beginDateSplitBtn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            beginDateSplitBtn.Text = e.ClickedItem.Text;
        }

        private void endDateSplitBtn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            endDateSplitBtn.Text = e.ClickedItem.Text;
        }
    }
}
