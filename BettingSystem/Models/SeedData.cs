using BettingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Models
{
    public class SeedData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new BettingSystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BettingSystemContext>>()))
            {
                if (context.Prize.Any())
                {
                    return; //DB has been seeded
                }
                context.Prize.AddRange(
                    new Prize
                    {
                        Title = "BMW M4",
                        Quantity = 4,
                        Price = 1M
                    },
                    new Prize
                    {
                        Title = "Kepurė",
                        Quantity = 4,
                        Price = 5
                    },
                    new Prize
                    {
                        Title = "Palakatas",
                        Quantity = 4,
                        Price = 8
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
