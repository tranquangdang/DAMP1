namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vaccine")]
    public partial class Vaccine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaccine()
        {
            ChiTietGoiTCs = new HashSet<ChiTietGoiTC>();
            ChiTietLoaiVaccines = new HashSet<ChiTietLoaiVaccine>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(300)]
        public string ten { get; set; }

        public int id_chiDinh { get; set; }

        public int giaTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaySanXuat { get; set; }

        public int hanSuDung { get; set; }

        public int soLuong { get; set; }

        [Required]
        [StringLength(200)]
        public string nhaSanXuat { get; set; }

        [Required]
        public string ghiChu { get; set; }

        public string hinhAnh { get; set; }

        public virtual ChiDinh ChiDinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiTC> ChiTietGoiTCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietLoaiVaccine> ChiTietLoaiVaccines { get; set; }
    }
}
