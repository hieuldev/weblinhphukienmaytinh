using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                var dao = new AdminDao();
                var result = dao.LoginAdmin(model.Username, Encryptor.MD5Hash(model.Password));
                if (result)
                {

                    var user = dao.GetId(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.adminUser;
                    userSession.UserID = user.adminId;
                    Session.Add(CommonConstants.USER_SESSION, userSession);//(tenbien,giatrikhoitao)
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");


        }

    }


}