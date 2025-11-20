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
        public Form3()
        {
            InitializeComponent();
        }
        
        

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadSinhVienData();
        }
        // tải dữ liệu sinh viên lên DataGridView
        private void LoadSinhVienData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SinhVien"; // Giả sử bảng sinh viên tên là SinhVien
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Giả sử bạn có một DataGridView tên là dataGridView1
            }
        }

    }




}