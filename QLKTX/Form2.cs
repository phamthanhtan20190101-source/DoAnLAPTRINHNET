using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLKTX
{
    public partial class Form2 : Form
    {
        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        //string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
            txtTenDN.Focus();
        }

        private void btnDang_Nhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDN.Text.Trim(); // Trim() để xóa khoảng trắng thừa
            string matKhau = txtMatKhau.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // 2. Kiểm tra CSDL
            string chucVu = KiemTraDangNhap(tenDangNhap, matKhau);

            // 3. Điều hướng
            if (chucVu == "Quản lý")
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else if (chucVu == "Sinh viên")
            {

                string mssv = txtTenDN.Text;


                Form3 form3 = new Form3(mssv);

                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear(); // Xóa mật khẩu để nhập lại
                txtMatKhau.Focus();
            }
        }

        private string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string chucVu = null;

            // Dùng query này để lấy ChucVu từ bảng TaiKhoan (theo file SQL của bạn)
            string query = "SELECT ChucVu FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Dùng Parameters để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        // Dùng ExecuteScalar vì chúng ta chỉ cần lấy 1 giá trị (ChucVu)
                        object result = cmd.ExecuteScalar();

                        if (result != null) // Nếu tìm thấy kết quả
                        {
                            chucVu = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return chucVu;
        }

        private void checkHienMK_CheckedChanged(object sender, EventArgs e)
        {

            if (checkHienMK.Checked)
            {
                // Hiện mật khẩu: Xóa ký tự che
                txtMatKhau.PasswordChar = '\0'; // '\0' là ký tự null
            }
            else
            {
                // Ẩn mật khẩu: Đặt lại ký tự *
                txtMatKhau.PasswordChar = '*';
            }
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi hàm click của nút đăng nhập
                btnDang_Nhap.PerformClick();
            }
        }
    }
}
