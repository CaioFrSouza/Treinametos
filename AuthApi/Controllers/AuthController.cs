using AuthApi.Data;
using AuthApi.Services.Interfaces;
using DTOs.Auth.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AuthUserModel> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<AuthUserModel> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequestDTO requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var response = await _authService.LoginUser(requestDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost ("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateNewUserRequestDTO requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var response = await _authService.CreateUser(requestDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}