namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDangKyTiemChung")]
    public partial class PhieuDangKyTiemChung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDangKyTiemChung()
        {
            MuiTiems = new HashSet<MuiTiem>();
        }

        public int id { get; set; }

        public int id_treEm { get; set; }

        public int id_goiTiemChung { get; set; }

        public int id_nhanVien { get; set; }

        public DateTime ngayYeuCau { get; set; }

        public int tongTien { get; set; }

        public DateTime? ngayHen { get; set; }

        public virtual GoiTiemChung GoiTiemChung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuiTiem> MuiTiems { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual TreEm TreEm { get; set; }
    }
}
