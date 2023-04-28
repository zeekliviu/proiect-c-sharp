namespace Proiect_C_.Forms
{
    partial class AdminLogOn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogOn));
            this.pwdBox = new System.Windows.Forms.TextBox();
            this.InputLbl = new System.Windows.Forms.Label();
            this.submitBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.SuspendLayout();
            // 
            // pwdBox
            // 
            this.pwdBox.Location = new System.Drawing.Point(15, 41);
            this.pwdBox.Name = "pwdBox";
            this.pwdBox.PasswordChar = '*';
            this.pwdBox.Size = new System.Drawing.Size(313, 20);
            this.pwdBox.TabIndex = 0;
            // 
            // InputLbl
            // 
            this.InputLbl.AutoSize = true;
            this.InputLbl.Location = new System.Drawing.Point(12, 9);
            this.InputLbl.Name = "InputLbl";
            this.InputLbl.Size = new System.Drawing.Size(318, 13);
            this.InputLbl.TabIndex = 1;
            this.InputLbl.Text = "Please input the password to decrypt credentials in the box below:";
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.submitBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.submitBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.submitBtn.BorderRadius = 20;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(90, 67);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(180, 33);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // AdminLogOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 112);
            this.ControlBox = false;
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.InputLbl);
            this.Controls.Add(this.pwdBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminLogOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter the password...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pwdBox;
        private System.Windows.Forms.Label InputLbl;
        private Custom_Controls.CustomButton submitBtn;
    }
}