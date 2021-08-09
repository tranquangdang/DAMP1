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
            var result = db.Admins.Any(x => x.Username == user);
            if (!result)
            {
                return "Không tìm thấy tài khoản này!";
            }
            else
            {
                var model = db.Admins.SingleOrDefault(x => x.Username.Contains(user) && x.Password.Contains(pass));
                if (model != null)
                {
                    if (model.Status != 0)
                    {
                        return "";
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
