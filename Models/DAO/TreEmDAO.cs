using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
  public  class TreEmDAO
    {
        private WebDbContext db;

        public TreEmDAO()
        {
            db = new WebDbContext();
        }
        public List<TreEm> ListAll(int id_ph)
        {
            return db.TreEms.Where(s => s.id_phuHuynh == id_ph).ToList();
        }

        public TreEm Find(int ID)
        {
            return db.TreEms.Find(ID);
        }

        public int TreEmNum()
        {
            return (int)db.TreEms.Count();
        }

        public string Insert(TreEm treEmEntity)
        {
            var model = Find(treEmEntity.id);
            if (model == null)
            {
                db.TreEms.Add(treEmEntity);
            }
            else
            {
                model.id_phuHuynh = treEmEntity.id_phuHuynh;
                model.ten = treEmEntity.ten;
                model.ngaySinh = treEmEntity.ngaySinh;
                model.gioiTinh = treEmEntity.gioiTinh;
            }
            db.SaveChanges();
            return treEmEntity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var model = Find(ID);
                db.TreEms.Remove(model);
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
