using Models.DAO;
using Models.EF;
using PagedList;
using QuanLyTiemChung.Common;
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
            Notification();
            var model = new PhuHuynhDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new PhuHuynhDAO();

            if (str != null)
            {
                var PhuHuynhID = Convert.ToInt32(str);
                var result = model.Find(PhuHuynhID);
                return View(result);
            }
            else
            {
                ViewBag.Update = true;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(PhuHuynh model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = "";
                    model.matKhau = Encryptor.EncryptMD5(model.matKhau);
                    result = new PhuHuynhDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "PhuHuynh");
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
            var model = new PhuHuynhDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }

    }
}