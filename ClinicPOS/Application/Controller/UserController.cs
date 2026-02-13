using ClinicPOS.Application.Model.Request;
using ClinicPOS.Application.Model.Response;
using ClinicPOS.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicPOS.Application.Controller
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginDTO>> Login(LoginUserRequest request)
        {
            var loginDto = await _userService.LoginAsync(request.Username, request.Password);
            return Ok(loginDto);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateUserRequest request)
        {
            await _userService.CreateUserAsync(request);
            return Ok();
        }

        [HttpGet()]
        public async Task<ActionResult<List<UserDTO>>> GetAllUser()
            => await _userService.GetAllUserAsync();

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest request)
        {
            await _userService.UpdateUserAsync(id, request);
            return NoContent();
        }
    }
}
