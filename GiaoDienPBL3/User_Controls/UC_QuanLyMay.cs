using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;
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
    public partial class UC_QuanLyMay : UserControl
    {
        public static UC_ThongTinVaCaiDatMay my_UC;
        private bool checkBtnCaiDat = false;
        public UC_QuanLyMay()
        {
            InitializeComponent();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            my_UC = new UC_ThongTinVaCaiDatMay();
            if (checkBtnCaiDat == false)
            {
                panelThongTin.Controls.Add(my_UC);
                my_UC.Dock = DockStyle.Fill;
                panelChiTietQuanLyMay.SendToBack();
                checkBtnCaiDat = true;
            }
            else
            {
                panelChiTietQuanLyMay.BringToFront();
                checkBtnCaiDat = false;
            }
        }
    }
}
