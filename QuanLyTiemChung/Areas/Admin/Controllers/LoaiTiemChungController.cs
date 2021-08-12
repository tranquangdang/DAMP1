using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class LoaiTiemChungController : BaseController
    {
        private WebDbContext db;
        // GET: Admin/LoaiTiemChung
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new LoaiTiemChungDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new LoaiTiemChungDAO();

            if (str != null)
            {
                var ID = Convert.ToInt32(str);
                var result = model.Find(ID);
                return View(result);
            }
            else
            {
                ViewBag.Update = true;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(LoaiTiemChung model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = "";
                    result = new LoaiTiemChungDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "LoaiTiemChung");
                    }
                    else
                    {
                        SetAlert("Lỗi", "error");
                    }
                }
                else
                {
                    SetAlert("Lỗi", "error");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

       

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            var model = new LoaiTiemChungDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}