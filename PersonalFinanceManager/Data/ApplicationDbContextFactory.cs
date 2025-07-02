using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PersonalFinanceManager.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Pega o caminho do appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Lê a connection string
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

           optionsBuilder.UseSqlite(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
