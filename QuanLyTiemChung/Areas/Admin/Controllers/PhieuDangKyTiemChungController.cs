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
    public class PhieuDangKyTiemChungController : BaseController
    {
        // GET: Admin/PhieuDangKyTiemChung
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new PhieuDangKyTiemChungDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Book(int ID)
        {
            var model = new PhieuDangKyTiemChungDAO();
            var result = model.Find(ID);
            return View(result);
        }

        [HttpPost]
        public ActionResult Book(PhieuDangKyTiemChung model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = "";
                    result = new PhieuDangKyTiemChungDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "PhieuDangKyTiemChung");
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
            var model = new PhieuDangKyTiemChungDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}