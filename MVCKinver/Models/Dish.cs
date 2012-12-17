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

        public string Content { set; get; }

        public int ProductId { set; get; }
    }
}