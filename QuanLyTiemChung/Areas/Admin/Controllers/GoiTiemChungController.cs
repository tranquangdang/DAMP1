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
    public class GoiTiemChungController : BaseController
    {
        private static int ID_set;

        // GET: Admin/GoiTiemChung
        public ActionResult Index(int ID)
        {
            ID_set = ID;
            var model = new GoiTiemChungDAO();
            var list = model.ListAll(ID_set);
            ViewBag.tenSetTC = model.getTenSetTC(ID_set);
            return View(list.ToPagedList(1, 10));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new GoiTiemChungDAO();
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
        public ActionResult Create(GoiTiemChung model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = "";
                    model.id_setTiemChung = ID_set;
                    result = new GoiTiemChungDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "GoiTiemChung", new { ID = ID_set });
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
            var model = new GoiTiemChungDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}