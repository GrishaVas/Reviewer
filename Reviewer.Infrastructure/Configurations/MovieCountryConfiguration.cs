using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class MovieCountryConfiguration : IEntityTypeConfiguration<MovieCountry>
    {
        public void Configure(EntityTypeBuilder<MovieCountry> builder)
        {
            builder
                .HasKey(mc => new
                {
                    mc.CountryId,
                    mc.MovieId
                });

            builder
                .HasOne(mc => mc.Country)
                .WithMany()
                .HasForeignKey(mc => mc.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(mc => mc.Movie)
                .WithMany(c => c.Countries)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
