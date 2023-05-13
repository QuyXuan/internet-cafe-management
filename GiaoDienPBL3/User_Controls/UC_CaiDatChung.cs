using BLL;
using DTO;
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

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_CaiDatChung : UserControl
    {
        public UC_CaiDatChung()
        {
            InitializeComponent();
            SetData();
        }
        private void SetData()
        {
            cboTenLoaiMay.DataSource = TypeComputerBLL.Instance.GetListTypeComputer();
            cboTenLoaiMay.DisplayMember = "NameType";
            cboTenLoaiMay.ValueMember = "TypeId";
            cboTenGiamGia.DataSource = DiscountBLL.Instance.GetListDiscount();
            cboTenGiamGia.DisplayMember = "DiscountName";
            cboTenGiamGia.ValueMember = "DiscountId";
            cboSoMay.DataSource = ComputerBLL.Instance.GetListComputer();
            cboSoMay.DisplayMember = "ComputerName";
            cboSoMay.ValueMember = "ComputerId";
        }
        private void SetEnableTypeComputer(bool status)
        {
            cboTenLoaiMay.Enabled = status;
            txtMaLoaiMay.Enabled = status;
            txtGia.Enabled = status;
            txtMau.Enabled = status;
        }
        private void SetEnableDiscount(bool status)
        {
            cboTenGiamGia.Enabled = status;
            txtMaGiamGia.Enabled = status;
            txtPhanTramGiamGia.Enabled = status;
            cboLoaiKhach.Enabled = status;
        }
        private void SetEnableIP(bool status)
        {
            txtMaMayTinh.Enabled = status;
            cboSoMay.Enabled = status;
            txtIPMay.Enabled = status;
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnCaiDatLoaiMay")
            {
                SetEnableDiscount(false);
                SetEnableIP(false);
                SetEnableTypeComputer(true);
            }
            else if (button.Name == "btnCaiDatGiamGia")
            {
                SetEnableDiscount(true);
                SetEnableIP(false);
                SetEnableTypeComputer(false);
            }
            else if (button.Name == "btnCaiDatIP")
            {
                SetEnableDiscount(false);
                SetEnableIP(true);
                SetEnableTypeComputer(false);
            }
        }
    }
}
