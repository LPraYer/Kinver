using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class Area
    {
        [ScaffoldColumn(false)]
        public int AreaId { set; get; }

        [DisplayName("产地名称")]
        public string Name { set; get; }

        public List<Product> Products { set; get; }
    }
}