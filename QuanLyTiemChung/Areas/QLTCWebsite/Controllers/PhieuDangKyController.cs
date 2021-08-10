using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.QLTCWebsite.Controllers
{
    public class PhieuDangKyController : Controller
    {
        // GET: QLTCWebsite/PhieuDangKy
        public ActionResult Index(string str)
        {
            SetViewBag();
            var model = new PhieuDangKyTiemChungDAO();
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
        public ActionResult Index(PhieuDangKyTiemChung model)
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
        public void SetViewBag(string selectedId = null)
        {
            var listTreEm = new TreEmDAO();
            ViewBag.TreEm = new SelectList(listTreEm.ListAll(1), "id", "ten", selectedId);

            var listPH = new PhuHuynhDAO();
            ViewBag.PH = new SelectList(listPH.ListAll(), "id", "ten", selectedId);

            var listGoiTC = new GoiTiemChungDAO();
            ViewBag.GoiTC = new SelectList(listGoiTC.ListAll(), "id", "ten", selectedId);

            var listVaccine = new VaccineDAO();
            ViewBag.VC = new SelectList(listVaccine.ListAll(), "id", "ten", selectedId);

        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}