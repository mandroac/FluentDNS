using FDNS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FNDS.Persistence.Configurations
{
    public class UserContactsConfiguration : IEntityTypeConfiguration<UserContacts>
    {
        public void Configure(EntityTypeBuilder<UserContacts> builder)
        {
            builder.HasOne(c => c.User).WithMany(u => u.Contacts).HasForeignKey(c => c.UserId)
                .IsRequired(true).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Country).WithMany().HasForeignKey(c => c.CountryId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.AddressName).HasMaxLength(20).IsRequired(true);
            builder.Property(c => c.DefaultYN).IsRequired(true).HasDefaultValue(false)
                .HasComment("Specifies whether this particular set of contacts should be set as PRIMARY for the account");

            builder.Property(c => c.EmailAddress).HasMaxLength(128).IsRequired(true);
            builder.Property(c => c.FirstName).HasMaxLength(60).IsRequired(true);
            builder.Property(c => c.LastName).HasMaxLength(60).IsRequired(true);
            builder.Property(c => c.JobTitle).HasMaxLength(60).IsRequired(false);
            builder.Property(c => c.Organization).HasMaxLength(60).IsRequired(false);
            builder.Property(c => c.Address1).HasMaxLength(60).IsRequired(true);
            builder.Property(c => c.Address2).HasMaxLength(60).IsRequired(false);
            builder.Property(c => c.City).HasMaxLength(60).IsRequired(true);
            builder.Property(c => c.StateProvince).HasMaxLength(60).IsRequired(true);
            builder.Property(c => c.StateProvinceChoice).HasMaxLength(60).IsRequired(false);
            builder.Property(c => c.Zip).HasMaxLength(15).IsRequired(true);

            builder.Property(c => c.Phone).HasMaxLength(20).IsRequired(true)
                .HasComment("Phone number in the format +NNN.NNNNNNNNNN");

            builder.Property(c => c.PhoneExt).HasMaxLength(10).IsRequired(false);
            builder.Property(c => c.Fax).HasMaxLength(20).IsRequired(false)
                .HasComment("Fax number in the format +NNN.NNNNNNNNNN");
        }
    }
}
