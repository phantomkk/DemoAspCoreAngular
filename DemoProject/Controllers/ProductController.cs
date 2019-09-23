using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Business;
using Demo.DataAccess.Models;
using DemoProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("getAllProducts")]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            var results = _productService.GetAllProducts().ToList();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(results);
        }
    }
}