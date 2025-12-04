# 🏠 HỆ THỐNG QUẢN LÝ KÝ TÚC XÁ (Dormitory Management System)

![.NET](https://img.shields.io/badge/.NET-Framework%204.8-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue?style=for-the-badge)

📘 *Đồ án môn Lập trình .Net (TIE501)*  

---

## 🧩 Giới thiệu  
Đây là **Đồ án Quản lý ký túc xá** được phát triển trong khuôn khổ môn **Lập trình .Net** tại **Trường Đại học An Giang – Khoa Công nghệ Thông tin**.  
Ứng dụng được xây dựng bằng **C#**
> Đồ án giúp số hóa quy trình quản lý sinh viên, phòng ở và tài chính tại ký túc xá trường Đại học.

---

## 🚀 Tính Năng Nổi Bật

Hệ thống được phân quyền chi tiết cho **Ban Quản Lý** và **Sinh Viên**.

### 👮‍♂️ Dành cho Quản Lý (Admin)
- **Quản lý Sinh viên:**
  - **Thêm, Xóa, Sửa** hồ sơ sinh viên.
  - **Tự động gợi ý** phòng còn trống và phù hợp giới tính.
  - **Tìm kiếm thông minh** (theo MSSV, Tên) và **Lọc theo tòa nhà/phòng**.
- **Quản lý Phòng & Tòa nhà:**
  - **Sơ đồ trực quan (Card View):** Xem trạng thái của từng tòa nhà và sinh viên cư trú tại từng tòa nhà/phòng.
  - **Kiểm soát sức chứa:** Chặn thêm người nếu phòng đã đầy (logic chặt chẽ).
  - **Cập nhật giá phòng, điện nước**.
- **Quản lý Tài chính:**
  - 💰 **Ghi nhận đóng tiền:** Tính tổng tiền tự động (Giá phòng + Điện nước).
  - 🧾 **Xuất phiếu thu:** Xuất hóa đơn ra file `.txt` để in ấn.
  - 🔒 **Giao dịch an toàn:** Sử dụng `SQL Transaction` để đảm bảo dữ liệu tiền bạc không bị sai lệch.

### 👨‍🎓 Dành cho Sinh Viên (User)
- **Tra cứu thông tin:** Xem hồ sơ cá nhân, thông tin phòng đang ở.
- **Lịch sử giao dịch:** Xem lại chi tiết các lần đóng tiền (Ngày đóng, Số tiền) để dễ kiểm soát các lần giao dịch.
- **Tiện ích:** Tự đổi mật khẩu và cập nhật số điện thoại liên lạc.

---

## 🛠 Công Nghệ Sử Dụng

| Thành phần | Công nghệ / Kỹ thuật |
| :--- | :--- |
| **Ngôn ngữ** | C# (Visual Studio 2022) |
| **Framework** | .NET Framework (Windows Forms) |
| **Cơ sở dữ liệu** | Microsoft SQL Server |
| **Kết nối dữ liệu** | **ADO.NET** (Mô hình Disconnected & Connected) |
| **Giao diện** | `DataGridView`, `FlowLayoutPanel`, **UserControl** (Tự thiết kế) |
| **Thư viện Icon** | **FontAwesome.Sharp** (NuGet) |
| **Kỹ thuật nâng cao**| `SqlTransaction`, `UserControl`, `Disconnected Architecture` |

---

## ⚙️ Hướng Dẫn Cài Đặt

Để chạy dự án trên máy của bạn, hãy làm theo các bước sau:

### Bước 1: Chuẩn bị Database
1. Mở **SQL Server Management Studio (SSMS)**.
2. Mở file script `Database.sql` (nằm trong thư mục `Database` của dự án).
3. Chạy (**Execute**) để tạo CSDL `QL_KyTucXa01` và các bảng dữ liệu.

### Bước 2: Cấu hình Code
1. Mở dự án bằng **Visual Studio**.
2. Tìm đến file `DatabaseHelper.cs` (hoặc phần khai báo biến ở đầu các Form).
3. Sửa dòng `connectionString` cho đúng với tên máy của bạn:
```csharp
// Thay .\SQLEXPRESS bằng tên máy SQL của bạn
string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";

```

### Bước 3: Cài đặt Thư viện
Nếu báo lỗi thiếu thư viện, hãy:
1. Chuột phải vào **Solution** -> chọn **Manage NuGet Packages**.
2. Tìm và cài đặt gói: **`FontAwesome.Sharp`**.
3. Nhấn **Restore** các gói nếu cần.

### Bước 4: Chạy ứng dụng
Nhấn **F5** hoặc nút **Start** 

---

## 📂 Cấu Trúc Dự Án

```text
QLKTX/
├── Database/            # Script tạo CSDL SQL
├── UserControls/        # Các thẻ giao diện tự tạo (UCToaNha, UCPhong)
├── Forms/               
│   ├── Form1.cs         # Quản lý Sinh viên
│   ├── Form2.cs         # Đăng nhập
│   ├── Form4.cs         # Thu phí & Xuất hóa đơn
│   ├── Form5.cs         # Quản lý Phòng
│   └── ...
├── Program.cs           # Điểm khởi chạy ứng dụng
└── README.md            # Tài liệu hướng dẫn

```text

## 👨‍💻 Nhóm thực hiện đồ án
| Họ tên         | Mã số SV  |
|----------------|-----------|
| Phạm Thanh Tân | DTH235761 | 
| Vũ Thị Yến Vy  | DTH235820 |
| Nguyễn Thị Mỹ Xuyên  |  | 
---

## 🏁 Kết luận
Dự án Ứng dụng quản lý ký túc xá giúp sinh viên vận dụng kiến thức **Python, Tkinter, SQL Server** để xây dựng ứng dụng thực tế phục vụ công tác quản lý ký túc xá một cách hiệu quả và chính xác.  

## 📜 Giấy phép
Dự án phục vụ mục đích **học tập** trong môn *Lập trình Python – Đại học An Giang*.  
Không sử dụng cho mục đích thương mại. 

## 📬 Liên hệ
Nếu bạn có bất kỳ thắc mắc hoặc góp ý nào về dự án, vui lòng liên hệ với các thành viên của nhóm thực hiện qua email:

📧 Phạm Thanh Tân – tan_dth234761@student.agu.edu.vn
📧 Vũ Thị Yến Vy – vy_dth235820@student.agu.edu.vn

