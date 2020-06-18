using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult UserProfile(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CustomerDao();
            var model = dao.UserProfile(searchString, page, pageSize);
            ViewBag.searchString = searchString; ;
            return View(model);
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var dao = new CustomerDao();
            var model = dao.Viewdetail(id);
            return View(model);
        }
    }
}