using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasOne(r => r.Actor)
                .WithMany(a => a.Roles)
                .HasForeignKey(r => r.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(r => r.Movie)
                .WithMany(m => m.Roles)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}
