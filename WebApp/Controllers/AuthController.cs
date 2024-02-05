using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using WebApp.Models.User;
using WebApp.Models.User.UserDto;
using WebApp.Services.UserService;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user =new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;


        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        [HttpGet,Authorize]
        public ActionResult<string> GetMyName()
        {
            return Ok(_userService.GetMyName()); 
        }

        [HttpPost("register")]

        public ActionResult<User> Register(UserDto request)
        {
            string PasswordHash= BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.PasswordHash = PasswordHash;

            return Ok(user);
        }

        [HttpPost("login")]

        public ActionResult<User> Login(UserDto request)
        {
            if(user.Username != request.Username)
            {
                return BadRequest("user not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("wrong password");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, user.Username),
                new Claim (ClaimTypes.Role,"Admin"),
                new Claim (ClaimTypes.Role,"User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials : creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
