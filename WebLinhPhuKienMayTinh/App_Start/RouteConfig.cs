using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebLinhPhuKienMayTinh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Chi tiet",
               url: "chi-tiet/{productName}-{id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
           );
            routes.MapRoute(
                  name: "Gio hang",
                  url: "them-gio-hang",
                  defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Xem Gio hang",
                  url: "gio-hang",
                  defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Thanh toan offline",
                  url: "thanh-toan-offline",
                  defaults: new { controller = "Cart", action = "Offlinepayment", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Thanh toan online",
                  url: "thanh-toan-online",
                  defaults: new { controller = "Cart", action = "Onlinepayment", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );

            routes.MapRoute(
                  name: "Thanh toan visa",
                  url: "thanh-toan-visa",
                  defaults: new { controller = "Cart", action = "Visa", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Thanh toan noi dia",
                  url: "thanh-toan-noi-dia",
                  defaults: new { controller = "Cart", action = "NoiDia", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Thanh toan ",
                  url: "thanh-toan",
                  defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Liên hệ ",
                  url: "lien-he",
                  defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                  name: "Đăng ký ",
                  url: "dang-ky",
                  defaults: new { controller = "Customer", action = "Register", id = UrlParameter.Optional },
                  namespaces: new[] { "WebLinhPhuKienMayTinh.Controllers" }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebLinhPhuKienMayTinh.Controllers"}
            );
        }
    }
}
