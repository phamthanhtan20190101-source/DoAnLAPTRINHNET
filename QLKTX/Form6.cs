using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class Form6 : Form
    {
        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        //string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
        
        private string _mssv;
        private string _hoten;
        private string _phong;
        public Form6(string mssv, string hoten, string phong)
        {
            InitializeComponent();
            _mssv = mssv;
            _hoten = hoten;
            _phong = phong;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            txtMSSV.Text = _mssv;
            txtHoTen.Text = _hoten;
            txtPhong.Text = _phong;

            // 2. Tải dữ liệu lịch sử
            TaiLichSu();
        }

        private void TaiLichSu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Câu lệnh lấy lịch sử của ĐÚNG sinh viên đó (WHERE MSSV = @MSSV)
                    string query = @"
                        SELECT MaThanhToan AS [Mã GD],
                               ThangDongTien AS [Tháng], 
                               NamDongTien AS [Năm], 
                               SoTien AS [Số Tiền], 
                               NgayDong AS [Ngày Đóng]
                        FROM LichSuDongTien 
                        WHERE MSSV = @MSSV 
                        ORDER BY NgayDong DESC"; // Sắp xếp ngày mới nhất lên đầu

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MSSV", _mssv);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Đổ dữ liệu vào Grid
                        dgvLichSu.DataSource = dt;

                        // Định dạng cột tiền cho đẹp (ví dụ: 1,000,000)
                        if (dgvLichSu.Columns["Số Tiền"] != null)
                        {
                            dgvLichSu.Columns["Số Tiền"].DefaultCellStyle.Format = "N0";
                            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }

                        // Tính tổng tiền
                        TinhTongTien(dt);

                        // Thông báo nếu chưa đóng lần nào
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Sinh viên này chưa có lịch sử giao dịch nào.", "Thông tin");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử: " + ex.Message);
            }
        }
        private void TinhTongTien(DataTable dt)
        {
            decimal tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Số Tiền"] != DBNull.Value)
                {
                    tong += Convert.ToDecimal(row["Số Tiền"]);
                }
            }
            
            lblTongTien.Text = "Tổng tiền đã đóng: " + tong.ToString("N0") + " VNĐ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại
            this.Close();

        }

    }
}
