using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.DataAccess.Models
{
    public class ProductColor
    {  
        public Product Product { get; set; }

        public int ProductId { get; set; } 

        public Color Color { get; set; }

        public int ColorId { get; set; }

        public float Price { get; set; }
    }
}
