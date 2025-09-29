namespace QLNVWinApp
{
    partial class frmQuanLyLuong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.lblChonNam = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.lblChonThang = new System.Windows.Forms.Label();
            this.btnTinhLuongHangLoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLuong
            // 
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLuong.Location = new System.Drawing.Point(0, 81);
            this.dgvLuong.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.RowTemplate.Height = 28;
            this.dgvLuong.Size = new System.Drawing.Size(1282, 572);
            this.dgvLuong.TabIndex = 0;
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(453, 23);
            this.txtNam.Margin = new System.Windows.Forms.Padding(4);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(125, 34);
            this.txtNam.TabIndex = 3;
            // 
            // lblChonNam
            // 
            this.lblChonNam.AutoSize = true;
            this.lblChonNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChonNam.Location = new System.Drawing.Point(380, 26);
            this.lblChonNam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChonNam.Name = "lblChonNam";
            this.lblChonNam.Size = new System.Drawing.Size(62, 28);
            this.lblChonNam.TabIndex = 4;
            this.lblChonNam.Text = "Năm:";
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThang.Location = new System.Drawing.Point(166, 19);
            this.cboThang.Margin = new System.Windows.Forms.Padding(4);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(112, 36);
            this.cboThang.TabIndex = 5;
            // 
            // lblChonThang
            // 
            this.lblChonThang.AutoSize = true;
            this.lblChonThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChonThang.Location = new System.Drawing.Point(19, 22);
            this.lblChonThang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChonThang.Name = "lblChonThang";
            this.lblChonThang.Size = new System.Drawing.Size(126, 28);
            this.lblChonThang.TabIndex = 6;
            this.lblChonThang.Text = "Chọn tháng:";
            // 
            // btnTinhLuongHangLoat
            // 
            this.btnTinhLuongHangLoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTinhLuongHangLoat.Location = new System.Drawing.Point(601, 19);
            this.btnTinhLuongHangLoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnTinhLuongHangLoat.Name = "btnTinhLuongHangLoat";
            this.btnTinhLuongHangLoat.Size = new System.Drawing.Size(270, 42);
            this.btnTinhLuongHangLoat.TabIndex = 7;
            this.btnTinhLuongHangLoat.Text = "Tính Lương";
            this.btnTinhLuongHangLoat.UseVisualStyleBackColor = true;
            this.btnTinhLuongHangLoat.Click += new System.EventHandler(this.btnTinhLuongHangLoat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.lblChonThang);
            this.panel1.Controls.Add(this.btnTinhLuongHangLoat);
            this.panel1.Controls.Add(this.txtNam);
            this.panel1.Controls.Add(this.cboThang);
            this.panel1.Controls.Add(this.lblChonNam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 74);
            this.panel1.TabIndex = 8;
            // 
            // frmQuanLyLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvLuong);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "frmQuanLyLuong";
            this.Text = "Quản Lý Lương";
            this.Load += new System.EventHandler(this.frmQuanLyLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label lblChonNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label lblChonThang;
        private System.Windows.Forms.Button btnTinhLuongHangLoat;
        private System.Windows.Forms.Panel panel1;
    }
}