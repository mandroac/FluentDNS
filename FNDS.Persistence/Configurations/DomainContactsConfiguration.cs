using FDNS.Common.Constants;
using FDNS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FNDS.Persistence.Configurations
{
    public class DomainContactsConfiguration : IEntityTypeConfiguration<DomainContacts>
    {
        public void Configure(EntityTypeBuilder<DomainContacts> builder)
        {
            builder.HasOne(c => c.Domain).WithMany(d => d.Contacts).HasForeignKey(c => c.DomainId)
                .IsRequired(true).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Country).WithMany().HasForeignKey(c => c.CountryId).IsRequired(true)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.OrganizationName).HasMaxLength(255).IsRequired(false);
            builder.Property(c => c.JobTitle).HasMaxLength(255).IsRequired(false);
            builder.Property(c => c.FirstName).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.LastName).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.Address1).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.Address2).HasMaxLength(255).IsRequired(false);
            builder.Property(c => c.City).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.StateProvince).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.StateProvinceChoice).HasMaxLength(50).IsRequired(false);
            builder.Property(c => c.PostalCode).HasMaxLength(50).IsRequired(true);
            
            builder.Property(c => c.Phone).HasMaxLength(50).IsRequired(true)
                .HasComment("Phone number in the format +NNN.NNNNNNNNNN");
           
            builder.Property(c => c.PhoneExt).HasMaxLength(50).IsRequired(false);
            builder.Property(c => c.Fax).HasMaxLength(50).IsRequired(false)
                .HasComment("Fax number in the format +NNN.NNNNNNNNNN");
           
            builder.Property(c => c.EmailAddress).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.ContactsType).HasConversion(
                t => t.ToString(),
                t =>  (ContactsType)Enum.Parse(typeof(ContactsType), t));
        }
    }
}
