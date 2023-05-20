namespace Proiect_C_.Forms
{
    partial class PersonalPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalPageForm));
            this.profileMenuStrip = new System.Windows.Forms.MenuStrip();
            this.yourBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoBox = new System.Windows.Forms.PictureBox();
            this.photoChangeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePhotosetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enable2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disable2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.profileMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).BeginInit();
            this.photoChangeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileMenuStrip
            // 
            this.profileMenuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.profileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yourBookingsToolStripMenuItem,
            this.bookToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.profileMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.profileMenuStrip.Name = "profileMenuStrip";
            this.profileMenuStrip.Size = new System.Drawing.Size(127, 305);
            this.profileMenuStrip.TabIndex = 0;
            this.profileMenuStrip.Text = "menuStrip1";
            // 
            // yourBookingsToolStripMenuItem
            // 
            this.yourBookingsToolStripMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yourBookingsToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourBookingsToolStripMenuItem.Image = global::Proiect_C_.Properties.Resources.your_bookings;
            this.yourBookingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yourBookingsToolStripMenuItem.Name = "yourBookingsToolStripMenuItem";
            this.yourBookingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 86);
            this.yourBookingsToolStripMenuItem.Size = new System.Drawing.Size(114, 108);
            this.yourBookingsToolStripMenuItem.Text = "Your Bookings";
            this.yourBookingsToolStripMenuItem.Click += new System.EventHandler(this.yourBookingsToolStripMenuItem_Click);
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookToolStripMenuItem.Image = global::Proiect_C_.Properties.Resources.book;
            this.bookToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 75);
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(114, 97);
            this.bookToolStripMenuItem.Text = "Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.Image = global::Proiect_C_.Properties.Resources.log_out;
            this.logOutToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 73);
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(114, 95);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // photoBox
            // 
            this.photoBox.ContextMenuStrip = this.photoChangeContextMenuStrip;
            this.photoBox.Location = new System.Drawing.Point(149, 12);
            this.photoBox.Name = "photoBox";
            this.photoBox.Size = new System.Drawing.Size(287, 166);
            this.photoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox.TabIndex = 1;
            this.photoBox.TabStop = false;
            // 
            // photoChangeContextMenuStrip
            // 
            this.photoChangeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePhotoToolStripMenuItem,
            this.removePhotosetToDefaultToolStripMenuItem,
            this.changeEmailToolStripMenuItem,
            this.changeNameToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.enable2FAToolStripMenuItem,
            this.disable2FAToolStripMenuItem});
            this.photoChangeContextMenuStrip.Name = "photoChangeContextMenuStrip";
            this.photoChangeContextMenuStrip.Size = new System.Drawing.Size(242, 180);
            // 
            // changePhotoToolStripMenuItem
            // 
            this.changePhotoToolStripMenuItem.Name = "changePhotoToolStripMenuItem";
            this.changePhotoToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.changePhotoToolStripMenuItem.Text = "Change Photo...";
            this.changePhotoToolStripMenuItem.Click += new System.EventHandler(this.changePhotoToolStripMenuItem_Click);
            // 
            // removePhotosetToDefaultToolStripMenuItem
            // 
            this.removePhotosetToDefaultToolStripMenuItem.Name = "removePhotosetToDefaultToolStripMenuItem";
            this.removePhotosetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.removePhotosetToDefaultToolStripMenuItem.Text = "Remove Photo (set to default)...";
            this.removePhotosetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.removePhotosetToDefaultToolStripMenuItem_Click);
            // 
            // changeEmailToolStripMenuItem
            // 
            this.changeEmailToolStripMenuItem.Name = "changeEmailToolStripMenuItem";
            this.changeEmailToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.changeEmailToolStripMenuItem.Text = "Change Email...";
            this.changeEmailToolStripMenuItem.Click += new System.EventHandler(this.changeEmailToolStripMenuItem_Click);
            // 
            // changeNameToolStripMenuItem
            // 
            this.changeNameToolStripMenuItem.Name = "changeNameToolStripMenuItem";
            this.changeNameToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.changeNameToolStripMenuItem.Text = "Change Name...";
            this.changeNameToolStripMenuItem.Click += new System.EventHandler(this.changeNameToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password...";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // enable2FAToolStripMenuItem
            // 
            this.enable2FAToolStripMenuItem.Name = "enable2FAToolStripMenuItem";
            this.enable2FAToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.enable2FAToolStripMenuItem.Text = "Enable 2FA...";
            this.enable2FAToolStripMenuItem.Click += new System.EventHandler(this.enable2FAToolStripMenuItem_Click);
            // 
            // disable2FAToolStripMenuItem
            // 
            this.disable2FAToolStripMenuItem.Name = "disable2FAToolStripMenuItem";
            this.disable2FAToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.disable2FAToolStripMenuItem.Text = "Disable 2FA...";
            this.disable2FAToolStripMenuItem.Click += new System.EventHandler(this.disable2FAToolStripMenuItem_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(130, 213);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(85, 29);
            this.welcomeLabel.TabIndex = 2;
            this.welcomeLabel.Text = "label1";
            // 
            // PersonalPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 305);
            this.ControlBox = false;
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.photoBox);
            this.Controls.Add(this.profileMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.profileMenuStrip;
            this.Name = "PersonalPageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your Profile";
            this.profileMenuStrip.ResumeLayout(false);
            this.profileMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).EndInit();
            this.photoChangeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip profileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem yourBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.PictureBox photoBox;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ContextMenuStrip photoChangeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changePhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePhotosetToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enable2FAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disable2FAToolStripMenuItem;
    }
}