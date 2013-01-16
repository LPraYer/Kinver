using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ShoppingCart
    {
        KinverEntities storeDB = new KinverEntities();

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        //Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(ProductSize productsize)
        { 
            //获得匹配的购物车和产品实例
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == productsize.ProductSizeId);
            if (cartItem == null)
            {
                //如果没有购物车实例则创建一个新的
                cartItem = new Cart
                {
                    ProductId = productsize.ProductSizeId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            { 
                //如果已经存在一个购物车，则增加对应产品（及规格）的数量
                cartItem.Count ++;
            }
            //保存更改
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        { 
            //获得购物车
            var cartItem = storeDB.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }
                //保存更改
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(cart => cart.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            var cartItems = storeDB.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
            foreach (var cartItem in cartItems)
            {
                //这里比较绕，先填充产品规格，然后找到产品id，然后再填充产品，并重新填充产品规格
                var pss = storeDB.ProductSizes.Where(ps => ps.ProductSizeId == cartItem.ProductId).ToList();
                var pId = pss.Find(ps => ps.ProductSizeId == cartItem.ProductId).ProductId;
                cartItem.Product = storeDB.Products.Find(pId);
                cartItem.Product.ProductSizes = storeDB.ProductSizes.Where(ps => ps.ProductSizeId == cartItem.ProductId).ToList();
            }
            return cartItems;
        }

        public int GetCount()
        { 
            //获取每个产品的数量并叠加
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        { 
            //统计产品总价
            //decimal? total = (from cartItems in storeDB.Carts
            //                  where cartItems.CartId == ShoppingCartId
            //                  select (int?)cartItems.Count * cartItems.Product.Price).Sum();
            //return total ?? decimal.Zero;
            return 0;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            //遍历购物车的产品，添加到订单详细
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    //UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };
                //设置购物车的订单总价
               // orderTotal += (item.Count * item.Product.Price);
                storeDB.OrderDetails.Add(orderDetail);
            }
            //设置订单总价
            order.Total = orderTotal;
            //保存订单
            storeDB.SaveChanges();
            //清空购物车
            EmptyCart();
            //返回订单Id
            return order.OrderId;
        }

        //使用HttpContextBase访问Session
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                { 
                    //创建一个GUID
                    Guid tempCartId = Guid.NewGuid();
                    //用Session向客户端返回tempCartId
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        
        //当用户已登录，便使购物车关联其用户名
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(c => c.CartId == ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}