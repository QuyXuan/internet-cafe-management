namespace GiaoDienPBL3.User_Controls
{
    partial class UC_LoaiMay
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
            this.btnColorMay = new Guna.UI2.WinForms.Guna2Button();
            this.lblLoaiMay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnColorMay
            // 
            this.btnColorMay.BorderColor = System.Drawing.Color.Gray;
            this.btnColorMay.BorderRadius = 8;
            this.btnColorMay.BorderThickness = 3;
            this.btnColorMay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnColorMay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnColorMay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnColorMay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnColorMay.FillColor = System.Drawing.Color.Transparent;
            this.btnColorMay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnColorMay.ForeColor = System.Drawing.Color.White;
            this.btnColorMay.Location = new System.Drawing.Point(5, 6);
            this.btnColorMay.Name = "btnColorMay";
            this.btnColorMay.Size = new System.Drawing.Size(25, 25);
            this.btnColorMay.TabIndex = 20;
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.AutoSize = true;
            this.lblLoaiMay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiMay.Location = new System.Drawing.Point(54, 9);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.lblLoaiMay.Size = new System.Drawing.Size(68, 20);
            this.lblLoaiMay.TabIndex = 28;
            this.lblLoaiMay.Text = "LoaiMay";
            // 
            // UC_LoaiMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lblLoaiMay);
            this.Controls.Add(this.btnColorMay);
            this.Name = "UC_LoaiMay";
            this.Size = new System.Drawing.Size(254, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnColorMay;
        private System.Windows.Forms.Label lblLoaiMay;
    }
}
