using Microsoft.EntityFrameworkCore;
using EveningMovies.Models;

namespace EveningMovies.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EveningMovie> EveningMovies { get; set; }
    }
}