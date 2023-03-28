using ITStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //public static Member member = new Member();
        private readonly SqlDataAccess _db;

        public IConfiguration _config;

        public AuthController(IConfiguration config, SqlDataAccess db)
        {
            _config = config;
            _db = db;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Member>> RegisterAsync(Member request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            
            string sql = @"insert into dbo.Member2 (FirstName, LastName, Email, Password, Role) 
                          values (@FirstName, @LastName, @Email, @Password, @Role);";
            var member = new Member()
            {
                Email = request.Email,
                Password = passwordHash,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role
            };
            
            await _db.SaveData(sql, member);

            return Ok(member);
        }

        [HttpPost("login")]
        public ActionResult<Member> Login(MemberDto request)
        {
            string sql = "select * from dbo.Member2 where Email=@Email";
            Member memberAccount = _db.LoadSingleData<Member, dynamic>(sql, new { Email = request.Email }).Result;
            if (memberAccount.Email == null || !BCrypt.Net.BCrypt.Verify(request.Password, memberAccount.Password))
            {
                return BadRequest(new { message = "Invalid Email or Password", token = "" });
            }
            //if (member.Email != request.Email || !BCrypt.Net.BCrypt.Verify(request.Password, member.Password))
            //{
            //    return BadRequest("Invalid Email or Password");
            //}
            string token = CreateToken(memberAccount);

            return Ok( new { message = "Login Success", token = token! });
        }
        private string CreateToken(Member member)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, member.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                claims: claims, 
                expires:DateTime.Now.AddDays(1),
                signingCredentials:cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
