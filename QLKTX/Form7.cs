using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class Form7 : Form
    {
        //string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
        private string _mssv;
        public Form7(string mssv)
        {
            InitializeComponent();
            _mssv = mssv;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SDT FROM SinhVien WHERE MSSV = @MSSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MSSV", _mssv);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtSDT.Text = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private bool KiemTraMatKhauCu(string tk, string mk)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TK AND MatKhau = @MK";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TK", tk);
                    cmd.Parameters.AddWithValue("@MK", mk);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Trả về true nếu tìm thấy
                }
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hien = !chkHienMatKhau.Checked; // Nếu check thì hiện (UseSystemPasswordChar = false)

            txtMatKhauCu.UseSystemPasswordChar = hien;
            txtMatKhauMoi.UseSystemPasswordChar = hien;
            txtXacNhanMK.UseSystemPasswordChar = hien;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMatKhauCu.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại để xác nhận thay đổi.", "Yêu cầu xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            // Kiểm tra mật khẩu cũ có đúng không
            if (!KiemTraMatKhauCu(_mssv, txtMatKhauCu.Text))
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 2.1. Kiểm tra SĐT (Luôn kiểm tra vì SĐT luôn hiển thị)
            string sdtMoi = txtSDT.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdtMoi, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\n(Phải bắt đầu bằng 0 và đủ 10 số)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            // 2.2. Kiểm tra Mật khẩu mới (Chỉ kiểm tra NẾU người dùng có nhập)
            bool coDoiMatKhau = !string.IsNullOrEmpty(txtMatKhauMoi.Text);
            if (coDoiMatKhau)
            {
                if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
                {
                    MessageBox.Show("Mật khẩu mới và Xác nhận mật khẩu không khớp.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // A. LUÔN CẬP NHẬT SỐ ĐIỆN THOẠI
                    string updateSDT = "UPDATE SinhVien SET SDT = @SDT WHERE MSSV = @MSSV";
                    using (SqlCommand cmd = new SqlCommand(updateSDT, conn))
                    {
                        cmd.Parameters.AddWithValue("@SDT", sdtMoi);
                        cmd.Parameters.AddWithValue("@MSSV", _mssv);
                        cmd.ExecuteNonQuery();
                    }

                    // B. CHỈ CẬP NHẬT MẬT KHẨU NẾU CÓ NHẬP MỚI
                    if (coDoiMatKhau)
                    {
                        string updatePass = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenDangNhap = @MSSV";
                        using (SqlCommand cmd = new SqlCommand(updatePass, conn))
                        {
                            cmd.Parameters.AddWithValue("@MatKhau", txtMatKhauMoi.Text);
                            cmd.Parameters.AddWithValue("@MSSV", _mssv);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Thông báo kết quả phù hợp
                    if (coDoiMatKhau)
                    {
                        MessageBox.Show("Cập nhật Số điện thoại và Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật Số điện thoại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Close(); // Đóng form sau khi xong
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
