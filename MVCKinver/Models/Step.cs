using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCKinver.Models
{
    public class Step
    {
        public int StepId { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public int DishId { get; set; }
    }
}