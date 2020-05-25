using BettingSystem2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem2.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Tourney> Tourneys { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Prize> Prizes { get; set; }
    }
}
