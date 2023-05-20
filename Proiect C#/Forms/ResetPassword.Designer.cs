namespace Proiect_C_.Forms
{
    partial class ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.cancelBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.submitBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.hideNewRetypedPwdBtn = new System.Windows.Forms.Button();
            this.showNewRetypedPwdBtn = new System.Windows.Forms.Button();
            this.hideNewPwdBtn = new System.Windows.Forms.Button();
            this.showNewPwdBtn = new System.Windows.Forms.Button();
            this.retypePwdTxtBox = new System.Windows.Forms.TextBox();
            this.newPwdTxtBox = new System.Windows.Forms.TextBox();
            this.retypePwdLbl = new System.Windows.Forms.Label();
            this.newPwdLbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.cancelBtn.Location = new System.Drawing.Point(12, 104);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(150, 40);
            this.cancelBtn.TabIndex = 19;
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
            this.submitBtn.BorderRadius = 20;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(231, 104);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(150, 40);
            this.submitBtn.TabIndex = 18;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // hideNewRetypedPwdBtn
            // 
            this.hideNewRetypedPwdBtn.BackColor = System.Drawing.Color.White;
            this.hideNewRetypedPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.eye;
            this.hideNewRetypedPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hideNewRetypedPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideNewRetypedPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.hideNewRetypedPwdBtn.Location = new System.Drawing.Point(317, 61);
            this.hideNewRetypedPwdBtn.Name = "hideNewRetypedPwdBtn";
            this.hideNewRetypedPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.hideNewRetypedPwdBtn.TabIndex = 37;
            this.hideNewRetypedPwdBtn.UseVisualStyleBackColor = false;
            this.hideNewRetypedPwdBtn.Visible = false;
            this.hideNewRetypedPwdBtn.Click += new System.EventHandler(this.hideNewRetypedPwdBtn_Click);
            // 
            // showNewRetypedPwdBtn
            // 
            this.showNewRetypedPwdBtn.BackColor = System.Drawing.Color.White;
            this.showNewRetypedPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.closed_eye;
            this.showNewRetypedPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showNewRetypedPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showNewRetypedPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.showNewRetypedPwdBtn.Location = new System.Drawing.Point(317, 61);
            this.showNewRetypedPwdBtn.Name = "showNewRetypedPwdBtn";
            this.showNewRetypedPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.showNewRetypedPwdBtn.TabIndex = 36;
            this.showNewRetypedPwdBtn.UseVisualStyleBackColor = false;
            this.showNewRetypedPwdBtn.Click += new System.EventHandler(this.showNewRetypedPwdBtn_Click);
            // 
            // hideNewPwdBtn
            // 
            this.hideNewPwdBtn.BackColor = System.Drawing.Color.White;
            this.hideNewPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.eye;
            this.hideNewPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hideNewPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideNewPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.hideNewPwdBtn.Location = new System.Drawing.Point(317, 12);
            this.hideNewPwdBtn.Name = "hideNewPwdBtn";
            this.hideNewPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.hideNewPwdBtn.TabIndex = 35;
            this.hideNewPwdBtn.UseVisualStyleBackColor = false;
            this.hideNewPwdBtn.Visible = false;
            this.hideNewPwdBtn.Click += new System.EventHandler(this.hideNewPwdBtn_Click);
            // 
            // showNewPwdBtn
            // 
            this.showNewPwdBtn.BackColor = System.Drawing.Color.White;
            this.showNewPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.closed_eye;
            this.showNewPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showNewPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showNewPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.showNewPwdBtn.Location = new System.Drawing.Point(317, 12);
            this.showNewPwdBtn.Name = "showNewPwdBtn";
            this.showNewPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.showNewPwdBtn.TabIndex = 34;
            this.showNewPwdBtn.UseVisualStyleBackColor = false;
            this.showNewPwdBtn.Click += new System.EventHandler(this.showNewPwdBtn_Click);
            // 
            // retypePwdTxtBox
            // 
            this.retypePwdTxtBox.Location = new System.Drawing.Point(132, 61);
            this.retypePwdTxtBox.Name = "retypePwdTxtBox";
            this.retypePwdTxtBox.Size = new System.Drawing.Size(217, 20);
            this.retypePwdTxtBox.TabIndex = 33;
            this.retypePwdTxtBox.UseSystemPasswordChar = true;
            this.retypePwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.retypePwdTxtBox_Validating);
            // 
            // newPwdTxtBox
            // 
            this.newPwdTxtBox.Location = new System.Drawing.Point(132, 12);
            this.newPwdTxtBox.Name = "newPwdTxtBox";
            this.newPwdTxtBox.Size = new System.Drawing.Size(217, 20);
            this.newPwdTxtBox.TabIndex = 32;
            this.newPwdTxtBox.UseSystemPasswordChar = true;
            this.newPwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.newPwdTxtBox_Validating);
            // 
            // retypePwdLbl
            // 
            this.retypePwdLbl.AutoSize = true;
            this.retypePwdLbl.Location = new System.Drawing.Point(22, 64);
            this.retypePwdLbl.Name = "retypePwdLbl";
            this.retypePwdLbl.Size = new System.Drawing.Size(95, 13);
            this.retypePwdLbl.TabIndex = 31;
            this.retypePwdLbl.Text = "Re-type password:";
            // 
            // newPwdLbl
            // 
            this.newPwdLbl.AutoSize = true;
            this.newPwdLbl.Location = new System.Drawing.Point(37, 12);
            this.newPwdLbl.Name = "newPwdLbl";
            this.newPwdLbl.Size = new System.Drawing.Size(80, 13);
            this.newPwdLbl.TabIndex = 30;
            this.newPwdLbl.Text = "New password:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 156);
            this.ControlBox = false;
            this.Controls.Add(this.hideNewRetypedPwdBtn);
            this.Controls.Add(this.showNewRetypedPwdBtn);
            this.Controls.Add(this.hideNewPwdBtn);
            this.Controls.Add(this.showNewPwdBtn);
            this.Controls.Add(this.retypePwdTxtBox);
            this.Controls.Add(this.newPwdTxtBox);
            this.Controls.Add(this.retypePwdLbl);
            this.Controls.Add(this.newPwdLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResetPassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Your Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controls.CustomButton cancelBtn;
        private Custom_Controls.CustomButton submitBtn;
        private System.Windows.Forms.Button hideNewRetypedPwdBtn;
        private System.Windows.Forms.Button showNewRetypedPwdBtn;
        private System.Windows.Forms.Button hideNewPwdBtn;
        private System.Windows.Forms.Button showNewPwdBtn;
        private System.Windows.Forms.TextBox retypePwdTxtBox;
        private System.Windows.Forms.TextBox newPwdTxtBox;
        private System.Windows.Forms.Label retypePwdLbl;
        private System.Windows.Forms.Label newPwdLbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}