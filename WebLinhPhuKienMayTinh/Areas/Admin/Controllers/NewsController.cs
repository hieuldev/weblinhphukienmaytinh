using System;
using System.Web.Mvc;
using System.Web.WebPages;
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        // GET: Admin/News
        public ActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNews(NewsModel NewsModel)
        {
            var Newsdao = new NewsDao();
            var News = new NEWS();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                News.newsTitle = NewsModel.newsTitle;
                News.newsImg = NewsModel.newsImg;
                News.newsContent = NewsModel.newsContent;
                News.newsType = NewsModel.newsType;


                long id = Newsdao.AddNews(News);
                if (id < 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                    return RedirectToAction("AddNews", "News");
                }
                else
                {

                    ViewData["success"] = "Thêm News thành công";

                }

            }
            return View();
        }
        public ActionResult Newslist(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NewsDao();
            var model = dao.ListAllNews(searchString, page, pageSize);
            ViewBag.searchString = searchString; ;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var News = new NewsDao().Viewdetail(id);
            ViewBag.type = News.newsType;
            return View(News);
        }
        [HttpPost]
        public ActionResult Edit(NewsModel Newsmodel, int id)
        {
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                var News = new NEWS();
                var dao = new NewsDao();
                News.newsTitle = Newsmodel.newsTitle;
                News.newsImg = Newsmodel.newsImg;
                News.newsContent = Newsmodel.newsContent;
                News.newsType = Newsmodel.newsType;

                var result = dao.UpdateNews(News, id);
                if (result)
                {
                    //ViewData["success"] = "Sửa thương hiệu thành công";
                    return RedirectToAction("Newslist");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa tin tức thất bại");

                }


            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            new NewsDao().DeleteNews(id);
            return RedirectToAction("Newslist");

        }
    }
}