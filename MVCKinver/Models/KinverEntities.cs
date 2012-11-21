using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCKinver.Models
{
    public class KinverEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}