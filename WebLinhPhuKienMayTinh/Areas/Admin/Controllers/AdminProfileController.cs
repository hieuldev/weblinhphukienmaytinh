using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;


namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class AdminProfileController : BaseController
    {
        // GET: Admin/AdminProfile
        public ActionResult Detail()
        { int id=Convert.ToInt32(Session["id"]);

            var dao = new AdminDao();
            var model = dao.ViewProfile(id);           
            return View(model);
            
        }
    }
}