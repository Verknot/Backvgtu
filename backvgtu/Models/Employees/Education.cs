namespace backvgtu.Models.Employees;

public class Education : EntityBase<int>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public Employee Employee { get; set; } 
}