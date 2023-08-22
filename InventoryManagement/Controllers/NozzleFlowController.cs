using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NozzleFLowController : ControllerBase
    {
        private readonly IServiceManager _service;
        public NozzleFLowController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNozzleFLow()
        {
            var NozzleFlowResult = await _service.NozzleFlow.GetAllNozzleFlowAsync();
            return Ok(NozzleFlowResult);
        }
        [HttpGet("{id}", Name = "NozzleFLowById")]
        public async Task<IActionResult> GetNozzleFLowByid(int id)
        {
            var NozzleFlowResult = await _service.NozzleFlow.GetNozzleFlowByIDAsync(id);
            return Ok(NozzleFlowResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNozzleFLow([FromBody] NozzleFlowDto NozzleInfo)
        {
            if (NozzleInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            var createdNozzle = await _service.NozzleFlow.CreateNewNozzleFlowAsync(NozzleInfo);

            return CreatedAtRoute("NozzleFLowById", new { id = createdNozzle.Id }, createdNozzle);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNozzleFLow(int id, [FromBody] NozzleFlowDto NozzleInfo)
        {
            if (NozzleInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            await _service.NozzleFlow.UpdateNozzleFlowAsync(id, NozzleInfo);

            return Accepted();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNozzleFlow(int id)
        {
            await _service.NozzleFlow.DeleteNozzleFlowAsync(id);
            return NoContent();
        }
    }
}
