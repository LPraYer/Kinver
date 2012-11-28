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
        public int GenreId { get; set; }

        [DisplayName("供应商")]
        public int ProducerId { get; set; }

        [DisplayName("产品名称")]
        [Required(ErrorMessage = "A Product Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [DisplayName("价格")]
        [Required(ErrorMessage= "Price is required")]
        [Range(0.01,1000.00,ErrorMessage="Price must be between 0.01 and 1000.00")]
        public decimal Price { get; set; }

        [DisplayName("产品图片地址")]
        [StringLength(1024)]
        public string ProductImageUrl { get; set; }
        
        public Genre Genre { get; set; }
        
        public Producer Producer { get; set; }

        public int IsHot { get; set; }

        //public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}