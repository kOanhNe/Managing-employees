using System;
using System.Data;
using System.Windows.Forms;
using QLNVWinApp.DAL;
using QLNVWinApp.DTO;

namespace QLNVWinApp
{
    public partial class frmChamCong : Form
    {
        private DataAccess _dataAccess;
        private bool _isManager;
        private bool _isFormLoaded = false;

        public frmChamCong()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            SetupFormByRole();
            _isFormLoaded = true;
            // Load initial data for the current user
            LoadChamCongDataForSelectedEmployee();
        }

        private void SetupFormByRole()
        {
            _isManager = CurrentUser.User.LoaiND.Trim().Equals("QuanLy", StringComparison.OrdinalIgnoreCase);

            btnDuyet.Visible = _isManager;
            dgvChamCong.MultiSelect = _isManager;

            if (_isManager)
            {
                LoadNhanVienForComboBox();
                cbNhanVien.Enabled = true;
            }
            else
            {
                var nv = new { HoTen = CurrentUser.User.HoTen, MaNV = CurrentUser.User.MaND };
                var list = new System.Collections.ArrayList { nv };
                cbNhanVien.DataSource = list;
                cbNhanVien.DisplayMember = "HoTen";
                cbNhanVien.ValueMember = "MaNV";
                cbNhanVien.Enabled = false;
            }
        }

        private void LoadNhanVienForComboBox()
        {
            try
            {
                DataTable dt = _dataAccess.GetDanhSachNhanVien();
                cbNhanVien.DataSource = dt;
                cbNhanVien.DisplayMember = "HoTen";
                cbNhanVien.ValueMember = "MaNV";
                cbNhanVien.SelectedValue = CurrentUser.User.MaND;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChamCongDataForSelectedEmployee()
        {
            if (cbNhanVien.SelectedValue == null) return;

            int maNV;
            // Handle the case where the data source is a DataTable or an ArrayList
            if (cbNhanVien.SelectedValue is DataRowView drv)
            {
                maNV = Convert.ToInt32(drv["MaNV"]);
            }
            else
            {
                maNV = Convert.ToInt32(cbNhanVien.SelectedValue);
            }

            if (maNV == 0) return;

            DateTime ngayLam = dtpNgayChamCong.Value;
            try
            {
                dgvChamCong.DataSource = _dataAccess.GetChamCongByDate(maNV, ngayLam);
                if (dgvChamCong.Columns.Contains("MaCC"))
                {
                    dgvChamCong.Columns["MaCC"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUIBasedOnSelection()
        {
            if (dgvChamCong.CurrentRow == null)
            {
                ToggleInputControls(false);
                return;
            }

            DataGridViewRow row = dgvChamCong.CurrentRow;
            txtCaLamViec.Text = row.Cells["TenCa"].Value?.ToString();
            DateTime ngayChon = dtpNgayChamCong.Value.Date;

            object gioVaoDb = row.Cells["GioVao"].Value;
            dtpGioVao.Value = (gioVaoDb != DBNull.Value && gioVaoDb != null) ? ngayChon + (TimeSpan)gioVaoDb : ngayChon + (TimeSpan)row.Cells["GioBD"].Value;

            object gioRaDb = row.Cells["GioRa"].Value;
            dtpGioRa.Value = (gioRaDb != DBNull.Value && gioRaDb != null) ? ngayChon + (TimeSpan)gioRaDb : ngayChon + (TimeSpan)row.Cells["GioKT"].Value;

            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

            string trangThaiDuyet = row.Cells["TrangThaiDuyet"].Value?.ToString();
            bool isApproved = (trangThaiDuyet == "Đã duyệt");
            bool canEdit = !isApproved;

            if (_isManager)
            {
                btnDuyet.Enabled = canEdit;
            }
            ToggleInputControls(canEdit);
        }

        private void ToggleInputControls(bool isEnabled)
        {
            dtpGioVao.Enabled = isEnabled;
            dtpGioRa.Enabled = isEnabled;
            txtGhiChu.Enabled = isEnabled;
            btnLuuChamCong.Enabled = isEnabled;
        }

        // =================== ADD THIS METHOD ===================
        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            LoadChamCongDataForSelectedEmployee();
        }
        // =======================================================

        private void btnLuuChamCong_Click(object sender, EventArgs e)
        {
            if (dgvChamCong.CurrentRow == null) return;
            if (cbNhanVien.SelectedValue == null) return;

            int maNV = Convert.ToInt32(cbNhanVien.SelectedValue);
            if (maNV == 0) return;

            try
            {
                DataGridViewRow selectedRow = dgvChamCong.CurrentRow;
                var chamCong = new ChamCongDTO
                {
                    MaNV = maNV,
                    MaCa = Convert.ToInt32(selectedRow.Cells["MaCa"].Value),
                    NgayLam = dtpNgayChamCong.Value,
                    GhiChu = txtGhiChu.Text,
                    GioVao = dtpGioVao.Value.TimeOfDay,
                    GioRa = dtpGioRa.Value.TimeOfDay
                };

                if (_dataAccess.ThucHienChamCong(chamCong))
                {
                    MessageBox.Show("Lưu chấm công thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChamCongDataForSelectedEmployee();
                }
                else
                {
                    MessageBox.Show("Lưu chấm công thất bại. Có thể mục này đã được quản lý duyệt hoặc không có gì thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvChamCong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mục để duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn duyệt {dgvChamCong.SelectedRows.Count} mục đã chọn?", "Xác nhận duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int successCount = 0;
            try
            {
                foreach (DataGridViewRow row in dgvChamCong.SelectedRows)
                {
                    if (row.Cells["MaCC"].Value != DBNull.Value && row.Cells["MaCC"].Value != null && row.Cells["TrangThaiDuyet"].Value.ToString() == "Chưa duyệt")
                    {
                        int maCC = Convert.ToInt32(row.Cells["MaCC"].Value);
                        if (_dataAccess.DuyetChamCong(maCC))
                        {
                            successCount++;
                        }
                    }
                }

                if (successCount > 0)
                {
                    MessageBox.Show($"Đã duyệt thành công {successCount} mục.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChamCongDataForSelectedEmployee();
                }
                else
                {
                    MessageBox.Show("Không có mục mới nào được duyệt (có thể chúng đã được duyệt trước đó).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình duyệt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChamCong_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUIBasedOnSelection();
        }

        private void cbNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Data will be loaded when the "Xem Dữ Liệu" button is clicked.
        }

        private void dtpNgayChamCong_ValueChanged(object sender, EventArgs e)
        {
            // Data will be loaded when the "Xem Dữ Liệu" button is clicked.
        }
    }
}