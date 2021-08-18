drop table if exists 
				MuiTiem,
				PhieuDangKyTiemChung, ChiTietGoiTC,
				TreEm, GoiTiemChung, SetTiemChung,
				PhuHuynh, Vaccine, LoaiTiemChung, ChiDinh, NhanVien
use DAPM;
set dateformat dmy;
-- Dùng kết hợp với [N'dd--mm--yyyy hh:mm:ss'] để định dạng ngày giờ theo kiểu dd-mm-yyyy
go

create table PhuHuynh
(
	id int not null identity(1,1) primary key,
	ten nvarchar(100) not null,
	sdt char(10) not null unique
		check (sdt like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	cmnd varchar(20) not null unique,
	taiKhoan varchar(100) not null unique,
	matKhau varchar(100) not null
)
go

insert into PhuHuynh
values	(N'Nguyễn Công Hùng', '0905467839', '201938385', 'tung12', '202cb962ac59075b964b07152d234b70'),
		(N'Trần Châu Linh', '0914535347', '201838482', 'linhlinh', '202cb962ac59075b964b07152d234b70'),
		(N'Trần Lê Quốc Tú', '0823485921', '201385384', 'tu', '202cb962ac59075b964b07152d234b70'),
		(N'Nguyễn Thị Thu Hoa', '0928148385', '201348521', 'hoa', '202cb962ac59075b964b07152d234b70'),
		(N'Châu Huệ Mẫn', '0943567421', '201385921', 'man', '202cb962ac59075b964b07152d234b70')
go

create table NhanVien
(
	id int not null identity(1,1) primary key,
	ten nvarchar(100) not null,
	sdt char(10) not null unique
		check (sdt like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	chucVu nvarchar(100) not null
		CHECK (chucVu like N'Quản lý' or chucVu like N'Y tế'),
	taiKhoan varchar(100) not null unique,
	matKhau varchar(100) not null,
	trangThai tinyint not null
)
go

insert into NhanVien
values	(N'Nguyễn Hải Hậu', '0905467839', N'Y tế', 'hau12', '202cb962ac59075b964b07152d234b70', 1),
		(N'Trần Minh Châu', '0914535347', N'Y tế', 'chau13', '202cb962ac59075b964b07152d234b70', 1),
		(N'Đặng Mai Anh', '0823485921', N'Y tế', 'anh', '202cb962ac59075b964b07152d234b70', 1),
		(N'Nguyễn Văn Phúc', '0928148385', N'Quản lý', 'phuc', '202cb962ac59075b964b07152d234b70', 1),
		(N'Lê Văn Nin', '0943567421', N'Quản lý', 'nin', '202cb962ac59075b964b07152d234b70', 1)
go

create table TreEm
(
	id int not null identity(1,1) primary key,
	ten nvarchar(100) not null,
	id_phuHuynh int not null foreign key references PhuHuynh(id) ON DELETE CASCADE,
	gioiTinh NVARCHAR(3) not null
		CHECK (gioiTinh like 'Nam' or gioiTinh like N'Nữ'),
	ngaySinh date not null
)
go

insert into TreEm
values	(N'Nguyễn Hà An', 1, N'Nữ', '07-03-2019'),
		(N'Nguyễn Công Hậu', 1, N'Nam', '03-07-2020'),
		(N'Lê Thị Ngọc Ánh', 2, N'Nữ', '21-02-2019'),
		(N'Trần Lê Minh Vương', 3, N'Nam', '14-11-2020'),
		(N'Nguyễn Ngọc Minh', 4, N'Nữ', '22-01-2020'),
		(N'Nguyễn Minh Sơn', 5, N'Nam', '01-03-2018'),
		(N'Nguyễn Minh Tú', 5, N'Nam', '02-02-2019'),
		(N'Nguyễn Thị Ngọc Linh', 5, N'Nữ', '01-02-2021')
go

create table LoaiTiemChung
(
	id int not null identity(1,1) primary key,
	ten nvarchar(200) not null,
)
go

insert into LoaiTiemChung
values	(N'Tiêm Lẻ'),
		(N'Gói dành cho trẻ em từ 0-12 tháng'),
		(N'Gói dành cho trẻ em từ 0-24 tháng'),
		(N'Gói dành cho trẻ em từ 6-24 tháng')
go

create table SetTiemChung
(
	id int not null identity(1,1) primary key,
	ten nvarchar(200) not null,
	id_loaiTiemChung int not null foreign key references LoaiTiemChung(id) ON DELETE CASCADE
)
go

insert into SetTiemChung
values	(N'Tiêm Lẻ', 1),
		(N'Set vắc xin Hexaxim', 2),
		(N'Set vắc xin Infanrix', 2),
		(N'Set vắc xin Hexaxim-Rotarix-Varilrix', 3),
		(N'Set vắc xin Hexaxim-Rotarix-Varilrix', 4),
		(N'Set vắc xin Pentaxim – Rotateq', 2),
		(N'Set vắc xin Hexaxim', 4)
go

create table GoiTiemChung
(
	id int not null identity(1,1) primary key,
	ten nvarchar(200) not null,
	id_setTiemChung int not null foreign key references SetTiemChung(id) ON DELETE CASCADE
)
go

insert into GoiTiemChung
values	(N'Tiêm lẻ', 1),
		(N'Gói linh động 1', 2),
		(N'Gói linh động 2', 2),
		(N'Gói linh động 1', 3),
		(N'Gói linh động 2', 3),
		(N'Gói linh động 0-12 tháng', 4),
		(N'Gói linh động 12-24 tháng', 5),
		(N'Có Varivax', 5),
		(N'Có Varilrix', 5),
		(N'Gói cơ bản', 6),
		(N'Gói linh động 1', 6),
		(N'Gói linh động 2', 6),
		(N'Gói cơ bản', 7),
		(N'Gói linh động 1', 7),
		(N'Gói linh động 2', 7)
go

create table ChiDinh
(
	id int not null identity(1,1) primary key,
	phongBenh nvarchar(300) not null
)
go

insert into ChiDinh
values	(N'Bạch hầu, ho gà, uốn ván, bại liệt và Hib'),
		(N'Bạch hầu, ho gà, uốn ván, bại liệt, Hib và viêm gan B'),
		(N'Rota virus'),
		(N'Các bệnh do phế cầu'),
		(N'Lao'),
		(N'Viêm gan B trẻ em'),
		(N'Viêm màng não mô cầu BC'),
		(N'Viêm màng não mô cầu ACYW'),
		(N'Sởi'),
		(N'Sởi – Quai bị – Rubella'),
		(N'Thủy đậu'),
		(N'Cúm'),
		(N'Phòng uốn ván'),
		(N'Viêm não Nhật Bản'),
		(N'Vắc xin phòng dại'),
		(N'Bạch hầu – Uốn ván – Ho gà'),
		(N'Bạch hầu – Ho gà – Uốn ván – Bại liệt'),
		(N'Bạch hầu – Uốn ván'),
		(N'Viêm gan B và Viêm gan A'),
		(N'Viêm gan A'),
		(N'Thương hàn'),
		(N'Các bệnh do Hib'),
		(N'Tả'),
		(N'Sốt vàng')
go

create table Vaccine
(
	id int not null identity(1,1) primary key,
	ten nvarchar(300) not null,
	id_chiDinh int not null foreign key references ChiDinh(id) ON DELETE CASCADE,
	giaTien int not null,
	ngaySanXuat date not null,
	hanSuDung int not null,
	soLuong int not null,
	nhaSanXuat nvarchar(200) not null,
	ghiChu nvarchar(max) not null,
	hinhAnh varchar(max)
)
go

insert into Vaccine
values	(N'Pentaxim (5in1)', 1, 785000, '15-08-2021', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/PENTAXIM-5.jpg'),
		(N'Infanrix IPV- HIB', 1, 791000, '15-08-2021', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/06/vac-xin-5-trong-1-infanrix-ipv-hib.jpg'),
		(N'Infanrix Hexa (6in1)', 2, 1015000, '15-08-2021', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/INFANRIX-6.jpg'),
		(N'Hexaxim (6in1)', 2, 1048000, '01-01-2019', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2018/06/vc-hexaxim.jpg'),
		(N'Rotateq', 3, 665000, '01-01-2019', 3, 100, N'Mỹ', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/ROTATEQ.jpg'),
		(N'Rotarix', 3, 825000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/ROTARIX.jpg'),
		(N'Rotavin', 3, 490000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2020/05/vacxin-rotavin-m1.jpg'),
		(N'Synflorix', 4, 1045000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/SYNFLORIX.jpg'),
		(N'Prevenar 13', 4, 1290000, '01-01-2019', 3, 100, N'Anh', N'Không', 'https://vnvc.vn/wp-content/uploads/2019/11/prevenar.jpg'),
		(N'BCG', 5, 125000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/bcg.jpg'),
		(N'Euvax B 0.5ml', 6, 116000, '01-01-2019', 3, 100, N'Hàn Quốc', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/EUVAX.jpg'),
		(N'Engerix B 0,5ml', 6, 190000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/ENGERIX-B.jpg'),
		(N'Hepavax Gene 0.5ml', 6, 145000, '01-01-2019', 3, 100, N'Hàn Quốc', N'Không', 'https://img.thuocbietduoc.com.vn/images/drugs/2018/9/vac-xin-Hepavax-gene_11-20918.JPG'),
		(N'Mengoc BC', 7, 295000, '01-01-2019', 3, 100, N'Cu Ba', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/VA-MENGOC-BC.jpg'),
		(N'Menactra', 8, 1260000, '01-01-2019', 3, 100, N'Mỹ', N'Không', 'https://vnvc.vn/wp-content/uploads/2020/02/menactra-1.jpg'),
		(N'MVVac (Lọ 5ml)', 9, 315000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/vacxin-MVVac.jpg'),
		(N'MVVac (Liều 0.5ml)', 9, 180000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/vacxin-MVVac.jpg'),
		(N'MMR II (3 in 1)', 10, 305000, '01-01-2019', 3, 100, N'Mỹ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/MMR-II.jpg'),
		(N'Measles- Mumps- Rubella', 10, 198000, '01-01-2019', 3, 100, N'Ấn Độ', N'Không', 'https://www.seruminstitute.com/images/products/viral-measles-mumps-rubella.jpg'),
		(N'Varivax', 11, 915000, '01-01-2019', 3, 100, N'Mỹ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/VARIVAX.jpg'),
		(N'Varilrix', 11, 940000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/01/vacxin-varilrix-2.jpg'),
		(N'Varicella', 11, 700000, '01-01-2019', 3, 100, N'Hàn Quốc', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/Varicella.jpg'),
		(N'Vaxigrip 0.25ml', 12, 305000, '01-01-2019', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/VAXYLGRYP.jpg'),
		(N'VAT', 13, 115000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/uonvanhapphu.jpg'),
		(N'SAT (huyết thanh kháng độc tố uốn ván)', 13, 100000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/huyet-thanh-uon-van.jpg'),
		(N'Imojev', 14, 665000, '01-01-2019', 3, 100, N'Thái Lan', N'Không', 'https://vnvc.vn/wp-content/uploads/2019/07/Imojev-boom.png'),
		(N'Jevax 1ml', 14, 170000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/JEVAX.jpg'),
		(N'Verorab 0,5ml (TB, TTD)', 15, 323000, '01-01-2019', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/VERORAB.jpg'),
		(N'Abhayrab 0,5ml (TB)', 15, 255000, '01-01-2019', 3, 100, N'Ấn Độ', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/vacxin-ABHAYRAB.jpg'),
		(N'Abhayrab 0,2ml (TTD)', 15, 215000, '01-01-2019', 3, 100, N'Ấn Độ', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/vacxin-ABHAYRAB.jpg'),
		(N'Adacel', 16, 620000, '01-01-2019', 3, 100, N'Canada', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/ADACELpsd.jpg'),
		(N'Boostrix', 16, 735000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2020/02/boostrix.jpg'),
		(N'Tetraxim', 17, 458000, '01-01-2019', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/TETRAXIM.jpg'),
		(N'Uốn ván, bạch hầu hấp phụ (Td)-Lọ 0,5ml', 18, 125000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2020/07/VX_BachHau.jpg'),
		(N'Uốn ván, bạch hầu hấp phụ (Td)-Liều 0,5 ml', 18, 95000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2020/07/VX_BachHau.jpg'),
		(N'Uốn ván, bạch hầu hấp phụ (Td)-Lọ 5ml', 18, 580000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2020/07/VX_BachHau.jpg'),
		(N'Twinrix', 19, 560000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/TWINRIX.jpg'),
		(N'Havax 0,5ml', 20, 235000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2021/02/HAVAX.jpg'),
		(N'Avaxim 80U', 20, 590000, '01-01-2019', 3, 100, N'Bỉ', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/121-Avaxim.jpg'),
		(N'Typhim VI', 21, 281000, '01-01-2019', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2017/04/TYPHIM.jpg'),
		(N'Typhoid VI', 21, 145000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2019/12/TYPHOID-VI-1.jpg'),
		(N'Quimihib', 22, 239000, '01-01-2019', 3, 100, N'Cu Ba', N'Không', 'https://vinmec-prod.s3.amazonaws.com/images/20200425_081447_545467_Lich_tiem_vacxin_Qu.max-1800x1800.png'),
		(N'mORCVAX', 23, 115000, '01-01-2019', 3, 100, N'Việt Nam', N'Không', 'https://vnvc.vn/wp-content/uploads/2019/06/vacxin-mocrvax.jpg'),
		(N'Stamaril', 24, 585000, '01-01-2019', 3, 100, N'Pháp', N'Không', 'https://vnvc.vn/wp-content/uploads/2019/07/STAMARIL-vacxin-phong-benh-sot-vang.jpg')
go

create table ChiTietGoiTC
(
	id int not null identity(1,1) primary key,
	id_goiTiemChung int not null foreign key references GoiTiemChung(id) ON DELETE CASCADE,
	id_vaccine int not null foreign key references Vaccine(id) ON DELETE CASCADE,
	lieu int not null,
)
go

insert into ChiTietGoiTC
values	(1, 1, 1),
		(2, 6, 2),
		(2, 4, 3),
		(2, 8, 4),
		(2, 23, 2),
		(2, 17, 1),
		(2, 26, 1),
		(2, 15, 1),
		(3, 5, 3),
		(3, 4, 3),
		(3, 8, 4),
		(3, 23, 2),
		(3, 17, 1),
		(3, 26, 1),
		(3, 15, 1),
		(4, 6, 2),
		(4, 3, 3),
		(4, 8, 4),
		(4, 23, 2),
		(4, 17, 1),
		(4, 26, 1),
		(4, 15, 1),
		(5, 5, 3),
		(5, 3, 3),
		(5, 8, 4),
		(5, 23, 2),
		(5, 17, 1),
		(5, 26, 1),
		(5, 15, 1),
		(6, 6, 2),
		(6, 4, 3),
		(6, 8, 4),
		(6, 23, 2),
		(6, 17, 1),
		(6, 18, 1),
		(6, 37, 1),
		(6, 21, 2),
		(6, 26, 1),
		(6, 15, 2),
		(7, 6, 2),
		(7, 4, 3),
		(7, 1, 1),
		(7, 8, 4),
		(7, 23, 2),
		(7, 17, 1),
		(7, 18, 1),
		(7, 37, 1),
		(7, 21, 2),
		(7, 26, 1),
		(7, 15, 2),
		(7, 41, 1),
		(8, 5, 3),
		(8, 1, 3),
		(8, 8, 4),
		(8, 23, 2),
		(8, 17, 1),
		(8, 18, 1),
		(8, 37, 1),
		(8, 20, 1),
		(8, 12, 3),
		(8, 26, 1),
		(8, 15, 2),
		(9, 5, 3),
		(9, 1, 3),
		(9, 8, 4),
		(9, 23, 2),
		(9, 17, 1),
		(9, 18, 1),
		(9, 37, 1),
		(9, 21, 2),
		(9, 12, 3),
		(9, 26, 1),
		(9, 15, 2),
		(10, 4, 1),
		(10, 23, 1),
		(10, 20, 1),
		(10, 26, 1),
		(10, 37, 1),
		(10, 41, 1),
		(11, 4, 1),
		(11, 23, 1),
		(11, 20, 2),
		(11, 26, 1),
		(11, 37, 2),
		(11, 41, 1),
		(11, 18, 1),
		(11, 15, 2),
		(12, 4, 1),
		(12, 23, 1),
		(12, 21, 2),
		(12, 26, 1),
		(12, 37, 2),
		(12, 41, 1),
		(12, 18, 1),
		(12, 15, 2),
		(13, 3, 1),
		(13, 23, 1),
		(13, 20, 1),
		(13, 26, 1),
		(13, 37, 1),
		(13, 41, 1),
		(14, 3, 1),
		(14, 23, 1),
		(14, 20, 2),
		(14, 26, 1),
		(14, 37, 2),
		(14, 41, 1),
		(14, 18, 1),
		(14, 15, 2),
		(15, 3, 1),
		(15, 23, 1),
		(15, 21, 2),
		(15, 26, 1),
		(15, 37, 2),
		(15, 41, 1),
		(15, 18, 1),
		(15, 15, 2)
go

create table PhieuDangKyTiemChung
(
	id int not null identity(1,1) primary key,
	id_treEm int not null foreign key references TreEm(id),
	id_goiTiemChung int not null foreign key references GoiTiemChung(id),
	id_nhanVien int foreign key references NhanVien(id),
	ngayYeuCau datetime not null,
	tongTien int not null default 0,
	ngayHen datetime
)
go

create trigger tongtien_dk
on PhieuDangKyTiemChung
for insert
as
begin
declare @t table(id_goi int, id_vac int ,gia money)
insert into @t select inserted.id_goiTiemChung,Vaccine.id, Vaccine.giaTien
				from Vaccine,ChiTietGoiTC,inserted 
				where ChiTietGoiTC.id_goiTiemChung = inserted.id_goiTiemChung 
				AND Vaccine.id=ChiTietGoiTC.id_vaccine
update PhieuDangKyTiemChung set tongTien=(select SUM(gia) from @t) from inserted 
	where PhieuDangKyTiemChung.id_goiTiemChung = inserted.id_goiTiemChung
end
go

insert into PhieuDangKyTiemChung
values	(1, 2, 4, '02-07-2021 08:00:00', 0, '05-07-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(2, 3, 5, '07-08-2021 08:00:00', 0, '11-07-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(3, 4, 4, '13-07-2021 08:00:00', 0, '15-07-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(4, 5, 5, '17-07-2021 08:00:00', 0, '19-07-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(5, 6, 4, '21-07-2021 08:00:00', 0, '23-07-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(1, 7, 4, '25-07-2021 08:00:00', 0, '02-08-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(2, 8, 5, '02-08-2021 08:00:00', 0, '07-08-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(3, 9, 4, '07-08-2021 08:00:00', 0, '09-08-2021 08:00:00')
insert into PhieuDangKyTiemChung
values(4, 10, NULL, '10-08-2021 08:00:00', 0, NULL)
insert into PhieuDangKyTiemChung
values(5, 11, NULL, '13-08-2021 08:00:00', 0, NULL)
insert into PhieuDangKyTiemChung
values(1, 10, NULL, '14-08-2021 08:00:00', 0, NULL)
go


create table MuiTiem
(
	id int not null identity(1,1) primary key,
	id_dangKy int not null foreign key references PhieuDangKyTiemChung(id) ON DELETE CASCADE,
	id_chiTietGoiTC int not null foreign key references ChiTietGoiTC(id) ON DELETE CASCADE,
	id_nhanVien int foreign key references NhanVien(id) ON DELETE CASCADE,
	ngayTiem datetime,
	trangThai nvarchar(100) not null,
	ghiChu nvarchar(max) default N'Bình thường'
)
go

insert into MuiTiem
values	(1, 2, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(1, 2, 2, '07-08-2021 8:00:00', N'Đã tiêm', N'Sốt nhẹ'),
		(1, 3, 1, '09-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 3, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 3, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 4, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 4, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 4, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 4, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 5, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 5, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 6, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 7, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),
		(1, 8, 2, '11-08-2021 8:00:00', N'Đã tiêm', default),

		(2, 9, 1, '11-08-2021 10:00:00', N'Đã tiêm', N'Sốt cao'),
		(2, 9, 1, '12-08-2021 10:00:00', N'Đã tiêm', default),
		(2, 9, 1, '13-08-2021 10:00:00', N'Đã tiêm', N'Sốt nhẹ'),
		(2, 10, 1, '14-08-2021 10:00:00', N'Đã tiêm', N'Ngứa'),
		(2, 10, NULL, '15-08-2021 10:00:00', N'Đặt hẹn', NULL),
		(2, 10, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 11, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 11, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 11, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 11, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 12, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 12, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 13, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 14, NULL, NULL, N'Chưa tiêm', NULL),
		(2, 15, NULL, NULL, N'Chưa tiêm', NULL),

		(3, 16, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 16, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 17, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 17, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 17, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 18, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 18, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 18, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 18, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 19, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 19, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 20, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 21, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(3, 22, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),

		(4, 23, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 23, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 23, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 24, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 24, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 24, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 25, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 25, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 25, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 25, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 26, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 26, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 27, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 28, 1, '05-08-2021 10:00:00', N'Đã tiêm', default),
		(4, 29, 1, '05-08-2021 10:00:00', N'Đã tiêm', default)
go

select m.* from PhieuDangKyTiemChung as p, MuiTiem as m
where p.id = 1 and p.id = m.id_dangKy and m.id_chiTietGoiTC = 7

select * from PhieuDangKyTiemChung
