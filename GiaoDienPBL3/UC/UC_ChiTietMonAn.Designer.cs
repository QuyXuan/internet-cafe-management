namespace GiaoDienPBL3.UC
{
    partial class UC_ChiTietMonAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblSoLuongMon = new System.Windows.Forms.Label();
            this.btnCongMon = new Guna.UI2.WinForms.Guna2Button();
            this.btnTruMon = new Guna.UI2.WinForms.Guna2Button();
            this.lblGiaMon = new System.Windows.Forms.Label();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GradientPanel1.Controls.Add(this.lblGiaMon);
            this.guna2GradientPanel1.Controls.Add(this.btnXoa);
            this.guna2GradientPanel1.Controls.Add(this.lblTenMon);
            this.guna2GradientPanel1.Controls.Add(this.lblSoLuongMon);
            this.guna2GradientPanel1.Controls.Add(this.btnCongMon);
            this.guna2GradientPanel1.Controls.Add(this.btnTruMon);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(484, 56);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // lblTenMon
            // 
            this.lblTenMon.BackColor = System.Drawing.Color.Transparent;
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(90, 0);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(350, 56);
            this.lblTenMon.TabIndex = 4;
            this.lblTenMon.Text = "TenMon";
            this.lblTenMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoLuongMon
            // 
            this.lblSoLuongMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblSoLuongMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoLuongMon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSoLuongMon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongMon.Location = new System.Drawing.Point(46, 0);
            this.lblSoLuongMon.Name = "lblSoLuongMon";
            this.lblSoLuongMon.Size = new System.Drawing.Size(44, 56);
            this.lblSoLuongMon.TabIndex = 2;
            this.lblSoLuongMon.Text = "1";
            this.lblSoLuongMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCongMon
            // 
            this.btnCongMon.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCongMon.BorderThickness = 2;
            this.btnCongMon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCongMon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCongMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCongMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCongMon.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCongMon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCongMon.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongMon.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnCongMon.Location = new System.Drawing.Point(440, 0);
            this.btnCongMon.Name = "btnCongMon";
            this.btnCongMon.Size = new System.Drawing.Size(44, 56);
            this.btnCongMon.TabIndex = 1;
            this.btnCongMon.Text = "+";
            this.btnCongMon.Click += new System.EventHandler(this.btnCongTruMon_Click);
            // 
            // btnTruMon
            // 
            this.btnTruMon.BorderColor = System.Drawing.Color.IndianRed;
            this.btnTruMon.BorderThickness = 2;
            this.btnTruMon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTruMon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTruMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTruMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTruMon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTruMon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnTruMon.Font = new System.Drawing.Font("Segoe UI", 19.8F);
            this.btnTruMon.ForeColor = System.Drawing.Color.Maroon;
            this.btnTruMon.Location = new System.Drawing.Point(0, 0);
            this.btnTruMon.Name = "btnTruMon";
            this.btnTruMon.Size = new System.Drawing.Size(46, 56);
            this.btnTruMon.TabIndex = 0;
            this.btnTruMon.Text = "-";
            this.btnTruMon.Click += new System.EventHandler(this.btnCongTruMon_Click);
            // 
            // lblGiaMon
            // 
            this.lblGiaMon.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaMon.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblGiaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaMon.Location = new System.Drawing.Point(292, 0);
            this.lblGiaMon.Name = "lblGiaMon";
            this.lblGiaMon.Size = new System.Drawing.Size(103, 56);
            this.lblGiaMon.TabIndex = 8;
            this.lblGiaMon.Text = "Gia";
            this.lblGiaMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnXoa
            // 
            this.btnXoa.BorderColor = System.Drawing.Color.IndianRed;
            this.btnXoa.BorderThickness = 2;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnXoa.Image = global::GiaoDienPBL3.Properties.Resources.Lovepik_com_450045211_Vector_Trash_Icon;
            this.btnXoa.Location = new System.Drawing.Point(395, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(45, 56);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Click += new System.EventHandler(this.btnCongTruMon_Click);
            // 
            // UC_ChiTietMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UC_ChiTietMonAn";
            this.Size = new System.Drawing.Size(484, 56);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label lblSoLuongMon;
        private Guna.UI2.WinForms.Guna2Button btnCongMon;
        private Guna.UI2.WinForms.Guna2Button btnTruMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblGiaMon;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
    }
}
