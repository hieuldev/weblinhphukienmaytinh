using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class SliderModel
    {
        [Required(ErrorMessage = "Tên slider không được để trống")]
        public string sliderName { get; set; }
        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        public string slider_Image { get; set; }
        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public int type0 { get; set; }
    }
}