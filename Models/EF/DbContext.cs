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

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChiDinh> ChiDinhs { get; set; }
        public virtual DbSet<ChiTietGoiTC> ChiTietGoiTCs { get; set; }
        public virtual DbSet<ChiTietLoaiVaccine> ChiTietLoaiVaccines { get; set; }
        public virtual DbSet<GoiTiemChung> GoiTiemChungs { get; set; }
        public virtual DbSet<LoaiTiemChung> LoaiTiemChungs { get; set; }
        public virtual DbSet<MuiTiem> MuiTiems { get; set; }
        public virtual DbSet<PhieuDangKyTiemChung> PhieuDangKyTiemChungs { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<SetTiemChung> SetTiemChungs { get; set; }
        public virtual DbSet<TreEm> TreEms { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ChiDinh>()
                .HasMany(e => e.Vaccines)
                .WithRequired(e => e.ChiDinh)
                .HasForeignKey(e => e.id_chiDinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietLoaiVaccine>()
                .HasMany(e => e.MuiTiems)
                .WithRequired(e => e.ChiTietLoaiVaccine)
                .HasForeignKey(e => e.id_chiTietLoaiVaccine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoiTiemChung>()
                .HasMany(e => e.ChiTietGoiTCs)
                .WithRequired(e => e.GoiTiemChung)
                .HasForeignKey(e => e.id_goiTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoiTiemChung>()
                .HasMany(e => e.ChiTietLoaiVaccines)
                .WithRequired(e => e.GoiTiemChung)
                .HasForeignKey(e => e.id_goiTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTiemChung>()
                .HasMany(e => e.SetTiemChungs)
                .WithRequired(e => e.LoaiTiemChung)
                .HasForeignKey(e => e.id_loaiTiemChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDangKyTiemChung>()
                .HasMany(e => e.ChiTietLoaiVaccines)
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
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.matkhau)
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

            modelBuilder.Entity<Vaccine>()
                .HasMany(e => e.ChiTietLoaiVaccines)
                .WithRequired(e => e.Vaccine)
                .HasForeignKey(e => e.id_vaccine)
                .WillCascadeOnDelete(false);
        }
    }
}
