using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_MongoDB.Models;

namespace WebAPI_MongoDB.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //[NoCache]
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.GetAllProducts();
        }


        // GET api/notes/5
        //[NoCache]
        [HttpGet("{id}")]
        public async Task<Product> Get(string id)
        {
            return await _productRepository.GetProduct(id) ?? new Product();
        }

        [HttpPost]
        public void Post([FromBody]Product item)
        {
            _productRepository.AddProduct(item);
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Product item)
        {
            _productRepository.UpdateProduct(id, item);
        }

        // DELETE api/notes/5
        public void Delete(string id)
        {
            _productRepository.RemoveProduct(id);
        }

    }
}