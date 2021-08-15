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

        public PhuHuynh Find(int ID)
        {
            return db.PhuHuynhs.Find(ID);
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
            var result = db.PhuHuynhs.Any(x => x.taiKhoan == taikhoan);
            if (!result)
            {
                return "Không tìm thấy tài khoản này!";
            }
            else
            {
                var model = db.PhuHuynhs.SingleOrDefault(x => x.taiKhoan.Contains(taikhoan) && x.matKhau.Contains(matkhau));
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

        public string Insert(PhuHuynh phuHuynhEntity)
        {
            var model = Find(phuHuynhEntity.id);
            if (model == null)
            {
                db.PhuHuynhs.Add(phuHuynhEntity);
            }
            else
            {
                model.ten = phuHuynhEntity.ten;
                model.sdt = phuHuynhEntity.sdt;
                model.cmnd = phuHuynhEntity.cmnd;
                model.taiKhoan = phuHuynhEntity.taiKhoan;
                model.matKhau = phuHuynhEntity.matKhau;
            }
            db.SaveChanges();
            return phuHuynhEntity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var model = Find(ID);
                db.PhuHuynhs.Remove(model);
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
