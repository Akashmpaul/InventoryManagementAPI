using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductCategoryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategory()
        {
            var CategoryResult = await _service.Category.GetAllProductCategoryAsync();
            return Ok(CategoryResult);
        }

        [HttpGet("{id}", Name = "ProductCategoryByID")]
        public async Task<IActionResult> GetProductCategoryByID(int id)
        {
            var CategoryResult = await _service.Category.GetAllProductCategoryByIDAsync(id);
            return Ok(CategoryResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategoryDto CategoryInfo)
        {
            if (CategoryInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            var createdcategory = await _service.Category.CreateNewProductCategoryAsync(CategoryInfo);

            return CreatedAtRoute("ProductCategoryByID", new { id = createdcategory.Id }, createdcategory);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryInfo(int id, [FromBody] ProductCategoryDto CategoryInfo)
        {
            if (CategoryInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            await _service.Category.UpdateProductCategoryAsync(id, CategoryInfo);

            return Accepted();
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    await _service.Category.DeleteProductCategoryAsync(id);
        //    return NoContent();
        //}
    }
}
