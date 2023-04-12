using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Proiect_C_.Entities;

namespace Proiect_C_.Forms
{
    public partial class BookForm : Form
    {
        public JObject json;
        public BookForm()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, logoBox.Width, logoBox.Height);
            logoBox.Region = new Region(path);
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgBox.Invalidate();
        }
        private void bgBox_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(global::Proiect_C_.Properties.Resources.book_room);
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            welcomeLabel.Parent = bgBox;
            welcomeLabel.BackColor = Color.Transparent;
            locationLbl.Parent = bgBox;
            locationLbl.BackColor = Color.Transparent;
            placeLbl.Parent = bgBox;
            placeLbl.BackColor = Color.Transparent;
            buildingLbl.Parent = bgBox;
            buildingLbl.BackColor = Color.Transparent;
            roomLbl.Parent = bgBox;
            roomLbl.BackColor = Color.Transparent;
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\final.json", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            json = JObject.Parse(File.ReadAllText(FileName));
            foreach (var item in json)
                locationComboBox.Items.Add(item.Key);
        }

        private void locationComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (!json.ContainsKey(locationComboBox.Text))
                locationComboBox.Text = string.Empty;
        }
        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            placeComboBox.Text = string.Empty;
            buildingComboBox.Text = string.Empty;
            placeComboBox.Items.Clear();
            var places = new JObject(json[locationComboBox.Text].Children());
            foreach (var item in places)
                placeComboBox.Items.Add(item.Key);
        }
        private void placeComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (!json[locationComboBox.Text].Children().Any(x => x.Path == placeComboBox.Text))
                placeComboBox.Text = string.Empty;
        }
        private void placeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildingComboBox.Text = string.Empty;
            roomComboBox.Text = string.Empty;
            buildingComboBox.Items.Clear();
            buildingComboBox.Items.AddRange(json[locationComboBox.Text][placeComboBox.Text].ToObject<string[]>());
            if (placeComboBox.Text == "Hoteluri")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.AddRange(Enum.GetNames(typeof(RoomType)));
            }
            else if (placeComboBox.Text == "Vile")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.Add("Suite");
            }
            else if(placeComboBox.Text == "Case")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.AddRange(new string[] { "Double", "Triple", "Single" });
            }
            else if(placeComboBox.Text == "Pensiuni")
            {
                roomComboBox.Items.Clear();
                roomComboBox.Items.AddRange(new string[] { "Single", "Double"});
            }
            else
            { roomComboBox.Items.Clear(); }
        }

        private void buildingComboBox_TextUpdate(object sender, EventArgs e)
        {
            buildingComboBox.Text = string.Empty;
        }
    }
}
