namespace Proiect_C_.Forms
{
    partial class YourBookings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YourBookings));
            this.bookingsListView = new System.Windows.Forms.ListView();
            this.exportingToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripExportToCSVBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExportToTXTBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.backToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printBtn = new System.Windows.Forms.ToolStripButton();
            this.exportingStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripExportingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.exportingToolStrip.SuspendLayout();
            this.exportingStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookingsListView
            // 
            this.bookingsListView.FullRowSelect = true;
            this.bookingsListView.HideSelection = false;
            this.bookingsListView.Location = new System.Drawing.Point(-1, 28);
            this.bookingsListView.Name = "bookingsListView";
            this.bookingsListView.Size = new System.Drawing.Size(801, 397);
            this.bookingsListView.TabIndex = 0;
            this.bookingsListView.UseCompatibleStateImageBehavior = false;
            this.bookingsListView.View = System.Windows.Forms.View.Details;
            // 
            // exportingToolStrip
            // 
            this.exportingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExportToCSVBtn,
            this.toolStripSeparator1,
            this.toolStripExportToTXTBtn,
            this.toolStripSeparator3,
            this.toolStripPrintPreview,
            this.backToolStripBtn,
            this.toolStripSeparator2,
            this.printBtn});
            this.exportingToolStrip.Location = new System.Drawing.Point(0, 0);
            this.exportingToolStrip.Name = "exportingToolStrip";
            this.exportingToolStrip.Size = new System.Drawing.Size(800, 25);
            this.exportingToolStrip.TabIndex = 1;
            // 
            // toolStripExportToCSVBtn
            // 
            this.toolStripExportToCSVBtn.Image = global::Proiect_C_.Properties.Resources.csv_icon;
            this.toolStripExportToCSVBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExportToCSVBtn.Name = "toolStripExportToCSVBtn";
            this.toolStripExportToCSVBtn.Size = new System.Drawing.Size(150, 22);
            this.toolStripExportToCSVBtn.Text = "Export to CSV (ALT + V)";
            this.toolStripExportToCSVBtn.Click += new System.EventHandler(this.toolStripExportToCSVBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripExportToTXTBtn
            // 
            this.toolStripExportToTXTBtn.Image = global::Proiect_C_.Properties.Resources.ezgif_com_webp_to_jpg;
            this.toolStripExportToTXTBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExportToTXTBtn.Name = "toolStripExportToTXTBtn";
            this.toolStripExportToTXTBtn.Size = new System.Drawing.Size(147, 22);
            this.toolStripExportToTXTBtn.Text = "Export to TXT (ALT + T)";
            this.toolStripExportToTXTBtn.Click += new System.EventHandler(this.toolStripExportToTXTBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripPrintPreview
            // 
            this.toolStripPrintPreview.Image = global::Proiect_C_.Properties.Resources.print_preview;
            this.toolStripPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrintPreview.Name = "toolStripPrintPreview";
            this.toolStripPrintPreview.Size = new System.Drawing.Size(96, 22);
            this.toolStripPrintPreview.Text = "Print Preview";
            this.toolStripPrintPreview.Click += new System.EventHandler(this.toolStripPrintPreview_Click);
            // 
            // backToolStripBtn
            // 
            this.backToolStripBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.backToolStripBtn.Image = global::Proiect_C_.Properties.Resources.back_button;
            this.backToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backToolStripBtn.Name = "backToolStripBtn";
            this.backToolStripBtn.Size = new System.Drawing.Size(52, 22);
            this.backToolStripBtn.Text = "Back";
            this.backToolStripBtn.Click += new System.EventHandler(this.backToolStripBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // printBtn
            // 
            this.printBtn.Image = global::Proiect_C_.Properties.Resources.pdf_printer_icon;
            this.printBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(91, 22);
            this.printBtn.Text = "Print To PDF";
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // exportingStatusStrip
            // 
            this.exportingStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripExportingStatus});
            this.exportingStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.exportingStatusStrip.Name = "exportingStatusStrip";
            this.exportingStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.exportingStatusStrip.TabIndex = 2;
            this.exportingStatusStrip.Text = "statusStrip1";
            // 
            // statusStripExportingStatus
            // 
            this.statusStripExportingStatus.Name = "statusStripExportingStatus";
            this.statusStripExportingStatus.Size = new System.Drawing.Size(57, 17);
            this.statusStripExportingStatus.Text = "Waiting...";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.PrintToFile = true;
            this.printDialog.UseEXDialog = true;
            // 
            // YourBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.exportingStatusStrip);
            this.Controls.Add(this.exportingToolStrip);
            this.Controls.Add(this.bookingsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "YourBookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your Bookings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YourBookings_KeyDown);
            this.exportingToolStrip.ResumeLayout(false);
            this.exportingToolStrip.PerformLayout();
            this.exportingStatusStrip.ResumeLayout(false);
            this.exportingStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView bookingsListView;
        private System.Windows.Forms.ToolStrip exportingToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripExportToCSVBtn;
        private System.Windows.Forms.ToolStripButton toolStripExportToTXTBtn;
        private System.Windows.Forms.StatusStrip exportingStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripExportingStatus;
        private System.Windows.Forms.ToolStripButton backToolStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.ToolStripButton toolStripPrintPreview;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton printBtn;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}