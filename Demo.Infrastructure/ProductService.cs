using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.DataAccess.DataAccessObjects;
using Demo.DataAccess.Models;

namespace Demo.Business
{
    public class ProductService : IProductService
    {
        private IUnitOfWork<WebDbContext> _unitOfWork;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        public ProductService(IUnitOfWork<WebDbContext> unitOfWork,
            IProductRepository productRepository
            )
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.Filter(x=> true);
        }

        public IEnumerable<Product> GetProducts()
        { 
             return _productRepository.Filter(x => true).ToList(); 
        }
    }
}
