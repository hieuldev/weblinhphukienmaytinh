using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class BrandModel
    {
        
        [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
        public string brandName { get; set; }
        [Required(ErrorMessage = "Mục chọn không được để trống")]
        public string topBrand { get; set; }

    }

   

}