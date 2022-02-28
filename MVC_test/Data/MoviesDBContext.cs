using Microsoft.EntityFrameworkCore;
using MVC_test.Models;

namespace MVC_test.Data
{
    public class MoviesDBContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Series> Series { get; set; }

        public MoviesDBContext(DbContextOptions<MoviesDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movies>()
                .HasIndex(m => m.Name)
                .IsUnique()
                ;

            builder.Entity<Series>()
                .HasIndex(s => s.Name)
                .IsUnique();
        }

    }
}
