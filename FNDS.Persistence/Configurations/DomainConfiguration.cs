using FDNS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FNDS.Persistence.Configurations
{
    internal class DomainConfiguration : IEntityTypeConfiguration<Domain>
    {
        public void Configure(EntityTypeBuilder<Domain> builder)
        {
            builder.HasOne(d => d.User).WithMany(u => u.Domains).HasForeignKey(d => d.UserId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.NamecheapId).IsRequired();
            builder.Property(d => d.Name).IsRequired().HasMaxLength(127);
            builder.Property(d => d.RegistrationDate).IsRequired();
            builder.Property(d => d.ExpirationDate).IsRequired();

            builder.HasIndex(d => d.NamecheapId).IsClustered(false).IsUnique();
        }
    }
}