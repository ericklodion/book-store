using bs_service;
using Microsoft.AspNetCore.Http;
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
    }
}
