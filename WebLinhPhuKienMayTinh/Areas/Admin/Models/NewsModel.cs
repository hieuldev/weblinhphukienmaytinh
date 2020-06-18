using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class NewsModel
    {
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string newsTitle { get; set; }
        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        public string newsImg { get; set; }
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [AllowHtml]
        public string newsContent { get; set; }
      

        [Required(ErrorMessage = "Loại tin tức không được để trống")]
        public string newsType { get; set; }
       
    }
}