using System;
using System.Web.Mvc;
using System.Web.WebPages;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class SliderController : BaseController
    {
        // GET: Admin/Slider
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlider(SliderModel sliderModel)
        {
            var sliderdao = new SliderDao();
            var slider = new SLIDER();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                slider.sliderName = sliderModel.sliderName;
                slider.slider_Image = sliderModel.slider_Image;
                slider.type0 = sliderModel.type0;


                long id = sliderdao.AddSlider(slider);
                if (id < 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                    return RedirectToAction("AddSlider", "Slider");
                }
                else
                {

                    ViewData["success"] = "Thêm slider thành công";

                }

            }
            return View();
        }
        public ActionResult Sliderlist(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SliderDao();
            var model = dao.ListAllSlider(searchString, page, pageSize);
            ViewBag.searchString = searchString; ;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var slider = new SliderDao().Viewdetail(id);
            ViewBag.type = slider.type0;
            return View(slider);
        }
        [HttpPost]
        public ActionResult Edit(SliderModel slidermodel, int id)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                var slider = new SLIDER();
                var dao = new SliderDao();
                slider.sliderName = slidermodel.sliderName;
                slider.slider_Image = slidermodel.slider_Image;
                slider.type0 = slidermodel.type0;

                var result = dao.UpdateSlider(slider, id);
                if (result)
                {
                    //ViewData["success"] = "Sửa thương hiệu thành công";
                    return RedirectToAction("Sliderlist");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa slider thất bại");

                }


            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            new SliderDao().DeleteSlider(id);
            return RedirectToAction("Sliderlist");

        }
    }
}