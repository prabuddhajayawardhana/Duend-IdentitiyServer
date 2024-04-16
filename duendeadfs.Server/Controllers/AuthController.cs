using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace duendeadfs.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Callback(string code, string state)
        {
            return Ok("log in");
        }
    }
}
