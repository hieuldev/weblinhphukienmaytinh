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
    public class CustomerDao
    {
        web db = null;
        public CustomerDao()
        {
            db = new web();
        }

        public IEnumerable<CUSTOMER> UserProfile(string searchString, int page, int pageSize)
        {
            IQueryable<CUSTOMER> model = db.CUSTOMERs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.address0.Contains(searchString) || x.city.Contains(searchString) || x.zipcode.Contains(searchString) || x.email.Contains(searchString) || x.phone.Contains(searchString));
                //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.customer_id).ToPagedList(page, pageSize);
        }
        public CUSTOMER Viewdetail(int id)
        {

            return db.CUSTOMERs.Find(id);//lay ra id

        }
    }
}