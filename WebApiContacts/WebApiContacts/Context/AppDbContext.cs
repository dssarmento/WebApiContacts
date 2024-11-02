using WebApiContacts.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiContacts.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole 
            { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), 
                ConcurrencyStamp = Guid.NewGuid().ToString() });


            builder.Entity<IdentityRole>().HasData(new IdentityRole 
            { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), 
                ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
