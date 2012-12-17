using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ProductValue
    {
        public int ProductValueId { set; get; }

        public int ProductId { set; get; }

        public float EnergeticValue { set; get; }

        public float Proteins { set; get; }

        public float Fat { set; get; }

        public float Carbohydrate { set; get; }

        public float DietaryFibre { set; get; }

        public float Cholesterol { set; get; }
    }
}