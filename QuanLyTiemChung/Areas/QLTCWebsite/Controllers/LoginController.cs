using Models.DAO;
using QuanLyTiemChung.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTiemChung.Common;
namespace QuanLyTiemChung.Areas.QLTCWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: QLTCWebsite/Login
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
                var dao = new PhuHuynhDAO();
                var result = dao.login(user.taiKhoan, Encryptor.EncryptMD5(user.matKhau));
                if (result == "")
                {
                    Session.Add(Constants.USER_SESSION, user.taiKhoan);
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