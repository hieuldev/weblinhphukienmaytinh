using System;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Brand
        public ActionResult Categoryadd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Categoryadd(CategoryModel categorydmodel)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                var cat = new CATEGORY();
                var dao = new CategoryDao();
                cat.catName= categorydmodel.CatName;
                long id = dao.Categoryadd(cat);
                if (id == 0)
                {
                    ModelState.AddModelError("", "Tên danh mục sản phẩm đã bị trùng");
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
                        ViewData["success"] = "Thêm danh mục sản phẩm thành công";

                    }
                }

            }
            return View();
        }
        public ActionResult Categorylist(string searchString,int page=1, int pageSize=10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllCategory(searchString, page, pageSize);
            ViewBag.searchString = searchString; ;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var cat = new CategoryDao().ViewdetailCat(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(CategoryModel categorydmodel, int id)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                var cat = new CATEGORY();
                var dao = new CategoryDao();
                cat.catName = categorydmodel.CatName;
                var result = dao.UpdateCategory(cat, id);
                if (result)
                {
                    //ViewData["success"] = "Sửa danh mục sản phẩm thành công";
                    return RedirectToAction("Categorylist");

                }
                else
                {
                    ModelState.AddModelError("", "Sửa danh mục sản phẩm thất bại");

                }


            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            new CategoryDao().DeleteCategory(id);
            return RedirectToAction("Categorylist");

        }
    }
}