using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("usersList")]
        //[Authorize(Policy = "isadmin")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromQuery] PaginationDTO paginationDTO)
        {
            var users = await userService.GetUsers(paginationDTO);
            return Ok(users);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponseDTO>> Register([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await userService.Register(userCredentialsDTO);
            return Ok(token);
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponseDTO>> Login(UserLoginDTO userCredentialsDTO)
        {
            var token = await userService.Login(userCredentialsDTO);
            if (token is null) return BadRequest("Invalid login");
            return Ok(token);
        }

        [HttpPost("makeadmin")]
        [Authorize(Policy = "isadmin")]
        public async Task<IActionResult> MakeAdmin(EditClaimDTO editClaimDTO)
        {
            await userService.MakeAdmin(editClaimDTO.Email);
            return NoContent();
        }

        [HttpPost("removeadmin")]
        [Authorize(Policy = "isadmin")]
        public async Task<IActionResult> RemoveAdmin(EditClaimDTO editClaimDTO)
        {
            await userService.RemoveAdmin(editClaimDTO.Email);
            return NoContent();
        }
    }
}
