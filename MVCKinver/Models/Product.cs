using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    [Bind(Exclude = "ProductId")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("类别")]
        [Required(ErrorMessage="分类必填")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [DisplayName("供应商")]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        [DisplayName("产品名称")]
        [Required(ErrorMessage = "产品名称必填")]
        [StringLength(160)]
        public string Title { get; set; }

        //[DisplayName("价格")]
        //[Required(ErrorMessage= "Price is required")]
        //[Range(0.01,1000.00,ErrorMessage="Price must be between 0.01 and 1000.00")]
        //public decimal Price { get; set; }

        //[DisplayName("产品图片地址")]
        //[StringLength(1024)]
        //public string ProductImageUrl { get; set; }
        
        [DisplayName("是否首页推荐")]
        public int IsHot { get; set; }

        //public virtual List<OrderDetail> OrderDetails { get; set; }
    

        //20121128
        [DisplayName("产品英文名")]
        [Required(ErrorMessage="产品英文名必填")]
        public string TitleEn { get; set; }

        [DisplayName("产地")]
        public int AreaId { get; set; }

        public Area Area { get; set; }

        [DisplayName("产品描述")]
        public string Description { get; set; }

        [DisplayName("产品规格说明")]
        public string SizeDescription { get; set; }

        public string MainImageUrl { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public ProductOtherInfo ProductOtherInfo { get; set; }

        public List<ProductSize> ProductSizes { get; set; }

        public ProductValue ProductValue { get; set; }

        public List<Service> Services { get; set; }

        public List<Dish> Dishes { get; set; }
    
    }
}