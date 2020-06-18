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
     
    public class BrandDao
    {
        web db = null;
        public BrandDao()
        {
            db = new web();
        }
        public long Brandadd(BRAND entity)
        {
            var result = db.BRANDs.Count(x => x.brandName == entity.brandName);
            if (result > 0)
            {
                return 0;
            }
            else
            {
                db.BRANDs.Add(entity);
                db.SaveChanges();
                return entity.brandId;
            }
        }
        public IEnumerable<BRAND> ListAllBrand(string searchString,int page,int pageSize)
        {
           IQueryable<BRAND> model = db.BRANDs;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.brandName.Contains(searchString));
                    //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.brandId).ToPagedList(page, pageSize);
        }
        public BRAND Viewdetail(int id)
        {

            return db.BRANDs.Find(id);//lay ra id

        }
       
        public bool UpdateBrand(BRAND entity, int id)
        {
            try// su ly ngoai le
            {

                var update = db.BRANDs.Find(id);
                update.brandName = entity.brandName;
                update.topBrand = entity.topBrand;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteBrand(int id)
        {
            try
            {
                var delete = db.BRANDs.Find(id);
                db.BRANDs.Remove(delete);
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