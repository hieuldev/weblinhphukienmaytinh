using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Models
{
    public class CartItem
    {
        
        public PRODUCT Product { set; get; }
        public int Quantity { set; get; }
    }
}