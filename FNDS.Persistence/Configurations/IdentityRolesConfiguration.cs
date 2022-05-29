using FDNS.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FDNS.Persistence.Configurations
{
    public class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid> 
                { 
                    Id = Guid.Parse("781ac221-b109-453b-a525-95bc9ec87678"),
                    Name = UserRoles.Admin,
                    NormalizedName = UserRoles.Admin.ToUpper()
                },
                new IdentityRole<Guid> 
                { 
                    Id = Guid.Parse("fd55fe70-7497-4f55-980e-0d936d6bee4e"),
                    Name = UserRoles.User,
                    NormalizedName = UserRoles.User.ToUpper()
                });
        }
    }
}