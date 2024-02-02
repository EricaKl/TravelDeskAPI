using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelDeskAPI.IRepo;
using TravelDeskAPI.Models;
using TravelDeskAPI.ViewModel;

namespace TravelDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginRepo _repo;
        private IConfiguration _configuration;
        IUserRepo _userRepo;

        public LoginController(ILoginRepo repo,IUserRepo ruserRepo,IConfiguration config)
        {
            _repo = repo;
            _userRepo = ruserRepo;
            _configuration = config;

        }


        [HttpPost]
        [Route("Login")]

        public IActionResult Login(LoginViewModel loginobj)
        {
            IActionResult response = Unauthorized();
            bool obj = _repo.Login(loginobj);

            if (obj)
            {
                int roleId = _userRepo.GetRole(loginobj);
                string role= _userRepo.GetRoleName(roleId);
                var claims = new List<Claim>();
                claims.Add(new Claim("email", loginobj.Email));
                claims.Add(new Claim("role", role));
                var tokenString = GenerateJSONWebToken(claims.ToArray());
                
                response = Ok(new { token = tokenString });
            }
            return response;

        }

        private string GenerateJSONWebToken(Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(120),
              claims:claims,
              signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }


     

    }
}
