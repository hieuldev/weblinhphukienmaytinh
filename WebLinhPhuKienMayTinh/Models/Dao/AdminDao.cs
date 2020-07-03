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
    public class AdminDao
    {
        web db = null;
        public AdminDao()
        {
            db = new web();
        }
        public long Insert(ADMIN entity)
        {
            db.ADMINs.Add(entity);
            db.SaveChanges();
            return entity.adminId;
        }
        public ADMIN GetId(string userName)
        {
            return db.ADMINs.SingleOrDefault(x => x.adminUser == userName);
        }
        public ADMIN ViewProfile(int id)
        {
            return db.ADMINs.Find(id);
        }
        public bool LoginAdmin(string userName, string PassWord)
        {
            var result = db.ADMINs.Count(x => x.adminUser == userName && x.adminPass == PassWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Changepassword(string userName, string PassWord,string newPassWord)
        {
            var result = db.ADMINs.Count(x => x.adminUser == userName && x.adminPass == PassWord);
            if (result > 0)
            {
                var update = db.ADMINs.SingleOrDefault(x => x.adminUser == userName&&x.adminPass== PassWord);
                update.adminPass = newPassWord;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
      
    }

}
