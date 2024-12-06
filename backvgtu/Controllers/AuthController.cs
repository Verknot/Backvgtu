using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backvgtu.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace backvgtu.Controllers;

//[Route("api/[controller]")]
//[ApiController]
public class AuthController : ControllerBase
{
    private List<User> _users = new()
    {
        new User(){Login = "admin@gmail.com", Password = "123456", Role = "admin"},
        new User(){Login = "user@gmail.com", Password = "123456", Role = "user"}
    };
    
    [HttpPost("/login")]
    public IActionResult Login(string username, string password)
    {
        var identity = GetIdentity(username, password);
        if (identity == null)
        {
            return BadRequest(new { errorText = " Invalid username or password" });
        }

        var now = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        notBefore: now,
        claims: identity.Claims,
        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            access_token = encodedJwt,
            username = identity.Name
        };
        
        return Ok(JsonConvert.SerializeObject(response));
    }

    private ClaimsIdentity GetIdentity(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Login == username && u.Password == password);
        if (user != null)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        return null;
    }
}