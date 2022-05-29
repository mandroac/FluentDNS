using FDNS.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FNDS.Persistence
{
    public class FndsDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public FndsDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<DomainContacts> DomainContacts { get; set; }
        public DbSet<UserContacts> UserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
