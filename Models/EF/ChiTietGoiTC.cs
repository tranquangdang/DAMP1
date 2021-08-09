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
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_goiTiemChung { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_vaccine { get; set; }

        public int lieu { get; set; }

        public virtual GoiTiemChung GoiTiemChung { get; set; }

        public virtual Vaccine Vaccine { get; set; }
    }
}
