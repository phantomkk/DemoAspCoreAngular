using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Business;
using Demo.DataAccess.Models; 
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private WebDbContext WebDbContext;
        public ValuesController(WebDbContext context)
        {
            WebDbContext = context;
        }
        IVozImageService _vozImageService;
        public ValuesController(IVozImageService vozImageService)
        {
            _vozImageService = vozImageService;
        } 

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
              
            Product p = new Product() { Id = 1 };
            //{
            //    description = "First product",
            //    Name = "Name of first",
            //    Price = 99
            //};
            // c.Add(p);
            //c.SaveChanges();

            List<Product> result = null;
            result = WebDbContext.Products.ToList(); //= 
                                          // var p = result.First();
                                          /// c.Remove(p);
            //c.Update(p);
            var state = WebDbContext.Entry(p).State;
            WebDbContext.SaveChanges();
            var state2 = WebDbContext.Entry(p).State;
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpGet("imgs")]
        public async Task<List<string>> GetImagesAsync(string url) {
            return await _vozImageService.LoadAllPages(url);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
