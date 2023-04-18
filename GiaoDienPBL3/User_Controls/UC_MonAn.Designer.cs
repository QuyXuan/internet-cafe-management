namespace GiaoDienPBL3.UC
{
    partial class UC_MonAn
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
            this.panelBackGroundMonAn = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.msStatusMonAn = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.msDaHetMon = new System.Windows.Forms.ToolStripMenuItem();
            this.msDaCoMon = new System.Windows.Forms.ToolStripMenuItem();
            this.picMonAn = new System.Windows.Forms.PictureBox();
            this.lblTenMonAn = new System.Windows.Forms.Label();
            this.panelTenMonAn = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblGiaMonAn = new System.Windows.Forms.Label();
            this.panelGiaMonAn = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelBackGroundMonAn.SuspendLayout();
            this.msStatusMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonAn)).BeginInit();
            this.panelTenMonAn.SuspendLayout();
            this.panelGiaMonAn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackGroundMonAn
            // 
            this.panelBackGroundMonAn.BackColor = System.Drawing.Color.Transparent;
            this.panelBackGroundMonAn.Controls.Add(this.panelTenMonAn);
            this.panelBackGroundMonAn.Controls.Add(this.panelGiaMonAn);
            this.panelBackGroundMonAn.Controls.Add(this.picMonAn);
            this.panelBackGroundMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackGroundMonAn.FillColor = System.Drawing.Color.White;
            this.panelBackGroundMonAn.Location = new System.Drawing.Point(0, 0);
            this.panelBackGroundMonAn.Name = "panelBackGroundMonAn";
            this.panelBackGroundMonAn.Padding = new System.Windows.Forms.Padding(3);
            this.panelBackGroundMonAn.ShadowColor = System.Drawing.Color.Black;
            this.panelBackGroundMonAn.Size = new System.Drawing.Size(165, 165);
            this.panelBackGroundMonAn.TabIndex = 0;
            // 
            // msStatusMonAn
            // 
            this.msStatusMonAn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msStatusMonAn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msStatusMonAn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msDaHetMon,
            this.msDaCoMon});
            this.msStatusMonAn.Name = "msStatusMonAn";
            this.msStatusMonAn.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.msStatusMonAn.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.msStatusMonAn.RenderStyle.ColorTable = null;
            this.msStatusMonAn.RenderStyle.RoundedEdges = true;
            this.msStatusMonAn.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.msStatusMonAn.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.msStatusMonAn.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.msStatusMonAn.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.msStatusMonAn.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.msStatusMonAn.Size = new System.Drawing.Size(163, 52);
            // 
            // msDaHetMon
            // 
            this.msDaHetMon.Name = "msDaHetMon";
            this.msDaHetMon.Size = new System.Drawing.Size(162, 24);
            this.msDaHetMon.Text = "Đã Hết Món";
            this.msDaHetMon.Click += new System.EventHandler(this.msDaHetMon_Click);
            // 
            // msDaCoMon
            // 
            this.msDaCoMon.Name = "msDaCoMon";
            this.msDaCoMon.Size = new System.Drawing.Size(162, 24);
            this.msDaCoMon.Text = "Đã Có Món";
            this.msDaCoMon.Click += new System.EventHandler(this.msDaCoMon_Click);
            // 
            // picMonAn
            // 
            this.picMonAn.BackColor = System.Drawing.Color.Transparent;
            this.picMonAn.ContextMenuStrip = this.msStatusMonAn;
            this.picMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMonAn.Image = global::GiaoDienPBL3.Properties.Resources.chad_montano_MqT0asuoIcU_unsplash;
            this.picMonAn.Location = new System.Drawing.Point(3, 3);
            this.picMonAn.Name = "picMonAn";
            this.picMonAn.Size = new System.Drawing.Size(159, 159);
            this.picMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMonAn.TabIndex = 0;
            this.picMonAn.TabStop = false;
            this.picMonAn.Click += new System.EventHandler(this.picMonAn_Click);
            // 
            // lblTenMonAn
            // 
            this.lblTenMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenMonAn.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMonAn.Location = new System.Drawing.Point(0, 0);
            this.lblTenMonAn.Name = "lblTenMonAn";
            this.lblTenMonAn.Size = new System.Drawing.Size(99, 28);
            this.lblTenMonAn.TabIndex = 0;
            this.lblTenMonAn.Text = "Pizza";
            this.lblTenMonAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTenMonAn
            // 
            this.panelTenMonAn.BackColor = System.Drawing.Color.Transparent;
            this.panelTenMonAn.Controls.Add(this.lblTenMonAn);
            this.panelTenMonAn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelTenMonAn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelTenMonAn.Location = new System.Drawing.Point(63, 134);
            this.panelTenMonAn.Name = "panelTenMonAn";
            this.panelTenMonAn.Size = new System.Drawing.Size(99, 28);
            this.panelTenMonAn.TabIndex = 1;
            // 
            // lblGiaMonAn
            // 
            this.lblGiaMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiaMonAn.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaMonAn.Location = new System.Drawing.Point(0, 0);
            this.lblGiaMonAn.Name = "lblGiaMonAn";
            this.lblGiaMonAn.Size = new System.Drawing.Size(99, 28);
            this.lblGiaMonAn.TabIndex = 0;
            this.lblGiaMonAn.Text = "50.000VND";
            this.lblGiaMonAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGiaMonAn
            // 
            this.panelGiaMonAn.BackColor = System.Drawing.Color.Transparent;
            this.panelGiaMonAn.Controls.Add(this.lblGiaMonAn);
            this.panelGiaMonAn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelGiaMonAn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelGiaMonAn.Location = new System.Drawing.Point(3, 3);
            this.panelGiaMonAn.Name = "panelGiaMonAn";
            this.panelGiaMonAn.Size = new System.Drawing.Size(99, 28);
            this.panelGiaMonAn.TabIndex = 1;
            // 
            // UC_MonAn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelBackGroundMonAn);
            this.Name = "UC_MonAn";
            this.Size = new System.Drawing.Size(165, 165);
            this.panelBackGroundMonAn.ResumeLayout(false);
            this.msStatusMonAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMonAn)).EndInit();
            this.panelTenMonAn.ResumeLayout(false);
            this.panelGiaMonAn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Guna.UI2.WinForms.Guna2ShadowPanel panelBackGroundMonAn;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip msStatusMonAn;
        private System.Windows.Forms.ToolStripMenuItem msDaHetMon;
        private System.Windows.Forms.ToolStripMenuItem msDaCoMon;
        private Guna.UI2.WinForms.Guna2GradientPanel panelTenMonAn;
        private System.Windows.Forms.Label lblTenMonAn;
        private Guna.UI2.WinForms.Guna2GradientPanel panelGiaMonAn;
        private System.Windows.Forms.Label lblGiaMonAn;
        private System.Windows.Forms.PictureBox picMonAn;
    }
}
