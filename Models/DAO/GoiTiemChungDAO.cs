using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class GoiTiemChungDAO
    {
        private WebDbContext db;

        public GoiTiemChungDAO()
        {
            db = new WebDbContext();
        }

        public List<GoiTiemChung> ListAll()
        {
            return db.GoiTiemChungs.ToList();
        }

        public List<GoiTiemChung> ListAll(int ID)
        {
            return db.GoiTiemChungs.Where(s => s.id_setTiemChung == ID).ToList();
        }

        public GoiTiemChung Find(int ID)
        {
            return db.GoiTiemChungs.Find(ID);
        }

        public string Insert(GoiTiemChung entity)
        {
            var goiTC = Find(entity.id);
            if (goiTC == null)
            {
                db.GoiTiemChungs.Add(entity);
            }
            else
            {
                goiTC.id_setTiemChung = entity.id_setTiemChung;
                goiTC.ten = entity.ten;
            }
            db.SaveChanges();
            return entity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var goiTC = Find(ID);
                db.GoiTiemChungs.Remove(goiTC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SetTiemChung> getSetTiemChung()
        {
            return db.SetTiemChungs.ToList();
        }

        public string getTenSetTC(int ID)
        {
            return db.SetTiemChungs.Find(ID).ten;
        }
    }
}
