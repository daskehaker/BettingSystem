using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettingSystem.Models
{
    public class Team
    {
        public int ID { get; set; }

        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }
    }
}
