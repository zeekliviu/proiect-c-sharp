namespace Proiect_C_.Forms
{
    partial class BookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookForm));
            this.bgBox = new System.Windows.Forms.PictureBox();
            this.bgTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bgBox
            // 
            this.bgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgBox.Image = global::Proiect_C_.Properties.Resources.book_room;
            this.bgBox.Location = new System.Drawing.Point(0, 0);
            this.bgBox.Name = "bgBox";
            this.bgBox.Size = new System.Drawing.Size(800, 450);
            this.bgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgBox.TabIndex = 0;
            this.bgBox.TabStop = false;
            // 
            // bgTimer
            // 
            this.bgTimer.Tick += new System.EventHandler(this.bgTimer_Tick);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bgBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookForm";
            this.Text = "BookForm";
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bgBox;
        private System.Windows.Forms.Timer bgTimer;
    }
}