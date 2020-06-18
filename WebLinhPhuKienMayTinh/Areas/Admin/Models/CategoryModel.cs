using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string CatName { get; set; }
    }
}