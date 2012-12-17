using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ProductToService
    {
        public int ProductToServiceId { set; get; }

        public int ProductId { set; get; }

        public int ServiceId { set; get; }
    }
}