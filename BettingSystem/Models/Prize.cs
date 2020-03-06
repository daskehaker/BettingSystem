using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Models
{
    public class Prize
    {
        public int ID { get; set; }

        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Kiekis")]
        public int Quantity { get; set; }

        [Display(Name = "Kaina")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
