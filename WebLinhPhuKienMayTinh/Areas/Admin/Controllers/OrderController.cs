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
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10,int productId=0, int customerId=0)
        {
            var dao = new OrderDao();
            var model = dao.ListAllOrder(searchString, page, pageSize);
            if(productId!=0&&customerId != 0)
            {
                var result = dao.UpdateOrder(productId, customerId);
            }
            ViewBag.searchString = searchString;
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Update(int productId, int customerId, string searchString, int page = 1, int pageSize = 10)
        //{
        //    var dao = new OrderDao();
        //    var result = dao.UpdateOrder(productId, customerId);
        //    var model = dao.ListAllOrder(searchString, page, pageSize);
        //    ViewBag.searchString = searchString; ;
           
        //    if (result)
        //    {
        //        ViewData["success"] = "Cập nhật đơn hàng thành công";

        //    }
        //    else
        //    {

        //        ModelState.AddModelError("", "Cập nhật đơn hàng thất bại");

        //    }
        //    return View(model);
        //}
    }
}