using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLinhPhuKienMayTinh.Areas.Admin.Models
{
    public class WarehouseModel
    {
        public string productName { set; get; }
        public string product_Code { set; get; }
        public string productQuantity { set; get; }

        public string procduct_Soldout { set; get; }

        public string product_Remain { set; get; }
        public string product_more_quantity { get; set; }
        public DateTime? sl_Ngaynhap { get; set; }
    }
}