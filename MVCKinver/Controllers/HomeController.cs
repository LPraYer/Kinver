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
                p.Area = storeDB.Areas.Find(p.AreaId);
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
            //2013.1.11:Where(g => g.FatherGenreId == 0 || g.FatherGenreId == 2)目前只有水产类产品，所以先屏蔽掉其他类别
            var genres = storeDB.Genres.Where(g => g.FatherGenreId == 0 || g.FatherGenreId == 2).ToList();
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
