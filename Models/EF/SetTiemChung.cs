namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SetTiemChung")]
    public partial class SetTiemChung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SetTiemChung()
        {
            GoiTiemChungs = new HashSet<GoiTiemChung>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string ten { get; set; }

        public int id_loaiTiemChung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoiTiemChung> GoiTiemChungs { get; set; }

        public virtual LoaiTiemChung LoaiTiemChung { get; set; }
    }
}
