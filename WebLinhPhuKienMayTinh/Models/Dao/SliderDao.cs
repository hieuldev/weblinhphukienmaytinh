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

    public class SliderDao
    {
        web db = null;
        public SliderDao()
        {
            db = new web();
        }
        public int AddSlider(SLIDER entity)
        {
            db.SLIDERs.Add(entity);
            db.SaveChanges();
            return entity.sliderID;

        }
        public IEnumerable<SLIDER> ListAllSlider(string searchString, int page, int pageSize)
        {
            IQueryable<SLIDER> model = db.SLIDERs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sliderName.Contains(searchString));
                //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.sliderID).ToPagedList(page, pageSize);
        }
        public SLIDER Viewdetail(int id)
        {

            return db.SLIDERs.Find(id);//lay ra id

        }
        public bool UpdateSlider(SLIDER entity, int id)
        {
            try// su ly ngoai le
            {

                var update = db.SLIDERs.Find(id);
                update.sliderName = entity.sliderName;
                update.slider_Image= entity.slider_Image;
                update.type0 = entity.type0;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteSlider(int id)
        {
            try
            {
                var delete = db.SLIDERs.Find(id);
                db.SLIDERs.Remove(delete);
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