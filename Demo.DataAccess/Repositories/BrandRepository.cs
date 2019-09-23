using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.DataAccessObjects
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(IUnitOfWork<WebDbContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
