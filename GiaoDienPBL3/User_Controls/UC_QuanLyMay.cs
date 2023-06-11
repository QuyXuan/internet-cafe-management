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
        public Guna2Button lastButtonComputer = null;
        public List<Guna2Button> listComputerOnPanel = new List<Guna2Button>();
        public UC_QuanLyMay()
        {
            InitializeComponent();
            my_UCThongTinVaCaiDatMay = new UC_ThongTinVaCaiDatMay();
            my_UCChiTietMay = new UC_ChiTietMay();
            AddUC();
            AddTypeComputer();
        }

        private Color ConvertToArgb(string HEXColor)
        {
            Color color = ColorTranslator.FromHtml(HEXColor);
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            return Color.FromArgb(red, green, blue);
        }
        private void AddTypeComputer()
        {
            List<TypeComputer> listTypeComputer = TypeComputerBLL.Instance.GetListTypeComputer();
            foreach (TypeComputer typeComputer in listTypeComputer)
            {
                UC_LoaiMay myUC_LoaiMay = new UC_LoaiMay();
                myUC_LoaiMay.ColorLoaiMay = ConvertToArgb(typeComputer.ColorId);
                myUC_LoaiMay.TextLoaiMay = typeComputer.NameType;
                panelLoaiMay.Controls.Add(myUC_LoaiMay);
            }
            my_UCThongTinVaCaiDatMay.cboLoaiMay.DataSource = listTypeComputer;
            my_UCThongTinVaCaiDatMay.cboLoaiMay.DisplayMember = "NameType";
            my_UCThongTinVaCaiDatMay.cboLoaiMay.ValueMember = "TypeId";
        }
        public void AddComputerOnPanel(Computer computer)
        {
            //Panel panelTemp = new Panel();
            //panelTemp.Size = new Size(60, 60);
            //panelTemp.Padding = new Padding(10, 10, 10, 10);
            Guna2Button button = new Guna2Button();
            button.Size = new Size(50, 50);
            button.BorderColor = Color.Transparent;
            button.BorderRadius = 8;
            button.BorderThickness = 3;
            button.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            button.Text = computer.ComputerName;
            button.Cursor = Cursors.Hand;
            button.Margin = new Padding(10, 10, 10, 10);
            //button.ButtonMode = ButtonMode.RadioButton;
            Color color = ConvertToArgb(TypeComputerBLL.Instance.GetColoIdByTypeId(computer.TypeId));
            button.BorderColor = color;
            if (computer.Status == "Bảo Trì")
            {
                button.FillColor = Color.Blue;
                button.ForeColor = Color.Black;
            }
            else if (computer.Status == "Đã Tắt")
            {
                button.FillColor = Color.Black;
                button.ForeColor = Color.Wheat;
            }
            else if (computer.Status == "Đang Hoạt Động")
            {
                button.FillColor = Color.Pink;
                button.ForeColor = Color.Black;
            }
            button.Tag = computer;
            //panelTemp.Controls.Add(button);
            listComputerOnPanel.Add(button);
            //frmMain.myUC_QuanLyMay.panelQuanLyMay.Controls.Add(panelTemp);
            frmMain.myUC_QuanLyMay.panelQuanLyMay.Controls.Add(button);
            button.MouseEnter += new EventHandler(button_MouseEnter);
            button.MouseLeave += new EventHandler(button_MouseLeave);
            button.Click += new EventHandler(button_Click);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (UC_ThongTinVaCaiDatMay.checkAddComputer == true)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Không Thể Xem Thông Tin Máy Trong Lúc Thêm Máy");
                return;
            }
            Guna2Button button = sender as Guna2Button;
            Computer computer = (button.Tag) as Computer;
            TypeComputer typeComputer = TypeComputerBLL.Instance.GetTypeComputerByTypeComputerId(computer.TypeId);
            my_UCThongTinVaCaiDatMay.TextMaMay = computer.ComputerId;
            my_UCThongTinVaCaiDatMay.TextTenMay = computer.ComputerName;
            my_UCThongTinVaCaiDatMay.TextGia = string.Format("{0:N3}VNĐ", typeComputer.Price);
            //my_UCThongTinVaCaiDatMay.TextLoaiMay = typeComputer.NameType;
            my_UCThongTinVaCaiDatMay.cboLoaiMay.SelectedIndex = my_UCThongTinVaCaiDatMay.cboLoaiMay.FindStringExact(typeComputer.NameType);
            my_UCThongTinVaCaiDatMay.TextTrangThai = computer.Status;
            lastButtonComputer = button;
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            Computer computer = (button.Tag) as Computer;
            //Panel panelTemp = (button.Parent) as Panel;
            my_UCChiTietMay.TextMaMay = computer.ComputerId;
            my_UCChiTietMay.TextSoMay = computer.ComputerName;
            TypeComputer typeComputer = ComputerBLL.Instance.GetTypeComputerByTypeId(computer.TypeId);
            my_UCChiTietMay.TextLoaiMay = typeComputer.NameType;
            my_UCChiTietMay.TextGiaMay = string.Format("{0:N3}VNĐ", typeComputer.Price);
            my_UCChiTietMay.TextTrangThai = computer.Status;
            my_UCChiTietMay.TextNguoiDung = computer.AccountId;
            panelPhu.Controls.Add(my_UCChiTietMay);
            int locationX = button.Location.X + 50;
            int locationY = button.Location.Y + 50;
            if (button.Location.X + 50 + my_UCChiTietMay.Width > panelQuanLyMay.Width)
            {
                locationX = button.Location.X - my_UCChiTietMay.Width;
            }
            if (button.Location.Y + 50 + my_UCChiTietMay.Height > panelQuanLyMay.Height)
            {
                locationY = button.Location.Y - my_UCChiTietMay.Height;
            }
            my_UCChiTietMay.Location = new Point(locationX, locationY);
            my_UCChiTietMay.BringToFront();
            my_UCChiTietMay.Visible = true;
            //panelTemp.Padding = new Padding(0, 0, 0, 0);
            //button.Dock = DockStyle.Fill;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            //Guna2Button button = sender as Guna2Button;
            //Panel panelTemp = button.Parent as Panel;
            //panelTemp.Padding = new Padding(10, 10, 10, 10);
            //button.Dock = DockStyle.None;
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
            AddComputerOnPanel();
        }
        private void AddComputerOnPanel()
        {
            List<Computer> listComputer = ComputerBLL.Instance.GetListComputer();
            foreach (Computer computer in listComputer)
            {
                if (computer.ComputerId == "mt0031") continue;
                AddComputerOnPanel(computer);
            }
            int Online = ComputerBLL.Instance.GetComputerByStatus("Đang Hoạt Động").Count();
            int All = ComputerBLL.Instance.GetListComputer().Count() - 1;
            lblCountOnline.Text = Online + "/" + All;
        }
        private void msLamMoiDanhSachMay_Click(object sender, EventArgs e)
        {
            msLamMoiDanhSachMay.Enabled = false;
            panelQuanLyMay.Controls.Clear();
            foreach (Guna2Button button in listComputerOnPanel)
            {
                panelQuanLyMay.Controls.Remove(button);
                button.Dispose();
            }
            AddComputerOnPanel();
            msLamMoiDanhSachMay.Enabled = true;
        }
    }
}
