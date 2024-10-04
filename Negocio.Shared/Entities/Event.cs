using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Negocio.Shared.Entities
{
    public class Event
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del evento")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Descripción del evento")]
        public string Description { get; set; }

        [Display(Name = "Fecha y hora del evento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Capacidad del evento")]
        [Range(1, 500, ErrorMessage = "La {1} debe estar entre 1 y 500")]
        public int Capacity { get; set; }

        [JsonIgnore]
        public ICollection<Member> Participants { get; set; }

    }
}
