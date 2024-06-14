using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder
                .HasKey(mg => new
                {
                    mg.GenreId,
                    mg.MovieId
                });

            builder
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.Genres)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(mg => mg.Genre)
                .WithMany()
                .HasForeignKey(mg => mg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
