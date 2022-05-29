using FDNS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FNDS.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(u => u.PhoneNumber);
            builder.Ignore(u => u.PhoneNumberConfirmed);

            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(20);
            builder.Property(u => u.AccountBalance).HasPrecision(18, 2);
        }
    }
}
