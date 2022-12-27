using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizz.jmh.Api.Extensions;
using Quizz.jmh.Api.Request;
using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.SwaggerExamples;
using Quizz.jmh.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace Quizz.jmh.Api.Controllers
{
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;


        public RoleController(IRoleService roleService )
        {
            _roleService = roleService;
        }


        [HttpPost("/roles")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RolesResponse), Description = "Add a Role")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(RolesResponseExample))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Not found")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Role created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad request")]
        public async Task<IActionResult> CreateRole([FromBody] RolePostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleService.AddRoleAsync(request.ToRole());
            return StatusCode(StatusCodes.Status201Created, new RoleResponse { Role = role.ToRoleViewModel()});
        }
    }
}


