using Cedesistemas.WheresMyStuff.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cedesistemas.WheresMyStuff.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
