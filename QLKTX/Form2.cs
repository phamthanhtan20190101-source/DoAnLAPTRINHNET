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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }

        private void btnDang_Nhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDN.Text;
            string matKhau = txtMatKhau.Text;

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra CSDL
            // Hàm này sẽ trả về "Quản lý", "Sinh viên", hoặc null (nếu sai)
            string chucVu = KiemTraDangNhap(tenDangNhap, matKhau);

            // 3. Điều hướng dựa trên chức vụ
            if (chucVu == "Quản lý")
            {
                

                // Mở Form1 (Form Quản lý)
                Form1 form1 = new Form1();
                form1.Show();

                // Ẩn Form đăng nhập
                this.Hide();
            }
            else if (chucVu == "Sinh viên")
            {
                MessageBox.Show("Đăng nhập thành công với tư cách Sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở Form3 (Form Sinh viên - dựa theo file Form3.cs của bạn)
                Form3 form3 = new Form3();
                form3.Show();

                // Ẩn Form đăng nhập
                this.Hide();
            }
            else
            {
                // Nếu hàm trả về null (sai thông tin)
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
