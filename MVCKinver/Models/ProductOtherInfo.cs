using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ProductOtherInfo
    {
        public int ProductOtherInfoId { set; get; }

        public int ProductId { set; get; }

        public string TransportTemperature { set; get; }

        public string StorageTemperature { set; get; }

        public string ExpiryTime { set; get; }

        public string AfterDefrosting { set; get; }

        public string ThawingMethod { set; get; }
    }
}