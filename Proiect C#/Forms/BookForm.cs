using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgBox.Invalidate();
        }
        private void bgBox_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(global::Proiect_C_.Properties.Resources.book_room);
        }
    }
}
