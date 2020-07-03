using System;
using System.Web.Mvc;
using System.Web.WebPages;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Productadd()
        {
            var dao = new ProductDao();
            ViewBag.ListBrand = dao.ListBrand();
            ViewBag.ListCategory = dao.ListCategory();
            return View();
        }
        // GET: Admin/Product
        [HttpPost]
        public ActionResult Productadd(ProductModel productmodel)
        {
            var productdao = new ProductDao();
            var product = new PRODUCT();
            ViewBag.ListBrand = productdao.ListBrand();
            ViewBag.ListCategory = productdao.ListCategory();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                product.productName = productmodel.productName;
                product.product_Code = productmodel.product_Code;
                product.productQuantity = productmodel.productQuantity;
                product.brandId = productmodel.brandId;
                product.catId = productmodel.catId;
                product.product_Desc = productmodel.product_Desc;
                product.images = productmodel.images;
                product.types = productmodel.types;
                product.price = productmodel.price;
                product.procduct_Soldout = "0";
                product.product_Remain = product.productQuantity;


                long id = productdao.Productdadd(product);
                if (id < 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                    return RedirectToAction("Productadd", "Product");
                }
                else
                {

                    ViewData["success"] = "Thêm sản phẩm thành công";

                }

            }
            return View();
        }
        public ActionResult Productlist(string select_category,string select_brand,string select_type,string pricefrom, string priceto, string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            ViewBag.ListBrand = dao.ListBrand();
            ViewBag.ListCategory = dao.ListCategory();
            var model = dao.ListAllproduct(select_category,select_brand,select_type, pricefrom, priceto, searchString,page,pageSize);
            ViewBag.searchString = searchString;
            return View(model);

        }
        public ActionResult Delete(int id)
        {
            new ProductDao().DeleteProduct(id);
            return RedirectToAction("Productlist");

        }
        public ActionResult Edit(int id)
        {
            var dao = new ProductDao();
            var product = dao.Viewdetail(id);
            ViewBag.ListBrand = dao.ListBrand();
            ViewBag.ListCategory = dao.ListCategory();
            ViewBag.types = product.types;
            if (dao.ViewBrandNamebyProductId(id) is null)
            {
                ViewBag.BrandName = "";
            }
            else
            {
                ViewBag.BrandName = dao.ViewBrandNamebyProductId(id).brandName;
                ViewBag.BrandId = dao.ViewdetailBrandId(id).brandId;
            }
            if (dao.ViewCatNamebyProductId(id) is null)
            {
                ViewBag.CategoryName = "";
            }
            else
            {
                ViewBag.CategoryName = dao.ViewCatNamebyProductId(id).catName;
                ViewBag.CatId = dao.ViewdetailCatId(id).catId;
            }
            return View(product);

        }
        [HttpPost]
        public ActionResult Edit(ProductModel productmodel, int id)
        {
            var dao = new ProductDao();
            var product = new PRODUCT();
            ViewBag.ListBrand = dao.ListBrand();
            ViewBag.ListCategory = dao.ListCategory();
            ViewBag.types = product.types;
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                product.productName = productmodel.productName;
                product.product_Code = productmodel.product_Code;
                product.productQuantity = productmodel.productQuantity;
                product.brandId = productmodel.brandId;
                product.catId = productmodel.catId;
                product.product_Desc = productmodel.product_Desc;
                product.images = productmodel.images;
                product.types = productmodel.types;
                product.price = productmodel.price;
                product.procduct_Soldout = "0";
                product.product_Remain = product.productQuantity;
                var result = dao.UpdateProduct(product, id);
                if (result)
                {
                    //ViewData["success"] = "Sửa thương hiệu thành công";
                    return RedirectToAction("Productlist");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thương hiệu thất bại");

                }


            }
            return View();
        }
        public ActionResult EnterProduct(int id)
        {
            var dao = new ProductDao();
            var product = dao.Viewdetail(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EnterProduct(ProductModel productmodel, int id)
        {
            string soluong = Request.Form["product_more_quantity"];
            var dao = new ProductDao();
            var product = new PRODUCT();
            var warehouse = new WAREHOUSE();
            if (soluong == "")
            {
                ViewData["error"] = "Hãy nhập số lượng sản phẩm ";
            }
            else
            {
                product.product_Remain = (Convert.ToInt32(productmodel.product_Remain) + Convert.ToInt32(soluong)).ToString();
                warehouse.product_more_quantity = soluong;
                warehouse.productId = id;
                warehouse.sl_Ngaynhap = DateTime.Now;
                var result = dao.EnterProduct(product, id);
                if (result)
                {
                    ViewData["success"] = "Nhập thêm hàng thành công";
                    dao.InsertWareHose(warehouse, id);
                }
                else
                {
                    ViewData["error"] = "Nhập thêm hàng thất bại";
                }
                
            }
            return View();

        }



    }
}
