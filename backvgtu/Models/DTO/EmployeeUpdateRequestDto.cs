namespace backvgtu.Models.DTO;

public class EmployeeUpdateRequestDto : EntityBase<int>
{
    public int DepartmentId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string MidleName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string BirthDate { get; set; }
}