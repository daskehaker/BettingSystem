using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem2.Models;

namespace BettingSystem2.Data
{
    public class DbInitializer
    {
        public static void Initialize(SystemContext context)
        {
            context.Database.EnsureCreated();

            // Look for any teams
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{Title="Krepšinis"},
                new Category{Title="Futbolas"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }

            var tourneys = new Tourney[]
            {
                new Tourney{CategoryID=1, Title="Krepšinio turnyras 1"},
                new Tourney{CategoryID=1, Title="Krepšinio turnyras 2"},
                new Tourney{CategoryID=1, Title="Krepšinio turnyras 3"},
                new Tourney{CategoryID=2, Title="Futbolo turnyras 1"},
                new Tourney{CategoryID=2, Title="Futbolo turnyras 2"},
                new Tourney{CategoryID=2, Title="Futbolo turnyras 3"}
            };
            foreach (Tourney t in tourneys)
            {
                context.Tourneys.Add(t);
            }

            var teams = new Team[]
            {
                new Team{TourneyID=1, Title="BC Žalgiris"},
                new Team{TourneyID=1, Title="Vilniaus Rytas"},
                new Team{TourneyID=1, Title="Klaipėdos Neptūnas"},
                new Team{Title="Madrido Real"},
                new Team{Title="Bacelona"},
                new Team{Title="Liverpool"},
                new Team{Title="Paris Saint - Germain"},
                new Team{Title="Manchester United"},
                new Team{Title="Chelsea"},
                new Team{Title="Bayern"}
            };
            foreach (Team t in teams)
            {
                context.Teams.Add(t);
            }
            context.SaveChanges();
        }
    }
}
