namespace Proiect_C_.Forms
{
    partial class ChangePassword
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.oldPwdLbl = new System.Windows.Forms.Label();
            this.newPwdLbl = new System.Windows.Forms.Label();
            this.retypePwdLbl = new System.Windows.Forms.Label();
            this.oldPwdTxtBox = new System.Windows.Forms.TextBox();
            this.newPwdTxtBox = new System.Windows.Forms.TextBox();
            this.retypePwdTxtBox = new System.Windows.Forms.TextBox();
            this.showPwdChkBox = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cancelBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.submitBtn = new Proiect_C_.Custom_Controls.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // oldPwdLbl
            // 
            this.oldPwdLbl.AutoSize = true;
            this.oldPwdLbl.Location = new System.Drawing.Point(27, 21);
            this.oldPwdLbl.Name = "oldPwdLbl";
            this.oldPwdLbl.Size = new System.Drawing.Size(74, 13);
            this.oldPwdLbl.TabIndex = 0;
            this.oldPwdLbl.Text = "Old password:";
            // 
            // newPwdLbl
            // 
            this.newPwdLbl.AutoSize = true;
            this.newPwdLbl.Location = new System.Drawing.Point(21, 71);
            this.newPwdLbl.Name = "newPwdLbl";
            this.newPwdLbl.Size = new System.Drawing.Size(80, 13);
            this.newPwdLbl.TabIndex = 1;
            this.newPwdLbl.Text = "New password:";
            // 
            // retypePwdLbl
            // 
            this.retypePwdLbl.AutoSize = true;
            this.retypePwdLbl.Location = new System.Drawing.Point(6, 123);
            this.retypePwdLbl.Name = "retypePwdLbl";
            this.retypePwdLbl.Size = new System.Drawing.Size(95, 13);
            this.retypePwdLbl.TabIndex = 2;
            this.retypePwdLbl.Text = "Re-type password:";
            // 
            // oldPwdTxtBox
            // 
            this.oldPwdTxtBox.Location = new System.Drawing.Point(116, 18);
            this.oldPwdTxtBox.Name = "oldPwdTxtBox";
            this.oldPwdTxtBox.Size = new System.Drawing.Size(217, 20);
            this.oldPwdTxtBox.TabIndex = 3;
            this.oldPwdTxtBox.UseSystemPasswordChar = true;
            // 
            // newPwdTxtBox
            // 
            this.newPwdTxtBox.Location = new System.Drawing.Point(116, 71);
            this.newPwdTxtBox.Name = "newPwdTxtBox";
            this.newPwdTxtBox.Size = new System.Drawing.Size(217, 20);
            this.newPwdTxtBox.TabIndex = 4;
            this.newPwdTxtBox.UseSystemPasswordChar = true;
            this.newPwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.newPwdTxtBox_Validating);
            // 
            // retypePwdTxtBox
            // 
            this.retypePwdTxtBox.Location = new System.Drawing.Point(116, 120);
            this.retypePwdTxtBox.Name = "retypePwdTxtBox";
            this.retypePwdTxtBox.Size = new System.Drawing.Size(217, 20);
            this.retypePwdTxtBox.TabIndex = 5;
            this.retypePwdTxtBox.UseSystemPasswordChar = true;
            this.retypePwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.retypePwdTxtBox_Validating);
            // 
            // showPwdChkBox
            // 
            this.showPwdChkBox.AutoSize = true;
            this.showPwdChkBox.Location = new System.Drawing.Point(116, 97);
            this.showPwdChkBox.Name = "showPwdChkBox";
            this.showPwdChkBox.Size = new System.Drawing.Size(102, 17);
            this.showPwdChkBox.TabIndex = 6;
            this.showPwdChkBox.Text = "Show Password";
            this.showPwdChkBox.UseVisualStyleBackColor = true;
            this.showPwdChkBox.CheckedChanged += new System.EventHandler(this.showPwdChkBox_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cancelBtn.BorderRadius = 13;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(30, 164);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(89, 31);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.submitBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.submitBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.submitBtn.BorderRadius = 13;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(269, 164);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(89, 31);
            this.submitBtn.TabIndex = 7;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 207);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.showPwdChkBox);
            this.Controls.Add(this.retypePwdTxtBox);
            this.Controls.Add(this.newPwdTxtBox);
            this.Controls.Add(this.oldPwdTxtBox);
            this.Controls.Add(this.retypePwdLbl);
            this.Controls.Add(this.newPwdLbl);
            this.Controls.Add(this.oldPwdLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Your Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oldPwdLbl;
        private System.Windows.Forms.Label newPwdLbl;
        private System.Windows.Forms.Label retypePwdLbl;
        private System.Windows.Forms.TextBox oldPwdTxtBox;
        private System.Windows.Forms.TextBox newPwdTxtBox;
        private System.Windows.Forms.TextBox retypePwdTxtBox;
        private System.Windows.Forms.CheckBox showPwdChkBox;
        private Custom_Controls.CustomButton submitBtn;
        private Custom_Controls.CustomButton cancelBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}