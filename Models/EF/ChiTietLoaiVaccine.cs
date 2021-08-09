namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietLoaiVaccine")]
    public partial class ChiTietLoaiVaccine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietLoaiVaccine()
        {
            MuiTiems = new HashSet<MuiTiem>();
        }

        public int id { get; set; }

        public int id_dangKy { get; set; }

        public int id_goiTiemChung { get; set; }

        public int id_vaccine { get; set; }

        public DateTime? ngayTiem { get; set; }

        public virtual PhieuDangKyTiemChung PhieuDangKyTiemChung { get; set; }

        public virtual GoiTiemChung GoiTiemChung { get; set; }

        public virtual Vaccine Vaccine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuiTiem> MuiTiems { get; set; }
    }
}
