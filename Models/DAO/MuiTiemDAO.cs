using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MuiTiemDAO
    {
        private WebDbContext db;

        public MuiTiemDAO()
        {
            db = new WebDbContext();
        }

        public List<MuiTiem> ListAll(int ID)
        {
            return db.MuiTiems.Where(s => s.id_chiTietLoaiVaccine == ID).ToList();
        }

        public MuiTiem Find(int id)
        {
            return db.MuiTiems.Find(id);
        }

        public string Update(MuiTiem muiTiemEntity)
        {
            var muiTiem = Find(muiTiemEntity.id);
            muiTiem.id_chiTietLoaiVaccine = muiTiemEntity.id_chiTietLoaiVaccine;
            muiTiem.ngayTiem = muiTiemEntity.ngayTiem;
            muiTiem.trangThai = muiTiemEntity.trangThai;
            muiTiem.ghiChu = muiTiemEntity.ghiChu;
            db.SaveChanges();
            return muiTiemEntity.id.ToString();
        }
    }
}
