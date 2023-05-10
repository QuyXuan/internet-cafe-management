using BLL;
using DTO;
using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
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
        private int CountOnline = 0;
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
            COLOR.Add("Purple", Color.FromArgb(107, 13, 179));//
            COLOR.Add("BrightBlue", Color.FromArgb(77, 167, 236));//
            COLOR.Add("Brown", Color.FromArgb(128, 64, 0));//
            COLOR.Add("Yellow", Color.FromArgb(211, 240, 17));//
            COLOR.Add("BrightYellow", Color.FromArgb(185, 192, 138));//
            COLOR.Add("Green", Color.FromArgb(17, 240, 55));
            COLOR.Add("Black", Color.Black);
            COLOR.Add("Pink", Color.FromArgb(225, 33, 246));
            COLOR.Add("Blue", Color.Blue);
        }
        private void AddComputerOnPanel(Computer computer)
        {
            Panel panelTemp = new Panel();
            panelTemp.Size = new Size(60, 60);
            panelTemp.Padding = new Padding(10, 10, 10, 10);
            Guna2Button button = new Guna2Button();
            button.Size = new Size(50, 50);
            button.BorderColor = Color.Transparent;
            button.BorderRadius = 8;
            button.BorderThickness = 3;
            //button.Margin = new Padding(10, 10, 10, 10);
            button.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            button.Text = computer.ComputerName;
            button.Cursor = Cursors.Hand;
            button.ButtonMode = ButtonMode.RadioButton;
            if (computer.TypeId == "type0001")
                button.BorderColor = COLOR["Purple"];
            else if (computer.TypeId == "type0002")
                button.BorderColor = COLOR["BrightBlue"];
            else if (computer.TypeId == "type0003")
                button.BorderColor = COLOR["Brown"];
            else if (computer.TypeId == "type0004")
                button.BorderColor = COLOR["Yellow"];
            else if (computer.TypeId == "type0005")
                button.BorderColor = COLOR["BrightYellow"];
            else if (computer.TypeId == "type0006")
                button.BorderColor = COLOR["Green"];
            if (computer.Status == "Bảo Trì")
            {
                button.FillColor = COLOR["Blue"];
                button.ForeColor = COLOR["Black"];
            }
            else if (computer.Status == "Đã Tắt")
            {
                button.FillColor = COLOR["Black"];
                button.ForeColor = Color.Wheat;
            }
            else if (computer.Status == "Đang Hoạt Động")
            {
                button.FillColor = COLOR["Pink"];
                button.ForeColor = COLOR["Black"];
                CountOnline++;
            }
            button.Tag = computer;
            panelTemp.Controls.Add(button);
            frmMain.myUC_QuanLyMay.panelQuanLyMay.Controls.Add(panelTemp);
            button.MouseEnter += new EventHandler(button_MouseEnter);
            button.MouseLeave += new EventHandler(button_MouseLeave);
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            Computer computer = (button.Tag) as Computer;
            Panel panelTemp = (button.Parent) as Panel;
            my_UCChiTietMay.TextMaMay = computer.ComputerId;
            my_UCChiTietMay.TextSoMay = computer.ComputerName;
            my_UCChiTietMay.TextGiaMay = string.Format("{0:N3}VNĐ", 10);
            my_UCChiTietMay.TextLoaiMay = ComputerBLL.Instance.GetTypeComputerByTypeId(computer.TypeId).NameType;
            my_UCChiTietMay.TextTrangThai = computer.Status;
            panelPhu.Controls.Add(my_UCChiTietMay);
            int locationX = panelTemp.Location.X + 50;
            int locationY = panelTemp.Location.Y + 50;
            if (panelTemp.Location.X + 50 + my_UCChiTietMay.Width > panelQuanLyMay.Width)
            {
                locationX = panelTemp.Location.X - my_UCChiTietMay.Width;
            }
            if (panelTemp.Location.Y + 50 + my_UCChiTietMay.Height > panelQuanLyMay.Height)
            {
                locationY = panelTemp.Location.Y - my_UCChiTietMay.Height;
            }
            my_UCChiTietMay.Location = new Point(locationX, locationY);
            my_UCChiTietMay.BringToFront();
            my_UCChiTietMay.Visible = true;
            panelTemp.Padding = new Padding(0, 0, 0, 0);
            button.Dock = DockStyle.Fill;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            Panel panelTemp = button.Parent as Panel;
            panelTemp.Padding = new Padding(10, 10, 10, 10);
            button.Dock = DockStyle.None;
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
            List<Computer> listComputer = ComputerBLL.Instance.GetListComputer();
            foreach (Computer computer in listComputer)
            {
                AddComputerOnPanel(computer);
            }
            lblCountOnline.Text = CountOnline + "/" + listComputer.Count();
        }

    }
}
