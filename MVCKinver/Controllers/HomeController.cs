using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{
    public class HomeController : Controller
    {
        KinverEntities storeDB = new KinverEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //get most popular products
            var products = GetTopSellingProducts(3);
            return View(products);
        }

        private List<Product> GetTopSellingProducts(int count)
        {
            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}
