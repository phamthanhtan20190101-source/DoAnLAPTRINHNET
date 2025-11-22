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
        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        //string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
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
            cboMaToaNha.Text = "";
            cboLoaiPhong.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            txtGia.Text = "";
            txtTienDN.Text = "";
        }

        private bool KiemTraNhapLieu(bool ktMaPhong = true)
        {
            // 1. Kiểm tra để trống các trường bắt buộc
            if (string.IsNullOrWhiteSpace(cboMaToaNha.Text) ||
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
            // Mặc định không chọn cái nào (để người dùng tự chọn) hoặc chọn cái đầu
            cboTrangThai.SelectedIndex = -1;

            string sQueryToaNha = "SELECT MaToaNha FROM ToaNha"; // Lấy danh sách mã tòa nhà
            daPhong = new SqlDataAdapter(sQueryToaNha, connectionString);
            daPhong.Fill(ds, "ToaNha"); // Đổ vào DataSet bảng tên là "ToaNha"
            cboMaToaNha.DataSource = ds.Tables["ToaNha"];
            cboMaToaNha.DisplayMember = "MaToaNha"; // Hiển thị Mã
            cboMaToaNha.ValueMember = "MaToaNha";   // Giá trị lấy cũng là Mã
            cboMaToaNha.SelectedIndex = -1; // Mặc định không chọn gì

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
            dgDSP.ClearSelection();
            dgDSP.CurrentCell = null; // Đảm bảo không có ô nào bị focus viền xanh

            // 2. Xóa trắng các ô Textbox (đề phòng sự kiện SelectionChanged đã lỡ chạy 1 lần)
            Reset(); // Hoặc ResetFormState(); (tùy tên hàm bạn đặt)

            // 3. Đưa con trỏ nháy vào ô Mã phòng để nhập luôn
            // Lưu ý: Trong Form_Load, lệnh .Focus() thường không chạy, phải dùng ActiveControl
            this.ActiveControl = txtMaPhong;
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
                    //txtMaPhong.Enabled = false;
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

        private bool KiemTraTrangThai(string maPhong, string loaiPhong, string trangThaiSua)
        {
            int soLuongToiDa = 0;
            int soLuongHienTai = 0;

            // 1. Lấy số lượng tối đa (Sức chứa)
            if (loaiPhong.Contains("4")) soLuongToiDa = 4;
            else if (loaiPhong.Contains("6")) soLuongToiDa = 6;

            // 2. Lấy số lượng hiện tại SinhVien
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

            // Logic B: Phòng chưa đủ người thì không được sửa thành 'Đầy'
            if (soLuongHienTai < soLuongToiDa && trangThaiSua == "Đầy")
            {
                MessageBox.Show($"Phòng {maPhong} có {soLuongHienTai}/{soLuongToiDa} sinh viên.\nKhông thể chuyển trạng thái sang 'Đầy'!",
                                "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Không hợp lệ
            }

            return true; // Hợp lệ
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
            if (!KiemTraSucChua(cboMaToaNha.Text)) return;

            // 2. Kiểm tra trùng Mã phòng trong lưới (Vì chưa lưu xuống SQL nên phải check trên lưới)
            DataRow rowKiemTra = dt.Rows.Find(txtMaPhong.Text);
            if (rowKiemTra != null)
            {
                MessageBox.Show("Mã phòng này đã tồn tại trong danh sách (chưa lưu vào csdl)!", "Thông báo");
                return;
            }
            
            try
            {
                //Tạo một dòng mới từ DataTable
                DataRow row = dt.NewRow();

                //Gán giá trị từ TextBox vào dòng đó
                row["MaPhong"] = txtMaPhong.Text;
                row["MaToaNha"] = cboMaToaNha.Text;
                row["LoaiPhong"] = cboLoaiPhong.Text;
                // Chuyển đổi số an toàn
                row["Gia"] = decimal.Parse(txtGia.Text);
                row["TrangThai"] = cboTrangThai.Text;

                row["TienDienNuoc"] = txtTienDN.Text;

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

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            dgDSP.ClearSelection();
            dgDSP.CurrentCell = null; // Xóa luôn viền nét đứt (focus) quanh ô

            // 2. Xóa trắng các ô nhập liệu (Hàm Reset bạn đã viết trước đó)
            Reset();

            // 3. Đảm bảo ô Mã phòng được MỞ KHÓA (Enabled = true)
            // (Phòng trường hợp bạn vừa bấm vào dòng nào đó để Sửa và Mã phòng bị khóa lại)
            //txtMaPhong.Enabled = true;

            // Nếu bạn có khóa cboMaToaNha khi sửa thì mở lại luôn
            // cboMaToaNha.Enabled = true; 

            // 4. Đưa con trỏ chuột về ô Mã phòng để tiện nhập liệu mới
            txtMaPhong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Ràng buộc: Phải chọn phòng trước khi sửa
            // (Mã phòng là khóa chính dùng để tìm dòng cần sửa)
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ràng buộc: Kiểm tra nhập liệu (Rỗng, sai định dạng số...)
            // Truyền false vì không cần check lại Regex của Mã phòng (Mã phòng ko đổi)
            if (!KiemTraNhapLieu(false)) return;

            if (KiemTraTrangThai(txtMaPhong.Text, cboLoaiPhong.Text, cboTrangThai.Text) == false)
            {
                return; // Nếu hàm trả về false (không hợp lệ) thì dừng lại ngay
            }

            // 3. Tìm dòng dữ liệu trong DataTable (Bộ nhớ tạm)
            DataRow row = dt.Rows.Find(txtMaPhong.Text);

            if (row == null)
            {
                MessageBox.Show("Không tìm thấy Mã phòng này trong dữ liệu nguồn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Ràng buộc LOGIC: Kiểm tra Sức chứa nếu thay đổi Tòa Nhà
            // Lấy mã tòa nhà cũ đang lưu trong dòng
            string toaNhaCu = row["MaToaNha"].ToString();
            // Lấy mã tòa nhà mới người dùng vừa chọn
            string toaNhaMoi = cboMaToaNha.Text;

            // Chỉ kiểm tra sức chứa nếu người dùng CỐ TÌNH đổi tòa nhà khác
            if (toaNhaCu != toaNhaMoi)
            {
                // Nếu tòa nhà mới đã đầy -> Không cho chuyển sang
                if (KiemTraSucChua(toaNhaMoi) == false)
                {
                    // Trả lại giá trị tòa nhà cũ để người dùng biết
                    cboMaToaNha.Text = toaNhaCu;
                    return;
                }
            }

            try
            {
                // 5. Bắt đầu cập nhật vào DataTable
                row.BeginEdit(); // Mở chế độ chỉnh sửa dòng

                row["MaToaNha"] = cboMaToaNha.Text;
                row["LoaiPhong"] = cboLoaiPhong.Text;

                // Chuyển đổi số (Vì hàm KiemTraNhapLieu đã check rồi nên Parse an toàn)
                row["Gia"] = decimal.Parse(txtGia.Text);
                row["TrangThai"] = cboTrangThai.Text;

                // Xử lý tiền điện nước (nếu rỗng thì cho là 0)
                decimal tienDN = 0;
                if (!string.IsNullOrWhiteSpace(txtTienDN.Text))
                {
                    decimal.TryParse(txtTienDN.Text, out tienDN);
                }
                row["TienDienNuoc"] = tienDN;

                row.EndEdit(); // Kết thúc chỉnh sửa, Grid sẽ tự cập nhật

                MessageBox.Show("Đã sửa thông tin (Nhấn 'Lưu' để ghi xuống CSDL).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // (Tùy chọn) Bỏ chọn sau khi sửa xong
                // btnBoChon_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Phải chọn phòng trước khi xóa
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //Tìm dòng dữ liệu trong DataTable
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
                this.BindingContext[dt].EndCurrentEdit(); // Chốt dữ liệu
                daPhong = new SqlDataAdapter("SELECT * FROM Phong", connectionString);
                new SqlCommandBuilder(daPhong);

                daPhong.Update(dt);
                dt.AcceptChanges();
                MessageBox.Show("Đã lưu thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void ibtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Close();
            }
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
            frm.ShowDialog(); // Hiện form lên
            
        }
    }
    
}
