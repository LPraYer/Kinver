namespace MVCKinver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        ProducerId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 160),
                        IsHot = c.Int(nullable: false),
                        TitleEn = c.String(nullable: false),
                        AreaId = c.Int(nullable: false),
                        Description = c.String(),
                        SizeDescription = c.String(),
                        MainImageUrl = c.String(),
                        ProductOtherInfo_ProductOtherInfoId = c.Int(),
                        ProductValue_ProductValueId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.ProductOtherInfoes", t => t.ProductOtherInfo_ProductOtherInfoId)
                .ForeignKey("dbo.ProductValues", t => t.ProductValue_ProductValueId)
                .Index(t => t.GenreId)
                .Index(t => t.ProducerId)
                .Index(t => t.AreaId)
                .Index(t => t.ProductOtherInfo_ProductOtherInfoId)
                .Index(t => t.ProductValue_ProductValueId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Level = c.Int(nullable: false),
                        FatherGenreId = c.Int(nullable: false),
                        GenreUrl = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProducerId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductImageUrl = c.String(),
                        ProductImageTitle = c.String(),
                    })
                .PrimaryKey(t => t.ProductImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductOtherInfoes",
                c => new
                    {
                        ProductOtherInfoId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        TransportTemperature = c.String(),
                        StorageTemperature = c.String(),
                        ExpiryTime = c.String(),
                        AfterDefrosting = c.String(),
                        ThawingMethod = c.String(),
                    })
                .PrimaryKey(t => t.ProductOtherInfoId);
            
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        ProductSizeId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Size = c.String(),
                        NetWeightPerSingle = c.String(),
                        NetWeightPerBox = c.Int(nullable: false),
                        PricePerBox = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PricePerJin = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductSizeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductValues",
                c => new
                    {
                        ProductValueId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        EnergeticValue = c.Single(nullable: false),
                        Proteins = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbohydrate = c.Single(nullable: false),
                        DietaryFibre = c.Single(nullable: false),
                        Cholesterol = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductValueId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        KeyDescription = c.String(),
                        PlusDescription = c.String(),
                        ServiceImageUrl = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        DishId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Intro = c.String(),
                        ImageUrl = c.String(),
                        Remark = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DishId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.String(),
                        DishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Order = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StepId)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.ProductToServices",
                c => new
                    {
                        ProductToServiceId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductToServiceId);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        ContactInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MailAddress = c.String(),
                        PhoneNumber = c.String(),
                        Message = c.String(),
                        Service = c.String(),
                    })
                .PrimaryKey(t => t.ContactInfoId);
            
            CreateTable(
                "dbo.DishGenres",
                c => new
                    {
                        DishGenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.DishGenreId);
            
            CreateTable(
                "dbo.DishToDishGenres",
                c => new
                    {
                        DishToDishGenreId = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        DishGenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DishToDishGenreId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Steps", new[] { "DishId" });
            DropIndex("dbo.Materials", new[] { "DishId" });
            DropIndex("dbo.Dishes", new[] { "ProductId" });
            DropIndex("dbo.Services", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductSizes", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductValue_ProductValueId" });
            DropIndex("dbo.Products", new[] { "ProductOtherInfo_ProductOtherInfoId" });
            DropIndex("dbo.Products", new[] { "AreaId" });
            DropIndex("dbo.Products", new[] { "ProducerId" });
            DropIndex("dbo.Products", new[] { "GenreId" });
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Steps", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Materials", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Dishes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Services", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductSizes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductValue_ProductValueId", "dbo.ProductValues");
            DropForeignKey("dbo.Products", "ProductOtherInfo_ProductOtherInfoId", "dbo.ProductOtherInfoes");
            DropForeignKey("dbo.Products", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Products", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.Products", "GenreId", "dbo.Genres");
            DropTable("dbo.DishToDishGenres");
            DropTable("dbo.DishGenres");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.ProductToServices");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Carts");
            DropTable("dbo.Steps");
            DropTable("dbo.Materials");
            DropTable("dbo.Dishes");
            DropTable("dbo.Services");
            DropTable("dbo.ProductValues");
            DropTable("dbo.ProductSizes");
            DropTable("dbo.ProductOtherInfoes");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Areas");
            DropTable("dbo.Producers");
            DropTable("dbo.Genres");
            DropTable("dbo.Products");
        }
    }
}
