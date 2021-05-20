using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cedesistemas.WheresMyStuff.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }

        public bool IsHidden { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
