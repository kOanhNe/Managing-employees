using System;
using System.Windows.Forms;
using QLNVWinApp.DAL;
using QLNVWinApp.DTO;

namespace QLNVWinApp
{
    public partial class frmMain : Form
    {
        private Form activeForm = null;
        private bool _isManager;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetupUIBasedOnRole();
            _isManager = CurrentUser.User.LoaiND.Trim().Equals("QuanLy", StringComparison.OrdinalIgnoreCase);

            if (_isManager)
            {
                try
                {
                    DataAccess da = new DataAccess();
                    if (da.KiemTraVaTaoCaMacDinh())
                    {
                        MessageBox.Show("Đã tạo ca làm việc mặc định thành công!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra/tạo ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetupUIBasedOnRole()
        {
            if (CurrentUser.User == null)
            {
                MessageBox.Show("Không có thông tin người dùng. Vui lòng đăng nhập lại.");
                Application.Exit();
                return;
            }

            lblWelcome.Text = $"Chào, {CurrentUser.User.HoTen}!";

            bool isManager = CurrentUser.User.LoaiND.Trim().Equals("QuanLy", StringComparison.OrdinalIgnoreCase);

            chứcNăngQuảnLýToolStripMenuItem.Visible = isManager;
            chứcNăngToolStripMenuItem.Visible = true; // Luôn hiển thị cho mọi vai trò
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Đặt một cờ để biết rằng đây là hành động đăng xuất, không phải thoát ứng dụng
            this.DialogResult = DialogResult.Retry; // Sử dụng một DialogResult tùy ý
            CurrentUser.Logout();
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Đặt cờ là thoát để vòng lặp trong Program.cs biết và dừng lại
            this.DialogResult = DialogResult.Abort;
            Application.Exit();
        }

        // --- Chức năng chung ---
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongTinCaNhan());
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChamCong());
        }

        private void xemBảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyLuong());
        }

        // --- Chức năng quản lý ---
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
        }

        private void quảnLýChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChucVu());
        }

        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyLuong());
        }
    }
}