using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.jmh.Api.Controllers
{
    [ApiController]
    [Route("Claims")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
