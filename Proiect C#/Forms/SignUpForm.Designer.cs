using Proiect_C_.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Proiect_C_.Forms
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.reqLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.FirstPwdLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.firstPwdTxtBox = new System.Windows.Forms.TextBox();
            this.secondPwdTxtBox = new System.Windows.Forms.TextBox();
            this.firstNameTxtBox = new System.Windows.Forms.TextBox();
            this.lastNameTxtBox = new System.Windows.Forms.TextBox();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.showPwdChkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.Location = new System.Drawing.Point(40, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(176, 56);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome!";
            // 
            // reqLabel
            // 
            this.reqLabel.AutoSize = true;
            this.reqLabel.Location = new System.Drawing.Point(43, 52);
            this.reqLabel.Name = "reqLabel";
            this.reqLabel.Size = new System.Drawing.Size(186, 13);
            this.reqLabel.TabIndex = 1;
            this.reqLabel.Text = "Please fill in the following informations:";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(44, 211);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // FirstPwdLabel
            // 
            this.FirstPwdLabel.AutoSize = true;
            this.FirstPwdLabel.Location = new System.Drawing.Point(48, 142);
            this.FirstPwdLabel.Name = "FirstPwdLabel";
            this.FirstPwdLabel.Size = new System.Drawing.Size(56, 13);
            this.FirstPwdLabel.TabIndex = 3;
            this.FirstPwdLabel.Text = "Password:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(69, 108);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(43, 248);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.LastNameLabel.TabIndex = 5;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(8, 177);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(96, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Re-type Password:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(63, 282);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.PhoneLabel.TabIndex = 7;
            this.PhoneLabel.Text = "Phone:";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(110, 105);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(191, 20);
            this.emailTxtBox.TabIndex = 8;
            this.emailTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.emailTxtBox_Validating);
            // 
            // firstPwdTxtBox
            // 
            this.firstPwdTxtBox.Location = new System.Drawing.Point(110, 139);
            this.firstPwdTxtBox.Name = "firstPwdTxtBox";
            this.firstPwdTxtBox.PasswordChar = '*';
            this.firstPwdTxtBox.Size = new System.Drawing.Size(191, 20);
            this.firstPwdTxtBox.TabIndex = 9;
            this.firstPwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.firstPwdTxtBox_Validating);
            // 
            // secondPwdTxtBox
            // 
            this.secondPwdTxtBox.Location = new System.Drawing.Point(110, 174);
            this.secondPwdTxtBox.Name = "secondPwdTxtBox";
            this.secondPwdTxtBox.PasswordChar = '*';
            this.secondPwdTxtBox.Size = new System.Drawing.Size(191, 20);
            this.secondPwdTxtBox.TabIndex = 10;
            this.secondPwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.secondPwdTxtBox_Validating);
            // 
            // firstNameTxtBox
            // 
            this.firstNameTxtBox.Location = new System.Drawing.Point(110, 208);
            this.firstNameTxtBox.Name = "firstNameTxtBox";
            this.firstNameTxtBox.Size = new System.Drawing.Size(191, 20);
            this.firstNameTxtBox.TabIndex = 11;
            this.firstNameTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.firstNameTxtBox_Validating);
            // 
            // lastNameTxtBox
            // 
            this.lastNameTxtBox.Location = new System.Drawing.Point(110, 245);
            this.lastNameTxtBox.Name = "lastNameTxtBox";
            this.lastNameTxtBox.Size = new System.Drawing.Size(191, 20);
            this.lastNameTxtBox.TabIndex = 12;
            this.lastNameTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.lastNameTxtBox_Validating);
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(110, 279);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(191, 20);
            this.phoneTxtBox.TabIndex = 13;
            this.phoneTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.phoneTxtBox_Validating);
            // 
            // logoBox
            // 
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoBox.Image = global::Proiect_C_.Properties.Resources.logo1;
            this.logoBox.Location = new System.Drawing.Point(254, 12);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(100, 75);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
            this.logoBox.TabIndex = 14;
            this.logoBox.TabStop = false;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(324, 206);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(58, 96);
            this.submitBtn.TabIndex = 15;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(324, 105);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(58, 96);
            this.backBtn.TabIndex = 16;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // showPwdChkBox
            // 
            this.showPwdChkBox.AutoSize = true;
            this.showPwdChkBox.Location = new System.Drawing.Point(2, 158);
            this.showPwdChkBox.Name = "showPwdChkBox";
            this.showPwdChkBox.Size = new System.Drawing.Size(102, 17);
            this.showPwdChkBox.TabIndex = 17;
            this.showPwdChkBox.Text = "Show Password";
            this.showPwdChkBox.UseVisualStyleBackColor = true;
            this.showPwdChkBox.CheckedChanged += new System.EventHandler(this.showPwdChkBox_CheckedChanged);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 325);
            this.Controls.Add(this.showPwdChkBox);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.phoneTxtBox);
            this.Controls.Add(this.lastNameTxtBox);
            this.Controls.Add(this.firstNameTxtBox);
            this.Controls.Add(this.secondPwdTxtBox);
            this.Controls.Add(this.firstPwdTxtBox);
            this.Controls.Add(this.emailTxtBox);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.FirstPwdLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.reqLabel);
            this.Controls.Add(this.welcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SignUpForm";
            this.Text = "Join us!";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label reqLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label FirstPwdLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.TextBox firstPwdTxtBox;
        private System.Windows.Forms.TextBox secondPwdTxtBox;
        private System.Windows.Forms.TextBox firstNameTxtBox;
        private System.Windows.Forms.TextBox lastNameTxtBox;
        private System.Windows.Forms.TextBox phoneTxtBox;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox showPwdChkBox;
    }
}