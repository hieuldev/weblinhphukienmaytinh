using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Mời nhập tên sản phẩm")]
        public string productName { set; get; }

        [Required(ErrorMessage = "Mời nhập mã sản phẩm")]
        public string product_Code { set; get; }
        [Required(ErrorMessage = "Mời nhập số lượng sản phẩm")]
        public string productQuantity { set; get; }
  
        public string procduct_Soldout { set; get; }
       
        public string product_Remain { set; get; }
        [Required(ErrorMessage = "Mời chọn danh mục sản phẩm ")]
        public int catId { set; get; }
        [Required(ErrorMessage = "Mời chọn thương hiệu sản phẩm")]
        public int brandId { set; get; }
        [Required(ErrorMessage = "Mời nhập mô tả")]
        [AllowHtml]
        public string product_Desc { set; get; }
        [Required(ErrorMessage = "Mời nhập giá sản phẩm")]
        public string price { set; get; }
        [Required(ErrorMessage = "Mời thêm hình ảnh")]
        public string images { set; get; }
        [Required(ErrorMessage = "Mời chọn kiểu sản phẩm")]
        public int types { set; get; }

    }
}