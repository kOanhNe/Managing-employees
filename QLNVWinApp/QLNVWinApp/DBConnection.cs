using System.Data.SqlClient;
using QLNVWinApp.DTO;

namespace QLNVWinApp.DAL
{
    public static class DBConnection
    {
        private static string _server, _db, _appAdminUser, _appAdminPass;

        /// <summary>
        /// Khởi tạo thông tin kết nối và tài khoản admin của ứng dụng.
        /// Phương thức này phải được gọi một lần khi ứng dụng bắt đầu.
        /// </summary>
        /// <param name="LAPTOP-O8J1ULHM">Tên server SQL, ví dụ: LAPTOP-O8J1ULHM</param>
        /// <param name="QLNV">Tên database, ví dụ: QLNV</param>
        /// <param name="sa">Tài khoản SQL có quyền cao, ví dụ: sa</param>
        /// <param name="admin123">Mật khẩu của tài khoản admin123</param>
        public static void Initialize(string serverName, string dbName, string appAdminUser, string appAdminPassword)
        {
            _server = serverName;
            _db = dbName;
            _appAdminUser = appAdminUser;
            _appAdminPass = appAdminPassword;
        }

        /// <summary>
        /// Tạo kết nối bằng tài khoản admin của ứng dụng.
        /// Chỉ sử dụng cho việc đăng nhập ban đầu.
        /// </summary>
        public static SqlConnection CreateAdminConnection()
        {
            string connStr = $"Data Source={_server};Initial Catalog={_db};User ID={_appAdminUser};Password={_appAdminPass};TrustServerCertificate=True";
            return new SqlConnection(connStr);
        }

        /// <summary>
        /// Tạo kết nối bằng tài khoản của người dùng cá nhân (sau khi đã đăng nhập).
        /// Mọi thao tác sau khi đăng nhập sẽ sử dụng kết nối này.
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            if (CurrentUser.User == null || string.IsNullOrEmpty(CurrentUser.User.TenDN))
            {
                throw new System.Exception("Người dùng chưa đăng nhập hoặc thông tin đăng nhập không hợp lệ.");
            }

            // Sử dụng TenDN và mật khẩu gốc mà người dùng đã nhập để tạo kết nối
            string connStr = $"Data Source={_server};Initial Catalog={_db};User ID={CurrentUser.User.TenDN};Password={CurrentUser.User.MatKhauGoc};TrustServerCertificate=True";
            return new SqlConnection(connStr);
        }
    }
}