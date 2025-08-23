using apitestingDatabase.Model;
using apitestingDatabase.Services.UsereducationDetailsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apitestingDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsereducationDetailsController : ControllerBase
    {
        private readonly IUsereducationDetailsService _usereducationDetailsService;
        public UsereducationDetailsController(IUsereducationDetailsService usereducationDetailsService)
        {
            _usereducationDetailsService = usereducationDetailsService;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _usereducationDetailsService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _usereducationDetailsService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("CreateUserData")]
        public async Task<IActionResult> CreateUserDataAsync([FromBody] UsereducationDetails user)
        {
            if (user == null)
                return BadRequest("User data is invalid.");

            var createdUser = await _usereducationDetailsService.CreateUserData(user);

            return Ok(createdUser);
        }


        [HttpPut("UpdateById/")]
        public async Task<IActionResult> UpdateUserByIdAsync(int id, [FromBody] UsereducationDetails user)
        {
            if (user == null || id != user.id)
            {
                return BadRequest("User data is invalid.");
            }
            var updatedUser = await _usereducationDetailsService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _usereducationDetailsService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _usereducationDetailsService.DeleteUser(id);
            return NoContent();
        }

    }
}
