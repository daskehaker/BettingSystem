using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem2.Models
{
    public class Tourney
    {
        //Properties
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }

        //Navigation properties
        public ICollection<Team> Teams { get; set; }
        public Category Category { get; set; }
    }
}
