using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasIndex(m => m.Name)
                .IsUnique();
        }
    }
}
