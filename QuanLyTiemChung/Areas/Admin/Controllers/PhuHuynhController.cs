using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class PhuHuynhController : BaseController
    {
        // GET: Admin/PhuHuynh
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new PhuHuynhDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var model = new PhuHuynhDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }
    }
}