using Microsoft.AspNetCore.Mvc;
using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.SwaggerExamples;
using Quizz.jmh.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using Quizz.jmh.Api.Extensions;
using Quizz.jmh.Api.Request;

namespace Quizz.jmh.Api.Controllers
{
    [ApiController]
    [Route("UserRoles")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet("/users/{IdUser}/roles")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserRolesResponse), Description = "Retrieve list of all Users roles")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserRolesResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetUserRolesAsync([FromRoute] String IdUser)
        {
            if (IdUser == null || IdUser == string.Empty)
                return BadRequest();


            var uRoles = await _userRoleService.GetUserRolesAsync(IdUser);
            return Ok(new UserRolesResponse {  UserRoles = uRoles});
        }


        [HttpPost("/users/{IdUser}/roles/{IdRole}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserRolesResponse), Description = "Add an User role")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserRolesResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Not found")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "User created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad request")]
        public async Task<IActionResult> AddUserRoleAsync([FromRoute] string IdUser, [FromRoute] string IdRole, [FromBody] UserRolePostRequest Request)
        {
            if (!ModelState.IsValid || IdUser == null ||IdUser != Request.UserId || Request.RoleId == null)
            {
                return BadRequest(ModelState);
            }

            var userRoleAdded = await _userRoleService.AddUserRoleAsync(Request.ToUserRole());
            if (userRoleAdded == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status201Created, new UserRoleResponse {  UserRole = userRoleAdded.ToUserRoleViewModel()});
        }


        [HttpPut("/users/{IdUser}/roles")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserRoleResponse), Description = "Update a user role")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserRoleResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateUserRoleAsync([FromRoute] string IdUser, [FromBody] UserRolePutRequest Request)
        {
            var userRole = await _userRoleService.UpdateUserRoleAsync(IdUser, Request.ToUserRole());
            return Ok(new UserRoleResponse {  UserRole = userRole.ToUserRoleViewModel() });
        }


        [HttpDelete("/users/{IdUser}/roles")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserRoleResponse), Description = "Delete a user role")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserRoleResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteUserRoleAsync([FromRoute] string IdUser)
        {

            if (IdUser == null)
            {
                return BadRequest(ModelState);
            }

            await _userRoleService.DeleteUserRoleAsync(IdUser);
            return NoContent();
        }


    }
}