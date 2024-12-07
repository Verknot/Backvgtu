namespace backvgtu.Models.Employees;

public class WorkExperience : EntityBase<int>
{
    public int WorkedYears { get; set; } = 0;

    public string? Description { get; set; } = null;
    
    //public Employee Employee { get; set; }
}