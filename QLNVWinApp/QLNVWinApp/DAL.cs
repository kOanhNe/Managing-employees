using QLNVWinApp.DTO;
using QLNVWinApp.DTO.QLNVWinApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNVWinApp.DAL
{
    public class DataAccess
    {
        // LƯU Ý: LỚP NÀY SẼ LUÔN SỬ DỤNG DBConnection.CreateConnection()
        // KẾT NỐI SẼ DÙNG TÀI KHOẢN CỦA NGƯỜI DÙNG ĐÃ ĐĂNG NHẬP

        #region Authentication & User Info
        // Phương thức này chỉ để tham khảo, logic thực tế nằm ở frmDangNhap
        public TaiKhoanDTO DangNhap(string tenDN, string matKhau)
        {
            // Logic đăng nhập đã được chuyển sang frmDangNhap
            // để sử dụng CreateAdminConnection
            throw new NotImplementedException();
        }

        public DataTable GetThongTinCaNhan(string tenDN)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XemThongTinCaNhan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenDN", tenDN);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        #endregion

        #region Employee Management
        public DataTable GetDanhSachNhanVien()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetDanhSachNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public int? ThemNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemNguoiDung", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@NgSinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                cmd.Parameters.AddWithValue("@LoaiND", nv.LoaiND);
                cmd.Parameters.AddWithValue("@MaCV", (object)nv.MaCV ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayVaoLam", nv.NgayVaoLam);
                cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
                return (int?)cmd.ExecuteScalar();
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatNguoiDung", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaND", nv.MaNV);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@NgSinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                cmd.Parameters.AddWithValue("@MaCV", (object)nv.MaCV ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoNgayPhep", (object)nv.SoNgayPhep ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaNguoiDung", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaND", maNV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        #endregion

        #region Position Management
        public DataTable GetFullListChucVu()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetFullListChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool ThemChucVu(ChucVuDTO cv)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenCV", cv.TenCV);
                cmd.Parameters.AddWithValue("@MucLuongCB", cv.MucLuongCB);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CapNhatChucVu(ChucVuDTO cv)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCV", cv.MaCV);
                cmd.Parameters.AddWithValue("@TenCV", cv.TenCV);
                cmd.Parameters.AddWithValue("@MucLuongCB", cv.MucLuongCB);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaChucVu(int maCV)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCV", maCV);
                var result = cmd.ExecuteScalar();
                return result != null && result.ToString() == "1";
            }
        }
        #endregion

        #region Timekeeping
        public DataTable GetChamCongByDate(int maNV, DateTime ngayLam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetChamCongByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@NgayLam", ngayLam.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool DuyetChamCong(int maCC)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DuyetChamCong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCC", maCC);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ThucHienChamCong(ChamCongDTO chamCong)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ChamCong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", chamCong.MaNV);
                cmd.Parameters.AddWithValue("@MaCa", chamCong.MaCa);
                cmd.Parameters.AddWithValue("@NgayLam", chamCong.NgayLam.Date);
                cmd.Parameters.AddWithValue("@GioVao", chamCong.GioVao.HasValue ? (object)chamCong.GioVao.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@GioRa", chamCong.GioRa.HasValue ? (object)chamCong.GioRa.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(chamCong.GhiChu) ? (object)DBNull.Value : chamCong.GhiChu);

                try
                {
                    var result = cmd.ExecuteScalar();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL khi chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        #endregion

        #region Salary
        public DataTable GetLuongTheoThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XemLuongTheoThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetLuongCaNhan(string tenDN)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XemLuongCaNhan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenDN", tenDN);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void TinhLuongChoTatCa(int thang, int nam)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TinhLuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.CommandTimeout = 120;
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region System & Utilities
        public bool KiemTraVaTaoCaMacDinh()
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand("sp_CheckCaLamViec", conn);
                cmdCheck.CommandType = CommandType.StoredProcedure;
                int count = (int)cmdCheck.ExecuteScalar();

                if (count == 0)
                {
                    string[] caData = {
                        "Ca Sáng, 08:00:00, 12:00:00",
                        "Ca Chiều, 13:00:00, 17:00:00",
                        "Ca Tối, 18:00:00, 22:00:00"
                    };

                    foreach (string ca in caData)
                    {
                        string[] parts = ca.Split(',');
                        SqlCommand cmd = new SqlCommand("sp_ThemCaLamViec", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenCa", parts[0].Trim());
                        cmd.Parameters.AddWithValue("@GioBD", parts[1].Trim());
                        cmd.Parameters.AddWithValue("@GioKT", parts[2].Trim());
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                return false;
            }
        }
        #endregion 
    }
}