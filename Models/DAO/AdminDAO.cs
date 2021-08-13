using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AdminDAO
    {
        private WebDbContext db;

        public AdminDAO()
        {
            db = new WebDbContext();
        }

        public string login(string user, string pass)
        {
            var result = db.NhanViens.Any(x => x.taiKhoan == user);
            if (!result)
            {
                return "Không tìm thấy tài khoản này!";
            }
            else
            {
                var model = db.NhanViens.SingleOrDefault(x => x.taiKhoan.Contains(user) && x.matKhau.Contains(pass));
                if (model != null)
                {
                    if (model.trangThai != 0)
                    {
                        return db.NhanViens.SingleOrDefault(x => x.taiKhoan.Contains(user) && x.matKhau.Contains(pass)).id.ToString();
                    }
                    else
                    {
                        return "Tài khoản bị khóa! ";
                    }
                }
                else
                {
                    return "Sai mật khẩu! ";
                }
            }
        }
    }
}
