using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;
using MVCKinver.ViewModels;

namespace MVCKinver.Controllers
{
    public class ShoppingCartController : Controller
    {
        KinverEntities storeDB = new KinverEntities();

        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        // Get:/Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            //实际添加到购物车的是产品型号
            //var addedProduct = storeDB.Products.Single(
            //    product => product.ProductId == id);
            var addedProductSize = storeDB.ProductSizes.Single(
                ps => ps.ProductSizeId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProductSize);
            return RedirectToAction("Index");
        }

        //Ajax: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var pId = storeDB.Carts.Single(c => c.RecordId == id).ProductId;
            string productName = storeDB.Products.Single(p => p.ProductId == pId).Title;
            int itemCount = cart.RemoveFromCart(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = "* " + Server.HtmlEncode(productName) +
                "已被从购物车中清除",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                EditId = id
            };
            return Json(results);
        }

        //Ajax: /ShoppingCart/Jia/5
        [HttpPost]
        public ActionResult Jia(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var pId = storeDB.Carts.Single(c => c.RecordId == id).ProductId;
            //string productName = storeDB.Products.Single(p => p.ProductId == pId).Title;
            int itemCount = cart.Jia(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = "",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                EditId = id
            };
            return Json(results);
        }

        //Ajax: /ShoppingCart/Jian/5
        [HttpPost]
        public ActionResult Jian(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var pId = storeDB.Carts.Single(c => c.RecordId == id).ProductId;
            //string productName = storeDB.Products.Single(p => p.ProductId == pId).Title;
            int itemCount = cart.Jian(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = "",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                EditId = id
            };
            return Json(results);
        }

        //Ajax: /ShoppingCart/EditCount/5
        [HttpPost]
        public ActionResult EditCount(int id,int count)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var pId = storeDB.Carts.Single(c => c.RecordId == id).ProductId;
            //string productName = storeDB.Products.Single(p => p.ProductId == pId).Title;
            int itemCount = cart.EditCount(id,count);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = "",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                EditId = id
            };
            return Json(results);
        }

        // Get: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            if (cart.GetCount() > 0)
            {
                return PartialView("CartSummary");
            }
            else {
                return null;
            }
            
        }
    }
}
