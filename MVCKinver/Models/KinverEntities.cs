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

        //20121128
        public DbSet<Area> Areas { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductOtherInfo> ProductOtherInfoes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductToService> ProductToServices { get; set; }
        public DbSet<ProductValue> ProductValues { get; set; }

        //20121206
        public DbSet<ContactInfo> ContactInfoes { get; set; }


        //建立外链关系
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("Products");
            //modelBuilder.Entity<Product>().HasRequired(p => p.Genre).WithMany().HasForeignKey(p => p.GenreId);

            //modelBuilder.Entity<Genre>().ToTable("Genres");
            //modelBuilder.Entity<Genre>().HasMany(g => g.Products).WithRequired().HasForeignKey(g => g.GenreId);

            ///产品和图片的1对多关系（为了方便首页和列表页使用，在产品表里增加了一个主图，其他附图在图片表中）
            modelBuilder.Entity<Product>().HasMany(p => p.ProductImages).WithRequired().HasForeignKey(i => i.ProductId);
            //modelBuilder.Entity<ProductImage>().HasRequired(i => i.Product).WithMany().HasForeignKey(i => i.ProductId);

            ///产品和菜式的1对多关系
            modelBuilder.Entity<Product>().HasMany(p => p.Dishes).WithRequired().HasForeignKey(d => d.ProductId);
            ///
            //modelBuilder.Entity<Product>().HasRequired(p => p.Genre).WithRequiredDependent();


            base.OnModelCreating(modelBuilder);
        }
    }
}