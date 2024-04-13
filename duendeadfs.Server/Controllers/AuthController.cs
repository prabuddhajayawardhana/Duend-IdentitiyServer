using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace duendeadfs.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Login()
        {
            return Ok("log in");
        }
    }
}
