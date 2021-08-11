using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class ChiTietGoiTcController : Controller
    {
        private static int id_dangKy;

        public ActionResult Index(int ID)
        {
            id_dangKy = ID;
            var model = new ChiTietGoiTcDAO();
            var list = model.ListAll(id_dangKy);
            ViewBag.ID_dangKy = id_dangKy;
            return View(list.ToPagedList(1, 10));
        }
    }
}