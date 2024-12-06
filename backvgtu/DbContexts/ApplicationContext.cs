using backvgtu.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace backvgtu.DbContexts;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext()
    {
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=backvgtu;Username=devuser;Password=12345678");
        
    }
}