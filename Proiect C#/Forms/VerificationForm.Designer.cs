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
            this.verifyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // verifyLabel
            // 
            this.verifyLabel.AutoSize = true;
            this.verifyLabel.Location = new System.Drawing.Point(26, 18);
            this.verifyLabel.Name = "verifyLabel";
            this.verifyLabel.Size = new System.Drawing.Size(0, 13);
            this.verifyLabel.TabIndex = 0;
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
            this.verifyBtn.Location = new System.Drawing.Point(286, 112);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(74, 23);
            this.verifyBtn.TabIndex = 2;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.UseVisualStyleBackColor = true;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(29, 112);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VerificationForm";
            this.Text = "Account confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label verifyLabel;
        private System.Windows.Forms.TextBox verifyTxtBox;
        private System.Windows.Forms.Button verifyBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}