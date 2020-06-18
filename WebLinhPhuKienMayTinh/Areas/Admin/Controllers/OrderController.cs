using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Oder
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new OrderDao();
            var model = dao.ListAllOrder(searchString, page, pageSize);
            ViewBag.searchString = searchString; ;
            return View(model);
        }

        //[HttpGet]
        ////public ActionResult Update(int productId, int customerId)
        //{
        //    var dao = new OrderDao();
        //    var result = dao.UpdateOrder(productId, customerId);
        //    if (result)
        //    {
        //        ViewData["success"] = "Cập nhật đơn hàng thành công";

        //    }
        //    else
        //    {

        //        ModelState.AddModelError("", "Cập nhật đơn hàng thất bại");

        //    }
        //    return View();
        //}
    }
}