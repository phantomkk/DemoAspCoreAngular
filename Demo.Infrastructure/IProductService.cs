using Demo.DataAccess.DataAccessObjects;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Business
{
    public interface IProductService
    {

        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetAllProducts();
    }
}
