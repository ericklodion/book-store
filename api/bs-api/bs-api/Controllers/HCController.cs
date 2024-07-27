using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HCController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok(new { message= "It's working" });
        }
    }
}
