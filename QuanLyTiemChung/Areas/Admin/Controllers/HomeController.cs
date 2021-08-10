using Models.DAO;
using QuanLyTiemChung.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var phieuDangKyTiemChung = new PhieuDangKyTiemChungDAO();
            ViewBag.Revenue = phieuDangKyTiemChung.Revenue();
            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}