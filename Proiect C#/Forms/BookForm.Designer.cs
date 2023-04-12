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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.locationLbl = new System.Windows.Forms.Label();
            this.placeComboBox = new System.Windows.Forms.ComboBox();
            this.placeLbl = new System.Windows.Forms.Label();
            this.buildingComboBox = new System.Windows.Forms.ComboBox();
            this.buildingLbl = new System.Windows.Forms.Label();
            this.roomLbl = new System.Windows.Forms.Label();
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bgBox
            // 
            this.bgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgBox.Image = global::Proiect_C_.Properties.Resources.book_room;
            this.bgBox.Location = new System.Drawing.Point(0, 0);
            this.bgBox.Name = "bgBox";
            this.bgBox.Size = new System.Drawing.Size(701, 417);
            this.bgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgBox.TabIndex = 0;
            this.bgBox.TabStop = false;
            // 
            // bgTimer
            // 
            this.bgTimer.Tick += new System.EventHandler(this.bgTimer_Tick);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(53, 26);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(594, 42);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome to our virtual reception!";
            // 
            // logoBox
            // 
            this.logoBox.Image = global::Proiect_C_.Properties.Resources.logo1;
            this.logoBox.Location = new System.Drawing.Point(353, 163);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(38, 26);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 3;
            this.logoBox.TabStop = false;
            // 
            // locationComboBox
            // 
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.IntegralHeight = false;
            this.locationComboBox.Location = new System.Drawing.Point(123, 102);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(192, 21);
            this.locationComboBox.TabIndex = 4;
            this.locationComboBox.SelectedIndexChanged += new System.EventHandler(this.locationComboBox_SelectedIndexChanged);
            this.locationComboBox.TextUpdate += new System.EventHandler(this.locationComboBox_TextUpdate);
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.Location = new System.Drawing.Point(57, 105);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(56, 13);
            this.locationLbl.TabIndex = 5;
            this.locationLbl.Text = "Location";
            // 
            // placeComboBox
            // 
            this.placeComboBox.FormattingEnabled = true;
            this.placeComboBox.Location = new System.Drawing.Point(123, 149);
            this.placeComboBox.Name = "placeComboBox";
            this.placeComboBox.Size = new System.Drawing.Size(192, 21);
            this.placeComboBox.TabIndex = 6;
            this.placeComboBox.SelectedIndexChanged += new System.EventHandler(this.placeComboBox_SelectedIndexChanged);
            this.placeComboBox.TextUpdate += new System.EventHandler(this.placeComboBox_TextUpdate);
            // 
            // placeLbl
            // 
            this.placeLbl.AutoSize = true;
            this.placeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeLbl.Location = new System.Drawing.Point(74, 152);
            this.placeLbl.Name = "placeLbl";
            this.placeLbl.Size = new System.Drawing.Size(39, 13);
            this.placeLbl.TabIndex = 7;
            this.placeLbl.Text = "Place";
            // 
            // buildingComboBox
            // 
            this.buildingComboBox.FormattingEnabled = true;
            this.buildingComboBox.Location = new System.Drawing.Point(123, 196);
            this.buildingComboBox.Name = "buildingComboBox";
            this.buildingComboBox.Size = new System.Drawing.Size(192, 21);
            this.buildingComboBox.TabIndex = 8;
            this.buildingComboBox.TextUpdate += new System.EventHandler(this.buildingComboBox_TextUpdate);
            // 
            // buildingLbl
            // 
            this.buildingLbl.AutoSize = true;
            this.buildingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingLbl.Location = new System.Drawing.Point(61, 199);
            this.buildingLbl.Name = "buildingLbl";
            this.buildingLbl.Size = new System.Drawing.Size(52, 13);
            this.buildingLbl.TabIndex = 9;
            this.buildingLbl.Text = "Building";
            // 
            // roomLbl
            // 
            this.roomLbl.AutoSize = true;
            this.roomLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomLbl.Location = new System.Drawing.Point(42, 240);
            this.roomLbl.Name = "roomLbl";
            this.roomLbl.Size = new System.Drawing.Size(71, 13);
            this.roomLbl.TabIndex = 10;
            this.roomLbl.Text = "Room Type";
            // 
            // roomComboBox
            // 
            this.roomComboBox.FormattingEnabled = true;
            this.roomComboBox.Location = new System.Drawing.Point(123, 237);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(192, 21);
            this.roomComboBox.TabIndex = 11;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 417);
            this.Controls.Add(this.roomComboBox);
            this.Controls.Add(this.roomLbl);
            this.Controls.Add(this.buildingLbl);
            this.Controls.Add(this.buildingComboBox);
            this.Controls.Add(this.placeLbl);
            this.Controls.Add(this.placeComboBox);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.bgBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.Load += new System.EventHandler(this.BookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bgBox;
        private System.Windows.Forms.Timer bgTimer;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.ComboBox placeComboBox;
        private System.Windows.Forms.Label placeLbl;
        private System.Windows.Forms.ComboBox buildingComboBox;
        private System.Windows.Forms.Label buildingLbl;
        private System.Windows.Forms.Label roomLbl;
        private System.Windows.Forms.ComboBox roomComboBox;
    }
}