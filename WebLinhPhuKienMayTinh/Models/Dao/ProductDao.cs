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
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebLinhPhuKienMayTinh.Models.Dao
{
    public class ProductDao
    {
        web db = null;
      
        public ProductDao()
        {
            db = new web();
        }
        public List<BRAND> ListBrand()
        {
            return db.BRANDs.ToList();
        }
        public List<CATEGORY> ListCategory()
        {
            return db.CATEGORies.ToList();
        }
        public int Productdadd(PRODUCT entity)
        {
                db.PRODUCTs.Add(entity);
                db.SaveChanges();
                return entity.productId;
  
        }
        public List<PRODUCT> ListNewProduct(int top)
        {
            return db.PRODUCTs.OrderByDescending(x => x.productId).Take(top).ToList();
        }
        public List<PRODUCT> ListFeatureProduct(int top)
        {
            return db.PRODUCTs.OrderByDescending(x => x.product_Remain).Take(top).ToList();
        }
        public IEnumerable<PRODUCT> ListAllproduct(string select_category, string select_brand, string select_type, string pricefrom, string priceto, string searchString, int page, int pageSize)
        { 
            
            var model= db.PRODUCTs.SqlQuery("select *from PRODUCT where catId like N'%" + select_category + "%' and brandId like N'%" + select_brand + "%' and types like N'%" + select_type + "%' order by productId desc");
            if (!string.IsNullOrEmpty(searchString))
            {
                if (!string.IsNullOrEmpty(priceto) && !string.IsNullOrEmpty(pricefrom))
                {
                   model = db.PRODUCTs.SqlQuery("select *from PRODUCT where catId like N'%"+select_category+"%' and brandId like N'%"+select_brand+"%' and types like N'%"+select_type+ "%' and (Convert(int,price)>=" + pricefrom + " and Convert(int,price)<" + priceto + ") and (product_Code like N'%"+searchString+"%' or productName like N'%"+searchString+ "%') order by productId desc");
                    
                } 
                else
                {
                    model = db.PRODUCTs.SqlQuery("select *from PRODUCT where catId like N'%" + select_category + "%' and brandId like N'%" + select_brand + "%' and types like N'%" + select_type + "%' and (product_Code like N'%" + searchString + "%' or productName like N'%" + searchString + "%') order by productId desc");
                }
            }
             else
            {
                if(!string.IsNullOrEmpty(priceto) && !string.IsNullOrEmpty(pricefrom))
                {
                    model = db.PRODUCTs.SqlQuery("select *from PRODUCT where catId like N'%" + select_category + "%' and brandId like N'%" + select_brand + "%' and types like N'%" + select_type + "%' and (Convert(int,price)>=" + pricefrom + " and Convert(int,price)<" + priceto + ")  order by productId desc");
                }
            }
             return model.ToPagedList(page,pageSize);
        }
        public BRAND ViewdetailBrand(int id)
        {

            return db.BRANDs.Find(id);//lay ra id

        }
       
        public BRAND ViewBrandNamebyProductId(int id)
        {

            var brand= Viewdetail(id).brandId;//lay ra id
            return db.BRANDs.Find(brand);

        }
        public PRODUCT ViewdetailBrandId(int id)
        {

            return db.PRODUCTs.Find(id);//lay ra id

        }
        public PRODUCT ViewdetailCatId(int id)
        {

            return db.PRODUCTs.Find(id);//lay ra id

        }

        public CATEGORY ViewdetailCat(int id)
        {

            return db.CATEGORies.Find(id);//lay ra id

        }
        public CATEGORY ViewCatNamebyProductId(int id)
        {

            var cat = Viewdetail(id).catId;//lay ra id
            return db.CATEGORies.Find(cat);

        }
        
        public bool DeleteProduct(int id)
        {
            try
            {
                var delete = db.PRODUCTs.Find(id);
                db.PRODUCTs.Remove(delete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public PRODUCT Viewdetail(int id)
        {

            return db.PRODUCTs.Find(id);//lay ra id

        }
        public bool UpdateProduct(PRODUCT entity, int id)
        {
            try// su ly ngoai le
            {

                var update = db.PRODUCTs.Find(id);
                update.productName = entity.productName;
                update.product_Code = entity.product_Code;
                update.productQuantity = entity.productQuantity;
                update.product_Desc = entity.product_Desc;
                update.price = entity.price;
                update.types = entity.types;
                update.brandId = entity.brandId;
                update.catId = entity.catId;
                update.images = entity.images;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool EnterProduct(PRODUCT entity, int id)
        {
            try// su ly ngoai le
            {

                var update = db.PRODUCTs.Find(id);
                update.product_Remain = entity.product_Remain;              
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public int InsertWareHose(WAREHOUSE entity,int id)
        {
            db.WAREHOUSEs.Add(entity);
            db.SaveChanges();
            return entity.id_warehouse;

        }
    }
}