using Microsoft.EntityFrameworkCore;
using ViljaladuMVC.Models;

namespace ViljaladuMVC.Data
{
    public class ViljaladuDbContext : DbContext
    {
        public ViljaladuDbContext(DbContextOptions<ViljaladuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Koorma> Koormad { get; set; }
    }
}
