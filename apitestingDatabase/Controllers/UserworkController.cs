using apitestingDatabase.Model;
using apitestingDatabase.Services.UserworkService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apitestingDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserworkController : ControllerBase
    {
        private readonly IUserworkService _userworkService;
        public UserworkController(IUserworkService userworkService)
        {
            _userworkService = userworkService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userworkService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userworkService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("CreateUserData")]
        public async Task<IActionResult> CreateUserDataAsync([FromBody] Userwork user)
        {
            if (user == null)
                return BadRequest("User data is invalid.");

            var createdUser = await _userworkService.CreateUserData(user);

            return Ok(createdUser);
        }
        [HttpPut("UpdateById/")]
        public async Task<IActionResult> UpdateUserByIdAsync(int id, [FromBody] Userwork user)
        {
            if (user == null || id != user.id)
            {
                return BadRequest("User data is invalid.");
            }
            var updatedUser = await _userworkService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await _userworkService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}


    

