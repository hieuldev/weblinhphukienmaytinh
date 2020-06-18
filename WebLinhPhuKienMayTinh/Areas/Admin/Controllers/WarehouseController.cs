using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class WarehouseController : BaseController
    {
        // GET: Admin/Warehouse
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new WarehouseDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
    }
}