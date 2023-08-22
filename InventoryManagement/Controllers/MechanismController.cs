using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MechanismController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MechanismController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMechanism()
        {
            var MechanismResult = await _service.Mechanism.GetAllMechanismAsync();
            return Ok(MechanismResult);
        }
        [HttpGet("{id}", Name = "MechanismById")]
        public async Task<IActionResult> GetTravelOptionByid(int id)
        {
            var MechanismResult = await _service.Mechanism.GetMechanismByIDAsync(id);
            return Ok(MechanismResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMechanism([FromBody] MechanismDto MechanismInfo)
        {
            if (MechanismInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            var createdMechanism = await _service.Mechanism.CreateNewMechanismAsync(MechanismInfo);

            return CreatedAtRoute("MechanismById", new { id = createdMechanism.Id }, createdMechanism);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMechanism(int id, [FromBody] MechanismDto MechanismInfo)
        {
            if (MechanismInfo == null)
            {
                throw new BadRequestException("lead object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model object");
            }

            await _service.Mechanism.UpdateMechanismAsync(id, MechanismInfo);

            return Accepted();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMechanism(int id)
        {
            await _service.Mechanism.DeleteMechanismAsync(id);
            return NoContent();
        }
    }
}
