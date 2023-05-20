using Google.Authenticator;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class Verify2FA : Form
    {
        string private_key;
        TwoFactorAuthenticator tfa;
        public Verify2FA()
        {
            InitializeComponent();
            firstDigitTxtBox.MaxLength = secondDigitTxtBox.MaxLength = thirdDigitTxtBox.MaxLength = fourthDigitTxtBox.MaxLength = fifthDigitTxtBox.MaxLength = sixthDigitTxtBox.MaxLength = 1;
            firstDigitTxtBox.Focus();
        }

        public Verify2FA(string private_key) : this()
        {
            this.private_key = private_key;
            tfa = new TwoFactorAuthenticator();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void firstDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(firstDigitTxtBox.Text, "[^0-9]{1}"))
                firstDigitTxtBox.Text = "";
            if (firstDigitTxtBox.Text.Length == 1)
            {
                secondDigitTxtBox.Focus();
            }
        }

        private void secondDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(secondDigitTxtBox.Text, "[^0-9]{1}"))
                secondDigitTxtBox.Text = "";
            if (secondDigitTxtBox.Text.Length == 1)
            {
                thirdDigitTxtBox.Focus();
            }
            else
            {
                firstDigitTxtBox.Focus();
            }
        }

        private void thirdDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(thirdDigitTxtBox.Text, "[^0-9]{1}"))
                thirdDigitTxtBox.Text = "";
            if (thirdDigitTxtBox.Text.Length == 1)
            {
                fourthDigitTxtBox.Focus();
            }
            else
            {
                secondDigitTxtBox.Focus();
            }
        }

        private void fourthDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(fourthDigitTxtBox.Text, "[^0-9]{1}"))
                fourthDigitTxtBox.Text = "";
            if (fourthDigitTxtBox.Text.Length == 1)
            {
                fifthDigitTxtBox.Focus();
            }
            else
            {
                thirdDigitTxtBox.Focus();
            }
        }

        private void fifthDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(fifthDigitTxtBox.Text, "[^0-9]{1}"))
                fifthDigitTxtBox.Text = "";
            if (fifthDigitTxtBox.Text.Length == 1)
            {
                sixthDigitTxtBox.Focus();
            }
            else
            {
                fourthDigitTxtBox.Focus();
            }
        }

        private void sixthDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(sixthDigitTxtBox.Text, "[^0-9]{1}"))
                sixthDigitTxtBox.Text = "";
            if (sixthDigitTxtBox.Text.Length == 1)
            {
                verifyBtn.Focus();
            }
            else
            {
                fifthDigitTxtBox.Focus();
            }
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            var code = firstDigitTxtBox.Text + secondDigitTxtBox.Text + thirdDigitTxtBox.Text + fourthDigitTxtBox.Text + fifthDigitTxtBox.Text + sixthDigitTxtBox.Text;
            if (code.Length != 6)
            {
                MessageBox.Show("Input the full code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!tfa.ValidateTwoFactorPIN(private_key, code, TimeSpan.Zero))
            {
                MessageBox.Show("Invalid code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
