using Proiect_C_.Forms;
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

namespace Proiect_C_
{
    public partial class MainForm : Form
    {
        public string pwd;
        public MainForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
            var AdminLogOnForm = new AdminLogOn();
            this.Hide();
            if(AdminLogOnForm.ShowDialog() == DialogResult.OK)
            {
                pwd = AdminLogOnForm.pwd;
                this.Show();
            }
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            var SignUpForm = new SignUpForm(pwd)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            SignUpForm.ShowDialog();
            this.Show();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            var LogInForm = new LogInForm(pwd)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            while(LogInForm.ShowDialog() == DialogResult.OK)
            {
                var personalForm = new PersonalPageForm(LogInForm);
                while(personalForm.ShowDialog() != DialogResult.Abort)
                {
                    var bookForm = new BookForm(personalForm);
                    bookForm.ShowDialog();
                }
            }
            this.Show();
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgBox.Invalidate();
        }

        private void bgBox_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(Properties.Resources.hotel);
        }
    }
}
