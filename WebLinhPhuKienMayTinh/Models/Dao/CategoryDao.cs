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
    public class CategoryDao
    {
        web db = null;
        public CategoryDao()
        {
            db = new web();
        }
        public long Categoryadd(CATEGORY entity)
        {
            var result = db.CATEGORies.Count(x => x.catName == entity.catName);
            if (result > 0)
            {
                return 0;
            }
            else
            {
                db.CATEGORies.Add(entity);
                db.SaveChanges();
                return entity.catId;
            }
        }
        public IEnumerable<CATEGORY> ListAllCategory(string searchString,int page, int pageSize)
        {
            IQueryable<CATEGORY> model = db.CATEGORies;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.catName.Contains(searchString));
                //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.catId).ToPagedList(page, pageSize);
        }
        public CATEGORY ViewdetailCat(int id)
        {

            return db.CATEGORies.Find(id);//lay ra id

        }
        public bool UpdateCategory(CATEGORY entity, int id)
        {
            try// su ly ngoai le
            {

                var update = db.CATEGORies.Find(id);
                update.catName = entity.catName;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteCategory(int id)
        {
            try
            {
                var delete = db.CATEGORies.Find(id);
                db.CATEGORies.Remove(delete);
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