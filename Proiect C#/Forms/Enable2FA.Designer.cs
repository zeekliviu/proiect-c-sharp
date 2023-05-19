namespace Proiect_C_.Forms
{
    partial class Enable2FA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enable2FA));
            this.instructionsLbl1 = new System.Windows.Forms.Label();
            this.googleAuthLbl = new System.Windows.Forms.LinkLabel();
            this.QRCodeBox = new System.Windows.Forms.PictureBox();
            this.scanLbl = new System.Windows.Forms.Label();
            this.manualEntryKeyLbl = new System.Windows.Forms.Label();
            this.enterTheCodeLbl = new System.Windows.Forms.Label();
            this.firstDigitTxtBox = new System.Windows.Forms.TextBox();
            this.secondDigitTxtBox = new System.Windows.Forms.TextBox();
            this.thirdDigitTxtBox = new System.Windows.Forms.TextBox();
            this.fourthDigitTxtBox = new System.Windows.Forms.TextBox();
            this.fifthDigitTxtBox = new System.Windows.Forms.TextBox();
            this.sixthDigitTxtBox = new System.Windows.Forms.TextBox();
            this.backBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.verifyBtn = new Proiect_C_.Custom_Controls.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // instructionsLbl1
            // 
            this.instructionsLbl1.AutoSize = true;
            this.instructionsLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl1.Location = new System.Drawing.Point(58, 29);
            this.instructionsLbl1.Name = "instructionsLbl1";
            this.instructionsLbl1.Size = new System.Drawing.Size(102, 25);
            this.instructionsLbl1.TabIndex = 2;
            this.instructionsLbl1.Text = "1. Install";
            // 
            // googleAuthLbl
            // 
            this.googleAuthLbl.AutoSize = true;
            this.googleAuthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.googleAuthLbl.Location = new System.Drawing.Point(166, 29);
            this.googleAuthLbl.Name = "googleAuthLbl";
            this.googleAuthLbl.Size = new System.Drawing.Size(234, 25);
            this.googleAuthLbl.TabIndex = 3;
            this.googleAuthLbl.TabStop = true;
            this.googleAuthLbl.Text = "Google Authenticator";
            this.googleAuthLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.googleAuthLbl_LinkClicked);
            // 
            // QRCodeBox
            // 
            this.QRCodeBox.Location = new System.Drawing.Point(142, 109);
            this.QRCodeBox.Name = "QRCodeBox";
            this.QRCodeBox.Size = new System.Drawing.Size(180, 163);
            this.QRCodeBox.TabIndex = 4;
            this.QRCodeBox.TabStop = false;
            // 
            // scanLbl
            // 
            this.scanLbl.AutoSize = true;
            this.scanLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanLbl.Location = new System.Drawing.Point(67, 70);
            this.scanLbl.Name = "scanLbl";
            this.scanLbl.Size = new System.Drawing.Size(309, 25);
            this.scanLbl.TabIndex = 5;
            this.scanLbl.Text = "2. Scan the QR Code below:";
            // 
            // manualEntryKeyLbl
            // 
            this.manualEntryKeyLbl.AutoSize = true;
            this.manualEntryKeyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualEntryKeyLbl.Location = new System.Drawing.Point(98, 275);
            this.manualEntryKeyLbl.Name = "manualEntryKeyLbl";
            this.manualEntryKeyLbl.Size = new System.Drawing.Size(174, 13);
            this.manualEntryKeyLbl.TabIndex = 6;
            this.manualEntryKeyLbl.Text = "or enter this key in your app: ";
            // 
            // enterTheCodeLbl
            // 
            this.enterTheCodeLbl.AutoSize = true;
            this.enterTheCodeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterTheCodeLbl.Location = new System.Drawing.Point(12, 299);
            this.enterTheCodeLbl.Name = "enterTheCodeLbl";
            this.enterTheCodeLbl.Size = new System.Drawing.Size(449, 25);
            this.enterTheCodeLbl.TabIndex = 7;
            this.enterTheCodeLbl.Text = "3. Enter the 6-digit code from your app below:";
            // 
            // firstDigitTxtBox
            // 
            this.firstDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstDigitTxtBox.Location = new System.Drawing.Point(37, 335);
            this.firstDigitTxtBox.Name = "firstDigitTxtBox";
            this.firstDigitTxtBox.Size = new System.Drawing.Size(36, 31);
            this.firstDigitTxtBox.TabIndex = 8;
            this.firstDigitTxtBox.TextChanged += new System.EventHandler(this.firstDigitTxtBox_TextChanged);
            // 
            // secondDigitTxtBox
            // 
            this.secondDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondDigitTxtBox.Location = new System.Drawing.Point(112, 335);
            this.secondDigitTxtBox.Name = "secondDigitTxtBox";
            this.secondDigitTxtBox.Size = new System.Drawing.Size(36, 31);
            this.secondDigitTxtBox.TabIndex = 9;
            this.secondDigitTxtBox.TextChanged += new System.EventHandler(this.secondDigitTxtBox_TextChanged);
            // 
            // thirdDigitTxtBox
            // 
            this.thirdDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdDigitTxtBox.Location = new System.Drawing.Point(188, 335);
            this.thirdDigitTxtBox.Name = "thirdDigitTxtBox";
            this.thirdDigitTxtBox.Size = new System.Drawing.Size(36, 31);
            this.thirdDigitTxtBox.TabIndex = 10;
            this.thirdDigitTxtBox.TextChanged += new System.EventHandler(this.thirdDigitTxtBox_TextChanged);
            // 
            // fourthDigitTxtBox
            // 
            this.fourthDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fourthDigitTxtBox.Location = new System.Drawing.Point(265, 335);
            this.fourthDigitTxtBox.Name = "fourthDigitTxtBox";
            this.fourthDigitTxtBox.Size = new System.Drawing.Size(36, 31);
            this.fourthDigitTxtBox.TabIndex = 11;
            this.fourthDigitTxtBox.TextChanged += new System.EventHandler(this.fourthDigitTxtBox_TextChanged);
            // 
            // fifthDigitTxtBox
            // 
            this.fifthDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fifthDigitTxtBox.Location = new System.Drawing.Point(344, 335);
            this.fifthDigitTxtBox.Name = "fifthDigitTxtBox";
            this.fifthDigitTxtBox.Size = new System.Drawing.Size(36, 31);
            this.fifthDigitTxtBox.TabIndex = 12;
            this.fifthDigitTxtBox.TextChanged += new System.EventHandler(this.fifthDigitTxtBox_TextChanged);
            // 
            // sixthDigitTxtBox
            // 
            this.sixthDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sixthDigitTxtBox.Location = new System.Drawing.Point(416, 335);
            this.sixthDigitTxtBox.Name = "sixthDigitTxtBox";
            this.sixthDigitTxtBox.Size = new System.Drawing.Size(36, 31);
            this.sixthDigitTxtBox.TabIndex = 13;
            this.sixthDigitTxtBox.TextChanged += new System.EventHandler(this.sixthDigitTxtBox_TextChanged);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.backBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.backBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.backBtn.BorderRadius = 20;
            this.backBtn.BorderSize = 0;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(49, 383);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(150, 40);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.TextColor = System.Drawing.Color.White;
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // verifyBtn
            // 
            this.verifyBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.verifyBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.verifyBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.verifyBtn.BorderRadius = 20;
            this.verifyBtn.BorderSize = 0;
            this.verifyBtn.FlatAppearance.BorderSize = 0;
            this.verifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyBtn.ForeColor = System.Drawing.Color.White;
            this.verifyBtn.Location = new System.Drawing.Point(280, 383);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(150, 40);
            this.verifyBtn.TabIndex = 0;
            this.verifyBtn.Text = "Verify Code";
            this.verifyBtn.TextColor = System.Drawing.Color.White;
            this.verifyBtn.UseVisualStyleBackColor = false;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // Enable2FA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 450);
            this.ControlBox = false;
            this.Controls.Add(this.sixthDigitTxtBox);
            this.Controls.Add(this.fifthDigitTxtBox);
            this.Controls.Add(this.fourthDigitTxtBox);
            this.Controls.Add(this.thirdDigitTxtBox);
            this.Controls.Add(this.secondDigitTxtBox);
            this.Controls.Add(this.firstDigitTxtBox);
            this.Controls.Add(this.enterTheCodeLbl);
            this.Controls.Add(this.manualEntryKeyLbl);
            this.Controls.Add(this.scanLbl);
            this.Controls.Add(this.QRCodeBox);
            this.Controls.Add(this.googleAuthLbl);
            this.Controls.Add(this.instructionsLbl1);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.verifyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Enable2FA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Up 2FA Authentication";
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controls.CustomButton verifyBtn;
        private Custom_Controls.CustomButton backBtn;
        private System.Windows.Forms.Label instructionsLbl1;
        private System.Windows.Forms.LinkLabel googleAuthLbl;
        private System.Windows.Forms.PictureBox QRCodeBox;
        private System.Windows.Forms.Label scanLbl;
        private System.Windows.Forms.Label manualEntryKeyLbl;
        private System.Windows.Forms.Label enterTheCodeLbl;
        private System.Windows.Forms.TextBox firstDigitTxtBox;
        private System.Windows.Forms.TextBox secondDigitTxtBox;
        private System.Windows.Forms.TextBox thirdDigitTxtBox;
        private System.Windows.Forms.TextBox fourthDigitTxtBox;
        private System.Windows.Forms.TextBox fifthDigitTxtBox;
        private System.Windows.Forms.TextBox sixthDigitTxtBox;
    }
}