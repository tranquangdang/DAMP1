namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TreEm")]
    public partial class TreEm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TreEm()
        {
            PhieuDangKyTiemChungs = new HashSet<PhieuDangKyTiemChung>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string ten { get; set; }

        public int id_phuHuynh { get; set; }

        [Required]
        [StringLength(3)]
        public string gioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDangKyTiemChung> PhieuDangKyTiemChungs { get; set; }

        public virtual PhuHuynh PhuHuynh { get; set; }
    }
}
