using DuAn2_ThucTapAlta.DTO.User;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(user.ToUserDTO());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetAllUsersAsync();

            var userDto = user.Select(s => s.ToUserDTO()).ToList();

            return Ok(userDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userDto == null)
            {
                return BadRequest(ModelState);
            }

            var userModel = userDto.ToUserFromCreateDTO();

            await _userService.CreateUserAsync(userModel);

            return CreatedAtAction(nameof(GetUserById), new { id = userModel.Id }, userModel.ToUserDTO());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _userService.UpdateUserAsync(id, updateDto);

            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel.ToUserDTO());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeactivateUserAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var result = await _userService.ActivateUserAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetInactiveUsers()
        {
            var inactiveUsers = await _userService.GetInactiveUsersAsync();

            if (!inactiveUsers.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var userDtos = inactiveUsers.Select(f => f.ToUserDTO()).ToList();
            return Ok(userDtos);
        }
    }
}
