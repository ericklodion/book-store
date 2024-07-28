using bs_service;
using bs_service.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceTableController : ControllerBase
    {
        public readonly PriceTableService _service;

        public PriceTableController(PriceTableService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PriceTableDTO dto)
        {
            return Ok(await _service.Create(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PriceTableDTO dto)
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
