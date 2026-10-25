using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportHub.API.DTOs.SportTypes;
using SportHub.API.Services.Interfaces;

namespace SportHub.API.Controllers
{
    [Route("api/sport-types")]
    [ApiController]
    public class SportTypesController : ControllerBase
    {
        private readonly ISportTypeService _service;
        
        public SportTypesController(ISportTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SportTypeDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SportTypeDto>> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<SportTypeDto>> Create(SportTypeRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SportTypeDto>> Update(int id, SportTypeRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
