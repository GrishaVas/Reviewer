using Microsoft.EntityFrameworkCore;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure
{
    public class ReviewerDbContext : DbContext
    {
        public ReviewerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
