using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem2.Models
{
    public class Prize
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public State State { get; set; }

        //nvaigation properties
        //laiskas
    }

    public enum State
    {
        Odered,
        Unordered,
        Sent
    }
}
