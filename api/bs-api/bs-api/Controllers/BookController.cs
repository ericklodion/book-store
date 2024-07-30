using bs_service;
using bs_service.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly BookService _service;
        public BookController(BookService service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get([FromRoute] long code)
        {
            return Ok(await _service.GetById(code));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookDTO dto)
        {
            return Ok(await _service.Create(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]BookDTO dto)
        {
            return Ok(await _service.Update(dto));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete([FromRoute] long code)
        {
            await _service.Delete(code);
            return Ok();
        }
    }
}
