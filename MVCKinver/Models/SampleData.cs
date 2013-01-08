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

            /*
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
                new Area {Name = "伊朗"},
                new Area {Name = "智利"}
            };
            areas.ForEach(a => context.Areas.Add(a));
            #endregion

            #region Materials 菜式材料
            var materials = new List<Material>
            {
                new Material {Name="阿拉斯加帝王蟹腿",Weight="",DishId=1},
                new Material {Name="青蒜",Weight="",DishId=1},
                new Material {Name="姜末",Weight="",DishId=1},
                new Material {Name="料酒",Weight="",DishId=1},
                new Material {Name="盐",Weight="",DishId=1},
                new Material {Name="白糖",Weight="",DishId=1},
                new Material {Name="米醋",Weight="",DishId=1},
                new Material {Name="胡椒粉",Weight="",DishId=1},
                new Material {Name="水淀粉",Weight="",DishId=1},
                new Material {Name="香油",Weight="",DishId=1},
                new Material {Name="清水",Weight="",DishId=1},

                new Material {Name="阿拉斯加帝王蟹腿",Weight="",DishId=2},
                new Material {Name="独蒜头",Weight="",DishId=2},
                new Material {Name="姜",Weight="",DishId=2},
                new Material {Name="葱",Weight="",DishId=2},
                new Material {Name="辣椒酱",Weight="",DishId=2},
                new Material {Name="盐",Weight="",DishId=2},
                new Material {Name="油",Weight="",DishId=2},

            };
            materials.ForEach(m => context.Materials.Add(m));
            #endregion

            #region Steps 菜式步骤
            var steps = new List<Step> { 
                new Step {Content="将阿拉斯加王蟹腿解冻后，切成适中的段，青蒜切段；",Order=1,DishId=1},
                new Step {Content="锅里加热油，下入青蒜、姜末，煸出香味，即可下蟹腿，再加入白糖、盐和清水200ml；",Order=2,DishId=1},
                new Step {Content="在旺火上烧开后，改用小火烧到汤汁转浓时，加入其他调料，再改用旺火，用水淀粉勾芡，颠翻几下，淋入香油即成。",Order=3,DishId=1},
                new Step {Content="将阿拉斯加王蟹腿解冻后切成适当大小的块；",Order=1,DishId=2},
                new Step {Content="蒜头去皮切片，姜切片，葱切成粗粒；",Order=2,DishId=2},
                new Step {Content="加热油，加入蒜、姜、葱、辣椒酱爆香，再加入螃蟹5和适量的盐翻炒；",Order=3,DishId=2},
                new Step {Content="加水适量，盖上盖子慢火焖10分钟，再用大火把多余的水蒸发掉即成。",Order=4,DishId=2},
                new Step {Content="",Order=1,DishId=3},
                new Step {Content="",Order=2,DishId=3},
                new Step {Content="",Order=3,DishId=3},
                new Step {Content="",Order=4,DishId=3},
                new Step {Content="",Order=5,DishId=3},
                new Step {Content="",Order=1,DishId=4},
                new Step {Content="",Order=2,DishId=4},
                new Step {Content="",Order=3,DishId=4},
                new Step {Content="",Order=4,DishId=4},
                new Step {Content="",Order=5,DishId=4},
            };
            steps.ForEach(s => context.Steps.Add(s));
            #endregion

            #region Dishes
            var dishes = new List<Dish> 
            { 
                new Dish {
                    DishId = 1,
                    Title = "香油阿拉斯加帝王蟹",
                    ProductId = 1,
                    Intro = "素有“蟹中之王”之称的帝王蟹因其硕大肥美，生长于寒冷的深海水域绿色无污染而深受人们的喜爱和推崇。如果生食，您将亲眼看到帝王蟹那晶莹剔透、令人垂涎欲滴的蟹脂蟹膏；而炭火烤的，仅从香飘满屋、烟雾萦绕的蟹腿中便可嗅出帝王蟹那独有的甜美气息。",
                    ImageUrl = "1",
                    Remark = "菜式内容来源于LPraYer@下厨房"
                },
                new Dish {
                    DishId = 2,
                    Title = "蒜头阿拉斯加帝王蟹",
                    ProductId = 1,
                    Intro = "",
                    ImageUrl = "2",
                    Remark = ""
                },
                new Dish {
                    DishId = 3,
                    Title = "香油帝王蟹",
                    ProductId = 2,
                    Intro = "",
                    ImageUrl = "",
                    Remark = ""
                },
                new Dish {
                    DishId = 4,
                    Title = "香油帝王蟹",
                    ProductId = 2,
                    Intro = "",
                    ImageUrl = "",
                    Remark = ""
                },
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


            #region Product
            new List<Product>
            {
                new Product { 
                    Title = "阿拉斯加深海帝王蟹",
                    TitleEn = "Alaska KingCrab - Legs",
                    Genre = genres.Single(g => g.Name == "蟹"), 
                    Area = areas.Single(a => a.Name == "阿拉斯加"),
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
            #endregion

            #region service
            new List<Service>
            {
                new Service {Title = "礼盒礼券",KeyDescription = "以“礼”服人，选择景悦锦辰",PlusDescription = "景悦锦辰为您提供多样化的礼盒服务，您可以从以下搭配礼盒中任选，亦可以个性化选择产品组合进行定制。",ServiceImageUrl = "Giftbox.png"},
                new Service {Title = "餐厅配送",KeyDescription = "餐厅配送业务主要描述餐厅配送业务主要描述",PlusDescription = "餐厅配送业务次要描述",ServiceImageUrl = "Canting.png"},
                new Service {Title = "家庭配送",KeyDescription = "家庭配送业务主要描述",PlusDescription = "家庭配送业务次要描述",ServiceImageUrl = "Jiating.png"}
            }.ForEach(a => context.Services.Add(a));
            #endregion

             */
        }
    }
}