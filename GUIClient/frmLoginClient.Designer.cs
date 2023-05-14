namespace GUIClient
{
    partial class frmLoginClient
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
            this.components = new System.ComponentModel.Container();
            this.panelDangNhap = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnThoat = new Guna.UI2.WinForms.Guna2ControlBox();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.chkHienThiMatKhau = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnDangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDangNhap
            // 
            this.panelDangNhap.Controls.Add(this.btnThoat);
            this.panelDangNhap.Controls.Add(this.txtMatKhau);
            this.panelDangNhap.Controls.Add(this.txtTaiKhoan);
            this.panelDangNhap.Controls.Add(this.lblThongBao);
            this.panelDangNhap.Controls.Add(this.chkHienThiMatKhau);
            this.panelDangNhap.Controls.Add(this.btnDangNhap);
            this.panelDangNhap.Controls.Add(this.pictureBox1);
            this.panelDangNhap.Controls.Add(this.label1);
            this.panelDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDangNhap.FillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelDangNhap.FillColor2 = System.Drawing.Color.Cyan;
            this.panelDangNhap.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelDangNhap.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelDangNhap.Location = new System.Drawing.Point(0, 0);
            this.panelDangNhap.Name = "panelDangNhap";
            this.panelDangNhap.Size = new System.Drawing.Size(545, 461);
            this.panelDangNhap.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThoat.IconColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(493, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(52, 28);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Visible = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.txtMatKhau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMatKhau.BorderRadius = 10;
            this.txtMatKhau.BorderThickness = 2;
            this.txtMatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatKhau.DefaultText = "";
            this.txtMatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMatKhau.ForeColor = System.Drawing.Color.Black;
            this.txtMatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhau.Location = new System.Drawing.Point(79, 295);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '\0';
            this.txtMatKhau.PlaceholderText = "Nhập Mật Khẩu";
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.Size = new System.Drawing.Size(386, 49);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.txtTaiKhoan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTaiKhoan.BorderRadius = 10;
            this.txtTaiKhoan.BorderThickness = 2;
            this.txtTaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaiKhoan.DefaultText = "";
            this.txtTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaiKhoan.ForeColor = System.Drawing.Color.Black;
            this.txtTaiKhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoan.Location = new System.Drawing.Point(79, 201);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.PasswordChar = '\0';
            this.txtTaiKhoan.PlaceholderText = "Nhập Tên Tài Khoản";
            this.txtTaiKhoan.SelectedText = "";
            this.txtTaiKhoan.Size = new System.Drawing.Size(386, 49);
            this.txtTaiKhoan.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblThongBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(115, 0);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(315, 66);
            this.lblThongBao.TabIndex = 6;
            this.lblThongBao.Text = "ThongBao";
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongBao.Visible = false;
            // 
            // chkHienThiMatKhau
            // 
            this.chkHienThiMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkHienThiMatKhau.AutoSize = true;
            this.chkHienThiMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.chkHienThiMatKhau.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkHienThiMatKhau.CheckedState.BorderRadius = 0;
            this.chkHienThiMatKhau.CheckedState.BorderThickness = 0;
            this.chkHienThiMatKhau.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkHienThiMatKhau.CheckMarkColor = System.Drawing.Color.Red;
            this.chkHienThiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkHienThiMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienThiMatKhau.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chkHienThiMatKhau.Location = new System.Drawing.Point(303, 350);
            this.chkHienThiMatKhau.Name = "chkHienThiMatKhau";
            this.chkHienThiMatKhau.Size = new System.Drawing.Size(174, 27);
            this.chkHienThiMatKhau.TabIndex = 2;
            this.chkHienThiMatKhau.Text = "Hiển Thị Mật Khẩu";
            this.chkHienThiMatKhau.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHienThiMatKhau.UncheckedState.BorderRadius = 0;
            this.chkHienThiMatKhau.UncheckedState.BorderThickness = 0;
            this.chkHienThiMatKhau.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHienThiMatKhau.UseVisualStyleBackColor = false;
            this.chkHienThiMatKhau.Click += new System.EventHandler(this.chkHienThiMatKhau_CheckedChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.BorderRadius = 20;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangNhap.FillColor = System.Drawing.Color.IndianRed;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(285, 400);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(180, 45);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GUIClient.Properties.Resources.icons8_react_60;
            this.pictureBox1.Location = new System.Drawing.Point(242, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(216, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng Nhập";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.lblThongBao;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            // 
            // frmLoginClient
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(545, 461);
            this.Controls.Add(this.panelDangNhap);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginClient";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoginClient";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelDangNhap.ResumeLayout(false);
            this.panelDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelDangNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblThongBao;
        private Guna.UI2.WinForms.Guna2CheckBox chkHienThiMatKhau;
        private Guna.UI2.WinForms.Guna2Button btnDangNhap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ControlBox btnThoat;
        private System.Windows.Forms.Timer timer1;
    }
}