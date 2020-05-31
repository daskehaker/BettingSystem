using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem2.Models
{
    public class Prize
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public State State { get; set; }

        //nvaigation properties
        public ICollection<SentForm> SentForm { get; set; }
    }
}
