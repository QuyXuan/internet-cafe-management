using BLL;
using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
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

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_ThongTinVaCaiDatMonAn : UserControl
    {
        public string TextGia
        {
            get { return txtGia.Text.Trim(); }
            set { txtGia.Text = value; }
        }
        public UC_ThongTinVaCaiDatMonAn()
        {
            InitializeComponent();
        }
        //private Image GetAnhByPathAnhMon(string path)
        //{
        //    try
        //    {
        //        Image image = Image.FromFile(path);
        //        return image;
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return null;
        //    }
        //}
        private string GetPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn Ảnh";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                return filePath;
            }
            return null;
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                txtPath.Text = GetPath();
                if (txtPath.Text == String.Empty)
                {
                    txtPath.Text = "Đường Dẫn Không Hợp Lệ";
                }
            }
            catch (Exception)
            {
                txtPath.Text = "Đường Dẫn Không Hợp Lệ";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtGia.ReadOnly = true;
            txtGia.Text = "";
            txtPath.Text = "";
            txtMaMonAn.Text = "";
            frmMain.myUC_QuanLyMenu.panelCaiDatVaThongTin.BringToFront();
        }

        private void btnThemGiaMon_Click(object sender, EventArgs e)
        {
            txtGia.ReadOnly = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValid())
                {
                    UC_MonAn myUC_MonAn = (frmMain.myUC_QuanLyMenu.lblTitle.Tag) as UC_MonAn;
                    byte[] bytes = new byte[1000000];
                    if (txtGia.Text == "")
                    {
                        bytes = ProductBLL.Instance.GetImageByFilePath(ProductBLL.Instance.ConvertToFilePath(SplitFilePath(txtPath.Text)));
                        ProductBLL.Instance.UpdateProductWithPriceAndPath(txtMaMonAn.Text, bytes);
                        myUC_MonAn.ImagePanel = ByteArrayToImage(bytes);
                    }
                    else if (txtPath.Text == "")
                    {
                        float Gia = (float)Convert.ToDouble(txtGia.Text);
                        ProductBLL.Instance.UpdateProductWithPriceAndPath(txtMaMonAn.Text, null, Gia);
                        myUC_MonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", Gia);
                    }
                    else
                    {
                        float Gia = (float)Convert.ToDouble(txtGia.Text);
                        bytes = ProductBLL.Instance.GetImageByFilePath(ProductBLL.Instance.ConvertToFilePath(SplitFilePath(txtPath.Text)));
                        ProductBLL.Instance.UpdateProductWithPriceAndPath(txtMaMonAn.Text, bytes, Gia);
                        myUC_MonAn.ImagePanel = ByteArrayToImage(bytes);
                        myUC_MonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", Gia);
                    }
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Chỉnh Sửa Thành Công");
                    btnHuy.PerformClick();
                }
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi, Chỉnh Sửa Thất Bại");
                return;
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            Image image = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArray);
                image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                return null;
            }
            return image;
        }

        private string SplitFilePath(string path)
        {
            string[] strings = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            return strings[strings.Length - 1];
        }
        private bool CheckValid()
        {
            if (txtGia.Text != "" && float.TryParse(txtGia.Text, out _) == false)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Giá Phải Là Một Số Nguyên");
                return false;
            }
            if (txtPath.Text == "Đường Dẫn Không Hợp Lệ")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Đường Dẫn Không Hợp Lệ");
                return false;
            }
            if (txtPath.Text == "" && txtGia.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Có Gì Để Thay Đổi");
                return false;
            }
            return true;
        }
    }
}