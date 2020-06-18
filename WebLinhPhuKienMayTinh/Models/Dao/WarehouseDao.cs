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
using WebLinhPhuKienMayTinh.Areas.Admin.Models;
namespace WebLinhPhuKienMayTinh.Models.Dao
{
    public class WarehouseDao
    {
        web db = null;
        public WarehouseDao()
        {
            db = new web();
        }
        public IEnumerable<WarehouseModel> ListAll(string searchString, int page, int pageSize)
        {
            var query = db.Database.SqlQuery<WarehouseModel>("SELECT a.product_Code,a.productName,a.productQuantity,a.procduct_Soldout,b.product_more_quantity,a.product_Remain,b.sl_Ngaynhap FROM PRODUCT as a INNER JOIN WAREHOUSE as b ON a.productId=b.productId");
            
            if (!string.IsNullOrEmpty(searchString))
            {
                query = db.Database.SqlQuery<WarehouseModel>("SELECT a.product_Code,a.productName,a.productQuantity,a.procduct_Soldout,b.product_more_quantity,a.product_Remain,b.sl_Ngaynhap FROM PRODUCT as a INNER JOIN WAREHOUSE as b ON a.productId=b.productId where product_Code like N'%"+searchString+ "%' or productName like N'%"+searchString+"%'");
            }
            return query.OrderByDescending(x => x.sl_Ngaynhap).ToPagedList(page, pageSize);
           
        }
    }
}