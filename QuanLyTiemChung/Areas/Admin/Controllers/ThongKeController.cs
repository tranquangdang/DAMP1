using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class ThongKeController : BaseController
    {
        // GET: Admin/ThongKe
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new PhieuDangKyTiemChungDAO().ListNull();
                return View(model.ToPagedList(page, pagesize));
         }
    }
}