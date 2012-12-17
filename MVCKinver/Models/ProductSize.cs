using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ProductSize
    {
        public int ProductSizeId { set; get; }

        public int ProductId { set; get; }

        public string Size { set; get; }

        public string NetWeightPerSingle { set; get; }

        public int NetWeightPerBox { set; get; }

        public decimal PricePerBox { set; get; }

        public decimal PricePerJin { set; get; }
    }
}