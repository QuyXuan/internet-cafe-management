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
<<<<<<< HEAD
using BLL;
using DTO;
using GiaoDienPBL3.User_Controls;
=======
>>>>>>> parent of 792afe9 (11:14 pm 3/25/2023 quy changed)
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyMenu : UserControl
    {
        public UC_QuanLyMenu()
        {
            InitializeComponent();
        }
        private void SetAllButtonDisableAndVisible()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Visible = true;
            btnOK.Visible = true;
        }
        private void SetAllButtonEnableAndInvisible()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Checked = false;
            btnXoa.Checked = false;
            btnSua.Checked = false;
            btnHuy.Visible = false;
            btnOK.Visible = false;
        }
        private void SetEnableComboboxAndTextBox(bool status)
        {
            txtMaMon.Enabled = status;
            txtTenMon.Enabled = status;
            txtGia.Enabled = status;
            cboLoai.Enabled = status;
            btnThemAnh.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtGia.Text = "";
            cboLoai.SelectedIndex = -1;
        }
        private void ThemXoaSuaClick(object sender, EventArgs e)
        {

        }
        private void HuyOKClick(object sender, EventArgs e)
        {
            //Guna2Button btn = sender as Guna2Button;
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Checked == false)
            {
                panelCaiDat.Visible = true;
            }
            else
            {
                panelCaiDat.Visible = false;
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
