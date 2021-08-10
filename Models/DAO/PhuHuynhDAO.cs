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

        public string login(string taikhoan, string matkhau)
        {
            var result = db.PhuHuynhs.Any(x => x.taikhoan == taikhoan);
            if (!result)
            {
                return "Không tìm thấy tài khoản này!";
            }
            else
            {
                var model = db.PhuHuynhs.SingleOrDefault(x => x.taikhoan.Contains(taikhoan) && x.matkhau.Contains(matkhau));
                if (model != null)
                {

                    return "";

                }
                else
                {
                    return "Sai mật khẩu! ";
                }
            }
        }
    }
}
