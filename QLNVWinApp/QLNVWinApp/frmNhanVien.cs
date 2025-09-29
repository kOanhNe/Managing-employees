using QLNVWinApp.DAL;
using QLNVWinApp.DTO;
using QLNVWinApp.DTO.QLNVWinApp.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLNVWinApp
{
    public partial class frmNhanVien : Form
    {
        private DataAccess _dataAccess;
        private bool _isAddingOrEditing = false;

        public frmNhanVien()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
            cboLoaiND.SelectedIndexChanged += cboLoaiND_SelectedIndexChanged;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadChucVu();
            LoadLoaiNguoiDung();
            LoadGioiTinh();
            LoadDanhSachNhanVien();
            SetInitialState();
        }

        #region Load Data Methods
        private void LoadChucVu()
        {
            try
            {
                cboChucVu.DataSource = _dataAccess.GetFullListChucVu();
                cboChucVu.DisplayMember = "TenCV";
                cboChucVu.ValueMember = "MaCV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoaiNguoiDung()
        {
            cboLoaiND.Items.Clear();
            cboLoaiND.Items.AddRange(new string[] { "NhanVien", "QuanLy" });
        }

        private void LoadGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                dgvNhanVien.DataSource = _dataAccess.GetDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region UI State Management
        private void ToggleInputControls(bool enabled)
        {
            txtHoTen.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            cboGioiTinh.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtCCCD.Enabled = enabled;
            dtpNgayVaoLam.Enabled = enabled;
            cboLoaiND.Enabled = enabled;
            chkTrangThai.Enabled = enabled; // <-- THÊM DÒNG NÀY
        }

        private void SetInitialState()
        {
            ClearInputs();
            ToggleInputControls(false);
            txtMaNV.ReadOnly = true;
            txtMaNV.BackColor = SystemColors.Info;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            _isAddingOrEditing = false;
            cboChucVu.Enabled = false;
            chkTrangThai.Enabled = false; // <-- THÊM DÒNG NÀY (Vô hiệu hóa khi bắt đầu)
        }

        private void ClearInputs()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            cboGioiTinh.SelectedIndex = -1;
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            cboChucVu.SelectedIndex = -1;
            dtpNgayVaoLam.Value = DateTime.Now;
            cboLoaiND.SelectedIndex = 0;
            chkTrangThai.Checked = true; // <-- THÊM DÒNG NÀY (Mặc định được check khi thêm mới)
        }
        #endregion

        #region Event Handlers
        private void cboLoaiND_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiND.SelectedItem == null) return;

            string selectedLoaiND = cboLoaiND.SelectedItem.ToString();
            if (selectedLoaiND == "QuanLy")
            {
                var quanLyItem = cboChucVu.Items.Cast<ChucVuDTO>()
                                        .FirstOrDefault(item => "Quản lý".Equals(item.TenCV.Trim(), StringComparison.OrdinalIgnoreCase));
                if (quanLyItem != null) cboChucVu.SelectedValue = quanLyItem.MaCV;
                else MessageBox.Show("Không tìm thấy chức vụ 'Quản lý' trong CSDL.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboChucVu.Enabled = false;
            }
            else // NhanVien
            {
                cboChucVu.Enabled = _isAddingOrEditing;
                if (_isAddingOrEditing && cboChucVu.SelectedItem is ChucVuDTO currentItem && "Quản lý".Equals(currentItem.TenCV.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    cboChucVu.SelectedIndex = -1;
                }
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null && !_isAddingOrEditing && dgvNhanVien.CurrentRow.DataBoundItem is DataRowView row)
            {
                txtMaNV.Text = row["MaNV"]?.ToString();
                txtHoTen.Text = row["HoTen"]?.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row["NgSinh"]);
                cboGioiTinh.SelectedItem = row["GioiTinh"]?.ToString();
                txtSDT.Text = row["SDT"]?.ToString();
                txtDiaChi.Text = row["DiaChi"]?.ToString();
                txtCCCD.Text = row["CCCD"]?.ToString();
                cboChucVu.Text = row["TenCV"]?.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(row["NgayVaoLam"]);

                // Cập nhật CheckBox dựa trên dữ liệu từ GridView
                chkTrangThai.Checked = row["TrangThaiNhanVien"]?.ToString() == "Đang làm"; // <-- THÊM DÒNG NÀY

                if ("Quản lý".Equals(row["TenCV"]?.ToString(), StringComparison.OrdinalIgnoreCase)) cboLoaiND.SelectedItem = "QuanLy";
                else cboLoaiND.SelectedItem = "NhanVien";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAddingOrEditing = true;
            ClearInputs();
            ToggleInputControls(true);
            cboLoaiND_SelectedIndexChanged(null, null);
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtHoTen.Focus();
            chkTrangThai.Enabled = false; // <-- Vô hiệu hóa khi thêm mới vì mặc định là "Đang làm"
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _isAddingOrEditing = true;
            ToggleInputControls(true); // Bật CheckBox khi sửa
            cboLoaiND_SelectedIndexChanged(null, null);
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_dataAccess.XoaNhanVien(int.Parse(txtMaNV.Text)))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNhanVien();
                        SetInitialState();
                    }
                    else MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var nv = new NhanVienDTO
            {
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                CCCD = txtCCCD.Text.Trim(),
                MaCV = (int)cboChucVu.SelectedValue,
                LoaiND = cboLoaiND.SelectedItem.ToString(),
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                TrangThai = chkTrangThai.Checked // <-- THAY ĐỔI DÒNG NÀY
            };

            try
            {
                bool success = false;
                string successMessage = "";

                if (!string.IsNullOrEmpty(txtMaNV.Text)) // Update case
                {
                    nv.MaNV = int.Parse(txtMaNV.Text);
                    DataRowView drv = (DataRowView)dgvNhanVien.CurrentRow.DataBoundItem;
                    nv.SoNgayPhep = Convert.ToInt32(drv["SoNgayPhep"]);
                    // Trạng thái đã được lấy từ CheckBox ở trên

                    if (_dataAccess.CapNhatNhanVien(nv))
                    {
                        success = true;
                        successMessage = "Cập nhật nhân viên thành công!";
                    }
                }
                else // Add new case
                {
                    // Khi thêm mới, TrangThai mặc định là true (được set trong ClearInputs)
                    int? newEmployeeId = _dataAccess.ThemNhanVien(nv);
                    if (newEmployeeId.HasValue)
                    {
                        success = true;
                        successMessage = $"Thêm {nv.LoaiND} mới thành công!\nTài khoản và mật khẩu mặc định đã được tạo tự động.";
                    }
                }

                if (success)
                {
                    MessageBox.Show(successMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                    SetInitialState();
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu:\n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetInitialState();
            dgvNhanVien_SelectionChanged(null, null);
        }
        #endregion

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || cboGioiTinh.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên, giới tính, SĐT và CCCD.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboChucVu.SelectedValue == null)
            {
                string errorMessage = (cboLoaiND.SelectedItem.ToString() == "QuanLy")
                    ? "Không tìm thấy chức vụ 'Quản lý' trong CSDL. Vui lòng kiểm tra lại dữ liệu."
                    : "Vui lòng chọn chức vụ cho nhân viên.";
                MessageBox.Show(errorMessage, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                MessageBox.Show("CCCD không hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (DateTime.Now.Year - dtpNgaySinh.Value.Year < 18)
            {
                MessageBox.Show("Nhân viên phải từ 18 tuổi trở lên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}