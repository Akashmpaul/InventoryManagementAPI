using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProductController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var ProductResult = await _service.Product.GetAllProductAsync();
            return Ok(ProductResult);
        }
        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var ProductResult = await _service.Product.GetAllProductByIDAsync(id);
            return Ok(ProductResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            var createdProduct = await _service.Product.CreateNewProductAsync(product);

            return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto product)
        {
            if (product == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            await _service.Product.UpdateProductAsync(id, product);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.Product.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
