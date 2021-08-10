using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ChiTietLoaiVaccineDAO
    {
        private WebDbContext db;

        public ChiTietLoaiVaccineDAO()
        {
            db = new WebDbContext();
        }

        public List<ChiTietLoaiVaccine> ListAll(int ID)
        {
            return db.ChiTietLoaiVaccines.Where(s => s.id_dangKy == ID).ToList();
        }
    }
}
