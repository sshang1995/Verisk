using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Services;

namespace Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService; 
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
            {
                return BadRequest("Invalid product data.");
            }
            var createdProduct = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
            {
                return BadRequest("Invalid product data.");
            }
            var updatedProduct = _productService.UpdateProduct(id, product);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
