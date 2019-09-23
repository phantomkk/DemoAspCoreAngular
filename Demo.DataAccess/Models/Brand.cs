using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
