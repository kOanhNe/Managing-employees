using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLNVWinApp.DAL;
using QLNVWinApp.DTO;

namespace QLNVWinApp
{
    public partial class frmThongTinCaNhan : Form
    {
        private DataAccess _dataAccess;

        public frmThongTinCaNhan()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
        }

        private void LoadThongTinCaNhan()
        {
            if (CurrentUser.User == null)
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                string tenDN = CurrentUser.User.TenDN;
                DataTable dt = _dataAccess.GetThongTinCaNhan(tenDN);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Gán dữ liệu cho các trường chung
                    txtMaNV.Text = row["MaND"]?.ToString();
                    txtHoTen.Text = row["HoTen"]?.ToString();
                    dtpNgaySinh.Value = Convert.ToDateTime(row["NgSinh"]);
                    txtGioiTinh.Text = row["GioiTinh"]?.ToString();
                    txtSDT.Text = row["SDT"]?.ToString();
                    txtDiaChi.Text = row["DiaChi"]?.ToString();
                    txtLoaiND.Text = row["LoaiND"]?.ToString();
                    txtCCCD.Text = row["CCCD"]?.ToString();

                    // Mặc định ẩn các panel của nhân viên
                    panelChucVu.Visible = false;
                    panelNgayVaoLam.Visible = false;
                    panelSoNgayPhep.Visible = false;

                    // Kiểm tra và hiển thị các trường của nhân viên nếu có
                    if (row["LoaiND"].ToString() != "QuanLy")
                    {
                        // Hiện lại các panel
                        panelChucVu.Visible = true;
                        panelNgayVaoLam.Visible = true;
                        panelSoNgayPhep.Visible = true;

                        // Gán dữ liệu riêng
                        txtChucVu.Text = row["TenCV"]?.ToString();
                        dtpNgayVaoLam.Value = Convert.ToDateTime(row["NgayVaoLam"]);
                        txtSoNgayPhep.Text = row["SoNgayPhep"]?.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể tải thông tin cá nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}