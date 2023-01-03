using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizz.jmh.api.Extensions;
using Quizz.jmh.Api.Request;
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
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [Authorize(AuthenticationSchemes = /*JwtBearerDefaults.AuthenticationScheme*/ "Bearer")]
        [HttpGet("/users")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Retrieve list of all Users")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetUserAsync()
        {
            //using var client = new HttpClient();
            //var token = await _tokenService.GetToken("jmh.api.read");

            //client.SetBearerToken(token.AccessToken);

            var users = await _userService.GetUsersAsync();
            return Ok(new UsersResponse { Users = users.ToUserViewModel()});
        }

        [HttpGet("/users/{Id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Retrieve an User")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetUserByIdUserAsync([FromRoute] String Id)
        {
            var user = await _userService.GetUserByIdUserAsync(Id);
            return Ok(new UserResponse { User = user.ToUserViewModel() });
        }


        [HttpPost("/users")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Add an User")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Not found")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "User created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad request")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserPostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAdded = await _userService.AddUserAsync(request.ToUser());
            if (userAdded == null)
            {
                return NotFound();
            }


            return StatusCode(StatusCodes.Status201Created, new UserResponse { User = userAdded.ToUserViewModel() });
        }

        
        [HttpPut("/users/{Id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Update a user")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] String Id, [FromBody] UserPutRequest Request)
        {
            var user = await _userService.UpdateUserAsync(Id, Request.ToUser());
            return Ok(new UserResponse { User = user.ToUserViewModel() });
        }


        [HttpDelete("/users/{Id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Delete a user")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] String IdUser)
        {
            if (IdUser == null)
            {
                return BadRequest(ModelState);
            }

            await _userService.DeleteUserAsync(IdUser);
            return NoContent();
        }


        //[HttpPut("/users/{Id}")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UsersResponse), Description = "Update all fields of an user")]
        //[SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UsersResponseExample))]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        //public async Task<IActionResult> ReplaceAllUserFieldsAsync([FromRoute] String Id)
        //{
        //    var user = await _userService.ReplaceAllUserFieldsAsync(Id);
        //    return Ok(new UserResponse { User = user.ToUserViewModel()});
        //}
    }
}
