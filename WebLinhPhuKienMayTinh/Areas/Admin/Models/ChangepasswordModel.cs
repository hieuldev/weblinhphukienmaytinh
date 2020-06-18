using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class ChangepasswordModel
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Mời nhập mật khẩu cũ")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Mời nhập mật khẩu mới")]
        public string newPassWord { set; get; }
    }
}