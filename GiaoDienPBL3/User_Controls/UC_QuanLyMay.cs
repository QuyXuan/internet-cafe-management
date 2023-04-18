using BLL;
using DTO;
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
        private Dictionary<string, Color> COLOR;
        public UC_QuanLyMay()
        {
            InitializeComponent();
<<<<<<< HEAD
            my_UC = new UC_ThongTinVaCaiDatMay();
            AddMauSac();
        }
        private void AddMauSac()
        {
            COLOR = new Dictionary<string, Color>();
            COLOR.Add("Red", Color.Red);
            COLOR.Add("Purple", Color.FromArgb(107, 13, 179));
            COLOR.Add("BrightBlue", Color.FromArgb(77, 167, 236));
            COLOR.Add("Brown", Color.FromArgb(128, 64, 0));
            COLOR.Add("Yellow", Color.FromArgb(211, 240, 17));
            COLOR.Add("BrightYellow", Color.FromArgb(185, 192, 138));
            COLOR.Add("Green", Color.FromArgb(17, 240, 55));
            COLOR.Add("Black", Color.Black);
            COLOR.Add("Pink", Color.FromArgb(225, 33, 246));
            COLOR.Add("Blue", Color.Blue);
        }
        private void AddMay(May may)
        {
            Guna2Button button = new Guna2Button();
            button.Size = new Size(60, 60);
            button.FillColor = Color.Gray;
            button.BorderColor = Color.Transparent;
            button.BorderRadius = 8;
            button.BorderThickness = 3;
            button.Margin = new Padding(10, 10, 10, 10);
            button.Text = may.SoMay;
            if (may.LoaiMay == "Khách")
                button.BorderColor = COLOR["Purple"];
            else if (may.LoaiMay == "Khách Thường Xuyên")
                button.BorderColor = COLOR["BrightBlue"];
            else if (may.LoaiMay == "Administrator")
                button.BorderColor = COLOR["Brown"];
            else if (may.LoaiMay == "Nhân Viên")
                button.BorderColor = COLOR["Yellow"];
            else if (may.LoaiMay == "Học Sinh")
                button.BorderColor = COLOR["BrightYellow"];
            else if (may.LoaiMay == "Online")
                button.BorderColor = COLOR["Green"];
            else if (may.LoaiMay == "Offline")
                button.BorderColor = COLOR["Black"];
            else if (may.LoaiMay == "Trả Sau")
                button.BorderColor = COLOR["Pink"];
            if (may.TrangThai == "Còn 5 Phút")
                button.FillColor = COLOR["Red"];
            else if (may.TrangThai == "Bảo Trì")
                button.FillColor = COLOR["Blue"];
            button.Tag = may;
            frmMain.myUC_QuanLyMay.panelQuanLyMay.Controls.Add(button);
=======
>>>>>>> parent of 792afe9 (11:14 pm 3/25/2023 quy changed)
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

        private void UC_QuanLyMay_Load(object sender, EventArgs e)
        {
            foreach (May item in BLLMay.Instance.GetListMay())
            {
                AddMay(item);
            }
        }
    }
}
