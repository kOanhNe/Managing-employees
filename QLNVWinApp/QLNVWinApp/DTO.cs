using System;

namespace QLNVWinApp.DTO
{
    /// <summary>
    /// Lớp tĩnh để lưu trữ thông tin người dùng đang đăng nhập trong suốt phiên làm việc.
    /// </summary>
    public static class CurrentUser
    {
        // Chỉ có thể gán giá trị từ bên trong lớp này.
        public static TaiKhoanDTO User { get; private set; }

        /// <summary>
        /// Phương thức công khai để gán người dùng khi đăng nhập thành công.
        /// </summary>
        /// <param name="loggedInUser">Thông tin người dùng đã được xác thực.</param>
        public static void Login(TaiKhoanDTO loggedInUser)
        {
            User = loggedInUser;
        }

        /// <summary>
        /// Phương thức để xóa thông tin người dùng khi đăng xuất.
        /// </summary>
        public static void Logout()
        {
            User = null;
        }
    }

    public class TaiKhoanDTO
    {
        public int MaND { get; set; }
        public string TenDN { get; set; }
        public string HoTen { get; set; }
        public string LoaiND { get; set; }
        public string MatKhauGoc { get; set; } // Thuộc tính lưu trữ tạm thời mật khẩu gốc
    }

    public class ChucVuDTO
    {
        public int MaCV { get; set; }
        public string TenCV { get; set; }
        public decimal MucLuongCB { get; set; }
    }

    namespace QLNVWinApp.DTO
    {
        public class NhanVienDTO
        {
            public int? MaNV { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public string GioiTinh { get; set; }
            public string SDT { get; set; }
            public string DiaChi { get; set; }
            public string CCCD { get; set; }
            public int? MaCV { get; set; }
            public DateTime NgayVaoLam { get; set; }
            public int? SoNgayPhep { get; set; } 
            public bool TrangThai { get; set; }
            public string LoaiND { get; set; }
        }
    }

    public class ChamCongDTO
    {
        public int MaCC { get; set; }
        public int MaNV { get; set; }
        public int MaCa { get; set; }
        public DateTime NgayLam { get; set; }
        public TimeSpan? GioVao { get; set; }
        public TimeSpan? GioRa { get; set; }
        public string GhiChu { get; set; }
    }

    public class LuongThangDTO
    {
        public int MaLuong { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal TienThuong { get; set; }
        public decimal TienPhat { get; set; }
        public string TrangThaiLuong { get; set; }
    }
}

