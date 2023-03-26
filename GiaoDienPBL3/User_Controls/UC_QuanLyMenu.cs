using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
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

        private void UC_QuanLyMenu_Load(object sender, EventArgs e)
        {
            SetFullMonAn();
        }
        private void SetFullMonAn()
        {
            List<MonAn> listFullMonAn = BLLMonAn.Instance.GetListMonAn();
            foreach (MonAn item in listFullMonAn)
            {
                AddMonAn(item);
            }
        }
        private void AddMonAn(MonAn monAn)
        {
            UC_MonAn my_UCMonAn = new UC_MonAn();
            my_UCMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", monAn.Gia);
            my_UCMonAn.TextTenMonAn = monAn.TenMonAn;
            my_UCMonAn.ImagePanel = GetAnhByPathAnhMon(monAn.PathAnhMon);
            my_UCMonAn.Tag = monAn;
            frmMain.myUC_QuanLyMenu.panelMonAn.Controls.Add(my_UCMonAn);
        }
        private Image GetAnhByPathAnhMon(string path)
        {
            try
            {
                Image image = Image.FromFile(path);
                return image;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
