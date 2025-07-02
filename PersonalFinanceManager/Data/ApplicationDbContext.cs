using Microsoft.EntityFrameworkCore;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
