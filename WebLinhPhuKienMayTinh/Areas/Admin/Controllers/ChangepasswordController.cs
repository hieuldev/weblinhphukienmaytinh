using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class ChangepasswordController : BaseController
    {
        // GET: Admin/Changepassword
        public ActionResult newPassword()
        {
            return View();
        }
        [HttpPost]
       public ActionResult newPassword(ChangepasswordModel model)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                var dao = new AdminDao();
                var result = dao.Changepassword(model.Username, Encryptor.MD5Hash(model.Password), Encryptor.MD5Hash(model.newPassWord));

                if (result)
                {
                    ViewData["success"] = "Đổi mật khẩu thành công";

                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản và mật khẩu không chính xác");
                }
            }
            return View();
        }
    }
}