using Google.Authenticator;
using Proiect_C_.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Proiect_C_.Forms
{
    public partial class Enable2FA : Form
    {
        string private_key;
        TwoFactorAuthenticator tfa;
        string pwd;
        string phone;
        public Enable2FA()
        {
            InitializeComponent();
            firstDigitTxtBox.MaxLength = secondDigitTxtBox.MaxLength = thirdDigitTxtBox.MaxLength = fourthDigitTxtBox.MaxLength = fifthDigitTxtBox.MaxLength = sixthDigitTxtBox.MaxLength = 1;
            firstDigitTxtBox.Focus();
            QRCodeBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public Enable2FA(string private_key, string email, string pwd, string phone):this()
        {
            this.pwd = pwd;
            this.phone = phone;
            this.private_key = private_key;
            tfa = new TwoFactorAuthenticator();
            var setupInfo = tfa.GenerateSetupCode("Bookify App", email, Encoding.ASCII.GetBytes(private_key));
            if(setupInfo != null )
            {
                manualEntryKeyLbl.Text += setupInfo.ManualEntryKey;
                QRCodeBox.Image = new Bitmap(new MemoryStream(Convert.FromBase64String(setupInfo.QrCodeSetupImageUrl.Split(',')[1])));
            }
        }

        private void firstDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(firstDigitTxtBox.Text, "[^0-9]{1}"))
                firstDigitTxtBox.Text = "";
            if(firstDigitTxtBox.Text.Length == 1)
            {
                secondDigitTxtBox.Focus();
            }
        }

        private void secondDigitTxtBox_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(secondDigitTxtBox.Text, "[^0-9]{1}"))
                secondDigitTxtBox.Text = "";
            if(secondDigitTxtBox.Text.Length == 1)
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
            if(thirdDigitTxtBox.Text.Length == 1)
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
            if(fourthDigitTxtBox.Text.Length == 1)
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
            if(fifthDigitTxtBox.Text.Length == 1)
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
            if(sixthDigitTxtBox.Text.Length == 1)
            {
                verifyBtn.Focus();
            }
            else
            {
                fifthDigitTxtBox.Focus();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            var code = firstDigitTxtBox.Text + secondDigitTxtBox.Text + thirdDigitTxtBox.Text + fourthDigitTxtBox.Text + fifthDigitTxtBox.Text + sixthDigitTxtBox.Text;
            if(code.Length != 6)
            {
                MessageBox.Show("Input the full code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!tfa.ValidateTwoFactorPIN(private_key, code, TimeSpan.Zero))
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

        private void googleAuthLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var device = MessageBox.Show("Do you have Android? If you click No, you will be sent the link to the App Store.", "Android or iOS?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(device == DialogResult.Yes)
            {
                var accountSid = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioSID, pwd);
                var authToken = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioAuthToken, pwd);
                var phoneNumber = Encryption.EncryptionUtils.DecryptString(Settings.Default.PhoneNumber, pwd);
                TwilioClient.Init(accountSid, authToken);
                MessageResource.Create(
                    body: $"Install Google Authenticator from Play Store: https://play.google.com/store/apps/details?id=com.google.android.apps.authenticator2&hl=en",
                    from: new Twilio.Types.PhoneNumber(phoneNumber),
                    to: new Twilio.Types.PhoneNumber("+4" + phone)
                );
            }
            else
            {
                var accountSid = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioSID, pwd);
                var authToken = Encryption.EncryptionUtils.DecryptString(Settings.Default.TwilioAuthToken, pwd);
                var phoneNumber = Encryption.EncryptionUtils.DecryptString(Settings.Default.PhoneNumber, pwd);
                TwilioClient.Init(accountSid, authToken);
                MessageResource.Create(
                    body: $"Install Google Authenticator from App Store: https://apps.apple.com/us/app/google-authenticator/id388497605",
                    from: new Twilio.Types.PhoneNumber(phoneNumber),
                    to: new Twilio.Types.PhoneNumber("+4" + phone)
                );
            }
        }
    }
}
