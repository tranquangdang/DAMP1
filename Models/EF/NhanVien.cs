namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            MuiTiems = new HashSet<MuiTiem>();
            PhieuDangKyTiemChungs = new HashSet<PhieuDangKyTiemChung>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string ten { get; set; }

        [Required]
        [StringLength(10)]
        public string sdt { get; set; }

        [Required]
        [StringLength(100)]
        public string chucVu { get; set; }

        [Required]
        [StringLength(100)]
        public string taiKhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string matKhau { get; set; }

        public byte trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuiTiem> MuiTiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDangKyTiemChung> PhieuDangKyTiemChungs { get; set; }
    }
}
