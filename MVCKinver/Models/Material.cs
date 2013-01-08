using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        public string Name { get; set; }

        public string Weight { get; set; }

        public int DishId { get; set; }
    }
}