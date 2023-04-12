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
        public MainForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            var SignUpForm = new SignUpForm
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            SignUpForm.ShowDialog();
            this.Show();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            var LogInForm = new LogInForm
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            LogInForm.ShowDialog();
            if(LogInForm.DialogResult!=DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                var personalForm = new PersonalPageForm(LogInForm);
                personalForm.ShowDialog();
                if (personalForm.DialogResult == DialogResult.Cancel)
                    LogInForm.ShowDialog();
                if (LogInForm.DialogResult == DialogResult.Cancel)
                    this.Show();
            }
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgBox.Invalidate();
        }

        private void bgBox_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(global::Proiect_C_.Properties.Resources.hotel);
        }
    }
}
