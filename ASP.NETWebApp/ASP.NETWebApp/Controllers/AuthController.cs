using ASP.NETWebApp.Data;
using ASP.NETWebApp.DTO.User;
using ASP.NETWebApp.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost ("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            ServiceResponse<int> serviceResponse = await _authRepo.Register(
                new User { Username = registerUserDto.Username },
                registerUserDto.Password
            );

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            ServiceResponse<string> serviceResponse = await _authRepo.Login(loginUserDto.Username, loginUserDto.Password);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);
        }

    }
}
