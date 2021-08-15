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
            Notification();
            var phieuDangKyTiemChung = new PhieuDangKyTiemChungDAO();
            var treEm = new TreEmDAO();
            var vaccine = new VaccineDAO();
            ViewBag.RevenueChart = phieuDangKyTiemChung.RevenueChart();
            ViewBag.Revenue = phieuDangKyTiemChung.Revenue();
            ViewBag.TreEmNum = treEm.TreEmNum();
            ViewBag.VaccineNum = vaccine.VaccineNum();
            ViewBag.PhieuNum = phieuDangKyTiemChung.PhieuNum();
            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}