using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MAGPRO;Database=MagDev;user id=sa;password=magdev@123456;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Light> Lights { get; set; }
    }
}
