using System;
using System.Collections.Generic;
using System.Linq;

namespace Cedesistemas.WheresMyStuff.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
