using bs_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReportController : ControllerBase
    {
        public readonly BookService _service;
        public BookReportController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetReport());
        }
    }
}
