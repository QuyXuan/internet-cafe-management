using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_LoaiMay : UserControl
    {
        public string TextLoaiMay
        {
            get { return lblLoaiMay.Text.Trim(); }
            set { lblLoaiMay.Text = value;}
        }

        public Color ColorLoaiMay
        {
            get { return btnColorMay.BorderColor; }
            set { btnColorMay.BorderColor = value; }
        }

        public UC_LoaiMay()
        {
            InitializeComponent();
        }
    }
}
