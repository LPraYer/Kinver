using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCKinver.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<KinverEntities>
    {
        protected override void Seed(KinverEntities context)
        {
            #region 分类genre
            var genres = new List<Genre>
            {
                new Genre { 
                    GenreId = 1,
                    Name = "肉类" , 
                    Description = "进口肉类" ,
                    Level = 0 , 
                    FatherGenreId = 0,
                },
                new Genre { 
                    GenreId =2,
                    Name = "水产" , 
                    Description = "进口水产" ,
                    Level = 0 , 
                    FatherGenreId = 0 },
                new Genre { 
                    GenreId =3,
                    Name = "配料" , 
                    Description = "进口配料" ,
                    Level = 0 , 
                    FatherGenreId = 0 },
                new Genre { 
                    GenreId =4,
                    Name = "牛肉" , 
                    Description = "进口牛肉" ,
                    Level = 1 , 
                    FatherGenreId = 1,
                    GenreUrl = "Beaf"
                },
                new Genre { 
                    GenreId =5,
                    Name = "猪肉" , 
                    Description = "进口猪肉" ,
                    Level = 1 , 
                    FatherGenreId = 1,
                    GenreUrl = "Pork"
                },
                new Genre { 
                    GenreId =6,
                    Name = "羊肉" , 
                    Description = "进口羊肉" ,
                    Level = 1 , 
                    FatherGenreId = 1,
                    GenreUrl = "Mutton"
                },
                new Genre { 
                    GenreId =7,
                    Name = "鱼" , 
                    Description = "进口鱼" ,
                    Level = 1 , 
                    FatherGenreId = 2,
                    GenreUrl = "Fishes"
                },
                new Genre { 
                    GenreId =8,
                    Name = "虾" , 
                    Description = "进口虾" ,
                    Level = 1 , 
                    FatherGenreId = 2,
                    GenreUrl = "Shrimps"
                },
                new Genre { 
                    GenreId =9,
                    Name = "蟹" , 
                    Description = "进口蟹" ,
                    Level = 1 , 
                    FatherGenreId = 2,
                    GenreUrl = "Crabs"
                },
                new Genre { 
                    GenreId =10,
                    Name = "贝壳" , 
                    Description = "进口贝壳" ,
                    Level = 1 , 
                    FatherGenreId = 2,
                    GenreUrl = "Shells"
                },
                new Genre { 
                    GenreId =11,
                    Name = "油料" , 
                    Description = "进口油料" ,
                    Level = 1 , 
                    FatherGenreId = 3,
                    GenreUrl = "Oils"
                },
                new Genre { 
                    GenreId =12,
                    Name = "奶酪" , 
                    Description = "进口奶酪" ,
                    Level = 1 , 
                    FatherGenreId = 3,
                    GenreUrl = "Cheese"
                },
            };
            genres.ForEach(a => context.Genres.Add(a));
            #endregion

            #region 供应商Producer
            var producers = new List<Producer>
            {
                new Producer { Name = "景悦锦辰" },
                new Producer { Name = "京申" }
            };
            producers.ForEach(a => context.Producers.Add(a));
            #endregion

            #region Area
            var areas = new List<Area>
            {
                new Area {Name = "挪威"},
                new Area {Name = "越南"},
                new Area {Name = "阿拉斯加"},
                new Area {Name = "伊朗"}
            };
            areas.ForEach(a => context.Areas.Add(a));
            #endregion

            #region Dishes
            var dishes = new List<Dish> 
            { 
                new Dish {Content = "香油帝王蟹",ProductId = 1},
                new Dish {Content = "爆炒黑虎虾,做法配料什么的看需要设计字段",ProductId = 2},
                new Dish {Content = "蒜香黑虎虾",ProductId = 2}
            };
            dishes.ForEach(a => context.Dishes.Add(a));
            #endregion

            #region ProductImages
            var productimages = new List<ProductImage>
            {
                new ProductImage {ProductId = 1,ProductImageUrl = "Crab_2.jpg",ProductImageTitle = "帝王蟹2"},
                new ProductImage {ProductId = 1,ProductImageUrl = "Crab_3.jpg",ProductImageTitle = "帝王蟹3"},
                new ProductImage {ProductId = 1,ProductImageUrl = "Crab_4.jpg",ProductImageTitle = "帝王蟹4"},
                new ProductImage {ProductId = 2,ProductImageUrl = "BlackTigerShrimp_2.jpg",ProductImageTitle = "黑虎虾2"},
                new ProductImage {ProductId = 2,ProductImageUrl = "BlackTigerShrimp_3.jpg",ProductImageTitle = "黑虎虾3"},
                new ProductImage {ProductId = 2,ProductImageUrl = "BlackTigerShrimp_4.jpg",ProductImageTitle = "黑虎虾4"},
                new ProductImage {ProductId = 2,ProductImageUrl = "BlackTigerShrimp_5.jpg",ProductImageTitle = "黑虎虾5"}
            };
            productimages.ForEach(a => context.ProductImages.Add(a));
            #endregion

            #region ProductOtherInfoes
            var productotherinfoes = new List<ProductOtherInfo>
            {
                new ProductOtherInfo {
                    ProductId = 1,
                    TransportTemperature = "低于-18℃",
                    StorageTemperature = "低于-20℃",
                    ExpiryTime = "240天",
                    AfterDefrosting = "请于24小时内食用，不可复冻",
                    ThawingMethod = "常温"
                    },
                new ProductOtherInfo {
                    ProductId = 2,
                    TransportTemperature = "低于-18℃",
                    StorageTemperature = "低于-20℃",
                    ExpiryTime = "240天",
                    AfterDefrosting = "请于24小时内食用，不可复冻",
                    ThawingMethod = "常温"
                    }
            };
            productotherinfoes.ForEach(a => context.ProductOtherInfoes.Add(a));
            #endregion

            #region ProductSize
            var productsizes = new List<ProductSize>
            {
                new ProductSize{
                    ProductId = 1,
                    Size = "16/20",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 111.00M
                    },
                new ProductSize{
                    ProductId = 1,
                    Size = "04/08",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 111.00M
                    },
                new ProductSize{
                    ProductId = 1,
                    Size = "08/12",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 330.00M
                    },
                new ProductSize{
                    ProductId = 1,
                    Size = "12/16",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 330.00M
                    },
                new ProductSize{
                    ProductId = 2,
                    Size = "08/12",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 330.00M
                    },
                    new ProductSize{
                    ProductId = 2,
                    Size = "12/16",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 330.00M
                    },
                    new ProductSize{
                    ProductId = 2,
                    Size = "16/20",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 330.00M
                    },
                    new ProductSize{
                    ProductId = 2,
                    Size = "20/24",
                    NetWeightPerSingle = "最小133克，最大200克",
                    NetWeightPerBox = 700,
                    PricePerBox = 330.00M
                    }
            };
            productsizes.ForEach(a => context.ProductSizes.Add(a));
            #endregion

            #region ProductToService
            var producttoservices = new List<ProductToService>
            {
                new ProductToService{
                    ProductId = 1,
                    ServiceId = 1
                },
                new ProductToService{
                    ProductId = 1,
                    ServiceId = 2
                },
                new ProductToService{
                    ProductId = 1,
                    ServiceId = 3
                },
                new ProductToService{
                    ProductId = 2,
                    ServiceId = 1
                },
                new ProductToService{
                    ProductId = 2,
                    ServiceId = 2
                },
                new ProductToService{
                    ProductId = 2,
                    ServiceId = 3
                }
            };
            producttoservices.ForEach(a => context.ProductToServices.Add(a));
            #endregion

            #region ProductValue
            var productvalue = new List<ProductValue>
            {
                new ProductValue {
                    ProductId = 1,
                    EnergeticValue = 11,
                    Proteins = 22,
                    Fat = 33,
                    Carbohydrate = 44,
                    DietaryFibre = 55,
                    Cholesterol = 66
                },
                new ProductValue {
                    ProductId = 2,
                    EnergeticValue = 11,
                    Proteins = 22,
                    Fat = 33,
                    Carbohydrate = 44,
                    DietaryFibre = 55,
                    Cholesterol = 66
                }
            };
            productvalue.ForEach(a => context.ProductValues.Add(a));
            #endregion



            new List<Product>
            {
                new Product { 
                    Title = "挪威深海帝王蟹 - 蟹腿",
                    TitleEn = "Norway KingCrab - Legs",
                    Genre = genres.Single(g => g.Name == "蟹"), 
                    Area = areas.Single(a => a.Name == "挪威"),
                    Producer = producers.Single(a => a.Name == "景悦锦辰"),
                    Description = "帝王蟹又名皇帝蟹、石蟹或岩蟹，即石蟹科的甲壳类，它们主要分布在寒冷的海域。因其体型巨大而得名，素有“蟹中之王”的美誉。由于它们的体型巨大及肉质美味，很多物种都被广泛捕捉来作为食物，当中最为普遍的是堪察加拟石蟹。",
                    SizeDescription = "每个马斯科箱的容量",
                    ProductValue = productvalue.Single(v => v.ProductId == 1),
                    ProductImages = productimages.FindAll(i => i.ProductId == 1),
                    Dishes = dishes.FindAll( d => d.ProductId == 1),
                    ProductOtherInfo = productotherinfoes.Single(o => o.ProductId ==1 ),
                    ProductSizes = productsizes.FindAll(s => s.ProductId == 1),
                    MainImageUrl = "Crab_1.jpg",
                    IsHot = 1 
                },
                new Product { 
                    Title = "黑虎虾 - 整虾",
                    TitleEn = "Black Tiger Shrimp - HOSO",
                    Genre = genres.Single(g => g.Name == "虾"), 
                    Area = areas.Single(a => a.Name == "越南"),
                    Producer = producers.Single(a => a.Name == "景悦锦辰"),
                    Description = "黑虎虾原产于东南亚、越南、泰国和缅甸，其中以越南南部出产的黑虎虾最为鲜美甘甜，肉质饱满弹性十足。 湄公河与南中国海咸淡交界处，矿物质含量丰富，所以这里产的虾营养丰富，肥美无比。 黑虎大虾越大越珍贵，特别是2头以上的，野生的黑虎大虾产量更是稀缺。",
                    SizeDescription = "每个马斯科箱的容量",
                    ProductValue = productvalue.Single(v => v.ProductId == 2),
                    ProductImages = productimages.FindAll(i => i.ProductId == 2),
                    Dishes = dishes.FindAll( d => d.ProductId == 2),
                    ProductOtherInfo = productotherinfoes.Single(o => o.ProductId == 2 ),
                    ProductSizes = productsizes.FindAll(s => s.ProductId == 2),
                    MainImageUrl = "BlackTigerSHrimp_1.jpg",
                    IsHot = 1 
                }
            }.ForEach(a => context.Products.Add(a));

            new List<Service>
            {
                new Service {Title = "礼盒礼券",KeyDescription = "以“礼”服人，选择景悦锦辰",PlusDescription = "景悦锦辰为您提供多样化的礼盒服务，您可以从以下搭配礼盒中任选，亦可以个性化选择产品组合进行定制。",ServiceImageUrl = "Giftbox.png"},
                new Service {Title = "餐厅配送",KeyDescription = "餐厅配送业务主要描述餐厅配送业务主要描述",PlusDescription = "餐厅配送业务次要描述",ServiceImageUrl = "Canting.png"},
                new Service {Title = "家庭配送",KeyDescription = "家庭配送业务主要描述",PlusDescription = "家庭配送业务次要描述",ServiceImageUrl = "Jiating.png"}
            }.ForEach(a => context.Services.Add(a));
        }
    }
}