using Proiect_C_.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            var LogInForm = new LogInForm();
            this.Hide();
            LogInForm.ShowDialog();
            this.Show();
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
