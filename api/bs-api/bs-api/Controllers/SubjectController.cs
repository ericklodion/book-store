using bs_service;
using bs_service.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        public readonly SubjectService _service;

        public SubjectController(SubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubjectDTO dto)
        {
            return Ok(await _service.Create(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SubjectDTO dto)
        {
            return Ok(await _service.Update(dto));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete([FromQuery] long code)
        {
            await _service.Delete(code);
            return Ok();
        }
    }
}
