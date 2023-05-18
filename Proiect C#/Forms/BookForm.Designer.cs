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
            this.yourCartListView = new System.Windows.Forms.ListView();
            this.yourCartLbl = new System.Windows.Forms.Label();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.endDateLbl = new System.Windows.Forms.Label();
            this.endDatePicker = new Proiect_C_.Custom_Controls.CustomDatePicker();
            this.startDatePicker = new Proiect_C_.Custom_Controls.CustomDatePicker();
            this.backBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.checkoutBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.emptyCartBtn = new Proiect_C_.Custom_Controls.CustomButton();
            this.addBookingBtn = new Proiect_C_.Custom_Controls.CustomButton();
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
            this.bgBox.Size = new System.Drawing.Size(982, 578);
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
            this.welcomeLabel.Location = new System.Drawing.Point(53, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(594, 42);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome to our virtual reception!";
            // 
            // logoBox
            // 
            this.logoBox.Image = global::Proiect_C_.Properties.Resources.logo1;
            this.logoBox.Location = new System.Drawing.Point(494, 222);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(60, 46);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 3;
            this.logoBox.TabStop = false;
            // 
            // locationComboBox
            // 
            this.locationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.locationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.IntegralHeight = false;
            this.locationComboBox.Location = new System.Drawing.Point(123, 102);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(304, 21);
            this.locationComboBox.Sorted = true;
            this.locationComboBox.TabIndex = 4;
            this.locationComboBox.SelectedIndexChanged += new System.EventHandler(this.locationComboBox_SelectedIndexChanged);
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
            this.placeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.placeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.placeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.placeComboBox.FormattingEnabled = true;
            this.placeComboBox.Location = new System.Drawing.Point(123, 149);
            this.placeComboBox.Name = "placeComboBox";
            this.placeComboBox.Size = new System.Drawing.Size(304, 21);
            this.placeComboBox.Sorted = true;
            this.placeComboBox.TabIndex = 6;
            this.placeComboBox.SelectedIndexChanged += new System.EventHandler(this.placeComboBox_SelectedIndexChanged);
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
            this.buildingComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.buildingComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.buildingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buildingComboBox.FormattingEnabled = true;
            this.buildingComboBox.Location = new System.Drawing.Point(123, 196);
            this.buildingComboBox.Name = "buildingComboBox";
            this.buildingComboBox.Size = new System.Drawing.Size(304, 21);
            this.buildingComboBox.Sorted = true;
            this.buildingComboBox.TabIndex = 8;
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
            this.roomComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.roomComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.roomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomComboBox.FormattingEnabled = true;
            this.roomComboBox.Location = new System.Drawing.Point(123, 237);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(304, 21);
            this.roomComboBox.Sorted = true;
            this.roomComboBox.TabIndex = 11;
            // 
            // yourCartListView
            // 
            this.yourCartListView.FullRowSelect = true;
            this.yourCartListView.HideSelection = false;
            this.yourCartListView.Location = new System.Drawing.Point(560, 105);
            this.yourCartListView.Name = "yourCartListView";
            this.yourCartListView.Size = new System.Drawing.Size(410, 223);
            this.yourCartListView.TabIndex = 13;
            this.yourCartListView.UseCompatibleStateImageBehavior = false;
            this.yourCartListView.View = System.Windows.Forms.View.Details;
            this.yourCartListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.yourCartListView_ColumnClick);
            this.yourCartListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yourCartListView_MouseDown);
            // 
            // yourCartLbl
            // 
            this.yourCartLbl.AutoSize = true;
            this.yourCartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourCartLbl.Location = new System.Drawing.Point(709, 64);
            this.yourCartLbl.Name = "yourCartLbl";
            this.yourCartLbl.Size = new System.Drawing.Size(123, 29);
            this.yourCartLbl.TabIndex = 14;
            this.yourCartLbl.Text = "Your Cart";
            // 
            // startDateLbl
            // 
            this.startDateLbl.AutoSize = true;
            this.startDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLbl.Location = new System.Drawing.Point(48, 294);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(65, 13);
            this.startDateLbl.TabIndex = 19;
            this.startDateLbl.Text = "Start Date";
            // 
            // endDateLbl
            // 
            this.endDateLbl.AutoSize = true;
            this.endDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLbl.Location = new System.Drawing.Point(53, 348);
            this.endDateLbl.Name = "endDateLbl";
            this.endDateLbl.Size = new System.Drawing.Size(60, 13);
            this.endDateLbl.TabIndex = 21;
            this.endDateLbl.Text = "End Date";
            // 
            // endDatePicker
            // 
            this.endDatePicker.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.endDatePicker.BorderSize = 0;
            this.endDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.endDatePicker.Location = new System.Drawing.Point(123, 339);
            this.endDatePicker.MinimumSize = new System.Drawing.Size(4, 35);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(304, 35);
            this.endDatePicker.SkinColor = System.Drawing.Color.DodgerBlue;
            this.endDatePicker.TabIndex = 20;
            this.endDatePicker.TextColor = System.Drawing.Color.White;
            // 
            // startDatePicker
            // 
            this.startDatePicker.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.startDatePicker.BorderSize = 0;
            this.startDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.startDatePicker.Location = new System.Drawing.Point(123, 281);
            this.startDatePicker.MinimumSize = new System.Drawing.Size(4, 35);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(304, 35);
            this.startDatePicker.SkinColor = System.Drawing.Color.DodgerBlue;
            this.startDatePicker.TabIndex = 18;
            this.startDatePicker.TextColor = System.Drawing.Color.White;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Crimson;
            this.backBtn.BackgroundColor = System.Drawing.Color.Crimson;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.backBtn.BorderColor = System.Drawing.Color.DeepPink;
            this.backBtn.BorderRadius = 20;
            this.backBtn.BorderSize = 0;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(45, 470);
            this.backBtn.Name = "backBtn";
            this.backBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backBtn.Size = new System.Drawing.Size(138, 49);
            this.backBtn.TabIndex = 17;
            this.backBtn.Text = "Back";
            this.backBtn.TextColor = System.Drawing.Color.White;
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.BackColor = System.Drawing.Color.SpringGreen;
            this.checkoutBtn.BackgroundColor = System.Drawing.Color.SpringGreen;
            this.checkoutBtn.BorderColor = System.Drawing.Color.DeepPink;
            this.checkoutBtn.BorderRadius = 20;
            this.checkoutBtn.BorderSize = 0;
            this.checkoutBtn.FlatAppearance.BorderSize = 0;
            this.checkoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutBtn.ForeColor = System.Drawing.Color.White;
            this.checkoutBtn.Location = new System.Drawing.Point(847, 334);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(123, 40);
            this.checkoutBtn.TabIndex = 16;
            this.checkoutBtn.Text = "Checkout";
            this.checkoutBtn.TextColor = System.Drawing.Color.White;
            this.checkoutBtn.UseVisualStyleBackColor = false;
            this.checkoutBtn.Click += new System.EventHandler(this.checkoutBtn_Click);
            // 
            // emptyCartBtn
            // 
            this.emptyCartBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.emptyCartBtn.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.emptyCartBtn.BorderColor = System.Drawing.Color.DeepPink;
            this.emptyCartBtn.BorderRadius = 20;
            this.emptyCartBtn.BorderSize = 0;
            this.emptyCartBtn.FlatAppearance.BorderSize = 0;
            this.emptyCartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emptyCartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyCartBtn.ForeColor = System.Drawing.Color.White;
            this.emptyCartBtn.Location = new System.Drawing.Point(560, 334);
            this.emptyCartBtn.Name = "emptyCartBtn";
            this.emptyCartBtn.Size = new System.Drawing.Size(123, 40);
            this.emptyCartBtn.TabIndex = 15;
            this.emptyCartBtn.Text = "Empty cart";
            this.emptyCartBtn.TextColor = System.Drawing.Color.White;
            this.emptyCartBtn.UseVisualStyleBackColor = false;
            this.emptyCartBtn.Click += new System.EventHandler(this.emptyCartBtn_Click);
            // 
            // addBookingBtn
            // 
            this.addBookingBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.addBookingBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.addBookingBtn.BorderColor = System.Drawing.Color.DeepPink;
            this.addBookingBtn.BorderRadius = 20;
            this.addBookingBtn.BorderSize = 0;
            this.addBookingBtn.FlatAppearance.BorderSize = 0;
            this.addBookingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBookingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBookingBtn.ForeColor = System.Drawing.Color.White;
            this.addBookingBtn.Location = new System.Drawing.Point(123, 403);
            this.addBookingBtn.Name = "addBookingBtn";
            this.addBookingBtn.Size = new System.Drawing.Size(304, 40);
            this.addBookingBtn.TabIndex = 12;
            this.addBookingBtn.Text = "Add to cart";
            this.addBookingBtn.TextColor = System.Drawing.Color.White;
            this.addBookingBtn.UseVisualStyleBackColor = false;
            this.addBookingBtn.Click += new System.EventHandler(this.addBookingBtn_Click);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 578);
            this.ControlBox = false;
            this.Controls.Add(this.endDateLbl);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDateLbl);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.checkoutBtn);
            this.Controls.Add(this.emptyCartBtn);
            this.Controls.Add(this.yourCartLbl);
            this.Controls.Add(this.yourCartListView);
            this.Controls.Add(this.addBookingBtn);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Now!";
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
        private Custom_Controls.CustomButton addBookingBtn;
        private System.Windows.Forms.ListView yourCartListView;
        private System.Windows.Forms.Label yourCartLbl;
        private Custom_Controls.CustomButton emptyCartBtn;
        private Custom_Controls.CustomButton checkoutBtn;
        private Custom_Controls.CustomButton backBtn;
        private Custom_Controls.CustomDatePicker startDatePicker;
        private System.Windows.Forms.Label startDateLbl;
        private Custom_Controls.CustomDatePicker endDatePicker;
        private System.Windows.Forms.Label endDateLbl;
    }
}