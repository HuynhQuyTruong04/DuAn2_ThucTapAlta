using DuAn2_ThucTapAlta.DTO.User;
using DuAn2_ThucTapAlta.Models;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest();
            }

            var user = await _userService.ValidateUserAsync(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var role = user.Role.Name;

            // Tạo token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, role)
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if (string.IsNullOrWhiteSpace(userRegisterDto.Email))
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(userRegisterDto.Password))
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(userRegisterDto.ConfirmPassWord))
            {
                return BadRequest();
            }

            if (userRegisterDto.Password != userRegisterDto.ConfirmPassWord)
            {
                return BadRequest();
            }

            var userExists = await _userService.GetUserByEmailAsync(userRegisterDto.Email);
            if (userExists != null)
            {
                return BadRequest();
            }

            var newUser = new User
            {
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                RoleId = userRegisterDto.RoleId,
                CreateDate = userRegisterDto.CreateDate,
                UpdateDate = userRegisterDto.UpdateDate
            };

            await _userService.CreateUserAsync(newUser);

            return Ok();
        }
    }
}
