using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        public ActionResult Detail(int id)
        {
            var product = new ProductDao().Viewdetail(id);
            ViewBag.Category = new CategoryDao().ViewdetailCat(product.catId.Value);
            return View(product);
        }
       
        
    }
}