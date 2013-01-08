using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class Dish
    {
        public int DishId { set; get; }

        public string Title { set; get; }

        public string Intro { set; get; }

        public string ImageUrl { set; get; }

        public string Remark { set; get; }

        public List<Material> Materials { set; get; }

        public List<Step> Steps { set; get; }

        public int ProductId { set; get; }
    }
}