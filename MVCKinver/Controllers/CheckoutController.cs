using System;
using System.Linq;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{
    //[Authorize]
    public class CheckoutController : Controller
    {
        KinverEntities storeDB = new KinverEntities();
        //const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            string BDTAll = "";
            string[] BDTs = values.GetValues("BestDeliverTime");
            if (BDTs != null)
            {
                foreach (var BDT in BDTs)
                {
                    BDTAll = BDTAll + BDT;
                }
            }
            order.BestDeliverTime = BDTAll;
            //var BDT = "";
            //for (int k = 0; k < Request.Form.AllKeys.Length ; k++ )
            //{
            //    if (Request.Form.GetKey(k) == "BestDeliverTime")
            //    {
            //        BDT = BDT + Request.Form.GetValues(k);
            //    }
            //}
            //order.BestDeliverTime = BDT;
            try
            {
                //if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                //{
                //    return View(order);
                //}
                //else
                //{
                    //order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    storeDB.SaveChanges();
                    return RedirectToAction("Complete");
                //}
            }
            catch
            { 
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //GET: /Checkout/Complete
        public ActionResult Complete()
        { 
            //Validate customer owns this order
            //bool isValid = storeDB.Orders.Any(
            //    o => o.OrderId == id
            // && o.Username == User.Identity.Name);
            //if (isValid)
            //{
            //    return View(id);
            //}
            //else
            //{
            //    return View("Error");
            //}
            return View();
        }

    }
}
