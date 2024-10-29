using AuthApi.Services.Interfaces;
using DTOs.Auth.Requests;
using DTOs.Auth.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet("list")]
        public async Task<IActionResult> ListUsers([FromQuery] ListUsersRequestDTO requestDto)
        {
            var response = await _userService.ListUsers(requestDto);
            return CustomResponse(response);
        }
    }
}