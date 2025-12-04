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
        //string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
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

                dt.DefaultView.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Added;
                dgDSP.DataSource = dt;
                dgDSP.Columns["MaPhong"].HeaderText = "Mã Phòng";
                dgDSP.Columns["MaPhong"].Width = 250;
                dgDSP.Columns["LoaiPhong"].HeaderText = "Loại Phòng";
                dgDSP.Columns["LoaiPhong"].Width = 250;
                dgDSP.Columns["Gia"].HeaderText = "Giá";
                dgDSP.Columns["Gia"].Width = 300;
                dgDSP.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgDSP.Columns["TrangThai"].Width = 250; 
                dgDSP.Columns["MaToaNha"].HeaderText = "Mã Tòa Nhà";
                dgDSP.Columns["MaToaNha"].Width = 250;
                dgDSP.Columns["TienDienNuoc"].HeaderText = "Tiền Điện Nước";
                dgDSP.Columns["TienDienNuoc"].Width = 250;
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
                MessageBox.Show("Lỗi khi tải danh sách tòa nhà: " + ex.Message);
            }
        }
        private void Reset()
        {
            txtMaPhong.Text = "";
            cboMaToaNha.Text = "";
            cboLoaiPhong.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            txtGia.Text = "";
            txtTienDN.Text = "";
        }
        private bool KiemTraNhapLieu(bool ktMaPhong = true)
        {
            if (string.IsNullOrWhiteSpace(cboMaToaNha.Text) ||
                string.IsNullOrWhiteSpace(cboLoaiPhong.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text)  ||
                string.IsNullOrWhiteSpace(cboTrangThai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    txtMaPhong.Clear();
                    txtMaPhong.Focus();
                    return false;
                }
            }

            decimal gia;
            if (!decimal.TryParse(txtGia.Text, out gia) || gia < 0)
            {
                MessageBox.Show("Giá phòng phải là một số và lớn hơn không.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Clear();
                txtGia.Focus(); 
                return false;
            }

            decimal tienDN;
            if (!string.IsNullOrWhiteSpace(txtTienDN.Text))
            {
                if (!decimal.TryParse(txtTienDN.Text, out tienDN) || tienDN <= 0)
                {
                    MessageBox.Show("Tiền điện nước phải là số và lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTienDN.Clear();
                    txtTienDN.Focus(); 
                    return false;
                }
            }
            return true;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            TaiDuLieuLenDataGird();
            TaiToaNhaVaoTimKiem();

            string sQueryLoaiPhong="SELECT DISTINCT LoaiPhong FROM Phong";
            daPhong= new SqlDataAdapter(sQueryLoaiPhong, connectionString);
            daPhong.Fill(ds, "LoaiPhong");
            cboLoaiPhong.DataSource = ds.Tables["LoaiPhong"];
            cboLoaiPhong.DisplayMember = "LoaiPhong";
            cboLoaiPhong.ValueMember = "LoaiPhong";

            string sQueryTrangThai = "SELECT DISTINCT TrangThai FROM Phong WHERE TrangThai IS NOT NULL AND TrangThai <> ''";
            daPhong = new SqlDataAdapter(sQueryTrangThai, connectionString);
            daPhong.Fill(ds, "TrangThai");
            cboTrangThai.DataSource = ds.Tables["TrangThai"];
            cboTrangThai.DisplayMember = "TrangThai";
            cboTrangThai.ValueMember = "TrangThai";

            cboTrangThai.SelectedIndex = -1;

            string sQueryToaNha = "SELECT MaToaNha FROM ToaNha"; 
            daPhong = new SqlDataAdapter(sQueryToaNha, connectionString);
            daPhong.Fill(ds, "ToaNha"); // Đổ vào DataSet bảng tên là "ToaNha"
            cboMaToaNha.DataSource = ds.Tables["ToaNha"];
            cboMaToaNha.DisplayMember = "MaToaNha"; // Hiển thị Mã
            cboMaToaNha.ValueMember = "MaToaNha";   // Giá trị lấy cũng là Mã
            cboMaToaNha.SelectedIndex = -1; // Mặc định không chọn gì

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Phong";
                daPhong = new SqlDataAdapter(sql, conn);

                //TỰ ĐỘNG TẠO LỆNH INSERT/UPDATE/DELETE 
                SqlCommandBuilder cmb = new SqlCommandBuilder(daPhong);

                //Đổ vào DataTable
                dt = new DataTable();
                daPhong.Fill(dt);

                // Gán khóa chính cho DataTable (Để tìm dòng khi Sửa dễ hơn)
                //  MaPhong là khóa chính
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MaPhong"] };

                // Hiển thị lên lưới
                dgDSP.DataSource = dt;
            }
            //dgDSP.ClearSelection();
            //dgDSP.CurrentCell = null; 

            //Reset(); 

            //this.ActiveControl = cboMaToaNha;
        }
        private void dgDSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDSP.SelectedRows.Count > 0 && dgDSP.CurrentRow != null && !dgDSP.CurrentRow.IsNewRow)
            {
                try
                {
                    DataGridViewRow row = dgDSP.SelectedRows[0];

                    txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString();
                    cboMaToaNha.Text = row.Cells["MaToaNha"].Value?.ToString();

                    // Với ComboBox, gán .Text để hiển thị mục tương ứng
                    cboLoaiPhong.Text = row.Cells["LoaiPhong"].Value?.ToString();
                    cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();

                    // Ô Giá phòng
                    txtGia.Text = row.Cells["Gia"].Value?.ToString();
                   
                    if (row.Cells["TienDienNuoc"].Value != null)
                    {
                        txtTienDN.Text = row.Cells["TienDienNuoc"].Value.ToString();
                    }
                    else
                    {
                        txtTienDN.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
                }
            }
            else
            {
                Reset();
            }
        }

        private bool KiemTraSucChua(string maToaNha)
        {
            int sucChuaToiDa = 0;
            int soPhongHienTai = 0;

            // Lấy Sức Chứa Tối Đa từ SQL (Bảng ToaNha)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT SoLuongPhong FROM ToaNha WHERE MaToaNha = @ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maToaNha);
                        object result = cmd.ExecuteScalar();
                        if (result != null) sucChuaToiDa = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                    return false;
                }
            }

            //  Đếm số phòng hiện tại TRÊN LƯỚI (DataTable)
            foreach (DataRow row in dt.Rows)
            {
                // Chỉ đếm các dòng chưa bị xóa
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row["MaToaNha"].ToString() == maToaNha)
                    {
                        soPhongHienTai++;
                    }
                }
            }

            // So sánh
            if (soPhongHienTai >= sucChuaToiDa)
            {
                MessageBox.Show($"Tòa nhà {maToaNha} đã đầy ({soPhongHienTai}/{sucChuaToiDa} phòng)!\nKhông thể thêm phòng mới.",
                                "Quá tải", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Chặn
            }

            return true; // Cho phép thêm
        }

        private bool KiemTraTrangThai(string maPhong, string loaiPhong, string trangThaiSua)
        {
            int soLuongToiDa = 0;
            int soLuongHienTai = 0;

            // Lấy số lượng tối đa (Sức chứa)
            if (loaiPhong.Contains("4")) soLuongToiDa = 4;
            else if (loaiPhong.Contains("6")) soLuongToiDa = 6;

            // Lấy số lượng hiện tại SinhVien
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Đếm xem có bao nhiêu sinh viên đang ở phòng này
                    string query = "SELECT COUNT(*) FROM SinhVien WHERE MaPhong = @MaPhong";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                        // ExecuteScalar trả về cột đầu tiên của dòng đầu tiên (chính là số lượng)
                        soLuongHienTai = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi đếm sinh viên: " + ex.Message);
                return false; // Gặp lỗi thì chặn luôn
            }

            // Phòng có người ở thì không được sửa thành 'Trống'
            if (soLuongHienTai > 0 && trangThaiSua == "Trống")
            {
                MessageBox.Show($"Phòng {maPhong} đang có {soLuongHienTai} sinh viên.\nKhông thể chuyển trạng thái sang 'Trống'!",
                                "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Không hợp lệ
            }

            //  Phòng chưa đủ người thì không được sửa thành 'Đầy'
            if (soLuongHienTai < soLuongToiDa && trangThaiSua == "Đầy")
            {
                MessageBox.Show($"Phòng {maPhong} có {soLuongHienTai}/{soLuongToiDa} sinh viên.\nKhông thể chuyển trạng thái sang 'Đầy'!",
                                "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }

            return true; 
        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (dt.GetChanges() != null)
            {
                // Nếu có thay đổi -> Hỏi xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy tất cả các thay đổi chưa lưu không?",
                                                      "Xác nhận hủy",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Hoàn tác dữ liệu trong DataTable
                    dt.RejectChanges();
                    MessageBox.Show("Đã hủy các thay đổi chưa lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return; 
                }
            }

            // Làm sạch giao diện 
            Reset();
            dgDSP.ClearSelection();
            dgDSP.CurrentCell = null;

            // Đưa con trỏ về ô đầu tiên
            this.ActiveControl = cboMaToaNha;

        }

        private void cboLocToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboLocToaNha.SelectedIndex == -1)
            {
                return;
            }
            //Nếu chọn tất cả
            if (cboLocToaNha.SelectedIndex == 0)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                string maToaNhaCanLoc = cboLocToaNha.Text;

                //Lọc theo cột MaToaNha
                dt.DefaultView.RowFilter = $"MaToaNha = '{maToaNhaCanLoc}'";

                // Kiểm tra nếu không có kết quả nào
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
            if (!KiemTraNhapLieu(true)) return;

            if (cboTrangThai.Text == "Đầy")
            {
                MessageBox.Show("Phòng chưa có sinh viên nên không thể là 'Đầy'.\nVui lòng chọn trạng thái 'Trống'.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus(); 
                cboTrangThai.SelectedIndex=-1;
                return; 
            }

            //KIỂM TRA SỨC CHỨA 
            if (KiemTraSucChua(cboMaToaNha.Text) == false) return;

            //Kiểm tra đặt tên
            string maToaNha = cboMaToaNha.Text;
            if (!txtMaPhong.Text.StartsWith(maToaNha))
            {
                MessageBox.Show($"Mã phòng phải bắt đầu bằng mã tòa nhà -'{maToaNha}'...", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Clear();
                txtMaPhong.Focus();
                return;
            }
            //Kiểm tra trùng mã
            if (dt.Rows.Find(txtMaPhong.Text) != null)
            {
                MessageBox.Show("Mã phòng này đã tồn tại!", "Trùng lặp");
                return;
            }

            try
            {
                DataRow row = dt.NewRow();
                row["MaPhong"] = txtMaPhong.Text;
                row["MaToaNha"] = cboMaToaNha.Text;
                row["LoaiPhong"] = cboLoaiPhong.Text;
                row["Gia"] = decimal.Parse(txtGia.Text);
                row["TrangThai"] = "Trống";
                row["TienDienNuoc"] = txtTienDN.Text;

                dt.Rows.Add(row); // Thêm

                Reset();
                cboTrangThai.Text = "Trống";
                MessageBox.Show("Đã thêm vào danh sách tạm (Nhấn 'Lưu' để ghi xuống CSDL)", "Thông báo");
                cboMaToaNha.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            dgDSP.ClearSelection();
            dgDSP.CurrentCell = null; 
            Reset();
            this.ActiveControl = cboMaToaNha;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa trên danh sách!", "Thông báo");
                return;
            }

            // === CHẶN SỬA KHÓA CHÍNH ===
            // Lấy dữ liệu gốc đang nằm trên lưới (Database)
            DataGridViewRow dongDangChon = dgDSP.SelectedRows[0];
            string maPhongGoc = dongDangChon.Cells["MaPhong"].Value.ToString();
            string maToaNhaGoc = dongDangChon.Cells["MaToaNha"].Value.ToString();

            // So sánh với dữ liệu người dùng đang nhập trên ô Textbox/Combobox
            if (txtMaPhong.Text != maPhongGoc)
            {
                MessageBox.Show("Không được phép sửa Mã Phòng (Khóa chính)!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                txtMaPhong.Text = maPhongGoc; // Tự động trả về giá trị cũ
                return;
            }

            if (cboMaToaNha.Text != maToaNhaGoc)
            {
                MessageBox.Show($"Không được phép chuyển phòng {maPhongGoc} sang tòa nhà khác!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                cboMaToaNha.Text = maToaNhaGoc; // Tự động trả về giá trị cũ
                return;
            }
            // ==========================================================

            // Kiểm tra nhập liệu (Bỏ qua check mã phòng vì đã check ở trên rồi)
            if (!KiemTraNhapLieu(false)) return;

            // Kiểm tra Logic Trạng thái
            if (KiemTraTrangThai(txtMaPhong.Text, cboLoaiPhong.Text, cboTrangThai.Text) == false)
            {
                return;
            }

            // Thực hiện Sửa vào DataTable
            DataRow row = dt.Rows.Find(txtMaPhong.Text);

            if (row != null)
            {
                try
                {
                    row.BeginEdit();

                    // Chỉ cập nhật các thông tin được phép sửa
                    row["LoaiPhong"] = cboLoaiPhong.Text;
                    row["Gia"] = decimal.Parse(txtGia.Text);
                    row["TrangThai"] = cboTrangThai.Text;

                    decimal tienDN = 0;
                    if (!string.IsNullOrWhiteSpace(txtTienDN.Text))
                        decimal.TryParse(txtTienDN.Text, out tienDN);
                    row["TienDienNuoc"] = tienDN;

                    row.EndEdit();

                    MessageBox.Show("Đã sửa thông tin (Nhấn 'Lưu' để ghi xuống CSDL).");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlCheck = "SELECT COUNT(*) FROM SinhVien WHERE MaPhong = @ma";
                    using (SqlCommand cmd = new SqlCommand(sqlCheck, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", txtMaPhong.Text);
                        int soSinhVien = (int)cmd.ExecuteScalar(); // Lấy số lượng sinh viên

                        if (soSinhVien > 0)
                        {
                            MessageBox.Show($"Phòng {txtMaPhong.Text} đang có {soSinhVien} sinh viên.\nBạn phải chuyển sinh viên đi nơi khác trước khi xóa!",
                                            "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra sinh viên: " + ex.Message);
                return;
            }
            //Phải chọn phòng trước khi xóa
            
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DataRow row = dt.Rows.Find(txtMaPhong.Text);
            if (row == null)
            {
                MessageBox.Show("Không tìm thấy Mã phòng này trong dữ liệu nguồn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                row.Delete();

                MessageBox.Show("Đã xóa phòng (Nhấn 'Lưu' để ghi xuống CSDL).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                this.BindingContext[dt].EndCurrentEdit();

                // Kiểm tra có thay đổi không
                if (dt.GetChanges() == null)
                {
                    MessageBox.Show("Không có thay đổi nào cần lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Thực hiện Lưu
                daPhong = new SqlDataAdapter("SELECT * FROM Phong", connectionString);
                new SqlCommandBuilder(daPhong); // Tự sinh lệnh Insert/Update/Delete

                daPhong.Update(dt);
                dt.AcceptChanges(); // Xác nhận đồng bộ

                MessageBox.Show("Đã lưu thành công vào CSDL!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtnThoat_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ibtnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
        }

        private void ibtnTTToaNha_Click(object sender, EventArgs e)
        {
            this.Hide();
            TTToaNha frm = new TTToaNha();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog(); 
        }
    }
    
}
