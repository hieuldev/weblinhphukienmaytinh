using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Models;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegiterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if(dao.CheckUserName(model.name))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if(dao.CheckMail(model.email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else if(dao.CheckPhone(model.phone))
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại");
                }
                else
                {
                    var customer = new CUSTOMER();
                    customer.name = model.name;
                    customer.password0 = model.password0;
                    customer.email = model.email;
                    customer.phone = model.phone;
                    customer.zipcode = model.zipcode;
                    customer.address0 = model.address0;
                    customer.city = model.city;
                    customer.country = model.country;
                    var result = dao.Insert(customer);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegiterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                    
                }
                
            }
            return View(model);
        }
    }
}