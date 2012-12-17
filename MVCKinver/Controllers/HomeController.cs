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
            foreach (var p in products)
            {
                //p.ProductImages = storeDB.ProductImages.Where(i => i.ProductId == p.ProductId).ToList();
                p.ProductSizes = storeDB.ProductSizes.Where(i => i.ProductId == p.ProductId).ToList();
                
            };
            this.ViewBag.menuSelected = "home";
            return View(products);
        }

        // Get: /首页推荐产品逻辑/
        private List<Product> GetTopSellingProducts(int count)
        {
            return storeDB.Products.OrderByDescending(a => a.IsHot == 1).Take(count).ToList();
        }

        // Get: /导航栏中的分类
        public ActionResult GenreMenuForNav()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }

        // Get: /Home/About
        public ActionResult About()
        {
            return View();
        }

        // Get: /Home/Contact
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
