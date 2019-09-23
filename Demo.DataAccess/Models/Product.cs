﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public IList<ProductColor> ProductColors { get; set; }
    }
}
