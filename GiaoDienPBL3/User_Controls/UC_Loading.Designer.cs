namespace GiaoDienPBL3.User_Controls
{
    partial class UC_Loading
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Loading));
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.circlerProgressBarLoad = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Controls.Add(this.circlerProgressBarLoad);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Gray;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Silver;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1254, 721);
            this.guna2CustomGradientPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(444, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đang Tải Dữ Liệu...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // circlerProgressBarLoad
            // 
            this.circlerProgressBarLoad.animated = true;
            this.circlerProgressBarLoad.animationIterval = 0;
            this.circlerProgressBarLoad.animationSpeed = 1500;
            this.circlerProgressBarLoad.BackColor = System.Drawing.Color.Transparent;
            this.circlerProgressBarLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circlerProgressBarLoad.BackgroundImage")));
            this.circlerProgressBarLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.circlerProgressBarLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circlerProgressBarLoad.LabelVisible = true;
            this.circlerProgressBarLoad.LineProgressThickness = 8;
            this.circlerProgressBarLoad.LineThickness = 5;
            this.circlerProgressBarLoad.Location = new System.Drawing.Point(550, 214);
            this.circlerProgressBarLoad.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.circlerProgressBarLoad.MaxValue = 100;
            this.circlerProgressBarLoad.Name = "circlerProgressBarLoad";
            this.circlerProgressBarLoad.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.circlerProgressBarLoad.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.circlerProgressBarLoad.Size = new System.Drawing.Size(154, 154);
            this.circlerProgressBarLoad.TabIndex = 1;
            this.circlerProgressBarLoad.Value = 0;
            // 
            // timerLoad
            // 
            this.timerLoad.Enabled = true;
            this.timerLoad.Interval = 1;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // UC_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "UC_Loading";
            this.Size = new System.Drawing.Size(1254, 721);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Label label1;
        public Bunifu.Framework.UI.BunifuCircleProgressbar circlerProgressBarLoad;
        private System.Windows.Forms.Timer timerLoad;
    }
}
