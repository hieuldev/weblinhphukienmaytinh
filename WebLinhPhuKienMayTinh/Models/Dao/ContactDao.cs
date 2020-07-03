using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Models.Dao
{
    
    public class ContactDao
    {
        web db = null;
        public ContactDao()
        {
            db = new web();
        }
        
    }
}