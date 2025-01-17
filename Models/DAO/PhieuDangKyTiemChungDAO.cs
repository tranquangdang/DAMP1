﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PhieuDangKyTiemChungDAO
    {
        private WebDbContext db;

        public PhieuDangKyTiemChungDAO()
        {
            db = new WebDbContext();
        }

        public List<PhieuDangKyTiemChung> ListAll()
        {
            return db.PhieuDangKyTiemChungs.OrderByDescending(s => s.ngayYeuCau).ToList();
        }
        public List<PhieuDangKyTiemChung> ListNull()
        {
            return db.PhieuDangKyTiemChungs.Where(x => x.ngayHen==null).ToList();
        }

        public PhieuDangKyTiemChung Find(int ID)
        {
            return db.PhieuDangKyTiemChungs.Find(ID);
        }

        public List<PhieuDangKyTiemChung> ListByTreEm(int? ID)
        {
            return db.PhieuDangKyTiemChungs.Where(s => s.id_treEm == ID).OrderByDescending(s => s.ngayYeuCau).ToList();
        }

        public int Unconfirmed()
        {
            return db.PhieuDangKyTiemChungs.Where(s => s.ngayHen == null).Count();
        }

        public List<PhieuDangKyTiemChung> ListUnconfirmed()
        {
            return db.PhieuDangKyTiemChungs.Where(s => s.ngayHen == null).OrderByDescending(s => s.ngayYeuCau).ToList();
        }

        public string Insert(PhieuDangKyTiemChung entity)
        {
            var phieuTC = Find(entity.id);
            phieuTC.ngayHen = entity.ngayHen;
            phieuTC.id_nhanVien = entity.id_nhanVien;
            db.SaveChanges();
            return entity.id.ToString();
        }

        public bool Delete(int ID)
        {
            try
            {
                var phieuTC = Find(ID);
                db.PhieuDangKyTiemChungs.Remove(phieuTC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int PhieuNum()
        {
            return (int)db.PhieuDangKyTiemChungs.Count();
        }

        public int Revenue()
        {
            return (int)db.PhieuDangKyTiemChungs.Sum(s => s.tongTien);
        }

        public string RevenueChart()
        {
            decimal? t, l;
            string js = "<script>";
            js += " $(document).ready(function() {";
            js += " function gd(year, day, month)";
            js += " {";
            js += " return new Date(year, month - 1, day).getTime();";
            js += " }";
            js += " graphArea2 = Morris.Area({";
            js += " element: 'hero-area',";
            js += " padding: 10,";
            js += " behaveLikeLine: true,";
            js += " gridEnabled: false,";
            js += " gridLineColor: '#dddddd',";
            js += " axes: true,";
            js += " resize: true,";
            js += " smooth: true,";
            js += " pointSize: 0,";
            js += " lineWidth: 0,";
            js += " fillOpacity: 0.85,";
            js += " data:[";
            for (int i = 1; i <= DateTime.Today.Day; i++)
            {
                t = db.PhieuDangKyTiemChungs.Where(s => s.ngayYeuCau.Day <= i &&
                                            s.ngayYeuCau.Month == DateTime.Today.Month).Sum(s => (decimal?)s.tongTien).GetValueOrDefault(0);
                l = db.PhieuDangKyTiemChungs.Where(s => s.ngayYeuCau.Day <= i &&
                                             s.ngayYeuCau.Month == DateTime.Today.Month - 1).Sum(s => (decimal?)s.tongTien).GetValueOrDefault(0);
                js += "{period: '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + i + "', thismonth: " + t + ", lastmonth: " + l + "}, ";
            }
            js += " ]";
            js += " ,";
            js += " lineColors:['#eb6f6f','#926383'],";
            js += " xkey: 'period',";
            js += " redraw: true,";
            js += " ykeys:['thismonth', 'lastmonth'],";
            js += " labels:['Tháng này', 'Tháng trước'],";
            js += " pointSize: 2,";
            js += " hideHover: 'auto',";
            js += " resize: true";
            js += " });";
            js += " });";
            js += " </script>";
            return js;
        }
    }
}
