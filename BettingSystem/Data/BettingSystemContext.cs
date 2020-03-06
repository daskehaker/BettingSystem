using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BettingSystem.Models;

namespace BettingSystem.Data
{
    public class BettingSystemContext : DbContext
    {
        public BettingSystemContext (DbContextOptions<BettingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<BettingSystem.Models.Prize> Prize { get; set; }
    }
}
