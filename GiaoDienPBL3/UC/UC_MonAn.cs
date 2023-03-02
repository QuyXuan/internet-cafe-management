using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_MonAn : UserControl
    {
        public Image ImagePanel
        {
            get { return picMonAn.Image; }
            set { picMonAn.Image = value; }
        }
        
        public string TextGiaMonAn
        {
            get { return lblGiaMonAn.Text.Trim(); }
            set { lblGiaMonAn.Text = value; }
        }

        public string TextTenMonAn
        {
            get { return lblTenMonAn.Text.Trim(); }
            set { lblTenMonAn.Text = value; }
        }

        public UC_MonAn()
        {
            InitializeComponent();
        }

        private void picMonAn_Click(object sender, EventArgs e)
        {
            if (panelBackGroundMonAn.BackColor == Color.Transparent)
                panelBackGroundMonAn.BackColor = Color.FromArgb(4, 121, 171);
            else
                panelBackGroundMonAn.BackColor = Color.Transparent;
        }
    }
}
