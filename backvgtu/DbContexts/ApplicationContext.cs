using backvgtu.Models.Departments;
using backvgtu.Models.Employees;
using backvgtu.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace backvgtu.DbContexts;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Department> Departments { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    
    public DbSet<Education> Educations { get; set; }
    
    public DbSet<WorkExperience> WorkExperience { get; set; }

    public DbSet<UserFile> UserFiles { get; set; }
    
    public ApplicationContext()
    {
        //Database.EnsureCreated();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=backvgtu;Username=devuser;Password=12345678");
        
    }
}