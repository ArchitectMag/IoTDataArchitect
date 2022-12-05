//System
using Microsoft.EntityFrameworkCore;

//Projects
using MyIoT.Entities.Models;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Entities.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=Localhost;Database=DevMag;user id=sa;password=magdev@123456;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Light> Lights { get; set; }
}
