using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Proiect_C_.Custom_Controls;

namespace Proiect_C_
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bgBox = new System.Windows.Forms.PictureBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.bgTimer = new System.Windows.Forms.Timer(this.components);
            this.logInBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.signUpBtn = new Proiect_C_.Custom_Controls.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bgBox
            // 
            this.bgBox.BackColor = System.Drawing.Color.Transparent;
            this.bgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgBox.Image = global::Proiect_C_.Properties.Resources.hotel;
            this.bgBox.Location = new System.Drawing.Point(0, 0);
            this.bgBox.Name = "bgBox";
            this.bgBox.Size = new System.Drawing.Size(705, 428);
            this.bgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgBox.TabIndex = 4;
            this.bgBox.TabStop = false;
            this.bgBox.Paint += new System.Windows.Forms.PaintEventHandler(this.bgBox_Paint);
            // 
            // logoBox
            // 
            this.logoBox.Image = global::Proiect_C_.Properties.Resources.logo1;
            this.logoBox.Location = new System.Drawing.Point(276, 0);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(151, 150);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // bgTimer
            // 
            this.bgTimer.Tick += new System.EventHandler(this.bgTimer_Tick);
            // 
            // logInBtn
            // 
            this.logInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logInBtn.AutoSize = true;
            this.logInBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.logInBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.logInBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.logInBtn.BorderRadius = 20;
            this.logInBtn.BorderSize = 0;
            this.logInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logInBtn.ForeColor = System.Drawing.Color.White;
            this.logInBtn.Location = new System.Drawing.Point(518, 285);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(116, 45);
            this.logInBtn.TabIndex = 3;
            this.logInBtn.Text = "Log In";
            this.logInBtn.TextColor = System.Drawing.Color.White;
            this.logInBtn.UseVisualStyleBackColor = false;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // signUpBtn
            // 
            this.signUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.signUpBtn.AutoSize = true;
            this.signUpBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.signUpBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.signUpBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.signUpBtn.BorderRadius = 20;
            this.signUpBtn.BorderSize = 0;
            this.signUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signUpBtn.ForeColor = System.Drawing.Color.White;
            this.signUpBtn.Location = new System.Drawing.Point(78, 285);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(116, 45);
            this.signUpBtn.TabIndex = 2;
            this.signUpBtn.Text = "Sign Up";
            this.signUpBtn.TextColor = System.Drawing.Color.White;
            this.signUpBtn.UseVisualStyleBackColor = false;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 428);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.bgBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookify";
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private CustomButton signUpBtn;
        private CustomButton logInBtn;
        private PictureBox bgBox;
        private Timer bgTimer;
        private PictureBox logoBox;
    }
}

