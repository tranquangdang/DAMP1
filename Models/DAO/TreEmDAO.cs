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
    }
}
