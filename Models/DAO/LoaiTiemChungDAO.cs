using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LoaiTiemChungDAO
    {
        private WebDbContext db;

        public LoaiTiemChungDAO()
        {
            db = new WebDbContext();
        }

        public List<LoaiTiemChung> ListAll()
        {
            return db.LoaiTiemChungs.ToList();
        }

        public LoaiTiemChung Find(int ID)
        {
            return db.LoaiTiemChungs.Find(ID);
        }

        public string Insert(LoaiTiemChung entity)
        {
            var loaiTC = Find(entity.id);
            if (loaiTC == null)
            {
                db.LoaiTiemChungs.Add(entity);
            }
            else
            {
                loaiTC.ten = entity.ten;
            }
            db.SaveChanges();
            return entity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var loaiTC = Find(ID);
                db.LoaiTiemChungs.Remove(loaiTC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
