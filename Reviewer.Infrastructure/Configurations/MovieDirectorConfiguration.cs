using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class MovieDirectorConfiguration : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> builder)
        {
            builder
                .HasKey(mp => new
                {
                    mp.MovieId,
                    mp.DirectorId
                });

            builder
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.Directors)
                .HasForeignKey(mp => mp.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(mp => mp.Director)
                .WithMany()
                .HasForeignKey(mp => mp.DirectorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
