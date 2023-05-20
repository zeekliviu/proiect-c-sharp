using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class VerificationForm : Form
    {
        private string code;
        private string email;

        public VerificationForm()
        {
            InitializeComponent();
        }
        public VerificationForm(string code, string email) : this()
        {
            this.code = code;
            this.email = email;
            verifyLabel.Text = "Enter the code sent on " + this.email + " in the box below: ";
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            if(this.code == verifyTxtBox.Text)
            {
                MessageBox.Show("E-mail is verified!", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {
            this.verifyLabel.Parent = this.bgBox;
            this.verifyLabel.BackColor = Color.Transparent;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
