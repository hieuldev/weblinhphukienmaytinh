using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLinhPhuKienMayTinh.Models.EF;
namespace WebLinhPhuKienMayTinh.Models.Dao
{
    public class ProductCategoryDao
    {
        web db = null;
        public ProductCategoryDao()
        {
            db = new web();
        }
        public List<CATEGORY> ListAll()
        {
            return db.CATEGORies.ToList();
        }
    }
}