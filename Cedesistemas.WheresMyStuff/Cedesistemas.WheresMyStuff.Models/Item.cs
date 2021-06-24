using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Cedesistemas.WheresMyStuff.Models
{
    //POCO: Plain Old CLR Object
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(64)]
        [Required]
        //[DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        //[Required] - No se requiere, porque DateTime es un VALUE type
        public DateTime CreatedDateTime { get; set; }

        public bool IsVisibleForAll { get; set; }

        //[Range(0, 9999)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MarketValue { get; set; }

        [NotMapped]
        public TimeSpan TimeSinceCreated
        {
            get
            {
                return DateTime.Now - CreatedDateTime;
            }
        }

        //public TimeSpan TimeSinceCreated => DateTime.Now - DateTime;

        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; } //Propiedad de navegación
    }
}