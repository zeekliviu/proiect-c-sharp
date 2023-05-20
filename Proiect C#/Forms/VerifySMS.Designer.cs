namespace Proiect_C_.Forms
{
    partial class VerifySMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifySMS));
            this.userTxtLbl = new System.Windows.Forms.Label();
            this.sixthDigitTxtBox = new System.Windows.Forms.TextBox();
            this.fifthDigitTxtBox = new System.Windows.Forms.TextBox();
            this.fourthDigitTxtBox = new System.Windows.Forms.TextBox();
            this.thirdDigitTxtBox = new System.Windows.Forms.TextBox();
            this.secondDigitTxtBox = new System.Windows.Forms.TextBox();
            this.firstDigitTxtBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.verifyBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.SuspendLayout();
            // 
            // userTxtLbl
            // 
            this.userTxtLbl.AutoSize = true;
            this.userTxtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTxtLbl.Location = new System.Drawing.Point(35, 9);
            this.userTxtLbl.Name = "userTxtLbl";
            this.userTxtLbl.Size = new System.Drawing.Size(308, 24);
            this.userTxtLbl.TabIndex = 9;
            this.userTxtLbl.Text = "Enter the code from your phone";
            // 
            // sixthDigitTxtBox
            // 
            this.sixthDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sixthDigitTxtBox.Location = new System.Drawing.Point(340, 58);
            this.sixthDigitTxtBox.Name = "sixthDigitTxtBox";
            this.sixthDigitTxtBox.Size = new System.Drawing.Size(41, 29);
            this.sixthDigitTxtBox.TabIndex = 15;
            this.sixthDigitTxtBox.TextChanged += new System.EventHandler(this.sixthDigitTxtBox_TextChanged);
            // 
            // fifthDigitTxtBox
            // 
            this.fifthDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fifthDigitTxtBox.Location = new System.Drawing.Point(278, 58);
            this.fifthDigitTxtBox.Name = "fifthDigitTxtBox";
            this.fifthDigitTxtBox.Size = new System.Drawing.Size(41, 29);
            this.fifthDigitTxtBox.TabIndex = 14;
            this.fifthDigitTxtBox.TextChanged += new System.EventHandler(this.fifthDigitTxtBox_TextChanged);
            // 
            // fourthDigitTxtBox
            // 
            this.fourthDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fourthDigitTxtBox.Location = new System.Drawing.Point(212, 58);
            this.fourthDigitTxtBox.Name = "fourthDigitTxtBox";
            this.fourthDigitTxtBox.Size = new System.Drawing.Size(41, 29);
            this.fourthDigitTxtBox.TabIndex = 13;
            this.fourthDigitTxtBox.TextChanged += new System.EventHandler(this.fourthDigitTxtBox_TextChanged);
            // 
            // thirdDigitTxtBox
            // 
            this.thirdDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdDigitTxtBox.Location = new System.Drawing.Point(145, 58);
            this.thirdDigitTxtBox.Name = "thirdDigitTxtBox";
            this.thirdDigitTxtBox.Size = new System.Drawing.Size(41, 29);
            this.thirdDigitTxtBox.TabIndex = 12;
            this.thirdDigitTxtBox.TextChanged += new System.EventHandler(this.thirdDigitTxtBox_TextChanged);
            // 
            // secondDigitTxtBox
            // 
            this.secondDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondDigitTxtBox.Location = new System.Drawing.Point(80, 58);
            this.secondDigitTxtBox.Name = "secondDigitTxtBox";
            this.secondDigitTxtBox.Size = new System.Drawing.Size(41, 29);
            this.secondDigitTxtBox.TabIndex = 11;
            this.secondDigitTxtBox.TextChanged += new System.EventHandler(this.secondDigitTxtBox_TextChanged);
            // 
            // firstDigitTxtBox
            // 
            this.firstDigitTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstDigitTxtBox.Location = new System.Drawing.Point(14, 58);
            this.firstDigitTxtBox.Name = "firstDigitTxtBox";
            this.firstDigitTxtBox.Size = new System.Drawing.Size(41, 29);
            this.firstDigitTxtBox.TabIndex = 10;
            this.firstDigitTxtBox.TextChanged += new System.EventHandler(this.firstDigitTxtBox_TextChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cancelBtn.BorderRadius = 20;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(12, 118);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(150, 40);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
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
            this.verifyBtn.Location = new System.Drawing.Point(229, 118);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(150, 40);
            this.verifyBtn.TabIndex = 16;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.TextColor = System.Drawing.Color.White;
            this.verifyBtn.UseVisualStyleBackColor = false;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // VerifySMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 170);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.verifyBtn);
            this.Controls.Add(this.sixthDigitTxtBox);
            this.Controls.Add(this.fifthDigitTxtBox);
            this.Controls.Add(this.fourthDigitTxtBox);
            this.Controls.Add(this.thirdDigitTxtBox);
            this.Controls.Add(this.secondDigitTxtBox);
            this.Controls.Add(this.firstDigitTxtBox);
            this.Controls.Add(this.userTxtLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerifySMS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify Code from SMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userTxtLbl;
        private System.Windows.Forms.TextBox sixthDigitTxtBox;
        private System.Windows.Forms.TextBox fifthDigitTxtBox;
        private System.Windows.Forms.TextBox fourthDigitTxtBox;
        private System.Windows.Forms.TextBox thirdDigitTxtBox;
        private System.Windows.Forms.TextBox secondDigitTxtBox;
        private System.Windows.Forms.TextBox firstDigitTxtBox;
        private Custom_Controls.CustomButton cancelBtn;
        private Custom_Controls.CustomButton verifyBtn;
    }
}