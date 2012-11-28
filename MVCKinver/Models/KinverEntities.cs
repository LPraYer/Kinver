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
        public DbSet<Service> Services { get; set; }


        //建立外链关系
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Product>().ToTable("Products");
        //    modelBuilder.Entity<Product>().HasRequired(p => p.Genre).WithMany().HasForeignKey(p => p.GenreId);

        //    //modelBuilder.Entity<Genre>().ToTable("Genres");
        //    modelBuilder.Entity<Genre>().HasMany(g => g.Products).WithRequired().HasForeignKey(g => g.GenreId);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}