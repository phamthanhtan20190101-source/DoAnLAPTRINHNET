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
using System.Text.RegularExpressions;

namespace QLKTX
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
        DataSet ds = new DataSet();
        SqlDataAdapter daPhong;
        DataTable dt;
        private void TaiDuLieuLenDataGird()
        {
            string query = "SELECT * FROM Phong";

            try
            {
            
                daPhong = new SqlDataAdapter(query, connectionString);
                SqlCommandBuilder builder = new SqlCommandBuilder(daPhong);
                dt = new DataTable();
                daPhong.Fill(dt);

                // 5. === SỬA LỖI HIỂN THỊ TẠI ĐÂY ===
                // Mặc định, DataView chỉ hiển thị các dòng 'Current'
                // Chúng ta phải CÀI ĐẶT cho nó hiển thị cả các dòng 'Added' (Mới thêm).
                dt.DefaultView.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Added;
                dgDSP.DataSource = dt;
                dgDSP.Columns["MaPhong"].HeaderText = "Mã Phòng";
                dgDSP.Columns["MaPhong"].Width = 190;
                dgDSP.Columns["LoaiPhong"].HeaderText = "Loại Phòng";
                dgDSP.Columns["LoaiPhong"].Width = 190;
                dgDSP.Columns["Gia"].HeaderText = "Giá";
                dgDSP.Columns["Gia"].Width = 190;
                dgDSP.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgDSP.Columns["TrangThai"].Width = 190;
                dgDSP.Columns["MaToaNha"].HeaderText = "Mã Tòa Nhà";
                dgDSP.Columns["MaToaNha"].Width = 190;
                dgDSP.Columns["TienDienNuoc"].HeaderText = "Tiền Điện Nước";
                dgDSP.Columns["TienDienNuoc"].Width = 190;
            }
            catch (Exception ex)    
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiToaNhaVaoTimKiem()
        {
            cboLocToaNha.Items.Clear();
            cboLocToaNha.Items.Add("--- Tất cả ---");

            string query = "SELECT MaToaNha FROM ToaNha ORDER BY MaToaNha";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cboLocToaNha.Items.Add(reader["MaToaNha"].ToString());
                        }
                    }
                }
                cboLocToaNha.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tòa nhà tìm kiếm: " + ex.Message);
            }
        }
        private void Reset()
        {
            txtMaPhong.Text = "";
            txtMaToaNha.Text = "";
            cboLoaiPhong.Items.Clear(); 
            cboTrangThai.Items.Clear();
            txtGia.Text = "";
            txtTienDN.Text = "";
        }

        private bool KiemTraNhapLieu(bool ktMaPhong = true)
        {
            // 1. Kiểm tra để trống các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaToaNha.Text) ||
                string.IsNullOrWhiteSpace(cboLoaiPhong.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text)  ||
                string.IsNullOrWhiteSpace(cboTrangThai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Tòa nhà, Loại phòng, Giá, Trạng thái).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ktMaPhong)
            {
                if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPhong.Focus();
                    return false;
                }
                if (!Regex.IsMatch(txtMaPhong.Text, @"^[ABCD][0-9]{3}$"))
                {
                    MessageBox.Show("Mã phòng không hợp lệ!\nPhải bắt đầu bằng A, B, C, D và kèm 3 số (Ví dụ: A101, C205).",
                                    "Lỗi định dạng",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPhong.Focus();
                    return false;
                }
            }

            //Kiểm tra Giá phòng (Phải là số và không âm)
            decimal gia;
            // Thử ép kiểu sang số, nếu thất bại (nhập chữ) hoặc số nhỏ hơn 0 thì báo lỗi
            if (!decimal.TryParse(txtGia.Text, out gia) || gia < 0)
            {
                MessageBox.Show("Giá phòng phải là một số và lớn hơn không.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus(); // Đưa con trỏ về ô Giá
                return false;
            }

            // 4. Kiểm tra Tiền điện nước 
            decimal tienDN;
            if (!string.IsNullOrWhiteSpace(txtTienDN.Text) && !decimal.TryParse(txtTienDN.Text, out tienDN))
            {
                MessageBox.Show("Tiền điện nước phải là số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            TaiDuLieuLenDataGird();
            TaiToaNhaVaoTimKiem();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // 1. Lấy dữ liệu
                string sql = "SELECT * FROM Phong";
                daPhong = new SqlDataAdapter(sql, conn);

                // 2. TỰ ĐỘNG TẠO LỆNH INSERT/UPDATE/DELETE (Bắt buộc dòng này)
                SqlCommandBuilder cmb = new SqlCommandBuilder(daPhong);

                // 3. Đổ vào DataTable
                dt = new DataTable();
                daPhong.Fill(dt);

                // 4. Gán khóa chính cho DataTable (Để tìm dòng khi Sửa dễ hơn)
                // Giả sử cột MaPhong là khóa chính
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MaPhong"] };

                // 5. Hiển thị lên lưới
                dgDSP.DataSource = dt;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult traloi= MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
        }

        private void dgDSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDSP.SelectedRows.Count > 0 && dgDSP.CurrentRow != null && !dgDSP.CurrentRow.IsNewRow)
            {
                try
                {

                    DataGridViewRow row = dgDSP.SelectedRows[0];

                    txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString();
                    txtMaToaNha.Text = row.Cells["MaToaNha"].Value?.ToString();

                    // Với ComboBox, gán .Text để hiển thị mục tương ứng
                    cboLoaiPhong.Text = row.Cells["LoaiPhong"].Value?.ToString();
                    cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();

                    // Ô Giá phòng
                    // Có thể format thêm dấu phẩy tiền tệ nếu muốn: string.Format("{0:0,0}", ...)
                    txtGia.Text = row.Cells["Gia"].Value?.ToString();

                   
                    if (row.Cells["TienDienNuoc"].Value != null)
                    {
                        txtTienDN.Text = row.Cells["TienDienNuoc"].Value.ToString();
                    }
                    else
                    {
                        txtTienDN.Text = "0";
                    }

                    // 3. Điều khiển trạng thái các nút bấm
                   // btnThem.Enabled = false;  // Khóa nút Thêm (tránh trùng mã)
                   // btnSua.Enabled = true;    // Mở nút Sửa
                   // btnXoa.Enabled = true;    // Mở nút Xóa

                    // Khóa ô Mã phòng không cho sửa (vì là khóa chính)
                    txtMaPhong.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
                }
            }
            else
            {
                // 4. Nếu click vào vùng trống hoặc không chọn dòng nào -> Xóa trắng form
                Reset();
            }
        }

        private bool KiemTraSucChua(string maToaNha)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                    (SELECT SoLuongPhong FROM ToaNha WHERE MaToaNha = @ma) AS MaxSucChua,
                    (SELECT COUNT(*) FROM Phong WHERE MaToaNha = @ma) AS HienCo";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", maToaNha);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int maxSucChua = Convert.ToInt32(reader["MaxSucChua"]);
                            int hienCo = Convert.ToInt32(reader["HienCo"]);

                            // Nếu Số phòng hiện có >= Sức chứa tối đa -> Đã đầy
                            if (hienCo >= maxSucChua)
                            {
                                return false; // Hết chỗ
                            }
                        }
                    }
                    return true; // Còn chỗ
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra sức chứa: " + ex.Message);
                    return false; // Gặp lỗi thì chặn luôn cho an toàn
                }
            }
        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy tất cả các thay đổi chưa lưu không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                dt.RejectChanges();
            MessageBox.Show("Đã hủy các thay đổi chưa lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboLocToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboLocToaNha.SelectedIndex == -1)
            {
                return;
            }
            // 2. Nếu chọn tất cả
            if (cboLocToaNha.SelectedIndex == 0)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                string maToaNhaCanLoc = cboLocToaNha.Text;

                // 3. Lọc theo cột MaToaNha
                dt.DefaultView.RowFilter = $"MaToaNha = '{maToaNhaCanLoc}'";

                // 4. Kiểm tra nếu không có kết quả nào
                if (dt.DefaultView.Count == 0)
                {
                    MessageBox.Show($"Không có phòng nào thuộc tòa nhà {maToaNhaCanLoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset bộ lọc về ban đầu
                    dt.DefaultView.RowFilter = string.Empty;

                    // (Tùy chọn thêm) Đưa ComboBox về lại "Tất cả" để giao diện khớp với dữ liệu
                    cboLocToaNha.SelectedIndex = 0;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập Mã phòng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string filterExpression = string.Format("MaPhong LIKE '%{0}%'", keyword);


            if (dt != null)
            {
                dt.DefaultView.RowFilter = filterExpression;

                if (dgDSP.Rows.Count == 0 || (dgDSP.Rows.Count == 1 && dgDSP.Rows[0].IsNewRow))
                {
                    MessageBox.Show("Không tìm thấy phòng nào với thông tin này.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu & Sức chứa tòa nhà (Code cũ của bạn)
            if (!KiemTraNhapLieu(true)) return;
            if (KiemTraSucChua(txtMaToaNha.Text) == false) return;

            // 2. Kiểm tra trùng Mã phòng trong lưới (Vì chưa lưu xuống SQL nên phải check trên lưới)
            DataRow rowKiemTra = dt.Rows.Find(txtMaPhong.Text);
            if (rowKiemTra != null)
            {
                MessageBox.Show("Mã phòng này đã tồn tại trong danh sách (chưa lưu)!", "Trùng mã");
                return;
            }

            try
            {
                // 3. Tạo một dòng mới từ DataTable
                DataRow row = dt.NewRow();

                // 4. Gán giá trị từ TextBox vào dòng đó
                row["MaPhong"] = txtMaPhong.Text;
                row["MaToaNha"] = txtMaToaNha.Text;
                row["LoaiPhong"] = cboLoaiPhong.Text;
                // Chuyển đổi số an toàn
                row["Gia"] = decimal.Parse(txtGia.Text);
                row["TrangThai"] = cboTrangThai.Text;

                // Nếu có cột Tiền điện nước
                // row["TienDienNuoc"] = 0; 

                // 5. Thêm dòng vào DataTable -> Lưới sẽ tự cập nhật dòng mới
                dt.Rows.Add(row);

                // Xóa trắng để nhập tiếp
                Reset();
                MessageBox.Show("Đã thêm vào danh sách tạm (Nhấn 'Lưu' để ghi xuống CSDL).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }
    }
}
