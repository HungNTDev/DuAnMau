create database Quan_Ly_Ban_Hang

use Quan_Ly_Ban_Hang

create table NhanVien(
id int identity(1,1) not null,
MaNV nvarchar(20) not null,
Email nvarchar(50) not null,
TenNV nvarchar(50) not null,
DiaChi nvarchar(100) not null,
VaiTro tinyint not null,
TinhTrang tinyint not null,
MatKhau nvarchar(50)
primary key (MaNV)
)

create table Hang(
MaHang int not null,
TenHang nvarchar(50) not null,
SoLuong int not null,
DonGiaNhap float not null,
DonGiaBan float not null,
HinhAnh nvarchar(500) not null,
GhiChu nvarchar(20) not null,
MaNV nvarchar(20) not null
primary key (MaHang)
)

create table KhachHang(
DienThoai nvarchar(15) not null,
TenKhach nvarchar(50) not null,
DiaChi nvarchar(100) not null,
Phai nvarchar(5) not null,
MaNV nvarchar(20) not null
primary key (DienThoai)
)

alter table KhachHang
add constraint fk_nv_kh
foreign key (MaNV) references NhanVien (MaNV) 

alter table Hang
add constraint fk_h_nv
foreign key (MaNV) references NhanVien (MaNV)

insert into NhanVien (MaNV, Email, TenNV, DiaChi, VaiTro, TinhTrang, MatKhau) values
('NV001','hungntps38090@gmail.com',N'Nguyễn Tuấn Hùng',N'Quận 12',1,1,'1234'),
('NV002','nguyenhunghocmon02@gmail.com',N'Trần Thanh Hưng',N'Củ Chi',1,1,'123')

update NhanVien set VaiTro = 0 where MaNV ='NV002'

--insert into Hang (MaHang,TenHang,SoLuong,DonGiaNhap,DonGiaBan,HinhAnh,GhiChu,MaNV) values--

insert into KhachHang (DienThoai,TenKhach,DiaChi,Phai,MaNV) values
('0836753008',N'Lê Trần Tâm',N'Huyện Hóc Môn',N'Nam','NV002'),
('0346202953',N'Trần Thanh Hoàng',N'Quận 12',N'Nữ','NV002')

update NhanVien
set MatKhau = '3244185981728979115075721453575112'
where MaNV = 'NV002'



alter table NhanVien
add constraint df_mk
Default '2331542419640203562132429613354120146463' for MatKhau

update NhanVien set VaiTro = '0' where MaNV = 'NV002'
-- Đăng nhập
create procedure DangNhap @email nvarchar(50),
                          @matkhau nvarchar(50) 
as
begin 
     declare @status int 
	 if exists(select * from NhanVien where Email =@email and MatKhau = @matkhau)
	    set @status =1
	 else 
	   set @status =0
	   select @status
end

-- Quên mật khẩu
create procedure QuenMatKhau @email nvarchar(50)
as
begin 
     declare @status int 
	 if exists(select * from NhanVien where Email =@email )
	    set @status =1
	 else 
	   set @status =0
	   select @status
end

-- Tạo mật khẩu mới 
alter procedure TaoMatKhauMoi @email nvarchar(50),
                               @matkhau nvarchar(50)
as
  begin
       update NhanVien set MatKhau = @matkhau 
	   where Email = @email
  end

-- Lấy Vai trò Nhân Viên

alter procedure LayVaiTroNV @email nvarchar(50)
as
  begin 
       declare @status int 
	 if exists(select VaiTro from NhanVien where Email =@email )
	    set @status =1
	 else 
	   set @status =0
	   select @status
 end

 exec LayVaiTroNV 'nguyenhunghocmon02@gmail.com'

 -- Thay đổi mật khẩu

 create procedure ThayDoimatKhau (@email nvarchar(50),
                                  @opwd nvarchar(50),
								  @npwd nvarchar(50))
as
  declare @op nvarchar(50)
  select @op= MatKhau from NhanVien where Email = @email
  if @op = @opwd
  begin 
       update NhanVien set MatKhau = @npwd where Email = @email
	   return 1
  end
  else 
       return -1

-- Danh sách Nhân Viên
create procedure DanhSachNV as 
begin
     select Email, TenNV, DiaChi, VaiTro, TinhTrang
	 from NhanVien
end

-- Thêm Nhân Viên
create procedure InsertNhanVien 
                                @email nvarchar(50),
								@tennv nvarchar(50),
								@diachi nvarchar(100),
								@vaitro tinyint,
								@tinhtrang tinyint
as 
  begin 
       declare @Manv nvarchar(20);
	   declare @Id int;

	   select @Id = ISNULL(MAX(ID),0) + 1 from NhanVien
	   select @Manv = 'NV' + Right('0000' + CAST(@Id AS nvarchar(4)),4)
	   insert into NhanVien (MaNV, Email, TenNV, DiaChi, VaiTro, TinhTrang) values 
	   (@Manv, @email, @tennv, @diachi, @vaitro, @tinhtrang) 
 end

 -- Sửa nhân viên
 create procedure UpdateNhanVien 
                                 @email nvarchar(50),
								@tennv nvarchar(50),
								@diachi nvarchar(100),
								@vaitro tinyint,
								@tinhtrang tinyint
