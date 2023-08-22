using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductStatusController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProductStatusController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductStatus()
        {
            var productResult = await _service.Status.GetAllProductStatusAsync();
            return Ok(productResult);
        }
        [HttpGet("{id}", Name = "ProductStatusById")]
        public async Task<IActionResult> GetTravelOptionByid(int id)
        {
            var productResult = await _service.Status.GetAllProductStatusByIDAsync(id);
            return Ok(productResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductStatus([FromBody] ProductStatusDto statusInfo)
        {
            if (statusInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            var createdStatus = await _service.Status.CreateNewProductStatusAsync(statusInfo);

            return CreatedAtRoute("ProductStatusById", new { id = createdStatus.Id }, createdStatus);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductStatusInfo(int id, [FromBody] ProductStatusDto statusInfo)
        {
            if (statusInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            await _service.Status.UpdateProductStatusAsync(id, statusInfo);

            return Accepted();
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProductStatus(int id)
        //{
        //    await _service.Status.DeleteProductStatusAsync(id);
        //    return NoContent();
        //}
    }
}
