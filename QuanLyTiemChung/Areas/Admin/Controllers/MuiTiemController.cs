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
        private static int ID_mui;

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

        public ActionResult Index(int ID)
        {
            ID_mui = ID;
            var model = new MuiTiemDAO();
            var list = model.ListAll(ID_mui);
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
                    model.id_chiTietLoaiVaccine = ID_mui;
                    result = new MuiTiemDAO().Update(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "MuiTiem", new { ID = ID_mui });
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