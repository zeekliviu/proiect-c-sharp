using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public PersonalPageForm()
        {
            InitializeComponent();
        }
        public PersonalPageForm(LogInForm lf):this()
        {
            welcomeLabel.Text = "Welcome, " + lf.Client.FirstName + " " + lf.Client.LastName + "!";
            if (lf.Client.ProfilePicture != null)
            {
                using (var ms = new System.IO.MemoryStream(lf.Client.ProfilePicture))
                {
                    photoBox.Image = Image.FromStream(ms);
                }
            }
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            bookForm.ShowDialog();
        }

        private void yourBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
