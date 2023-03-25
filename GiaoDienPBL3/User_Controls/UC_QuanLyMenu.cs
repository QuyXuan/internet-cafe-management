using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyMenu : UserControl
    {
        public static UC_ThongTinVaCaiDatMonAn my_UCThongTinVaCaiDatMonAn = new UC_ThongTinVaCaiDatMonAn();
        private bool checkBtnCaiDat = false;
        public UC_QuanLyMenu()
        {
            InitializeComponent();
            my_UCThongTinVaCaiDatMonAn = new UC_ThongTinVaCaiDatMonAn();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            if (checkBtnCaiDat == false)
            {
                panelThongTinChiTietMonAn.Controls.Add(my_UCThongTinVaCaiDatMonAn);
                my_UCThongTinVaCaiDatMonAn.Dock = DockStyle.Fill;
                panelCaiDatVaThongTin.SendToBack();
                checkBtnCaiDat = true;
            }
            else
            {
                panelCaiDatVaThongTin.BringToFront();
                checkBtnCaiDat = false;
            }
        }
    }
}
