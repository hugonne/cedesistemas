using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cedesistemas.WheresMyStuff.Models
{
    public class Location
    {
        public int Id { get; set; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Notes { get; set; }

        public bool IsHidden { get; set; }

        public ICollection<Item> Items { get; set; } //Propiedad de navegación
    }
}
