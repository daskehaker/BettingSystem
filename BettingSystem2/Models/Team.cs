using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem2.Models
{
    public class Team
    {
        //Properties
        public int ID { get; set; }
        public int? TourneyID { get; set; }
        public string Title { get; set; }

        //navigation properties
        public Tourney Tourney { get; set; }
    }
}
