using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using Quizz.jmh.api.Controllers;
using Quizz.jmh.Domain.Interfaces.Services;
using Quizz.jmh.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Quizz.jmh.Tests
{
    public class UserControllerTest
    {

        private readonly UserController _userController;
        private readonly IUserService _userService;

        public UserControllerTest()
        {
            _userService = Substitute.For<IUserService>();
            _userController = Substitute.For<UserController>(_userService);
        }


        [Theory, AutoData]
        public async Task Should_Return_200_When_Get_Users_Return_OK(IEnumerable<User> users)
        {
            _userService.GetUsersAsync().Returns(users);                
            var result = await _userController.GetUserAsync();
            Check.That(result).IsInstanceOf<OkObjectResult>();
        }
    }
}