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

        public string SaleUnit { set; get; }

        public int NetWeightPerUnit { set; get; }

        public decimal PricePerUnit { set; get; }

        public decimal CostPerUnit { set; get; }

        public decimal PricePerKG { set; get; }

        public decimal CostPerKG { set; get; }
    }
}