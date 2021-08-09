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
    public class SetTiemChungController : BaseController
    {
        private static int ID_loai;

        // GET: Admin/SetTiemChung
        public ActionResult Index(int ID)
        {
            ID_loai = ID;
            var model = new SetTiemChungDAO();
            var list = model.ListAll(ID_loai);
            ViewBag.tenLoaiTC = model.getTenLoaiTC(ID_loai);
            return View(list.ToPagedList(1, 10));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new SetTiemChungDAO();
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
        public ActionResult Create(SetTiemChung model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = "";
                    model.id_loaiTiemChung = ID_loai;
                    result = new SetTiemChungDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "SetTiemChung", new { ID = ID_loai});
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
            var model = new SetTiemChungDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}