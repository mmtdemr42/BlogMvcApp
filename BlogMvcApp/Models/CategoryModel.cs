﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public String CategoryName { get; set; }
        public int CategoryProductCount { get; set; }
    }
}