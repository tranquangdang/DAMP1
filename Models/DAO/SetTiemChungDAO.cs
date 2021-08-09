using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SetTiemChungDAO
    {
        private WebDbContext db;

        public SetTiemChungDAO()
        {
            db = new WebDbContext();
        }

        public List<SetTiemChung> ListAll(int ID)
        {
            return db.SetTiemChungs.Where(s => s.id_loaiTiemChung == ID).ToList();
        }

        public SetTiemChung Find(int ID)
        {
            return db.SetTiemChungs.Find(ID);
        }

        public string Insert(SetTiemChung entity)
        {
            var setTC = Find(entity.id);
            if (setTC == null)
            {
                db.SetTiemChungs.Add(entity);
            }
            else
            {
                setTC.id_loaiTiemChung = entity.id_loaiTiemChung;
                setTC.ten = entity.ten;
            }
            db.SaveChanges();
            return entity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var setTC = Find(ID);
                db.SetTiemChungs.Remove(setTC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<LoaiTiemChung> getLoaiTiemChung()
        {
            return db.LoaiTiemChungs.ToList();
        }

        public string getTenLoaiTC(int ID)
        {
            return db.LoaiTiemChungs.Find(ID).ten;
        }
    }
}
