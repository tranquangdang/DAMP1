using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class VaccineDAO
    {
        private WebDbContext db;

        public VaccineDAO()
        {
            db = new WebDbContext();
        }

        public List<Vaccine> ListAll()
        {
            return db.Vaccines.ToList();
        }

        public Vaccine Find(int ProductID)
        {
            return db.Vaccines.Find(ProductID);
        }

        public string Insert(Vaccine productEntity)
        {
            var product = Find(productEntity.id);
            if (product == null)
            {
                db.Vaccines.Add(productEntity);
            }
            else
            {
                product.id_chiDinh = productEntity.id_chiDinh;
                product.ten = productEntity.ten;
                product.giaTien = productEntity.giaTien;
                product.ngaySanXuat = productEntity.ngaySanXuat;
                product.hanSuDung = productEntity.hanSuDung;
                product.soLuong = productEntity.soLuong;
                product.nhaSanXuat = productEntity.nhaSanXuat;
                product.ghiChu = productEntity.ghiChu;
                product.hinhAnh = productEntity.hinhAnh;
            }
            db.SaveChanges();
            return productEntity.id.ToString();
        }

        public bool Delete(int ProductID)
        {
            try
            {
                var product = Find(ProductID);
                db.Vaccines.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        

        public List<ChiDinh> getChiDinh()
        {
            return db.ChiDinhs.ToList();
        }

        public IEnumerable<Vaccine> ListWhereAll(string keyword, int page, int pagesize)
        {
            IEnumerable<Vaccine> model = db.Vaccines;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(s => s.ten.Contains(keyword));
            }
            return model.OrderBy(s => s.ten).ToPagedList(page, pagesize);
        }
    }
}
