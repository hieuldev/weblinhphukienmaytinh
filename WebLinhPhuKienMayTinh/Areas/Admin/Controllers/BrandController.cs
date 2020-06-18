using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        // GET: Admin/Brand
        public ActionResult Brandadd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Brandadd(BrandModel brandmodel)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                var brand = new BRAND();
                var dao = new BrandDao();
                if (brandmodel.topBrand != "0" && brandmodel.topBrand != "1")
                {
                    ModelState.AddModelError("", "Chưa chọn loại thương hiệu");
                }
                else
                {
                    brand.brandName = brandmodel.brandName;
                    brand.topBrand = brandmodel.topBrand;
                    long id = dao.Brandadd(brand);
                    if (id == 0)
                    {
                        ModelState.AddModelError("", "Tên thương hiệu đã bị trùng");
                    }
                    else
                    {
                        if (id < 0)
                        {
                            ModelState.AddModelError("", "Thêm thất bại");
                            return RedirectToAction("Brandadd", "Brand");
                        }
                        else
                        {

                            ViewData["success"] = "Thêm thương hiệu thành công";

                        }

                    }
                }
            }
            
            return View();
        }
        public ActionResult Brandlist(string searchString,int page=1,int pageSize=10)
        {
            var dao = new BrandDao();
            var model = dao.ListAllBrand(searchString,page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var brand = new BrandDao().Viewdetail(id);
            ViewBag.topBrand = brand.topBrand;
            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(BrandModel brandmodel, int id)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                var brand = new BRAND();
                var dao = new BrandDao();
                brand.brandName = brandmodel.brandName;
                brand.topBrand = brandmodel.topBrand.ToString();
                var result = dao.UpdateBrand(brand, id);
                if (result)
                {
                    //ViewData["success"] = "Sửa thương hiệu thành công";
                    return RedirectToAction("Brandlist");
                }               
                else
                {
                    ModelState.AddModelError("", "Sửa thương hiệu thất bại");

                }
                

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            new BrandDao().DeleteBrand(id);
            return RedirectToAction("Brandlist");

        }
    }
}