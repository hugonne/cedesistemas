using Cedesistemas.WheresMyStuff.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cedesistemas.WheresMyStuff.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
