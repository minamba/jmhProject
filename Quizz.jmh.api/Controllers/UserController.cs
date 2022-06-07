using Microsoft.AspNetCore.Mvc;
using Quizz.jmh.api.Extensions;
using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.SwaggerExamples;
using Quizz.jmh.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace Quizz.jmh.api.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/users")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Retrieve list of all Users")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetUserAsync()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(new UsersResponse { Users = users.ToUserViewModel()});
        }
    }
}
