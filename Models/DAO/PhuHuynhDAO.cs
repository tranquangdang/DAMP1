using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PhuHuynhDAO
    {
        private WebDbContext db;

        public PhuHuynhDAO()
        {
            db = new WebDbContext();
        }

        public List<PhuHuynh> ListAll()
        {
            return db.PhuHuynhs.ToList();
        }

        public IEnumerable<PhuHuynh> ListWhereAll(string keyword, int page, int pagesize)
        {
            IEnumerable<PhuHuynh> model = db.PhuHuynhs;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(s => s.ten.Contains(keyword));
            }
            return model.OrderBy(s => s.ten).ToPagedList(page, pagesize);
        }
    }
}
