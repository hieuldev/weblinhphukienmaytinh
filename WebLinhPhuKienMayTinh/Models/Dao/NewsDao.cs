using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLinhPhuKienMayTinh.Models.EF;
using PagedList;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Data.Entity;

namespace WebLinhPhuKienMayTinh.Models.Dao
{

    public class NewsDao
    {
        web db = null;
        public NewsDao()
        {
            db = new web();
        }
        public int AddNews(NEWS entity)
        {
            db.NEWS.Add(entity);
            db.SaveChanges();
            return entity.newsID;

        }
        public IEnumerable<NEWS> ListAllNews(string searchString, int page, int pageSize)
        {
            IQueryable<NEWS> model = db.NEWS;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.newsTitle.Contains(searchString));
                //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.newsID).ToPagedList(page, pageSize);
        }
        public NEWS Viewdetail(int id)
        {

            return db.NEWS.Find(id);//lay ra id

        }
        public bool UpdateNews(NEWS entity, int id)
        {
            try// su ly ngoai le
            {

                var update = db.NEWS.Find(id);
                update.newsTitle = entity.newsTitle;
                update.newsImg = entity.newsImg;
                update.newsContent = entity.newsContent;
                update.newsType = entity.newsType;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteNews(int id)
        {
            try
            {
                var delete = db.NEWS.Find(id);
                db.NEWS.Remove(delete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}