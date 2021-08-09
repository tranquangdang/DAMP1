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
            ChiTietLoaiVaccines = new HashSet<ChiTietLoaiVaccine>();
        }

        public int id { get; set; }

        public int id_treEm { get; set; }

        public DateTime ngayYeuCau { get; set; }

        public int tongTien { get; set; }

        public DateTime? ngayHen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietLoaiVaccine> ChiTietLoaiVaccines { get; set; }

        public virtual TreEm TreEm { get; set; }
    }
}
