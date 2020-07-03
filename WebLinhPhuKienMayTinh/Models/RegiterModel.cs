using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLinhPhuKienMayTinh.Models
{
    public class RegiterModel
    {

        [Key]
        public int customer_id { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]

        public string name { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string password0 { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("password0", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Địa chỉ")]
        public string address0 { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]
        
        public string email { set; get; }

        [Display(Name = "Điện thoại")]
        public string phone { set; get; }
        [Display(Name = "Mã bưu điện")]
        public string zipcode { set; get; }

        [Display(Name = "Tỉnh/thành")]
        public string city { set; get; }
        [Display(Name = "Quốc gia")]
        public string country { set; get; }

        
    }
}