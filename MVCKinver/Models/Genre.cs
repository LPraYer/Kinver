﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCKinver.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}