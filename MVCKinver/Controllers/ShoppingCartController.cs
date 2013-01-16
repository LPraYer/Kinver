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
                Message = Server.HtmlEncode(productName) +
                "已被从购物车中清除。",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        // Get: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}
