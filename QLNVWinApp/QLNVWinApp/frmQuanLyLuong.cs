using System;
using System.Data;
using System.Windows.Forms;
using QLNVWinApp.DAL;
using QLNVWinApp.DTO;

namespace QLNVWinApp
{
    public partial class frmQuanLyLuong : Form
    {
        private readonly DataAccess _dataAccess;
        private readonly bool _isManagerMode;

        public frmQuanLyLuong()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
            _isManagerMode = CurrentUser.User.LoaiND.Trim().Equals("QuanLy", StringComparison.OrdinalIgnoreCase);
        }

        private void frmQuanLyLuong_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho tháng/năm
            cboThang.SelectedIndex = DateTime.Now.Month - 1; // 0-based index
            txtNam.Text = DateTime.Now.Year.ToString();

            SetupFormByRole();
            LoadData();
        }

        private void SetupFormByRole()
        {
            // Quản lý có thể xem theo tháng/năm và cập nhật
            lblChonThang.Visible = _isManagerMode;
            cboThang.Visible = _isManagerMode;
            lblChonNam.Visible = _isManagerMode;
            txtNam.Visible = _isManagerMode;
            btnTinhLuongHangLoat.Visible = _isManagerMode;

            // Nhân viên chỉ được xem, không được sửa
            dgvLuong.ReadOnly = !_isManagerMode;
        }

        private void LoadData()
        {
            try
            {
                DataTable dt;
                if (_isManagerMode)
                {
                    int thang = cboThang.SelectedIndex + 1; // 1-based
                    int nam = Convert.ToInt32(txtNam.Text);
                    dt = _dataAccess.GetLuongTheoThang(thang, nam);
                }
                else
                {
                    dt = _dataAccess.GetLuongCaNhan(CurrentUser.User.TenDN);
                }
                dgvLuong.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBangLuong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNam.Text))
            {
                MessageBox.Show("Vui lòng nhập năm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadData();
        }

        private void btnTinhLuongHangLoat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNam.Text) || !int.TryParse(txtNam.Text, out int nam))
            {
                MessageBox.Show("Vui lòng nhập năm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int thang = cboThang.SelectedIndex + 1;

            try
            {
                // Hiển thị thông báo chờ
                this.Cursor = Cursors.WaitCursor;

                // Gọi hàm mới
                _dataAccess.TinhLuongChoTatCa(thang, nam);

                this.Cursor = Cursors.Default;
                MessageBox.Show($"Đã tính và cập nhật lại lương tháng {thang}/{nam} cho tất cả nhân viên!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại bảng lương để xem kết quả
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi tính lương hàng loạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}