using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{
    public class StoreController : Controller
    {
        KinverEntities storeDB = new KinverEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        //
        // GET: /Store/Browse?genre=Shrimps

        public ActionResult Browse(string genre)
        {
            if (storeDB.Genres.SingleOrDefault(g => g.GenreUrl == genre) != null)
            {
                ///当前分类选中项
                this.ViewBag.genreSelected = genre;

                ///当前菜单选中项
                this.ViewBag.menuSelected = "store";

                var genreModel = storeDB.Genres.Include("Products").Single(g => g.GenreUrl == genre);

                ///为每个产品添加所需信息，如规格价格
                foreach( var product in genreModel.Products)
                {
                    product.ProductSizes = storeDB.ProductSizes.Where(s => s.ProductId == product.ProductId).ToList();
                }
                
                return View(genreModel);
            }
            else
            {
                return RedirectToAction("NotFound","Error");
            }
        }
        //
        // GET: /Store/Detail/1

        public ActionResult Details(int id)
        {
            
            if (storeDB.Products.Find(id) != null)
            {
                this.ViewBag.menuSelected = "store";
                
                var productModel = storeDB.Products.Find(id);

                //添加分类
                productModel.Genre = storeDB.Genres.Find(productModel.GenreId);

                //添加供应商
                productModel.Producer = storeDB.Producers.Find(productModel.ProducerId);

                //向产品中添加对应的服务
                var ptss = storeDB.ProductToServices.Where( p => p.ProductId == productModel.ProductId);
                if (ptss != null)
                {
                    productModel.Services = new List<Service>();
                    foreach (var pts in ptss)
                    {
                        var s = storeDB.Services.Find(pts.ServiceId);
                        productModel.Services.Add(s);
                    };
                }

                //添加对应的图片
                var pimages = storeDB.ProductImages.Where(i => i.ProductId == productModel.ProductId).ToList();
                if (pimages != null)
                {
                    productModel.ProductImages = new List<ProductImage>();
                    foreach (var pimage in pimages)
                    {
                        productModel.ProductImages.Add(pimage);
                    };
                }

                //添加产地
                productModel.Area = storeDB.Areas.Find(productModel.AreaId);

                //添加对应的规格
                var psizes = storeDB.ProductSizes.Where(s => s.ProductId == productModel.ProductId).ToList();
                if (psizes != null)
                {
                    productModel.ProductSizes = new List<ProductSize>();
                    foreach (var psize in psizes)
                    {
                        psize.PricePerJin = Math.Round(psize.PricePerBox / psize.NetWeightPerBox * 500,2) ;
                        productModel.ProductSizes.Add(psize);
                    }
                }

                //添加菜式
                var dishes = storeDB.Dishes.Where(d => d.ProductId == productModel.ProductId).ToList();
                if (dishes != null)
                {
                    productModel.Dishes = new List<Dish>();
                    foreach (var dish in dishes)
                    {
                        productModel.Dishes.Add(dish);
                    }
                }

                //添加营养表
                productModel.ProductValue = storeDB.ProductValues.SingleOrDefault(v => v.ProductId == productModel.ProductId);

                //添加其他说明表
                productModel.ProductOtherInfo = storeDB.ProductOtherInfoes.SingleOrDefault(o => o.ProductId == productModel.ProductId);

                //左侧列表内容
                this.ViewBag.productList = storeDB.Products.Where(p => p.GenreId == productModel.GenreId).Take(10).ToList();


                return View(productModel);
            }
            else
            {
                return RedirectToAction("NotFound","Error");
            }
        }

        //
        //Get: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }

    }
}