namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuiTiem")]
    public partial class MuiTiem
    {
        public int id { get; set; }

        public int id_chiTietLoaiVaccine { get; set; }

        public DateTime ngayHen { get; set; }

        [Required]
        public string ghiChu { get; set; }

        public virtual ChiTietLoaiVaccine ChiTietLoaiVaccine { get; set; }
    }
}
