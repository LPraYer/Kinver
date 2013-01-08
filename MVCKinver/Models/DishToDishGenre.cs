using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCKinver.Models
{
    public class DishToDishGenre
    {
        public int DishToDishGenreId { get; set; }

        public int DishId { get; set; }

        public int DishGenreId { get; set; }
    }
}