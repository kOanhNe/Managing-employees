using System;
using System.Windows.Forms;
using QLNVWinApp.DAL;

namespace QLNVWinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // BƯỚC 1: KHỞI TẠO KẾT NỐI VỚI TÀI KHOẢN ADMIN "SA" CỦA BẠN
            // Tài khoản này chỉ dùng để kiểm tra đăng nhập.
            try
            {
                DBConnection.Initialize("LAPTOP-O8J1ULHM", "QLNV", "sa", "admin123");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo kết nối database: " + ex.Message, "Lỗi nghiêm trọng");
                return; // Dừng ứng dụng nếu không thể kết nối
            }


            // BƯỚC 2: VÒNG LẶP ĐĂNG NHẬP VÀ CHẠY ỨNG DỤNG
            while (true)
            {
                frmDangNhap loginForm = new frmDangNhap();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, chạy form chính
                    frmMain mainForm = new frmMain();
                    Application.Run(mainForm);

                    // Sau khi frmMain đóng, kiểm tra xem có phải là đăng xuất không
                    if (mainForm.DialogResult == DialogResult.Retry) // "Retry" được dùng làm cờ đăng xuất
                    {
                        continue; // Nếu là đăng xuất, lặp lại để hiện form đăng nhập
                    }
                    else
                    {
                        break; // Nếu là thoát (hoặc đóng bằng nút X), thoát vòng lặp
                    }
                }
                else
                {
                    break; // Người dùng thoát từ form đăng nhập
                }
            }
        }
    }
}