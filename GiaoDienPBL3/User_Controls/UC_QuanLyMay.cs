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
        public static UC_ThongTinVaCaiDatMay my_UCThongTinVaCaiDatMay;
        private UC_ChiTietMay my_UCChiTietMay;
        private bool checkBtnCaiDat = false;
        private Dictionary<string, Color> COLOR;
        public UC_QuanLyMay()
        {
            InitializeComponent();
            my_UCThongTinVaCaiDatMay = new UC_ThongTinVaCaiDatMay();
            my_UCChiTietMay = new UC_ChiTietMay();
            AddUC();
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
        private void AddMayOnPanel(Computer computer)
        {
            Guna2Button button = new Guna2Button();
            button.Size = new Size(60, 60);
            button.FillColor = Color.Gray;
            button.BorderColor = Color.Transparent;
            button.BorderRadius = 8;
            button.BorderThickness = 3;
            button.Margin = new Padding(10, 10, 10, 10);
            button.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            button.Text = computer.ComputerName;
            if (computer.NameType == "Khách")
                button.BorderColor = COLOR["Purple"];
            else if (computer.NameType == "Khách Thường Xuyên")
                button.BorderColor = COLOR["BrightBlue"];
            else if (computer.NameType == "Administrator")
                button.BorderColor = COLOR["Brown"];
            else if (computer.NameType == "Nhân Viên")
                button.BorderColor = COLOR["Yellow"];
            else if (computer.NameType == "Học Sinh/Sinh Viên")
                button.BorderColor = COLOR["BrightYellow"];
            else if (computer.NameType == "Online")
                button.BorderColor = COLOR["Green"];
            else if (computer.NameType == "Offline")
                button.BorderColor = COLOR["Black"];
            else if (computer.NameType == "Khách Trả Sau")
                button.BorderColor = COLOR["Pink"];
            if (computer.Status == "Còn 5 Phút")
                button.FillColor = COLOR["Red"];
            else if (computer.Status == "Bảo Trì")
                button.FillColor = COLOR["Blue"];
            button.Tag = computer;
            frmMain.myUC_QuanLyMay.panelQuanLyMay.Controls.Add(button);
            button.MouseEnter += new EventHandler(button_MouseEnter);
            button.MouseLeave += new EventHandler(button_MouseLeave);
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            my_UCChiTietMay.Visible = true;
            Guna2Button button = sender as Guna2Button;
            Computer computer = button.Tag as Computer;
            my_UCChiTietMay.TextMaMay = computer.ComputerId;
            my_UCChiTietMay.TextSoMay = computer.ComputerName;
            my_UCChiTietMay.TextGiaMay = string.Format("{0:N3}VNĐ", 10);
            my_UCChiTietMay.TextLoaiMay = computer.NameType;
            my_UCChiTietMay.TextTrangThai = computer.Status;
            panelPhu.Controls.Add(my_UCChiTietMay);
            my_UCChiTietMay.Location = new Point(button.Location.X + 60, button.Location.Y + 60);
            my_UCChiTietMay.BringToFront();
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            my_UCChiTietMay.Visible = false;
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            if (checkBtnCaiDat == false)
            {
                panelChiTietQuanLyMay.SendToBack();
                checkBtnCaiDat = true;
            }
            else
            {
                panelChiTietQuanLyMay.BringToFront();
                checkBtnCaiDat = false;
            }
        }
        private void AddUC()
        {
            panelThongTin.Controls.Add(my_UCThongTinVaCaiDatMay);
            panelChiTietQuanLyMay.BringToFront();
            my_UCThongTinVaCaiDatMay.Dock = DockStyle.Fill;
        }
        private void UC_QuanLyMay_Load(object sender, EventArgs e)
        {
            foreach (Computer computer in ComputerBLL.Instance.GetListComputer())
            {
                AddMayOnPanel(computer);
            }
        }

    }
}
