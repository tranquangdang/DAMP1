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
        private static int ID_goi;

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
        public ActionResult DeleteVaccine(int ID)
        {
            var model = new ChiTietGoiTcDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            var model = new GoiTiemChungDAO();
            model.Delete(ID);
            return RedirectToAction("Index");
        }

        public void SetViewBag(string selectedId = null)
        {
            var vaccine = new VaccineDAO();
            ViewBag.vaccine = new SelectList(vaccine.ListAll(), "id", "ten", selectedId);

        }
       private WebDbContext db;
        public ActionResult EditVaccine(int goitiem)
        {
            SetViewBag();
            var model = new GoiTiemChungDAO();
            ViewBag.tenSetTC = model.getTenSetTC(ID_set);

            var vaccine = new ChiTietGoiTcDAO();
            var modelVaccine = vaccine.ListVaccine(goitiem);
            ID_goi = goitiem;
            //ChiTietGoiTC vaccine = new ChiTietGoiTC();
            //    vaccine = db.ChiTietGoiTCs.Where(x => x.id_goiTiemChung == goitiem).FirstOrDefault();
            return View(modelVaccine);
        }

        [HttpPost]
        public ActionResult EditVaccine(ChiTietGoiTC model)
        {
            //model.id_vaccine = string.Join(",",model.SelectedVaccineArray)
            try
            {
                
                if (ModelState.IsValid)
                {
                    string result = "";
                  model.id_goiTiemChung = ID_goi;
                    result = new ChiTietGoiTcDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("EditVaccine", "GoiTiemChung", new { goitiem = ID_goi });
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

        public bool IsExist(int idVaccine)
        {
            var listVaccine = from s in db.ChiTietGoiTCs where s.id_goiTiemChung == ID_goi select s;
            foreach (var i in listVaccine)
            {
                if (i.id_goiTiemChung == ID_goi && i.id_vaccine == idVaccine)
                {
                    return true;
                }
            }
            return false;
        }

    }
}