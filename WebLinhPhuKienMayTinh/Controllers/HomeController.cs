using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Models;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProduct = productDao.ListNewProduct(4);
            ViewBag.FeatureProduct = productDao.ListFeatureProduct(4);
            return View();
        }
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        
    }
}