using FunctionApp.Models;
using Microsoft.EntityFrameworkCore;
using FunctionApp.Models;

namespace FunctionApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FunktsiooniUurimine> FunktsiooniUurimised { get; set; }
    }
}
