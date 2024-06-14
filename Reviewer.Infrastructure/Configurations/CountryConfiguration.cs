using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
