using backvgtu.Models.Users;

namespace backvgtu.Models.Employees;

public class Employee : EntityBase<int>
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string MidleName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public List<Education> Educations { get; set; } 
    
    public List<WorkExperience> WorkExperience { get; set; } 
}