using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class MovieLenguageConfiguration : IEntityTypeConfiguration<MovieLanguage>
    {
        public void Configure(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder
                .HasKey(ml => new
                {
                    ml.LanguageId,
                    ml.MovieId
                });

            builder
                .HasOne(ml => ml.Movie)
                .WithMany(m => m.Languages)
                .HasForeignKey(ml => ml.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ml => ml.Language)
                .WithMany()
                .HasForeignKey(ml => ml.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
