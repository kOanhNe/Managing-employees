using QLNVWinApp.DAL;
using QLNVWinApp.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNVWinApp
{
    public partial class frmDangNhap : Form
    {
        private DataAccess _dataAccess;

        public frmDangNhap()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu thông tin");
                return;
            }

            try
            {
                TaiKhoanDTO user;
                // BƯỚC 1: DÙNG KẾT NỐI ADMIN ĐỂ XÁC THỰC
                using (SqlConnection adminConn = DBConnection.CreateAdminConnection())
                {
                    adminConn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DangNhap", adminConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDN", tenDN);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new TaiKhoanDTO
                            {
                                MaND = Convert.ToInt32(reader["MaND"]),
                                HoTen = reader["HoTen"].ToString(),
                                LoaiND = reader["LoaiND"].ToString(),
                                TenDN = reader["TenDN"].ToString(),
                                MatKhauGoc = matKhau 
                            };
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Đăng nhập thất bại");
                            return;
                        }
                    }
                }

                // BƯỚC 2: NẾU XÁC THỰC THÀNH CÔNG, LƯU THÔNG TIN VÀ ĐÓNG FORM
                CurrentUser.Login(user);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi đăng nhập");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Báo hiệu người dùng muốn thoát
            Application.Exit();
        }
    }
}

