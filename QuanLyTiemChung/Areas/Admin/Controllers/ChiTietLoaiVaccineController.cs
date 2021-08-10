using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class ChiTietLoaiVaccineController : BaseController
    {
        // GET: Admin/ChiTietLoaiVaccine
        private static int ID_phieu;

        public ActionResult Index(int ID)
        {
            ID_phieu = ID;
            var model = new ChiTietLoaiVaccineDAO();
            var list = model.ListAll(ID_phieu);
            return View(list.ToPagedList(1, 10));
        }
    }
}