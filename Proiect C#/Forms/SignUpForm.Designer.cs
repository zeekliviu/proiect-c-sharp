using Proiect_C_.Custom_Controls;
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
            this.RetypePwdLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.firstPwdTxtBox = new System.Windows.Forms.TextBox();
            this.secondPwdTxtBox = new System.Windows.Forms.TextBox();
            this.firstNameTxtBox = new System.Windows.Forms.TextBox();
            this.lastNameTxtBox = new System.Windows.Forms.TextBox();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.submitBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.backBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.photoLabel = new System.Windows.Forms.Label();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.selectImageBtn = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.bgBox = new System.Windows.Forms.PictureBox();
            this.showFirstPwdBtn = new System.Windows.Forms.Button();
            this.hideFirstPwdBtn = new System.Windows.Forms.Button();
            this.showSecondPwdBtn = new System.Windows.Forms.Button();
            this.hideSecondPwdBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Impact", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.Lime;
            this.welcomeLabel.Location = new System.Drawing.Point(40, 19);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(189, 56);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome!";
            // 
            // reqLabel
            // 
            this.reqLabel.AutoSize = true;
            this.reqLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reqLabel.Location = new System.Drawing.Point(20, 75);
            this.reqLabel.Name = "reqLabel";
            this.reqLabel.Size = new System.Drawing.Size(228, 13);
            this.reqLabel.TabIndex = 1;
            this.reqLabel.Text = "Please fill in the following informations:";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FirstNameLabel.Location = new System.Drawing.Point(36, 211);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(71, 13);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // FirstPwdLabel
            // 
            this.FirstPwdLabel.AutoSize = true;
            this.FirstPwdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstPwdLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FirstPwdLabel.Location = new System.Drawing.Point(39, 142);
            this.FirstPwdLabel.Name = "FirstPwdLabel";
            this.FirstPwdLabel.Size = new System.Drawing.Size(65, 13);
            this.FirstPwdLabel.TabIndex = 3;
            this.FirstPwdLabel.Text = "Password:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EmailLabel.Location = new System.Drawing.Point(63, 108);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(41, 13);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LastNameLabel.Location = new System.Drawing.Point(36, 248);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(71, 13);
            this.LastNameLabel.TabIndex = 5;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // RetypePwdLabel
            // 
            this.RetypePwdLabel.AutoSize = true;
            this.RetypePwdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetypePwdLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RetypePwdLabel.Location = new System.Drawing.Point(-1, 177);
            this.RetypePwdLabel.Name = "RetypePwdLabel";
            this.RetypePwdLabel.Size = new System.Drawing.Size(113, 13);
            this.RetypePwdLabel.TabIndex = 6;
            this.RetypePwdLabel.Text = "Re-type Password:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PhoneLabel.Location = new System.Drawing.Point(57, 282);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(47, 13);
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
            this.firstPwdTxtBox.Size = new System.Drawing.Size(191, 20);
            this.firstPwdTxtBox.TabIndex = 9;
            this.firstPwdTxtBox.UseSystemPasswordChar = true;
            this.firstPwdTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.firstPwdTxtBox_Validating);
            // 
            // secondPwdTxtBox
            // 
            this.secondPwdTxtBox.Location = new System.Drawing.Point(110, 174);
            this.secondPwdTxtBox.Name = "secondPwdTxtBox";
            this.secondPwdTxtBox.Size = new System.Drawing.Size(191, 20);
            this.secondPwdTxtBox.TabIndex = 10;
            this.secondPwdTxtBox.UseSystemPasswordChar = true;
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
            this.logoBox.TabIndex = 14;
            this.logoBox.TabStop = false;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.submitBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.submitBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.submitBtn.BorderRadius = 20;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(324, 206);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(58, 96);
            this.submitBtn.TabIndex = 15;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.backBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.backBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.backBtn.BorderRadius = 20;
            this.backBtn.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(324, 105);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(58, 96);
            this.backBtn.TabIndex = 16;
            this.backBtn.Text = "Back";
            this.backBtn.TextColor = System.Drawing.Color.White;
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // photoLabel
            // 
            this.photoLabel.AutoSize = true;
            this.photoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.photoLabel.Location = new System.Drawing.Point(12, 308);
            this.photoLabel.Name = "photoLabel";
            this.photoLabel.Size = new System.Drawing.Size(101, 13);
            this.photoLabel.TabIndex = 18;
            this.photoLabel.Text = "Photo (optional):";
            // 
            // openImage
            // 
            this.openImage.FileName = "openFileDialog1";
            // 
            // selectImageBtn
            // 
            this.selectImageBtn.Location = new System.Drawing.Point(110, 303);
            this.selectImageBtn.Name = "selectImageBtn";
            this.selectImageBtn.Size = new System.Drawing.Size(75, 23);
            this.selectImageBtn.TabIndex = 19;
            this.selectImageBtn.Text = "Upload...";
            this.selectImageBtn.UseVisualStyleBackColor = true;
            this.selectImageBtn.Click += new System.EventHandler(this.selectImageBtn_Click);
            // 
            // imageBox
            // 
            this.imageBox.Image = global::Proiect_C_.Properties.Resources.default_avatar;
            this.imageBox.Location = new System.Drawing.Point(254, 308);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(79, 37);
            this.imageBox.TabIndex = 20;
            this.imageBox.TabStop = false;
            this.imageBox.Visible = false;
            // 
            // bgBox
            // 
            this.bgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgBox.Image = global::Proiect_C_.Properties.Resources.sign_up;
            this.bgBox.Location = new System.Drawing.Point(0, 0);
            this.bgBox.Name = "bgBox";
            this.bgBox.Size = new System.Drawing.Size(383, 345);
            this.bgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgBox.TabIndex = 21;
            this.bgBox.TabStop = false;
            // 
            // showFirstPwdBtn
            // 
            this.showFirstPwdBtn.BackColor = System.Drawing.Color.White;
            this.showFirstPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.closed_eye;
            this.showFirstPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showFirstPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showFirstPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.showFirstPwdBtn.Location = new System.Drawing.Point(269, 139);
            this.showFirstPwdBtn.Name = "showFirstPwdBtn";
            this.showFirstPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.showFirstPwdBtn.TabIndex = 22;
            this.showFirstPwdBtn.UseVisualStyleBackColor = false;
            this.showFirstPwdBtn.Click += new System.EventHandler(this.showFirstPwdBtn_Click);
            // 
            // hideFirstPwdBtn
            // 
            this.hideFirstPwdBtn.BackColor = System.Drawing.Color.White;
            this.hideFirstPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.eye;
            this.hideFirstPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hideFirstPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideFirstPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.hideFirstPwdBtn.Location = new System.Drawing.Point(269, 139);
            this.hideFirstPwdBtn.Name = "hideFirstPwdBtn";
            this.hideFirstPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.hideFirstPwdBtn.TabIndex = 23;
            this.hideFirstPwdBtn.UseVisualStyleBackColor = false;
            this.hideFirstPwdBtn.Visible = false;
            this.hideFirstPwdBtn.Click += new System.EventHandler(this.hideFirstPwdBtn_Click);
            // 
            // showSecondPwdBtn
            // 
            this.showSecondPwdBtn.BackColor = System.Drawing.Color.White;
            this.showSecondPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.closed_eye;
            this.showSecondPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showSecondPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showSecondPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.showSecondPwdBtn.Location = new System.Drawing.Point(269, 174);
            this.showSecondPwdBtn.Name = "showSecondPwdBtn";
            this.showSecondPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.showSecondPwdBtn.TabIndex = 24;
            this.showSecondPwdBtn.UseVisualStyleBackColor = false;
            this.showSecondPwdBtn.Click += new System.EventHandler(this.showSecondPwdBtn_Click);
            // 
            // hideSecondPwdBtn
            // 
            this.hideSecondPwdBtn.BackColor = System.Drawing.Color.White;
            this.hideSecondPwdBtn.BackgroundImage = global::Proiect_C_.Properties.Resources.eye;
            this.hideSecondPwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hideSecondPwdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideSecondPwdBtn.ForeColor = System.Drawing.Color.Black;
            this.hideSecondPwdBtn.Location = new System.Drawing.Point(269, 174);
            this.hideSecondPwdBtn.Name = "hideSecondPwdBtn";
            this.hideSecondPwdBtn.Size = new System.Drawing.Size(32, 20);
            this.hideSecondPwdBtn.TabIndex = 25;
            this.hideSecondPwdBtn.UseVisualStyleBackColor = false;
            this.hideSecondPwdBtn.Visible = false;
            this.hideSecondPwdBtn.Click += new System.EventHandler(this.hideSecondPwdBtn_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 345);
            this.ControlBox = false;
            this.Controls.Add(this.hideSecondPwdBtn);
            this.Controls.Add(this.showSecondPwdBtn);
            this.Controls.Add(this.hideFirstPwdBtn);
            this.Controls.Add(this.showFirstPwdBtn);
            this.Controls.Add(this.reqLabel);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.selectImageBtn);
            this.Controls.Add(this.photoLabel);
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
            this.Controls.Add(this.RetypePwdLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.FirstPwdLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.bgBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SignUpForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Join us!";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).EndInit();
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
        private System.Windows.Forms.Label RetypePwdLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.TextBox firstPwdTxtBox;
        private System.Windows.Forms.TextBox secondPwdTxtBox;
        private System.Windows.Forms.TextBox firstNameTxtBox;
        private System.Windows.Forms.TextBox lastNameTxtBox;
        private System.Windows.Forms.TextBox phoneTxtBox;
        private System.Windows.Forms.PictureBox logoBox;
        private CustomButton submitBtn;
        private CustomButton backBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button selectImageBtn;
        private System.Windows.Forms.Label photoLabel;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.PictureBox bgBox;
        private System.Windows.Forms.Button hideFirstPwdBtn;
        private System.Windows.Forms.Button showFirstPwdBtn;
        private System.Windows.Forms.Button hideSecondPwdBtn;
        private System.Windows.Forms.Button showSecondPwdBtn;
    }
}