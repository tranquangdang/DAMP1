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

        public List<MuiTiem> ListAll(int id_chiTietGoiTC, int id_dangKy)
        {
            return db.MuiTiems.Where(s => s.id_chiTietGoiTC == id_chiTietGoiTC && s.id_dangKy == id_dangKy).ToList();
        }

        public MuiTiem Find(int id)
        {
            return db.MuiTiems.Find(id);
        }

        public string Update(MuiTiem muiTiemEntity)
        {
            var muiTiem = Find(muiTiemEntity.id);
            muiTiem.id_chiTietGoiTC = muiTiemEntity.id_chiTietGoiTC;
            muiTiem.ngayTiem = muiTiemEntity.ngayTiem;
            muiTiem.trangThai = muiTiemEntity.trangThai;
            muiTiem.ghiChu = muiTiemEntity.ghiChu;
            db.SaveChanges();
            return muiTiemEntity.id.ToString();
        }
    }
}