as
  begin
       update NhanVien set TenNV = @tennv, DiaChi = @diachi,
	                       VaiTro = @vaitro, TinhTrang= @tinhtrang
		where Email = @email
 end

 -- Xoá nhân viên
 create procedure DeleteNhanVien @email nvarchar(50)
 as 
   begin
        delete from NhanVien where Email = @email
	end
                     
-- Tìm kiếm Nhân Viên  
create procedure SearchNhanVien @tenNV nvarchar(50)
as
  begin 
      set nocount on;
	  select Email, TenNV, DiaChi, VaiTro, TinhTrang
	  from NhanVien where TenNV like + '%' +@tenNV + '%' 
  end

-- Danh sách khách hàng
create procedure DanhSachKhach 
as 
  begin 
        set nocount on;
		select * from KhachHang 
  end



-- Thêm khách hàng 
alter procedure InsertKhach @dienthoai nvarchar(15),
                             @tenkhach nvarchar(50),
							 @diachi nvarchar(100),
							 @phai nvarchar(5),
							 @email nvarchar(50)
as
  begin 
       declare @Manv nvarchar(20);
	   select @Manv = MaNV from NhanVien where Email = @email
	   
	   insert into KhachHang (DienThoai, TenKhach, DiaChi, Phai, MaNV)
	   values (@dienthoai,@tenkhach,@diachi,@phai, @Manv)
  end

  exec InsertKhach '9',N'Huy',N'12',N'Nam','nguyenhunghocmon02@gmail.com'

-- Sửa khách hàng
create procedure UpdateKhachHang @dienthoai nvarchar(15),
                                 @tenkhach nvarchar(50),
								 @diachi nvarchar(100),
								 @phai nvarchar(5)
as 
  begin
       update KhachHang set TenKhach =@tenkhach, DiaChi=@diachi, @phai = Phai
	   where DienThoai=@dienthoai
  end

-- Xoá khách hàng
create procedure DeleteKhachHang  @dienthoai nvarchar(15)
as 
  begin
       delete from KhachHang
	   where DienThoai = @dienthoai
  end 

-- Tìm kiếm khách hàng 
create procedure SearchKhach @dienthoai nvarchar(15)
as 
  begin
       set nocount on;
	   select * from KhachHang where DienThoai like + '%' +@dienthoai + '%'
  end

  -- Lấy danh sách sản phẩm
  create procedure DanhSachSanPham
  as
    begin 
	     set nocount on; 
		 select * from Hang
	end

-- Thêm sản phẩm
alter procedure InsertSanPham @tenHang nvarchar(50),
                               @soLuong int,
							   @dongianhap float,
							   @dongiaban float,
							   @hinhanh nvarchar(500),
							   @ghichu nvarchar(20),
							   @email nvarchar(50)
as 
 begin 
       declare @Manv nvarchar(20) 
	   select @Manv = MaNV from NhanVien where Email = @email 
	   
	   DECLARE @NextID INT;
	   DEclare @MaHang int;
       SELECT @NextID = ISNULL(MAX(MaHang), 0) + 1 FROM Hang;
    SET @MaHang = @NextID;

	  insert into Hang (MaHang,TenHang,SoLuong,DonGiaNhap,DonGiaBan,HinhAnh,GhiChu,MaNV)
	  values (@MaHang,@tenHang,@soLuong,@dongianhap,@dongiaban,@hinhanh,@ghichu,@Manv)
 end

 exec InsertSanPham  N'Áo',2,2500,2800,N'F:\Project\DuAnMau_PS38090\Source_code\GUI_QLBanHang\img\vn-11134207-7r98o-logb0vutj4qfeb.jpg',N'Áo nam','nguyenhunghocmon02@gmail.com'
 -- Sửa hàng
create procedure UpdateHang @mahang int,
                            @tenhang nvarchar(50),
                            @soluong int,
						    @dongianhap float,
						    @dongiaban float,
							@hinhanh nvarchar(500),
							@ghichu nvarchar(20)
as 
  begin
       update Hang set TenHang =@tenhang, SoLuong=@soluong, DonGiaNhap = @dongianhap,
	                   DonGiaBan = @dongiaban, HinhAnh = @hinhanh, GhiChu = @ghichu
	   where MaHang = @mahang
  end

  -- Xoá hàng
  create procedure  DeleteHang @mahang int
as 
  begin
       delete from Hang
	   where MaHang = @mahang
  end 

  -- Search hàng
create procedure SearchHang @tenhang nvarchar(50)
as 
  begin
       set nocount on;
	   select * from Hang where TenHang like + '%' +@tenhang + '%'
  end

  -- Thống kê tồn kho
create procedure ThongKeTonKho
as 
  begin 
	   select TenHang, sum(SoLuong)
	   from Hang
	   group by TenHang
  end

	-- Thống kê sản phẩm
create procedure ThongKeSP
as 
  begin
       select h.MaNV, TenNV, Count(MaHang)
	   from Hang h inner join NhanVien nv on h.MaNV = nv.MaNV
	   group by h.MaNV, TenNV
 end

