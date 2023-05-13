using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_ThongTinVaCaiDatMay : UserControl
    {
        private Guna2Button lastButton = null;
        private Dictionary<string, Color> COLOR;
        //kiểm tra xem có đang thêm máy k, có thì sẽ k chọn được xem máy
        public static bool checkAddComputer = false;
        public string TextMaMay
        {
            get { return txtMaMay.Text.Trim(); }
            set { txtMaMay.Text = value; }
        }
        public string TextTenMay
        {
            get { return txtSoMay.Text.Trim(); }
            set { txtSoMay.Text = value; }
        }
        public string TextGia
        {
            get { return txtGia.Text.Trim(); }
            set { txtGia.Text = value; }
        }
        public string TextLoaiMay
        {
            get { return cboLoaiMay.SelectedItem?.ToString(); }
            set
            {
                if (cboLoaiMay.Items.Contains(value))
                {
                    cboLoaiMay.SelectedItem = value;
                }
            }
        }
        public string TextTrangThai
        {
            get { return cboTrangThai.SelectedItem?.ToString(); }
            set
            {
                if (cboTrangThai.Items.Contains(value))
                {
                    cboTrangThai.SelectedItem = value;
                }
            }
        }
        public UC_ThongTinVaCaiDatMay()
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
            txtMaMay.ReadOnly = status;
            txtSoMay.ReadOnly = !status;
            //txtGia.ReadOnly = !status;
            cboLoaiMay.Enabled = status;
            cboTrangThai.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtMaMay.Text = "";
            txtSoMay.Text = "";
            txtGia.Text = "";
            cboLoaiMay.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }
        private void ThemXoaSuaClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetAllButtonDisableAndVisible();
            if (btn.Name == "btnThem")
            {
                checkAddComputer = true;
                btnThem.Enabled = true;
                ClearComboboxAndTextBox();
                SetEnableComboboxAndTextBox(true);
                txtMaMay.Text = ComputerBLL.Instance.GetRandomComputerId();
            }
            else if (btn.Name == "btnSua")
            {
                checkAddComputer = false;
                btnSua.Enabled = true;
                SetEnableComboboxAndTextBox(true);
                ClearComboboxAndTextBox();
            }
            else
            {
                checkAddComputer = false;
                btnXoa.Enabled = true;
                ClearComboboxAndTextBox();
            }
            lastButton = btn;
        }
        private void HuyOKClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn.Name == "btnOK")
            {
                if (CheckValid())
                {
                    if (lastButton.Name == "btnThem")
                    {
                        if (ComputerBLL.Instance.CheckComputerName(txtSoMay.Text))
                        {
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Số Máy Đã Tồn Tại" + Environment.NewLine + "Vui Lòng Thay Đổi Số Máy");
                            return;
                        }
                        AddComputer(new Computer
                        {
                            ComputerId = txtMaMay.Text,
                            ComputerName = txtSoMay.Text,
                            Status = cboTrangThai.Text,
                            TypeId = cboLoaiMay.SelectedValue as string,
                        });
                        int Online = ComputerBLL.Instance.GetComputerByStatus("Đang Hoạt Động").Count();
                        int All = ComputerBLL.Instance.GetListComputer().Count();
                        frmMain.myUC_QuanLyMay.lblCountOnline.Text = Online + "/" + All;
                    }
                    else if (lastButton.Name == "btnXoa")
                    {
                        DeleteComputer(txtMaMay.Text);
                        string[] Count = frmMain.myUC_QuanLyMay.lblCountOnline.Text.Split('/');
                        int Online = ComputerBLL.Instance.GetComputerByStatus("Đang Hoạt Động").Count();
                        int All = ComputerBLL.Instance.GetListComputer().Count();
                        frmMain.myUC_QuanLyMay.lblCountOnline.Text = Online + "/" + All;
                    }
                    else if (lastButton.Name == "btnSua")
                    {
                        EditComputer(new Computer
                        {
                            ComputerId = txtMaMay.Text,
                            ComputerName = txtSoMay.Text,
                            Status = cboTrangThai.Text,
                            TypeId = cboLoaiMay.SelectedValue as string,
                        });
                        string[] Count = frmMain.myUC_QuanLyMay.lblCountOnline.Text.Split('/');
                        int Online = ComputerBLL.Instance.GetComputerByStatus("Đang Hoạt Động").Count();
                        int All = ComputerBLL.Instance.GetListComputer().Count();
                        frmMain.myUC_QuanLyMay.lblCountOnline.Text = Online + "/" + All;
                    }
                    ClearComboboxAndTextBox();
                }
                else return;
            }
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
            checkAddComputer = false;
        }
        private bool CheckValid()
        {
            if (txtMaMay.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Máy Không Được Để Trống");
                return false;
            }
            else if (txtSoMay.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Số Máy Không Được Để Trống");
                return false;
            }
            else if ((txtGia.Text.Length < 7) || (txtGia.Text.Substring(txtGia.Text.Length - 7) != ".000VNĐ" && txtGia.Text.Substring(txtGia.Text.Length - 7) != ",000VNĐ"))
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Nhập Theo Định Dạng #,###.000VNĐ" + Environment.NewLine + "Ví Dụ: 20.000VNĐ / 1,000.000VNĐ");
                return false;
            }
            else if (cboLoaiMay.SelectedIndex == -1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Loại Máy Không Được Để Trống");
                return false;
            }
            else if (cboTrangThai.SelectedIndex == -1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Trạng Thái Không Được Để Trống");
                return false;
            }
            return true;
        }
        
        private void AddComputer(Computer computer)
        {
            try
            {
                ComputerBLL.Instance.AddNewComputer(computer);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thêm Máy Thành Công");
                frmMain.myUC_QuanLyMay.AddComputerOnPanel(computer);
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }

        private void DeleteComputer(string ComputerId)
        {
            try
            {
                ComputerBLL.Instance.DeleteComputer(ComputerId);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa Máy Thành Công");
                Guna2Button buttonComputer = frmMain.myUC_QuanLyMay.lastButtonComputer;
                buttonComputer.Visible = false;
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }

        private void EditComputer(Computer computer)
        {
            try
            {
                ComputerBLL.Instance.EditComputer(computer);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Chỉnh Sửa Máy Thành Công");
                Guna2Button buttonComputer = frmMain.myUC_QuanLyMay.lastButtonComputer;
                buttonComputer.Parent.Visible = false;
                frmMain.myUC_QuanLyMay.AddComputerOnPanel(computer);

            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }
        private void cboLoaiMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiMay.SelectedIndex == -1) return;
            string typeId = cboLoaiMay.SelectedValue as string;
            if (typeId == null) return;
            txtGia.Text = string.Format("{0:N3}VNĐ", TypeComputerBLL.Instance.GetTypeComputerByTypeComputerId(typeId).Price);
        }
    }
}
