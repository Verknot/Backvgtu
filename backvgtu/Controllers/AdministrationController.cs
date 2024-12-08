using backvgtu.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backvgtu.Controllers;

[ApiController]
public class AdministrationController : ControllerBase
{
    private ApplicationContext _context;

    public AdministrationController()
    {
        _context = new ApplicationContext();
    }
    
    [HttpGet("getusers")]
    [Authorize(Roles = "admin")]
    public IActionResult GetUsers()
    {
        try
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}