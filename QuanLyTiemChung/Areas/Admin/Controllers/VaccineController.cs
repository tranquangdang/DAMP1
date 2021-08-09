using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class VaccineController : BaseController
    {
        // GET: Admin/Vaccine
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new VaccineDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var model = new VaccineDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new VaccineDAO();
            var getChiDinh = model.getChiDinh();

            if (str != null)
            {
                var VaccineID = Convert.ToInt32(str);
                var result = model.Find(VaccineID);
                ViewBag.ChiDinhList = new SelectList(getChiDinh, "id", "phongBenh", result.id_chiDinh);
                return View(result);
            }
            else
            {
                ViewBag.Update = true;
                ViewBag.ChiDinhList = new SelectList(getChiDinh, "id", "phongBenh");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Vaccine model, HttpPostedFileBase postedFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    postedFile = Request.Files["hinhAnh"];
                    if (postedFile.ContentLength <= 0 && model.id == 0)
                    {
                        ViewBag.ChiDinhList = new SelectList(new VaccineDAO().getChiDinh(), "id", "phongBenh");
                        SetAlert("Vui lòng chọn ảnh!", "error");
                        return RedirectToAction("Create", "Vaccine");
                    }

                    if (postedFile.ContentLength > 0)
                    {
                        string filePath = "";
                        filePath = Server.MapPath("~/Images/");
                        var fileName = Path.GetFileName(postedFile.FileName);
                        filePath = filePath + fileName;
                        postedFile.SaveAs(filePath);
                        DeleteImg(model.hinhAnh);
                        model.hinhAnh = "~/Images/" + fileName;
                    }

                    string result = "";
                    result = new VaccineDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "Vaccine");
                    }
                    else
                    {
                        SetAlert("Lỗi", "error");
                    }
                }
                else
                {
                    ViewBag.ChiDinhList = new SelectList(new VaccineDAO().getChiDinh(), "id", "phongBenh");
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
            var model = new VaccineDAO();
            DeleteImg(model.Find(ID).hinhAnh);
            model.Delete(ID);
            return RedirectToAction("Index");
        }

        public void DeleteImg(string pathName)
        {
            if (!string.IsNullOrEmpty(pathName))
            {
                if (pathName.Substring(0, 4) != "http")
                {
                    string fullPath = Request.MapPath(pathName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
            }
        }
    }
}