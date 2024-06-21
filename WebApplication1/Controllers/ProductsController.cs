using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1,Name="Wafa",Description="pro1"},
            new Product { Id = 2,Name="Qamar",Description="pro2"},
            new Product { Id = 3,Name="Nami",Description="pro3"},
        };

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var product = products.First(product => product.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Add(Product request)
        {
            if (request is null)
            {
                return BadRequest();
            }
            var product  = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product request)
        {
            var currentProduct = products.FirstOrDefault(product => product.Id == id);
            if (currentProduct is null)
            {
                return NotFound();
            }
            currentProduct.Name = request.Name;
            currentProduct.Description = request.Description;
            return Ok(currentProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            products.Remove(product);
            return Ok();
        }
    }
}
