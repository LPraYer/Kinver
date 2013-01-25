using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCKinver.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductSizeId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public virtual Order Order { get; set; }
    }
}