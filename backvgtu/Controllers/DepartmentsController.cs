using backvgtu.DbContexts;
using backvgtu.Models.Departments;
using Microsoft.AspNetCore.Mvc;

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
    public IEnumerable<Department> GetDepartments()
    {
        return _context.Departments.ToList();
    }
    
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