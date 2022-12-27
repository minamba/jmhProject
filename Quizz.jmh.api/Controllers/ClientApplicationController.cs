using Microsoft.AspNetCore.Mvc;
using Quizz.jmh.Domain.Interfaces.Services;

namespace Quizz.jmh.Api.Controllers
{
    [ApiController]
    [Route("ClientApplication")]
    public class ClientApplicationController : ControllerBase
    {
        private readonly IClientApplicationService _clientApplicationService;

        public ClientApplicationController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }


        [HttpGet] 
        public async Task<IActionResult> CreateClientApplication()
        {
            await _clientApplicationService.CreateApplicationClient();
            return Ok();
        }
    }
}
