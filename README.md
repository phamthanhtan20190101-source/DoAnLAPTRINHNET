# 🏠 HỆ THỐNG QUẢN LÝ KÝ TÚC XÁ (Dormitory Management System)

![.NET](https://img.shields.io/badge/.NET-Framework%204.8-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue?style=for-the-badge)

---

## 👨‍🏫 Thông Tin Đồ Án

- **Giảng viên hướng dẫn:** Nguyễn Thị Mỹ Truyền
- **Môn học:** Lập trình .NET (TIE501)
- **Năm thực hiện:** 2025

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
2. Mở file script `Databasdth235822@student.agu.edu.vn



