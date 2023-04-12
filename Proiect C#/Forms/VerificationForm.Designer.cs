using Proiect_C_.Custom_Controls;
using Proiect_C_.Properties;
using System.Resources;

namespace Proiect_C_.Forms
{
    partial class VerificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificationForm));
            this.verifyLabel = new System.Windows.Forms.Label();
            this.verifyTxtBox = new System.Windows.Forms.TextBox();
            this.verifyBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.cancelBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.bgBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // verifyLabel
            // 
            this.verifyLabel.AutoSize = true;
            this.verifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.verifyLabel.Location = new System.Drawing.Point(26, 18);
            this.verifyLabel.Name = "verifyLabel";
            this.verifyLabel.Size = new System.Drawing.Size(35, 12);
            this.verifyLabel.TabIndex = 0;
            this.verifyLabel.Text = "label1";
            // 
            // verifyTxtBox
            // 
            this.verifyTxtBox.Location = new System.Drawing.Point(66, 55);
            this.verifyTxtBox.Name = "verifyTxtBox";
            this.verifyTxtBox.Size = new System.Drawing.Size(248, 20);
            this.verifyTxtBox.TabIndex = 1;
            // 
            // verifyBtn
            // 
            this.verifyBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.verifyBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.verifyBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.verifyBtn.BorderRadius = 20;
            this.verifyBtn.BorderSize = 0;
            this.verifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyBtn.ForeColor = System.Drawing.Color.White;
            this.verifyBtn.Location = new System.Drawing.Point(290, 105);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(70, 36);
            this.verifyBtn.TabIndex = 2;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.TextColor = System.Drawing.Color.White;
            this.verifyBtn.UseVisualStyleBackColor = true;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cancelBtn.BorderRadius = 20;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(29, 105);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 36);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // bgBox
            // 
            this.bgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgBox.Image = global::Proiect_C_.Properties.Resources.verify;
            this.bgBox.Location = new System.Drawing.Point(0, 0);
            this.bgBox.Name = "bgBox";
            this.bgBox.Size = new System.Drawing.Size(383, 159);
            this.bgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgBox.TabIndex = 4;
            this.bgBox.TabStop = false;
            // 
            // VerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 159);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.verifyBtn);
            this.Controls.Add(this.verifyTxtBox);
            this.Controls.Add(this.verifyLabel);
            this.Controls.Add(this.bgBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account confirmation";
            this.Load += new System.EventHandler(this.VerificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label verifyLabel;
        private System.Windows.Forms.TextBox verifyTxtBox;
        private CustomButton verifyBtn;
        private CustomButton cancelBtn;
        private System.Windows.Forms.PictureBox bgBox;
    }
}