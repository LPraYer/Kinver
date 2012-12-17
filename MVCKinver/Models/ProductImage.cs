using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ProductImage
    {
        public int ProductImageId { set; get; }

        public int ProductId { set; get; }

        [DisplayName("图片文件名")]
        public string ProductImageUrl { set; get; }

        [DisplayName("图片Title")]
        public string ProductImageTitle { set; get; }

    }
}