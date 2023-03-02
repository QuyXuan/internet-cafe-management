using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyMenu : UserControl
    {
        public UC_QuanLyMenu()
        {
            InitializeComponent();
        }

        private void UC_QuanLyMenu_Load(object sender, EventArgs e)
        {
            //SetScrollBarMonAn();
        }

        //private void SetScrollBarMonAn()
        //{
        //    // Gán sự kiện Scroll cho thanh cuộn
        //    scrollBarMonAn.Maximum = panelMonAn.Height;
        //    scrollBarMonAn.Scroll += new ScrollEventHandler(ScrollBarControl);
        //}

        //private void ScrollBarControl(object sender, ScrollEventArgs e)
        //{
        //    // Thay đổi vị trí của Panel dựa trên giá trị của thanh cuộn
        //    panelMonAn.Location = new Point(panelMonAn.Location.X, -e.NewValue);
        //}

        private void btnAnhMonAn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Cấu hình để hiển thị chi tiết các tập tin ảnh
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            // Mở hộp thoại FileDialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Kiểm tra xem người dùng đã chọn một tập tin ảnh hợp lệ chưa
                if (openFileDialog1.CheckFileExists)
                {
                    // Tải ảnh được chọn vào chương trình của bạn
                    Image img = Image.FromFile(openFileDialog1.FileName);
                    //
                }
            }
        }
    }
}
