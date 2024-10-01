using CryptoSphere.Wallet.Application.Common.DTOs.UserDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoSphere.Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var registeredUser = await _userService.Register(registerUserDto);
            if (!registeredUser.IsValid)
            {
                return BadRequest(registeredUser.ValidationMessage);
            }

            return Ok("Registered Successfully!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LogInUserDto loginUser)
        {
            var token = await _userService.Login(loginUser);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Something went wrong!");
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            var user = await _userService.GetUserByUserName(userName);

            if (user is null)
            {
                return BadRequest($"User with username: {userName} doesn't exist!");
            }

            return Ok(user);
        }

    }
}
