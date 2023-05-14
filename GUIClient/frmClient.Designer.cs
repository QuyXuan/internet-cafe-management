namespace GUIClient
{
    partial class frmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBackGround = new System.Windows.Forms.Panel();
            this.lblLoaiKhachHang = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTat = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblSoDu = new System.Windows.Forms.Label();
            this.btnMinisize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDanhSachHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNapGioChoi = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnTrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.imgbtnThoat = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panelDongHo = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.panelSideBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackGround
            // 
            this.panelBackGround.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackGround.Location = new System.Drawing.Point(283, 98);
            this.panelBackGround.Name = "panelBackGround";
            this.panelBackGround.Size = new System.Drawing.Size(1179, 697);
            this.panelBackGround.TabIndex = 9;
            // 
            // lblLoaiKhachHang
            // 
            this.lblLoaiKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoaiKhachHang.AutoSize = true;
            this.lblLoaiKhachHang.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiKhachHang.Location = new System.Drawing.Point(941, 37);
            this.lblLoaiKhachHang.Name = "lblLoaiKhachHang";
            this.lblLoaiKhachHang.Size = new System.Drawing.Size(88, 17);
            this.lblLoaiKhachHang.TabIndex = 4;
            this.lblLoaiKhachHang.Text = "Khách Hàng";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Location = new System.Drawing.Point(940, 9);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(37, 19);
            this.lblTenKhachHang.TabIndex = 4;
            this.lblTenKhachHang.Text = "Ten";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnTat);
            this.panel3.Controls.Add(this.lblSoDu);
            this.panel3.Controls.Add(this.btnMinisize);
            this.panel3.Controls.Add(this.lblLoaiKhachHang);
            this.panel3.Controls.Add(this.lblTenKhachHang);
            this.panel3.Controls.Add(this.guna2CirclePictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(283, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1179, 98);
            this.panel3.TabIndex = 8;
            // 
            // btnTat
            // 
            this.btnTat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTat.IconColor = System.Drawing.Color.White;
            this.btnTat.Location = new System.Drawing.Point(1028, 0);
            this.btnTat.Name = "btnTat";
            this.btnTat.Size = new System.Drawing.Size(75, 23);
            this.btnTat.TabIndex = 8;
            this.btnTat.Visible = false;
            this.btnTat.Click += new System.EventHandler(this.btnTat_Click);
            // 
            // lblSoDu
            // 
            this.lblSoDu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoDu.AutoSize = true;
            this.lblSoDu.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDu.Location = new System.Drawing.Point(940, 65);
            this.lblSoDu.Name = "lblSoDu";
            this.lblSoDu.Size = new System.Drawing.Size(53, 19);
            this.lblSoDu.TabIndex = 7;
            this.lblSoDu.Text = "Số dư";
            // 
            // btnMinisize
            // 
            this.btnMinisize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinisize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinisize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinisize.FillColor = System.Drawing.Color.Gray;
            this.btnMinisize.IconColor = System.Drawing.Color.White;
            this.btnMinisize.Location = new System.Drawing.Point(1099, 0);
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Size = new System.Drawing.Size(80, 23);
            this.btnMinisize.TabIndex = 6;
            this.btnMinisize.Click += new System.EventHandler(this.btnMinisize_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CirclePictureBox1.Image = global::GUIClient.Properties.Resources.avatar;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(870, 20);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(64, 64);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // panelSideBar
            // 
            this.panelSideBar.AutoScroll = true;
            this.panelSideBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelSideBar.Controls.Add(this.panel2);
            this.panelSideBar.Controls.Add(this.panel6);
            this.panelSideBar.Controls.Add(this.panel1);
            this.panelSideBar.Controls.Add(this.panel5);
            this.panelSideBar.Controls.Add(this.imgbtnThoat);
            this.panelSideBar.Controls.Add(this.panelDongHo);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(283, 795);
            this.panelSideBar.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDanhSachHoaDon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 233);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 45);
            this.panel2.TabIndex = 13;
            // 
            // btnDanhSachHoaDon
            // 
            this.btnDanhSachHoaDon.BorderRadius = 15;
            this.btnDanhSachHoaDon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDanhSachHoaDon.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(208)))));
            this.btnDanhSachHoaDon.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachHoaDon.CheckedState.Image = global::GUIClient.Properties.Resources.icons8_chart_arrow_rise_30__1_;
            this.btnDanhSachHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDanhSachHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDanhSachHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDanhSachHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDanhSachHoaDon.FillColor = System.Drawing.SystemColors.Control;
            this.btnDanhSachHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhSachHoaDon.ForeColor = System.Drawing.Color.Black;
            this.btnDanhSachHoaDon.Image = global::GUIClient.Properties.Resources.icons8_bill_351;
            this.btnDanhSachHoaDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDanhSachHoaDon.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDanhSachHoaDon.Location = new System.Drawing.Point(12, 0);
            this.btnDanhSachHoaDon.Name = "btnDanhSachHoaDon";
            this.btnDanhSachHoaDon.Size = new System.Drawing.Size(254, 45);
            this.btnDanhSachHoaDon.TabIndex = 6;
            this.btnDanhSachHoaDon.Text = "Danh Sách Hóa Đơn";
            this.btnDanhSachHoaDon.Click += new System.EventHandler(this.btnDanhSachHoaDon_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnNapGioChoi);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 188);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(283, 45);
            this.panel6.TabIndex = 12;
            // 
            // btnNapGioChoi
            // 
            this.btnNapGioChoi.BorderRadius = 15;
            this.btnNapGioChoi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNapGioChoi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(208)))));
            this.btnNapGioChoi.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnNapGioChoi.CheckedState.Image = global::GUIClient.Properties.Resources.icons8_chart_arrow_rise_30__1_;
            this.btnNapGioChoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNapGioChoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNapGioChoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNapGioChoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNapGioChoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNapGioChoi.FillColor = System.Drawing.SystemColors.Control;
            this.btnNapGioChoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNapGioChoi.ForeColor = System.Drawing.Color.Black;
            this.btnNapGioChoi.Image = global::GUIClient.Properties.Resources.icons8_chart_arrow_rise_30;
            this.btnNapGioChoi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNapGioChoi.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNapGioChoi.Location = new System.Drawing.Point(12, 0);
            this.btnNapGioChoi.Name = "btnNapGioChoi";
            this.btnNapGioChoi.Size = new System.Drawing.Size(254, 45);
            this.btnNapGioChoi.TabIndex = 6;
            this.btnNapGioChoi.Text = "Nạp Giờ Chơi";
            this.btnNapGioChoi.Click += new System.EventHandler(this.btnNapGioChoi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 45);
            this.panel1.TabIndex = 7;
            // 
            // btnMenu
            // 
            this.btnMenu.BorderRadius = 15;
            this.btnMenu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(208)))));
            this.btnMenu.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnMenu.CheckedState.Image = global::GUIClient.Properties.Resources.icons8_bill_35__1_;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenu.FillColor = System.Drawing.SystemColors.Control;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.Black;
            this.btnMenu.Image = global::GUIClient.Properties.Resources.icons8_bill_35;
            this.btnMenu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenu.ImageSize = new System.Drawing.Size(30, 30);
            this.btnMenu.Location = new System.Drawing.Point(12, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(254, 45);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnTrangChu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 98);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(283, 45);
            this.panel5.TabIndex = 4;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BorderRadius = 15;
            this.btnTrangChu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTrangChu.Checked = true;
            this.btnTrangChu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(208)))));
            this.btnTrangChu.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.CheckedState.Image = global::GUIClient.Properties.Resources.icons8_home_page_30__2_;
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTrangChu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTrangChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTrangChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTrangChu.FillColor = System.Drawing.SystemColors.Control;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTrangChu.ForeColor = System.Drawing.Color.Black;
            this.btnTrangChu.Image = global::GUIClient.Properties.Resources.icons8_home_page_30__1_;
            this.btnTrangChu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTrangChu.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTrangChu.Location = new System.Drawing.Point(12, 0);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(254, 45);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // imgbtnThoat
            // 
            this.imgbtnThoat.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.imgbtnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgbtnThoat.HoverState.Image = global::GUIClient.Properties.Resources.icons8_log_out_40;
            this.imgbtnThoat.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.imgbtnThoat.Image = global::GUIClient.Properties.Resources.icons8_logout_40;
            this.imgbtnThoat.ImageOffset = new System.Drawing.Point(0, 0);
            this.imgbtnThoat.ImageRotate = 0F;
            this.imgbtnThoat.Location = new System.Drawing.Point(12, 737);
            this.imgbtnThoat.Name = "imgbtnThoat";
            this.imgbtnThoat.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.imgbtnThoat.Size = new System.Drawing.Size(74, 56);
            this.imgbtnThoat.TabIndex = 3;
            this.imgbtnThoat.Click += new System.EventHandler(this.imgbtnThoat_Click);
            // 
            // panelDongHo
            // 
            this.panelDongHo.BackColor = System.Drawing.SystemColors.Control;
            this.panelDongHo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDongHo.Location = new System.Drawing.Point(0, 0);
            this.panelDongHo.Name = "panelDongHo";
            this.panelDongHo.Size = new System.Drawing.Size(283, 98);
            this.panelDongHo.TabIndex = 2;
            // 
            // frmClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1462, 795);
            this.Controls.Add(this.panelBackGround);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelSideBar);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClient";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.panelSideBar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBackGround;
        private System.Windows.Forms.Label lblLoaiKhachHang;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinisize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Panel panelSideBar;
        private Guna.UI2.WinForms.Guna2ImageButton imgbtnThoat;
        private Guna.UI2.WinForms.Guna2ControlBox btnTat;
        private System.Windows.Forms.Panel panel6;
        private Guna.UI2.WinForms.Guna2Button btnNapGioChoi;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI2.WinForms.Guna2Button btnTrangChu;
        private System.Windows.Forms.Panel panelDongHo;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnDanhSachHoaDon;
        private System.Windows.Forms.Label lblSoDu;
    }
}

