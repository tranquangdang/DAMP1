using Models.DAO;
using QuanLyTiemChung.Areas.Admin.Models;
using QuanLyTiemChung.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.login(user.taiKhoan, Encryptor.EncryptMD5(user.matKhau));
                if (int.TryParse(result, out int value))
                {
                    user.id = value;
                    user.chucVu = dao.getChucVu(value);
                    user.ten = dao.getTen(value);
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result);
                }
            }
            return View("Index");
        }
    }
}