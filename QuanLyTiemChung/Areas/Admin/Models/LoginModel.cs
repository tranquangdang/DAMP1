﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyTiemChung.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string taiKhoan { get; set; }
        [Required]
        public string matKhau { get; set; }
        public int id { get; set; }
        public string chucVu { get; set; }
        public string ten { get; set; }
    }
}