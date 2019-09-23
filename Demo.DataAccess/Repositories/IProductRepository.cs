using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.DataAccessObjects
{
    public interface IProductRepository: IRepository<Product>
    {
    }
}
