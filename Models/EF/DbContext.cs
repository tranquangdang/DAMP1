using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class WebDbContext : DbContext
    {
        public WebDbContext()
            : base("name=DbContextWeb")
        {
        }

        public virtual DbSet<ChiDinh> ChiDinhs { get; set; }
        public virtual DbSet<ChiTietGoiTC> ChiTietGoiTCs { get; set; }
        public virtual DbSet<GoiTiemChung> GoiTiemChungs { get; set; }
        public virtual DbSet<LoaiTiemChung> LoaiTiemChungs { get; set; }
        public virtual DbSet<MuiTiem> MuiTiems { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuDangKyTiemChung> PhieuDangKyTiemChungs { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<SetTiemChung> SetTiemChungs { get; set; }
        public virtual DbSet<TreEm> TreEms { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiDinh>()
                .HasMany(e => e.Vaccines)
                .WithRequired(e => e.ChiDinh)
                .HasForeignKey(e => e.id_chiDinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietGoiTC>()
                .HasMany(e => e.MuiTiems)
                .WithRequired(e => e.ChiTietGoiTC)
                .HasForeignKey(e => e.id_chiTietGoiTC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoiTiemChung>()
                .HasMany(e => e.ChiTietGoiTCs)
                .WithRequired(e => e.GoiTiemChung)
                .HasForeignKey(e => e.id_goiTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoiTiemChung>()
                .HasMany(e => e.PhieuDangKyTiemChungs)
                .WithRequired(e => e.GoiTiemChung)
                .HasForeignKey(e => e.id_goiTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTiemChung>()
                .HasMany(e => e.SetTiemChungs)
                .WithRequired(e => e.LoaiTiemChung)
                .HasForeignKey(e => e.id_loaiTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.chucVu)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.MuiTiems)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.id_nhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuDangKyTiemChungs)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.id_nhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDangKyTiemChung>()
                .HasMany(e => e.MuiTiems)
                .WithRequired(e => e.PhieuDangKyTiemChung)
                .HasForeignKey(e => e.id_dangKy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.cmnd)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .HasMany(e => e.TreEms)
                .WithRequired(e => e.PhuHuynh)
                .HasForeignKey(e => e.id_phuHuynh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTiemChung>()
                .HasMany(e => e.GoiTiemChungs)
                .WithRequired(e => e.SetTiemChung)
                .HasForeignKey(e => e.id_setTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TreEm>()
                .HasMany(e => e.PhieuDangKyTiemChungs)
                .WithRequired(e => e.TreEm)
                .HasForeignKey(e => e.id_treEm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vaccine>()
                .Property(e => e.hinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Vaccine>()
                .HasMany(e => e.ChiTietGoiTCs)
                .WithRequired(e => e.Vaccine)
                .HasForeignKey(e => e.id_vaccine)
                .WillCascadeOnDelete(false);
        }
    }
}
