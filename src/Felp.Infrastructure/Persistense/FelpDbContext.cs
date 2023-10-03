using Microsoft.EntityFrameworkCore;

namespace Felp.Infrastructure.Persistense
{
    public class FelpDbContext : DbContext
    {
        public FelpDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
