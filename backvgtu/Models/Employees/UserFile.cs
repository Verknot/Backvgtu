namespace backvgtu.Models.Employees;

public class UserFile : EntityBase<int>
{
    public string SystemName { get; set; }
    
    public string DisplayName { get; set; }
}