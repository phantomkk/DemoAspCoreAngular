using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<ProductColor> ProductColors { get; set; }
    }
}
