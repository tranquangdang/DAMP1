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
    public class TreEmController : BaseController
    {
        private static int ID_phuHuynh;

        public List<SelectListItem> getGioiTinh()
        {
            List<SelectListItem> getGioiTinh = new List<SelectListItem>();
            getGioiTinh.Add(new SelectListItem
            {
                Text = "Nam",
                Value = "Nam"
            });
            getGioiTinh.Add(new SelectListItem
            {
                Text = "Nam",
                Value = "Nữ"
            });
            return getGioiTinh;
        }

        // GET: Admin/SetTiemChung
        public ActionResult Index(int ID)
        {
            ID_phuHuynh = ID;
            var model = new TreEmDAO();
            var list = model.ListAll(ID_phuHuynh);
            return View(list.ToPagedList(1, 10));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new TreEmDAO();

            if (str != null)
            {
                var TreEmID = Convert.ToInt32(str);
                var result = model.Find(TreEmID);
                ViewBag.gioiTinh = new SelectList(getGioiTinh(), "Value", "Text", result.gioiTinh);
                return View(result);
            }
            else
            {
                ViewBag.Update = true;
                ViewBag.gioiTinh = new SelectList(getGioiTinh(), "Value", "Text");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(TreEm model)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    string result = "";
                    model.id_phuHuynh = ID_phuHuynh;
                    result = new TreEmDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "TreEm", new { ID = ID_phuHuynh });
                    }
                    else
                    {
                        SetAlert("Lỗi", "error");
                    }
                }
                else
                {
                    ViewBag.gioiTinh = new SelectList(getGioiTinh(), "Value", "Text");
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
            var model = new TreEmDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}