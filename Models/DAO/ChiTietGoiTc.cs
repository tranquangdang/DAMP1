using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ChiTietGoiTcDAO
    {
        private WebDbContext db;

        public ChiTietGoiTcDAO()
        {
            db = new WebDbContext();
        }

        public List<ChiTietGoiTC> ListAll(int ID)
        {
            List<ChiTietGoiTC> ct = db.ChiTietGoiTCs.ToList();
            List<PhieuDangKyTiemChung> phieu = db.PhieuDangKyTiemChungs.ToList();
            List<GoiTiemChung> goi = db.GoiTiemChungs.ToList();

            return (from c in ct
                    join g in goi on c.id_goiTiemChung equals g.id
                    join p in phieu on g.id equals p.id_goiTiemChung
                    where p.id == ID
                    select c).ToList();
        }
        public List<ChiTietGoiTC> ListVaccine(int goitiem)
        {
            IQueryable<ChiTietGoiTC> model = (from s in db.ChiTietGoiTCs where s.id_goiTiemChung == goitiem select s);
            return model.ToList();
        }

        public ChiTietGoiTC Find(int ID)
        {
            return db.ChiTietGoiTCs.Find(ID);
        }

        public string Insert(ChiTietGoiTC entity)
        {            
            ChiTietGoiTC chitietTC = new ChiTietGoiTC();        
                db.ChiTietGoiTCs.Add(entity);        
            db.SaveChanges();
            return entity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var vaccine = Find(ID);
                db.ChiTietGoiTCs.Remove(vaccine);
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
