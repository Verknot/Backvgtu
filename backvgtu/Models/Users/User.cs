using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backvgtu.Models.Users;

public class User : EntityBase<int>
{
    public string Login { get; set; }
    
    public string Password { get; set; }

    public string Role { get; set; }
}