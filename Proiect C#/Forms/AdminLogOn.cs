using System;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class AdminLogOn : Form
    {
        public string pwd;
        public AdminLogOn()
        {
            InitializeComponent();
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            pwd = pwdBox.Text;
            try
            {
                bool ok = Encryption.EncryptionUtils.DecryptString("+pYSKdAoLqh3ym/mtnyJsg==", pwd) != "Corect!";
            }
            catch
            {
                MessageBox.Show("The password is invalid!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pwdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                submitBtn_Click(sender, e);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
