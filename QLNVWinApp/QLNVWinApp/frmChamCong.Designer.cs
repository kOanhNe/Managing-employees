namespace QLNVWinApp
{
    partial class frmChamCong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXemDuLieu = new System.Windows.Forms.Button();
            this.dtpNgayChamCong = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChamCong = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnLuuChamCong = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpGioRa = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpGioVao = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCaLamViec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnXemDuLieu);
            this.panel1.Controls.Add(this.dtpNgayChamCong);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbNhanVien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnXemDuLieu
            // 
            this.btnXemDuLieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXemDuLieu.Location = new System.Drawing.Point(758, 16);
            this.btnXemDuLieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemDuLieu.Name = "btnXemDuLieu";
            this.btnXemDuLieu.Size = new System.Drawing.Size(180, 42);
            this.btnXemDuLieu.TabIndex = 4;
            this.btnXemDuLieu.Text = "Xem Dữ Liệu";
            this.btnXemDuLieu.UseVisualStyleBackColor = true;
            this.btnXemDuLieu.Click += new System.EventHandler(this.btnXemDuLieu_Click);
            // 
            // dtpNgayChamCong
            // 
            this.dtpNgayChamCong.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayChamCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayChamCong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayChamCong.Location = new System.Drawing.Point(513, 20);
            this.dtpNgayChamCong.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayChamCong.Name = "dtpNgayChamCong";
            this.dtpNgayChamCong.Size = new System.Drawing.Size(224, 34);
            this.dtpNgayChamCong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn ngày:";
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhanVien.FormattingEnabled = true;
            this.cbNhanVien.Location = new System.Drawing.Point(171, 18);
            this.cbNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(198, 36);
            this.cbNhanVien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn nhân viên:";
            // 
            // dgvChamCong
            // 
            this.dgvChamCong.AllowUserToAddRows = false;
            this.dgvChamCong.AllowUserToDeleteRows = false;
            this.dgvChamCong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChamCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChamCong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChamCong.Location = new System.Drawing.Point(0, 74);
            this.dgvChamCong.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.ReadOnly = true;
            this.dgvChamCong.RowHeadersWidth = 51;
            this.dgvChamCong.RowTemplate.Height = 28;
            this.dgvChamCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChamCong.Size = new System.Drawing.Size(1282, 335);
            this.dgvChamCong.TabIndex = 1;
            this.dgvChamCong.SelectionChanged += new System.EventHandler(this.dgvChamCong_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnDuyet);
            this.groupBox1.Controls.Add(this.btnLuuChamCong);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpGioRa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpGioVao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCaLamViec);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 417);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1282, 238);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thực hiện chấm công";
            // 
            // btnDuyet
            // 
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.Location = new System.Drawing.Point(758, 172);
            this.btnDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(225, 49);
            this.btnDuyet.TabIndex = 9;
            this.btnDuyet.Text = "Duyệt Công";
            this.btnDuyet.UseVisualStyleBackColor = true;
            this.btnDuyet.Visible = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnLuuChamCong
            // 
            this.btnLuuChamCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuuChamCong.Location = new System.Drawing.Point(503, 172);
            this.btnLuuChamCong.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuChamCong.Name = "btnLuuChamCong";
            this.btnLuuChamCong.Size = new System.Drawing.Size(225, 49);
            this.btnLuuChamCong.TabIndex = 8;
            this.btnLuuChamCong.Text = "Lưu Chấm Công";
            this.btnLuuChamCong.UseVisualStyleBackColor = true;
            this.btnLuuChamCong.Click += new System.EventHandler(this.btnLuuChamCong_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(503, 63);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(562, 83);
            this.txtGhiChu.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(508, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 28);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ghi chú:";
            // 
            // dtpGioRa
            // 
            this.dtpGioRa.CustomFormat = "HH:mm";
            this.dtpGioRa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGioRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioRa.Location = new System.Drawing.Point(215, 150);
            this.dtpGioRa.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGioRa.Name = "dtpGioRa";
            this.dtpGioRa.ShowUpDown = true;
            this.dtpGioRa.Size = new System.Drawing.Size(250, 34);
            this.dtpGioRa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(52, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giờ chấm ra:";
            // 
            // dtpGioVao
            // 
            this.dtpGioVao.CustomFormat = "HH:mm";
            this.dtpGioVao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGioVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioVao.Location = new System.Drawing.Point(215, 95);
            this.dtpGioVao.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGioVao.Name = "dtpGioVao";
            this.dtpGioVao.ShowUpDown = true;
            this.dtpGioVao.Size = new System.Drawing.Size(250, 34);
            this.dtpGioVao.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(52, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giờ chấm vào:";
            // 
            // txtCaLamViec
            // 
            this.txtCaLamViec.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaLamViec.Location = new System.Drawing.Point(215, 42);
            this.txtCaLamViec.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaLamViec.Name = "txtCaLamViec";
            this.txtCaLamViec.ReadOnly = true;
            this.txtCaLamViec.Size = new System.Drawing.Size(250, 34);
            this.txtCaLamViec.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(52, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ca làm việc:";
            // 
            // frmChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 655);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvChamCong);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "frmChamCong";
            this.Text = "Bảng Chấm Công Hàng Ngày";
            this.Load += new System.EventHandler(this.frmChamCong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpNgayChamCong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChamCong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLuuChamCong;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpGioRa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpGioVao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCaLamViec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnXemDuLieu;
    }
}