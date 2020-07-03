using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebLinhPhuKienMayTinh.Models;
using WebLinhPhuKienMayTinh.Models.Dao;


namespace WebLinhPhuKienMayTinh.Controllers
{
    
    public class CartController : Controller
    {

        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int productId, int quantity)
        {

            var product = new ProductDao().Viewdetail(productId);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list =(List < CartItem >) cart;
                if(list.Exists(x=>x.Product.productId==productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.productId == productId)
                        {
                            item.Quantity += quantity;
                        }

                    }
                }
                
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.productId == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.productId == item.Product.productId);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Payment()
        {

            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult OnlinePayment()
        {
            return View();
        }
        public ActionResult Visa()
        {
            return View();
        }
        public ActionResult NoiDia()
        {
            return View();
        }
        public ActionResult OfflinePayment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
            
        }


    }
}