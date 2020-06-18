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
    public class OrderDao
    {
        web db = null;
        public OrderDao()
        {
            db = new web();
        }
        public IEnumerable<ORDER> ListAllOrder(string searchString, int page, int pageSize)
        {
            IQueryable<ORDER> model = db.ORDERS;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.productName.Contains(searchString));
                //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.dateorder).ToPagedList(page, pageSize);
        }
        
        public bool UpdateOrder(int productId,int customerId)
        {
            var update = db.ORDERS.SingleOrDefault(x => x.productId == productId && x.customer_id == customerId);
            update.statuss = 1;
            db.SaveChanges();
            return true;
            
        }
    }
}