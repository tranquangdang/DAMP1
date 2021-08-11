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
    public class MuiTiemController : BaseController
    {
        // GET: Admin/MuiTiem
        private static int id_chiTietGoiTC;
        private static int id_dangKy;

        public List<SelectListItem> getStatusList()
        {
            List<SelectListItem> getStatusList = new List<SelectListItem>();
            getStatusList.Add(new SelectListItem
            {
                Text = "Chưa tiêm",
                Value = "Chưa tiêm"
            });
            getStatusList.Add(new SelectListItem
            {
                Text = "Đặt hẹn",
                Value = "Đặt hẹn"
            });
            getStatusList.Add(new SelectListItem
            {
                Text = "Đã tiêm",
                Value = "Đã tiêm"
            });
            return getStatusList;
        }

        public ActionResult Index(int ID_chiTietGoiTC, int ID_dangKy)
        {
            id_chiTietGoiTC = ID_chiTietGoiTC;
            id_dangKy = ID_dangKy;
            var model = new MuiTiemDAO();
            var list = model.ListAll(id_chiTietGoiTC, ID_dangKy);
            return View(list.ToPagedList(1, 10));
        }

        [HttpGet]
        public ActionResult Update(string str)
        {
            var model = new MuiTiemDAO();
            var ProductID = Convert.ToInt32(str);
            var result = model.Find(ProductID);
            ViewBag.StatusList = new SelectList(getStatusList(), "Value", "Text", result.trangThai);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(MuiTiem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = "";
                    model.id_chiTietGoiTC = id_chiTietGoiTC;
                    model.id_dangKy = id_dangKy;
                    result = new MuiTiemDAO().Update(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "MuiTiem", new { ID_chiTietGoiTC = id_chiTietGoiTC, ID_dangKy = id_dangKy});
                    }
                    else
                    {
                        ViewBag.StatusList = new SelectList(getStatusList(), "Value", "Text");
                        SetAlert("Lỗi", "error");
                    }
                }
                else
                {
                    ViewBag.StatusList = new SelectList(getStatusList(), "Value", "Text");
                    SetAlert("Lỗi", "error");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}