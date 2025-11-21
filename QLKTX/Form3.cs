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
    public partial class Form3 : Form
    {
        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        //string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
        private string _mssv;
        public Form3(string mssv)
        {
            InitializeComponent();
            _mssv = mssv;
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            HienThiThongTinSinhVien();
        }
        private void HienThiThongTinSinhVien()
        {
            // Câu lệnh SQL lấy tất cả thông tin của sinh viên có MSSV trùng khớp
            string query = "SELECT * FROM SinhVien WHERE MSSV = @MSSV";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền tham số MSSV an toàn
                        cmd.Parameters.AddWithValue("@MSSV", _mssv);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy sinh viên
                            {
                                // Gán dữ liệu từ CSDL vào các TextBox trên giao diện
                                // (Tên TextBox dựa theo file Designer bạn gửi)
                                txtmssv.Text = reader["MSSV"].ToString();
                                txthoten.Text = reader["HoTen"].ToString();
                                txtlop.Text = reader["Lop"].ToString();
                                txtsdt.Text = reader["SDT"].ToString();
                                txtgioitinh.Text = reader["GioiTinh"].ToString();
                                txtquequan.Text = reader["QueQuan"].ToString();
                                txtmaphong.Text = reader["MaPhong"].ToString();
                                txttrangthai.Text = reader["TrangThaiTienPhong"].ToString();

                                // Xử lý ngày tháng (Tránh lỗi nếu ngày bị NULL)
                                if (reader["NgaySinh"] != DBNull.Value)
                                {
                                    txtngaysinh.Text = Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy");
                                }

                                if (reader["NgayVao"] != DBNull.Value)
                                {
                                    // Lưu ý: Trong Designer của bạn tên là "ngayvao" (viết thường)
                                    ngayvao.Text = Convert.ToDateTime(reader["NgayVao"]).ToString("dd/MM/yyyy");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin sinh viên này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message, "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}