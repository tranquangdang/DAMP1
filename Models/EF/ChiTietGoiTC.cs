namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGoiTC")]
    public partial class ChiTietGoiTC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietGoiTC()
        {
            MuiTiems = new HashSet<MuiTiem>();
        }

        public int id { get; set; }

        public int id_goiTiemChung { get; set; }

        public int id_vaccine { get; set; }

        public int lieu { get; set; }

        public virtual GoiTiemChung GoiTiemChung { get; set; }

        public virtual Vaccine Vaccine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuiTiem> MuiTiems { get; set; }
    }
}
