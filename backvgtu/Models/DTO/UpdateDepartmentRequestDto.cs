namespace backvgtu.Models.DTO;

public class UpdateDepartmentRequestDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
}