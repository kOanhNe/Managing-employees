using System;
using System.Windows.Forms;
using QLNVWinApp.DAL;
using QLNVWinApp.DTO;

namespace QLNVWinApp
{
    public partial class frmChucVu : Form
    {
        private DataAccess _dataAccess;
        private bool _isAddingOrEditing = false;
        public frmChucVu()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            LoadChucVuData();
            SetInitialState();
        }

        private void LoadChucVuData()
        {
            try
            {
                dgvChucVu.DataSource = _dataAccess.GetFullListChucVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chức vụ: " + ex.Message);
            }
        }
        private void ToggleInputControls(bool enabled)
        {
            txtTenCV.Enabled = enabled;
            txtMucLuongCB.Enabled = enabled;
        }

        private void SetInitialState()
        {
            ClearInputs();
            ToggleInputControls(false);

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            _isAddingOrEditing = false;
        }
        private void ClearInputs()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtMucLuongCB.Clear();
        }
        private void dgvChucVu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChucVu.CurrentRow != null && !_isAddingOrEditing)
            {
                DataGridViewRow row = dgvChucVu.CurrentRow;
                txtMaCV.Text = row.Cells["MaCV"].Value.ToString();
                txtTenCV.Text = row.Cells["TenCV"].Value.ToString();
                txtMucLuongCB.Text = row.Cells["MucLuongCB"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAddingOrEditing = true;
            ClearInputs();
            ToggleInputControls(true);
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenCV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCV.Text))
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa.");
                return;
            }
            _isAddingOrEditing = true;
            ToggleInputControls(true);
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenCV.Text) || string.IsNullOrWhiteSpace(txtMucLuongCB.Text))
            {
                MessageBox.Show("Tên chức vụ và mức lương không được để trống.");
                return;
            }
            if (!decimal.TryParse(txtMucLuongCB.Text, out decimal mucLuong))
            {
                MessageBox.Show("Mức lương phải là một con số.");
                return;
            }

            var cv = new ChucVuDTO
            {
                TenCV = txtTenCV.Text.Trim(),
                MucLuongCB = mucLuong
            };

            try
            {
                bool result;
                if (string.IsNullOrEmpty(txtMaCV.Text)) // Add mode
                {
                    result = _dataAccess.ThemChucVu(cv);
                }
                else // Edit mode
                {
                    cv.MaCV = int.Parse(txtMaCV.Text);
                    result = _dataAccess.CapNhatChucVu(cv);
                }

                if (result)
                {
                    MessageBox.Show("Lưu thành công!");
                    LoadChucVuData();
                    SetInitialState();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetInitialState();
            dgvChucVu_SelectionChanged(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCV.Text))
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int maCV = int.Parse(txtMaCV.Text);
                    bool result = _dataAccess.XoaChucVu(maCV);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadChucVuData();
                        SetInitialState();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa chức vụ này vì vẫn còn nhân viên đang giữ chức vụ.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }
    }
}
