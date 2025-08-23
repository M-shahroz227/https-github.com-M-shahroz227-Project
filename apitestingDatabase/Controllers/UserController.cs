using apitestingDatabase.Model;
using apitestingDatabase.Services.UserService;
using apitestingDatabase.Services.UserworkService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apitestingDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _UserService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _UserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("CreateUserData")]
        public async Task<IActionResult> CreateUserDataAsync([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User data is invalid.");

            var createdUser = await _UserService.CreateUserData(user);

            return Ok(createdUser);
        }
        [HttpPut("UpdateById/")]
        public async Task<IActionResult> UpdateUserByIdAsync(int id, [FromBody] User user)
        {
            if (user == null || id != user.id)
            {
                return BadRequest("User data is invalid.");
            }
            var updatedUser = await _UserService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await _UserService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
