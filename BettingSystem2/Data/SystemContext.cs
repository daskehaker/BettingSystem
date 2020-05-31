using BettingSystem2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BettingSystem2.Data
{
    public class SystemContext : IdentityDbContext<IdentityUser>
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Tourney> Tourneys { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<SentForm> SentForms { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
