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
        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        //string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
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
            // --- BƯỚC 1: KIỂM TRA MẬT KHẨU CŨ ---
            if (string.IsNullOrEmpty(txtMatKhauCu.Text))
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ để xác nhận thay đổi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraMatKhauCu(_mssv, txtMatKhauCu.Text))
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- BƯỚC 2: THỰC HIỆN CẬP NHẬT ---
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // A. Cập nhật Số điện thoại (Bảng SinhVien)
                    string updateSDT = "UPDATE SinhVien SET SDT = @SDT WHERE MSSV = @MSSV";
                    using (SqlCommand cmd = new SqlCommand(updateSDT, conn))
                    {
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@MSSV", _mssv);
                        cmd.ExecuteNonQuery();
                    }

                    // B. Cập nhật Mật khẩu (Bảng TaiKhoan) - Chỉ nếu có nhập mật khẩu mới
                    if (!string.IsNullOrEmpty(txtMatKhauMoi.Text))
                    {
                        if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
                        {
                            MessageBox.Show("Mật khẩu mới và xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string updatePass = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenDangNhap = @MSSV";
                        using (SqlCommand cmd = new SqlCommand(updatePass, conn))
                        {
                            cmd.Parameters.AddWithValue("@MatKhau", txtMatKhauMoi.Text);
                            cmd.Parameters.AddWithValue("@MSSV", _mssv);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi lưu xong
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
    }
}
