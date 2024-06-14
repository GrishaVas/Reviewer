using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable("Persons");

            builder
                .HasIndex(d => d.Name)
                .IsUnique();

            builder
                .HasDiscriminator()
                .HasValue<Director>("Director")
                .HasValue<Actor>("Actor");
        }
    }
}
