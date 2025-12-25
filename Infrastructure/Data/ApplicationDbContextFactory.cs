using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();

            // Use LocalDb connection string (same as in appsettings.json)
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CultureDb;Trusted_Connection=true;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
