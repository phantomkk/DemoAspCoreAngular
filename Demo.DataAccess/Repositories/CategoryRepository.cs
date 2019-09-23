using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.DataAccessObjects
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(IUnitOfWork<WebDbContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
