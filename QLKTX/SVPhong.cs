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
    public partial class SVPhong : Form
    {
        public SVPhong(string maPhong)
        {
            InitializeComponent();
            this.maPhongHienTai = maPhong;

            this.Text = "Chi tiết phòng " + maPhong;

            lblTieuDe.Text = "DANH SÁCH SINH VIÊN PHÒNG " + maPhong;
            lblTieuDe.ForeColor = Color.DarkBlue;
            LoadDataSinhVien();
        }
        string maPhongHienTai;
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
        private void LoadDataSinhVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Câu lệnh lấy thông tin sinh viên đang ở phòng này
                    string sql = @"
                        SELECT 
                            MSSV AS [Mã SV], 
                            HoTen AS [Họ và Tên], 
                            Lop AS [Lớp], 
                            SDT AS [SĐT], 
                            GioiTinh AS [Giới tính],
                            NgaySinh AS [Ngày sinh], 
                            QueQuan AS [Quê quán]
                        FROM SinhVien 
                        WHERE MaPhong = @ma";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@ma", maPhongHienTai);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Đổ vào lưới
                    dgDSSV.DataSource = dt;

                    // Căn chỉnh giao diện lưới cho đẹp
                    dgDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Giãn cột đều
                    dgDSSV.ReadOnly = true; // Chỉ cho xem, không cho sửa ở đây

                    // Kiểm tra nếu phòng trống
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Phòng này hiện chưa có sinh viên nào.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
                }
            }
        }

        private void ibtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
