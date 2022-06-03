﻿using FDNS.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FNDS.Persistence
{
    public class FdnsDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public FdnsDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<DomainContacts> DomainContacts { get; set; }
        public DbSet<UserContacts> UserContacts { get; set; }
        public DbSet<SandboxDomainPrice> SandboxDomainPricing { get; set; }
        public DbSet<ProductionDomainPrice> ProductionDomainPricing { get; set; }
        public DbSet<SandboxTLD> SandboxTLDs { get; set; }
        public DbSet<ProductionTLD> ProductionTLDs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
