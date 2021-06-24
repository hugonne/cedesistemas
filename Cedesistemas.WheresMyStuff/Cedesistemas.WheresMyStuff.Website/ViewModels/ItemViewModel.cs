using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.WheresMyStuff.Website.ViewModels
{
    public class ItemViewModel
    {
        [Display(Name = "Identificación")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(64)]
        [Required(ErrorMessage = "El campo es requerido")]
        //[DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        public int LocationId { get; set; }

        [Display(Name = "Ubicación")]
        public string LocationName { get; set; }
    }
}
