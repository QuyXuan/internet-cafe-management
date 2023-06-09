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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_CaiDatChung : UserControl
    {
        private Guna2Button lastButtonCaiDat;
        private Guna2Button lastButton;
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
            btnThem.Checked = true;
            btnXoa.Checked = false;
            btnSua.Checked = false;
            btnHuy.Visible = false;
            btnOK.Visible = false;
        }
        private void ClearComboBoxAndTextBox()
        {
            txtMaLoaiMay.Text = "";
            cboTenLoaiMay.SelectedIndex = -1;
            txtGia.Text = "";
            txtMau.Text = "";
            txtMaMayTinh.Text = "";
            cboSoMay.SelectedIndex = -1;
            txtIPMay.Text = "";
            txtMaGiamGia.Text = "";
            cboTenGiamGia.SelectedIndex = -1;
            txtPhanTramGiamGia.Text = "";
            cboLoaiKhach.SelectedIndex = -1;
        }
        private void SetDisable()
        {
            txtMaLoaiMay.Enabled = false;
            cboTenLoaiMay.Enabled = false;
            txtGia.Enabled = false;
            txtMau.Enabled = false;
            btnChonMau.Enabled = false;
            txtMaMayTinh.Enabled = false;
            cboSoMay.Enabled = false;
            txtIPMay.Enabled = false;
            txtMaGiamGia.Enabled = false;
            cboTenGiamGia.Enabled = false;
            txtPhanTramGiamGia.Enabled = false;
            cboLoaiKhach.Enabled = false;
        }
        private void btnThemXoaSuaClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetAllButtonDisableAndVisible();
            if (btn.Name == "btnThem")
            {
                btnThem.Enabled = true;
                ClearComboBoxAndTextBox();
                if (lastButtonCaiDat == null)
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Chọn Chức Năng Trước");
                    return;
                }
                else if (lastButtonCaiDat.Name == "btnCaiDatLoaiMay")
                {
                    txtMaLoaiMay.Text = TypeComputerBLL.Instance.GetRandomTypeComputerId();
                    cboTenLoaiMay.DataSource = null;
                    txtGia.ReadOnly = false;
                    btnChonMau.Enabled = true;
                }
                else if (lastButtonCaiDat.Name == "btnCaiDatGiamGia")
                {
                    txtMaGiamGia.Text = DiscountBLL.Instance.GetRandomDiscountId();
                    cboTenGiamGia.DataSource = null;
                    txtPhanTramGiamGia.ReadOnly = false;
                }
                else if (lastButtonCaiDat.Name == "btnCaiDatIP")
                {
                    txtIPMay.ReadOnly = false;
                }
            }
            else if (btn.Name == "btnSua")
            {
                btnSua.Enabled = true;
                if (lastButtonCaiDat == null)
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Chọn Chức Năng Trước");
                    return;
                }
                else if (lastButtonCaiDat.Name == "btnCaiDatLoaiMay")
                {
                    txtGia.ReadOnly = false;
                    btnChonMau.Enabled = true;
                }
                else if (lastButtonCaiDat.Name == "btnCaiDatGiamGia")
                {
                    txtPhanTramGiamGia.ReadOnly = false;
                    cboLoaiKhach.Enabled = true;
                }
                else if (lastButtonCaiDat.Name == "btnCaiDatIP")
                {
                    txtIPMay.ReadOnly = false;
                }
                //ClearComboboxAndTextBox();
            }
            else
            {
                btnXoa.Enabled = true;
                if (lastButtonCaiDat == null)
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Chọn Chức Năng Trước");
                    return;
                }
            }
            lastButton = btn;
        }
        private bool CheckValidTypeComputer()
        {
            if (txtMaLoaiMay.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Loại Máy Không Được Để Trống");
                return false;
            }
            else if (cboTenLoaiMay.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Tên Loại Máy Không Được Để Trống");
                return false;
            }
            else if (int.TryParse(txtGia.Text, out _) == false)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Giá Không Hợp Lệ");
                return false;
            }
            else if (txtMau.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Màu Máy Không Được Để Trống" + Environment.NewLine + "Mã Màu Máy Không Được Trùng");
                return false;
            }
            return true;
        }
        private bool CheckValidIP()
        {
            if (txtMaMayTinh.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Máy Tính Không Được Để Trống");
                return false;
            }
            else if (cboSoMay.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Số Máy Không Được Để Trống");
                return false;
            }
            else if (txtIPMay.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "IP Máy Không Được Để Trống");
                return false;
            }
            return true;
        }
        private bool CheckValidDiscount()
        {
            if (txtMaGiamGia.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Giảm Giá Không Được Để Trống");
                return false;
            }
            else if (cboTenGiamGia.Text.Trim() == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Tên Giảm Giá Không Được Để Trống");
                return false;
            }
            else if (int.TryParse(txtPhanTramGiamGia.Text, out _) == false)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Phần Trăm Giảm Giá Không Hợp Lệ");
                return false;
            }
            else if (cboLoaiKhach.SelectedIndex == -1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Loại Khách Không Được Để Trống");
                return false;
            }
            return true;
        }
        private void btnHuyOKClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn.Name == "btnOK")
            {
                if (lastButton.Name == "btnThem")
                {
                    if (lastButtonCaiDat.Name == "btnCaiDatLoaiMay")
                    {
                        if (CheckValidTypeComputer())
                        {
                            if (TypeComputerBLL.Instance.CheckTypeComputerName(cboTenLoaiMay.Text.Trim()))
                            {
                                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Máy Đã Tồn Tại, Vui Lòng Đổi");
                                return;
                            }
                            if (TypeComputerBLL.Instance.CheckColorId(txtMau.Text))
                            {
                                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Màu Đã Tồn Tại, Vui Lòng Đổi");
                                return;
                            }
                            TypeComputerBLL.Instance.AddNewTypeComputer(new TypeComputer
                            {
                                TypeId = txtMaLoaiMay.Text,
                                ColorId = txtMau.Text,
                                NameType = cboTenLoaiMay.Text,
                                Price = (float)Convert.ToDouble(txtGia.Text),
                            });
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thêm Loại Máy Thành Công");
                        }
                    }
                    else if (lastButtonCaiDat.Name == "btnCaiDatIP")
                    {
                        if (CheckValidIP())
                        {
                            if (ComputerBLL.Instance.CheckIPByComputerName(cboSoMay.Text))
                            {
                                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Máy Này Đã Có IP, Không Thể Thêm");
                                return;
                            }
                            if (ComputerBLL.Instance.CheckIPComputer(txtIPMay.Text.Trim()))
                            {
                                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "IP Này Đã Tồn Tại, Không Thể Thêm");
                                return;
                            }
                            ComputerBLL.Instance.AddIPComputer(txtMaMayTinh.Text.Trim(), txtIPMay.Text.Trim());
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thêm IP Thành Công");
                        }
                    }
                    else if (lastButtonCaiDat.Name == "btnCaiDatGiamGia")
                    {
                        if (CheckValidDiscount())
                        {
                            if (DiscountBLL.Instance.CheckDiscountName(cboTenGiamGia.Text.Trim()))
                            {
                                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Tên Giảm Giá Không Được Trùng");
                                return;
                            }
                            DiscountBLL.Instance.AddNewDiscount(new Discount
                            {
                                DiscountId = txtMaGiamGia.Text.Trim(),
                                DiscountName = cboTenGiamGia.Text.Trim(),
                                DiscountPercent = (float)Convert.ToDouble(txtPhanTramGiamGia.Text),
                                TypeCustomer = (cboLoaiKhach.SelectedIndex == 1)
                            });
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thêm Giảm Giá Thành Công");
                        }
                    }
                }
                else if (lastButton.Name == "btnSua")
                {
                    if (lastButtonCaiDat.Name == "btnCaiDatLoaiMay")
                    {
                        if (TypeComputerBLL.Instance.CheckColorIdToEdit(txtMaLoaiMay.Text.Trim(), txtMau.Text.Trim()))
                        {
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Màu Này Đã Tồn Tại, Vui Lòng Đổi");
                            return;
                        }
                        if (CheckValidTypeComputer())
                        {
                            TypeComputerBLL.Instance.EditTypeComputer(new TypeComputer
                            {
                                TypeId = txtMaLoaiMay.Text,
                                ColorId = txtMau.Text,
                                NameType = cboTenLoaiMay.Text,
                                Price = (float)Convert.ToDouble(txtGia.Text),
                            });
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Sửa Loại Máy Thành Công");
                        }
                    }
                    else if (lastButtonCaiDat.Name == "btnCaiDatIP")
                    {
                        if (CheckValidIP())
                        {
                            if (ComputerBLL.Instance.CheckIPComputer(txtIPMay.Text.Trim()))
                            {
                                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "IP Này Đã Tồn Tại, Vui Lòng Đổi");
                                return;
                            }
                            ComputerBLL.Instance.AddIPComputer(txtMaMayTinh.Text.Trim(), txtIPMay.Text.Trim());
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Sửa IP Thành Công");
                        }
                    }
                    else if (lastButtonCaiDat.Name == "btnCaiDatGiamGia")
                    {
                        if (CheckValidDiscount())
                        {
                            DiscountBLL.Instance.EditDiscount(new Discount
                            {
                                DiscountId = txtMaGiamGia.Text.Trim(),
                                DiscountName = cboTenGiamGia.Text.Trim(),
                                DiscountPercent = (float)Convert.ToDouble(txtPhanTramGiamGia.Text),
                                TypeCustomer = (cboLoaiKhach.SelectedIndex == 1)
                            });
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Sửa Giảm Giá Thành Công");
                        }
                    }
                }
                else
                {
                    if (lastButtonCaiDat.Name == "btnCaiDatLoaiMay")
                    {
                        if (TypeComputerBLL.Instance.CheckTypeIsUsing(txtMaLoaiMay.Text.Trim()))
                        {
                            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Loại Máy Này Đang Được Sử Dụng Không Thể Xóa Được");
                            return;
                        }
                        TypeComputerBLL.Instance.DeleteTypeComputer(txtMaLoaiMay.Text.Trim());
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa Loại Máy Thành Công");
                    }
                    else if (lastButtonCaiDat.Name == "btnCaiDatIP")
                    {
                        ComputerBLL.Instance.AddIPComputer(txtMaMayTinh.Text.Trim(), "");
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa IP Thành Công");
                    }
                    else if (lastButtonCaiDat.Name == "btnCaiDatGiamGia")
                    {
                        DiscountBLL.Instance.RemoveDiscount(txtMaGiamGia.Text.Trim());
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa Giảm Giá Thành Công");
                    }
                }
            }
            SetAllButtonEnableAndInvisible();
            SetDisable();
            SetData();
            //SetEnableComboboxAndTextBox(false);
        }
        private void SetEnableTypeComputer(bool status)
        {
            cboTenLoaiMay.Enabled = status;
            txtMaLoaiMay.Enabled = status;
            txtGia.Enabled = status;
            txtMau.Enabled = status;
            //btnChonMau.Enabled = status;
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
            lastButtonCaiDat = button;
        }

        private void btnChonMau_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    txtMau.Text = ColorTranslator.ToHtml(colorDialog.Color);
                }
            }
        }

        private void cboTenLoaiMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenLoaiMay.SelectedIndex == -1) return;
            string typeComputerId = cboTenLoaiMay.SelectedValue as string;
            TypeComputer typeComputer = TypeComputerBLL.Instance.GetTypeComputerByTypeComputerId(typeComputerId);
            if (typeComputer == null) return;
            txtMaLoaiMay.Text = typeComputerId;
            txtGia.Text = string.Format("{0:N3}VNĐ", typeComputer.Price);
            txtMau.Text = typeComputer.ColorId;
        }

        private void cboSoMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoMay.SelectedIndex == -1) return;
            string computerId = cboSoMay.SelectedValue as string;
            Computer computer = ComputerBLL.Instance.GetComputerByID(computerId);
            if (computer == null) return;
            txtMaMayTinh.Text = computerId;
            txtIPMay.Text = computer.IPComputer;
        }

        private void cboTenGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenGiamGia.SelectedIndex == -1) return;
            string discountId = cboTenGiamGia.SelectedValue as string;
            Discount discount = DiscountBLL.Instance.GetDiscountByDiscountId(discountId);
            if (discount == null) return;
            txtMaGiamGia.Text = discountId;
            txtPhanTramGiamGia.Text = discount.DiscountPercent + " %";
            if (discount.TypeCustomer == true)
            {
                cboLoaiKhach.SelectedIndex = 1;
            }
            else
            {
                cboLoaiKhach.SelectedIndex = 0;
            }
        }
    }
}
