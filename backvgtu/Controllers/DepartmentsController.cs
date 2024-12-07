using backvgtu.DbContexts;
using backvgtu.Models.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backvgtu.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    
    private ApplicationContext _context { get; set; }

    public DepartmentsController()
    {
        _context = new ApplicationContext();
    }
    
    [HttpGet]
    [Authorize(Roles = "admin, manager")]
    public IEnumerable<Department> GetDepartments()
    {
        return _context.Departments
            .Include(d => d.Employees).ThenInclude(e => e.Educations)
            .Include(d => d.Employees).ThenInclude(e => e.WorkExperience)
            .ToList();
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("department")]
    public IActionResult UpdateDepartment(int id, string name, string? description)
    {
        var departmnet = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (departmnet != null)
        {
            departmnet.Name = name;
            departmnet.Description = description;
            _context.SaveChanges();
            return Ok();
        }

        return BadRequest("Департамент не найден");
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost("department")]
    public IActionResult AddDepartment(string name, string? description)
    {
        var departmnet = _context.Departments.Add(new Department()
        {
            Name = name,
            Description = description
        });
        _context.SaveChanges();
        
        return Ok(departmnet.Entity?.Id ?? 0);
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("department")]
    public IActionResult DeleteDepartment(int id)
    {
        var departmnet = _context.Departments.FirstOrDefault(d => d.Id == id);

        if (departmnet != null)
        {
            _context.Departments.Remove(departmnet);
            _context.SaveChanges();
            return Ok();
        }
        
        return BadRequest("Департамента не существует");
    }
}