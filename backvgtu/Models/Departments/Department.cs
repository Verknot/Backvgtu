using backvgtu.Models.Employees;

namespace backvgtu.Models.Departments;

public class Department : EntityBase<int>
{
    public string Name { get; set; }

    public string? Description { get; set; } = null;
    
    public List<Employee> Employees { get; set; }
    
}